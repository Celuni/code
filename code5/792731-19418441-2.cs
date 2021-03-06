    public partial class _CalibrateGeneralStep2 : Form
    {
        private const int NEEDED_X_POSITION = 0;
        private const int NEEDED_Y_POSITION = 0;
        private bool hasButton2BeenClicked = false;
    
        public _CalibrateGeneralStep2()
        {
            InitializeComponent();
            KeyPreview = true;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();      
            hasButton2BeenClicked = true;  
        }
    
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && IsCursorAtTheCorrectPosition() && hasButton2BeenClicked)
            {
                ShowStep3();
            }
        }
        private bool IsCursorAtTheCorrectPosition()
        {
            return Cursor.Position.X == NEEDED_X_POSITION && Cursor.Position.Y == NEEDED_Y_POSITION;
        }
        private void ShowStep3()
        {
            new _CalibrateGeneralStep3().Show();
        }
    }
