    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace CAM_Products.General_Controls
    {
        public class DataGridViewWithDraggableRows : DataGridView
        {
            private int? _predictedInsertIndex; //Index to draw divider at.  Null means no divider
            private Timer _autoScrollTimer;
            private int _scrollDirection;
            private static DataGridViewRow _selectedRow;
            private bool _ignoreSelectionChanged;
            private static event EventHandler<EventArgs> OverallSelectionChanged;
            private SolidBrush _dividerBrush;
            private Pen _selectionPen;
    
            #region Designer properties
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("The color of the divider displayed between rows while dragging")]
            public Color DividerColor
            {
                get { return _dividerBrush.Color; }
                set { _dividerBrush = new SolidBrush(value); }
            }
    
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("The color of the border drawn around the selected row")]
            public Color SelectionColor
            {
                get { return _selectionPen.Color; }
                set { _selectionPen = new Pen(value); }
            }
    
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("Height (in pixels) of the divider to display")]
            [DefaultValue(4)]
            public int DividerHeight { get; set; }
    
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("Width (in pixels) of the border around the selected row")]
            [DefaultValue(3)]
            public int SelectionWidth { get; set; }
            #endregion
    
            #region Form setup
            public DataGridViewWithDraggableRows()
            {
                InitializeProperties();
                SetupTimer();
            }
    
            private void InitializeProperties()
            {
                #region Code stolen from designer
                this.AllowDrop = true;
                this.AllowUserToAddRows = false;
                this.AllowUserToDeleteRows = false;
                this.AllowUserToOrderColumns = true;
                this.AllowUserToResizeRows = false;
                this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.EnableHeadersVisualStyles = false;
                this.MultiSelect = false;
                this.ReadOnly = true;
                this.RowHeadersVisible = false;
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.CellMouseDown += dataGridView1_CellMouseDown;
                this.DragOver += dataGridView1_DragOver;
                this.DragLeave += dataGridView1_DragLeave;
                this.DragEnter += dataGridView1_DragEnter;
                this.Paint += dataGridView1_Paint_Selection;
                this.Paint += dataGridView1_Paint_RowDivider;
                this.DefaultCellStyleChanged += dataGridView1_DefaultcellStyleChanged;
                this.Scroll += dataGridView1_Scroll;
                #endregion
    
                _ignoreSelectionChanged = false;
                OverallSelectionChanged += OnOverallSelectionChanged;
                _dividerBrush = new SolidBrush(Color.Red);
                _selectionPen = new Pen(Color.Blue);
                DividerHeight = 4;
                SelectionWidth = 3;
            }
            #endregion
    
            #region Selection
            /// <summary>
            /// All instances of this class share an event, so that only one row
            /// can be selected throughout all instances.
            /// This method is called when a row is selected on any DataGridView
            /// </summary>
            private void OnOverallSelectionChanged(object sender, EventArgs e)
            {
                if(sender != this && SelectedRows.Count != 0)
                {
                    ClearSelection();
                    Invalidate();
                }
            }
    
            protected override void OnSelectionChanged(EventArgs e)
            {
                if(!_ignoreSelectionChanged)
                {
                    if(SelectedRows.Count != 1 || SelectedRows[0] != _selectedRow)
                    {
                        _ignoreSelectionChanged = true; //Following lines cause event to be raised again
                        if(_selectedRow == null || _selectedRow.DataGridView != this)
                        {
                            ClearSelection();
                        }
                        else
                        {
                            _selectedRow.Selected = true; //Deny new selection
                            if(OverallSelectionChanged != null)
                                OverallSelectionChanged(this, EventArgs.Empty);
                        }
                        _ignoreSelectionChanged = false;
                    }
                    else
                    {
                        base.OnSelectionChanged(e);
                        if(OverallSelectionChanged != null)
                            OverallSelectionChanged(this, EventArgs.Empty);
                    }
                }
            }
    
            public void SelectRow(int rowIndex)
            {
                _selectedRow = Rows[rowIndex];
                _selectedRow.Selected = true;
                Invalidate();
            }
            #endregion
    
            #region Selection highlighting
            private void dataGridView1_Paint_Selection(object sender, PaintEventArgs e)
            {
                if(_selectedRow != null && _selectedRow.DataGridView == this)
                {
                    Rectangle displayRect = GetRowDisplayRectangle(_selectedRow.Index, false);
                    if(displayRect.Height == 0)
                        return;
    
                    _selectionPen.Width = SelectionWidth;
                    int heightAdjust = (int) Math.Ceiling((float) SelectionWidth/2);
                    e.Graphics.DrawRectangle(_selectionPen, displayRect.X - 1, displayRect.Y - heightAdjust,
                                             displayRect.Width, displayRect.Height + SelectionWidth - 1);
                }
            }
    
            private void dataGridView1_DefaultcellStyleChanged(object sender, EventArgs e)
            {
                DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
                DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;
            }
    
            private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
            {
                Invalidate();
            }
            #endregion
    
            #region Drag-and-drop
            protected override void OnDragDrop(DragEventArgs args)
            {
                if(args.Effect == DragDropEffects.None)
                    return;
    
                RemoveHighlighting();
    
                //Convert to coordinates within client (instead of screen-coordinates)
                Point clientPoint = PointToClient(new Point(args.X, args.Y));
    
                //Get index of row to insert into
                DataGridViewRow dragFromRow = (DataGridViewRow) args.Data.GetData(typeof(DataGridViewRow));
                int newRowIndex = GetNewRowIndex(clientPoint.Y);
    
                //Adjust index if both rows belong to same DataGridView, due to removal of row
                if(dragFromRow.DataGridView == this && dragFromRow.Index < newRowIndex)
                {
                    newRowIndex--;
                }
    
                //Insert the row
                MoveDraggedRow(dragFromRow, newRowIndex);
    
                //Clean up
                RemoveHighlighting();
                _autoScrollTimer.Enabled = false;
    
                //Let everyone know the selection has changed
                SelectRow(newRowIndex);
                base.OnDragDrop(args);
            }
    
            private void dataGridView1_DragLeave(object sender, EventArgs e1)
            {
                RemoveHighlighting();
                _autoScrollTimer.Enabled = false;
            }
    
            private void dataGridView1_DragEnter(object sender, DragEventArgs e)
            {
                if(e.Data.GetDataPresent(typeof(DataGridViewRow)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
    
            private void dataGridView1_DragOver(object sender, DragEventArgs e)
            {
                if(e.Effect == DragDropEffects.None)
                    return;
    
                Point clientPoint = PointToClient(new Point(e.X, e.Y));
    
                //Note: For some reason, HitTest is failing when clientPoint.Y = dataGridView1.Height-1.
                // I have no idea why.
                // clientPoint.Y is always 0 <= clientPoint.Y < dataGridView1.Height
                if(clientPoint.Y < Height - 1)
                {
                    int newRowIndex = GetNewRowIndex(clientPoint.Y);
                    HighlightInsertPosition(newRowIndex);
                    StartAutoscrollTimer(e);
                }
            }
    
            private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if(e.Button == MouseButtons.Left && e.RowIndex >= 0)
                {
                    SelectRow(e.RowIndex);
                    var dragObject = Rows[e.RowIndex];
                    DoDragDrop(dragObject, DragDropEffects.Move);
                        //TODO: Any way to make this *not* happen if they only click?
                }
            }
    
            /// <summary>
            /// Based on the mouse position, determines where the new row would
            /// be inserted if the user were to release the mouse-button right now
            /// </summary>
            /// <param name="clientY">
            /// The y-coordinate of the mouse, given with respectto the control
            /// (not the screen)
            /// </param>
            private int GetNewRowIndex(int clientY)
            {
                int lastRowIndex = Rows.Count - 1;
    
                //DataGridView has no cells
                if(Rows.Count == 0)
                    return 0;
    
                //Dragged above the DataGridView
                if(clientY < GetRowDisplayRectangle(0, true).Top)
                    return 0;
    
                //Dragged below the DataGridView
                int bottom = GetRowDisplayRectangle(lastRowIndex, true).Bottom;
                if(bottom > 0 && clientY >= bottom)
                    return lastRowIndex + 1;
    
                //Dragged onto one of the cells.  Depending on where in cell,
                // insert before or after row.
                var hittest = HitTest(2, clientY); //Don't care about X coordinate
    
                if(hittest.RowIndex == -1)
                {
                    //This should only happen when midway scrolled down the page,
                    //and user drags over header-columns
                    //Grab the index of the current top (displayed) row
                    return FirstDisplayedScrollingRowIndex;
                }
    
                //If we are hovering over the upper-quarter of the row, place above;
                // otherwise below.  Experimenting shows that placing above at 1/4 
                //works better than at 1/2 or always below
                if(clientY < GetRowDisplayRectangle(hittest.RowIndex, false).Top
                             + Rows[hittest.RowIndex].Height/4)
                    return hittest.RowIndex;
                return hittest.RowIndex + 1;
            }
    
            private void MoveDraggedRow(DataGridViewRow dragFromRow, int newRowIndex)
            {
                dragFromRow.DataGridView.Rows.Remove(dragFromRow);
                Rows.Insert(newRowIndex, dragFromRow);
            }
            #endregion
    
            #region Drop-and-drop highlighting
            //Draw the actual row-divider
            private void dataGridView1_Paint_RowDivider(object sender, PaintEventArgs e)
            {
                if(_predictedInsertIndex != null)
                {
                    e.Graphics.FillRectangle(_dividerBrush, GetHighlightRectangle());
                }
            }
    
            private Rectangle GetHighlightRectangle()
            {
                int width = DisplayRectangle.Width - 2;
    
                int relativeY = (_predictedInsertIndex > 0
                                     ? GetRowDisplayRectangle((int)_predictedInsertIndex - 1, false).Bottom
                                     : Columns[0].HeaderCell.Size.Height);
    
                if (relativeY == 0)
                    relativeY = GetRowDisplayRectangle(FirstDisplayedScrollingRowIndex, true).Top;
                int locationX = Location.X + 1;
                int locationY = relativeY - (int)Math.Ceiling((double)DividerHeight / 2);
                return new Rectangle(locationX, locationY, width, DividerHeight);
            }
    
            private void HighlightInsertPosition(int rowIndex)
            {
                if(_predictedInsertIndex != rowIndex)
                {
                    Rectangle oldRect = GetHighlightRectangle();
                    _predictedInsertIndex = rowIndex;
                    Rectangle newRect = GetHighlightRectangle();
    
                    Invalidate(oldRect);
                    Invalidate(newRect);
                }
            }
    
            private void RemoveHighlighting()
            {
                Rectangle oldRect = GetHighlightRectangle();
                _predictedInsertIndex = null;
                Invalidate(oldRect);
            }
            #endregion
    
            #region Autoscroll
            private void SetupTimer()
            {
                _autoScrollTimer = new Timer
                {
                    Interval = 250,
                    Enabled = false
                };
                _autoScrollTimer.Tick += OnAutoscrollTimerTick;
            }
    
            private void StartAutoscrollTimer(DragEventArgs args)
            {
                Point position = PointToClient(new Point(args.X, args.Y));
    
                if(position.Y <= Font.Height/2 &&
                   FirstDisplayedScrollingRowIndex > 0)
                {
                    //Near top, scroll up
                    _scrollDirection = -1;
                    _autoScrollTimer.Enabled = true;
                }
                else if(position.Y >= ClientSize.Height - Font.Height/2 &&
                        FirstDisplayedScrollingRowIndex < Rows.Count - 1)
                {
                    //Near bottom, scroll down
                    _scrollDirection = 1;
                    _autoScrollTimer.Enabled = true;
                }
                else
                {
                    _autoScrollTimer.Enabled = false;
                }
            }
    
            private void OnAutoscrollTimerTick(object sender, EventArgs e)
            {
                //Scroll up/down
                FirstDisplayedScrollingRowIndex += _scrollDirection;
            }
            #endregion
        }
    }
