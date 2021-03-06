    class ColorCheckBox : CheckBox
    {
        public Color CheckColor { get; set; }
        public ColorCheckBox()
        {
            Appearance = System.Windows.Forms.Appearance.Button;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TextAlign = ContentAlignment.MiddleRight;
            FlatAppearance.BorderSize = 0;
            AutoSize = false;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Point pt = new Point(pevent.ClipRectangle.Left + 1, pevent.ClipRectangle.Top + 1);
            Rectangle rect = new Rectangle(pt, new Size(21, 21));
            using (SolidBrush brush = new SolidBrush(CheckColor))
            using (Font wing = new Font("Wingdings", 14f))
                pevent.Graphics.DrawString("ü", wing, brush, rect);
            pevent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);
        }
    }
