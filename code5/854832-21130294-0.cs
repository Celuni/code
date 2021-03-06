    private void OpenFileDialogButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string souborFilename = openFileDialog1.FileName;
				
				foreach (var control in this.Controls)
				{
					if (control is TextBox)
					{
						TextBox tb = control as TextBox;
						Button b = sender as Button;
						if(b != null && tb.Name.Equals("filePathText" + b.Name.Substring(b.Name.Count()-1,1)))
						{
							tb.Text = souborFilename;
						}
					}
				}
				filePathText.Text = souborFilename;
			}
		}
		private void nextDialog_Click(object sender, EventArgs e)
		{
			if (calculate <= 7)
			{
				TextBox text = new TextBox();
				text.Location = new Point(filePathText.Location.X, filePathText.Location.Y + y);
				text.Size = new Size(194, 20);
				text.ReadOnly = true;
				text.Name = "filePathText" + calculate.ToString();
				//MessageBox.Show(text.Name);
				this.Controls.Add(text);
				Button button = new Button();
				button.Location = new Point(OpenFileDialogButton.Location.X, OpenFileDialogButton.Location.Y + y);
				button.Size = new Size(33, 24);
				button.Text = "...";
				button.Click += new EventHandler(OpenFileDialogButton_Click);
				button.Name = "filePathButton" + calculate.ToString();
				this.Controls.Add(button);
				this.nextDialog.Location = new Point(22, 49 + y);
			}
			else
			{
				this.nextDialog.Controls.Remove(nextDialog);
				this.nextDialog.Dispose();
				MessageBox.Show("Maximální možnost počtů přidaných souborů byla dosažena!");
			}
			y = y + 28;
			calculate++;
		}
