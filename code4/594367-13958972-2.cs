     foreach (Topic topic in result)
     {
       string topicName = topic.TopicArn.ToString().Split(':').Last();
       ListItem li = new ListItem(topicName, topic.TopicArn);
       li.Selected = subs.Any(s => s.Endpoint == txtEmail.Text);
       checkBoxList1.Items.Add(li); 
     }
    
