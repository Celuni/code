    using System.Windows.Forms;
    using System.Drawing;
    class AreaChart : Panel
    {
        public Padding ChartPadding { get; set; }
        public Point AxisOriginOffset { get; set; }
        public int RowNum { get; set; }
        public int ColNum { get; set; }
        olor[][] colors { get; set; }
        string[][] texts { get; set; }
        public string[] labels { get; set; }
        Rectangle chartArea = Rectangle.Empty;
        Point axisOrigin = Point.Empty;
        public void Init()
        {
            chartArea = new Rectangle(ChartPadding.Left, ChartPadding.Top,
                        this.Width - ChartPadding.Left - ChartPadding.Right, 
                        this.Height - ChartPadding.Top - ChartPadding.Bottom);
            axisOrigin = new Point(AxisOriginOffset.X, this.Height - AxisOriginOffset.Y);
        }
        public AreaChart()
        {
            ChartPadding = new Padding(80, 40, 40, 40);
            AxisOriginOffset = new Point(60, 20);
            RowNum = 3;
            ColNum = 2;
            BackColor = Color.AntiqueWhite;
            colors = new Color[RowNum][];
            for (int r = 0; r < RowNum; r++) colors[r] = new Color[ColNum];
            texts = new string[RowNum][];
            for (int r = 0; r < RowNum; r++) texts[r] = new string[ColNum];
            labels = new string[RowNum];
            Init();
            setColor(0, 0, Color.Plum);
            setColor(1, 0, Color.GreenYellow);
            setColor(2, 0, Color.Gold);
            setColor(0, 1, Color.LightSkyBlue);
            setColor(1, 1, Color.NavajoWhite);
            setColor(2, 1, Color.Pink);
            setText(0, 0, "AA");
            setText(1, 0, "BA");
            setText(2, 0, "CA");
            setText(0, 1, "AB");
            setText(1, 1, "BB");
            setText(2, 1, "BC");
            setLabel(0, "A");
            setLabel(1, "B");
            setLabel(2, "C");
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.DrawLine(Pens.Black, axisOrigin, 
                                new Point(axisOrigin.X, chartArea.Top));
            e.Graphics.DrawLine(Pens.Black, axisOrigin, 
                                new Point( chartArea.Right, axisOrigin.Y));
            int x = chartArea.X;
            int y = chartArea.Y;
            SizeF tSize = e.Graphics.MeasureString("XX", this.Font, 9999);
            int th = (int)tSize.Height / 2;
            int tw = (int)tSize.Width / 2;
            int h = chartArea.Height / RowNum;
            int w = chartArea.Width / ColNum;
            for (int r = 0; r < RowNum; r++)
                for (int c = 0; c < ColNum; c++)
                {
                    e.Graphics.FillRectangle(new SolidBrush(colors[r][c]), 
                               x + c * w, y + r * h, w, h);
                    e.Graphics.DrawRectangle(Pens.Black, x + c * w, y + r * h, w, h);
                    e.Graphics.DrawString(texts[r][c], this.Font, Brushes.Black, 
                               x + c * w  + w / 2 - tw, y + r * h + h / 2 - th);
                }
            for (int r = 0; r < RowNum; r++)
                e.Graphics.DrawString(labels[r], this.Font, Brushes.Black, 
                           AxisOriginOffset.X - tw * 2, y + r * h + h / 2 - th);
            base.OnPaint(e);
        }
        public void setColor (int row, int col, Color color)
        {
            try
            {
                colors[row][col] = color;
            } catch { throw new Exception("setColor : array index out of bounds!"); }
        }
        public void setText(int row, int col, string text)
        {
            try
            {
                texts[row][col] = text;
            } catch { throw new Exception("setText: array index out of bounds!"); }
        }
        public void setLabel(int row, string text)
        {
            try
            {
                labels[row] = text;
            } catch { throw new Exception("setLabel: array index out of bounds!"); }
        }
    }
  
