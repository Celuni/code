    private void Form1_KeyDown(object sender, KeyArgs e)
        {
          if (e.KeyCode == Keys.Q)
          {
            Application.Exit();
          }
          else if (e.KeyCode == Keys.Up)
            spaceInvaders.MoveUp();
        }
