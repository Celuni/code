    DateTime StartTime;
    DateTime EndTime;
    private void textBox1_Enter(object sender, EventArgs e)
    {
        MessageBox.Show("Entered");
        StartTime = DateTime.Now;
    }
    private void textBox1_Leave(object sender, EventArgs e)
    {
        MessageBox.Show("Left");
        EndTime = DateTime.Now;
        MessageBox.Show("Time in control: " + EndTime.Subtract(StartTime).ToString());
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        MessageBox.Show("Changed at : " + DateTime.Now.Subtract(StartTime).ToString());
        StartTime = DateTime.Now;
    }
