    public class PanelEx : Panel
    {
        public PictureBox PictureBox1 { get; set; }
        public PictureBox PictureBox2 { get; set; }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            if (PictureBox1 != null && PictureBox2 != null)
            {
                Bitmap bitmap = new Bitmap(this.Size.Width, this.Size.Height);
                e.Graphics.DrawImage(PictureBox1.BackgroundImage, new Rectangle(PictureBox1.Location, PictureBox1.Size));
                e.Graphics.DrawImage(PictureBox2.BackgroundImage, new Rectangle(PictureBox2.Location, PictureBox2.Size));
                e.Graphics.Flush();
    
                PictureBox1.Visible = false;
                PictureBox2.Visible = false;
                this.BackgroundImage = bitmap;
            }
        }
    }
