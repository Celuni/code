    private void autoGeneratedEventName_Click(object sender, EventArgs e)
            {
                Button b = sender as Button; //Clicked object is a Button
                if (b.BackColor == Color.Yellow) 
                {
                    b.BackColor = Color.Black;
                }
                label1.Text = b.Name;
            }
