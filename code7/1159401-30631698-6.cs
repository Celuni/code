    public partial class _Default : Page
        {
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                Response.Write("You have successfully added a Person!");
                Person.Genders gender = Person.Genders.NotSet;
                switch(DropDownList1.SelectedValue)
                {
                   case "Male": gender = Person.Genders.Male; break;
    			   case "Female": gender = Person.Genders.Female; break;
                }
                Person p = new Person(TextBox1.Text, Convert.ToInt32(TextBox2.Text), 
                TextBox3.Text, TextBox4.Text, gender, TextBox5.Text);
    
                Label1.Text = (p.PresentPerson());
            }
        }
    	
