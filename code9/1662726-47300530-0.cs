    using System.Linq; //import this namespace
    //...
    //...
    
    private void button4_Click(object sender, EventArgs e)
    {
    	if (listBox1.Items.Count >= 0)
    	{
    		listBox1.Items.Add(dataGridView1.CurrentRow.Cells[0].Value.ToString() + "                 " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "                                                      " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()) + "                        " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
    	}
    	label7.Text = listBox1.Items.OfType<int>().ToArray().Sum().ToString();
    }
