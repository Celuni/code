		 namespace Arrays
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            int[] numbers = new int[5];
            List<int> numbersList = new List<int> ();
            string text = System.IO.File.ReadAllText.Text(@"C:\Directory\list.txt");
            string[] displayStringArrays = null; 
            private void Form1_Load(object sender, EventArgs e)
            {
                //numbers[0] = 12;
                //numbers[1] = 10;
                //numbers[2] = 25;
                //numbers[3] = 10;
                //numbers[4] = 15;
                //numbersList.Add(23);
                //numbersList.Add(32);
                //numbersList.Add(35);
            }
            //Array Print
            private void button1_Click(object sender, EventArgs e)
            {
                displayArrays.Text = listText.Text;
            }
            //List Print
            private void button2_Click(object sender, EventArgs e)
             {
                displayStringArrays = text.Split('\n').ToArray();
                foreach (var item in displayStringArrays)
                {
                    displayArraysString.Text += item;
                     if (listText.Text == item.Substring(0,item.Length-1))
                    {
                         MessageBox.Show("Found a match!");
                    }
                    else
                    {
                        //Something.
                    }
                }
             }
        }
    }
