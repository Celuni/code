        using System.Windows.Forms;
        namespace ReusingUserControlsSample
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
                private void button1_Click(object sender, System.EventArgs e)
                {
                    Form1 second = new Form1();
                    second.TopMost = true;
                    second.Show();
                    MessageBox.Show(second, "BLARGH");
                }
                private void InitializeComponent()
                {
                    this.button1 = new System.Windows.Forms.Button();
                    this.SuspendLayout();
                    this.button1.Location = new System.Drawing.Point(178, 201);
                    this.button1.Name = "button1";
                    this.button1.Size = new System.Drawing.Size(75, 23);
                    this.button1.TabIndex = 0;
                    this.button1.Text = "button1";
                    this.button1.UseVisualStyleBackColor = true;
                    this.button1.Click += new System.EventHandler(this.button1_Click);
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(284, 264);
                    this.Controls.Add(this.button1);
                    this.Name = "Form1";
                    this.Text = "Form1";
                    this.ResumeLayout(false);
                }
                private System.Windows.Forms.Button button1;
            }
        }
