    class A
    {
        public TabPage a;
    } 
    class B : A
    {
            //Create a control to add and set its properties
            Button btn = new Button();
            btn.Location = new Point(20, 20);
            btn.Size = new Size(120, 25);
            btn.Text = "My new Button";
            //Add the control to the Tabpage.
            a.Controls.Add(btn);
    }
