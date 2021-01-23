    private DateTime lastChange = DateTime.Now;
    private bool textChanged = false;
    object lockObject = new object();
    
    private void textChanged(object sender, EventArg e)
    {
       lock(lockObject)
       {
          lastChange = DateTime.Now;
          textChanged = true;
       }
    }
    private void timer1_Tick(object sender, EventArgs е)
    {
        lock(lockObject)
        {
           if (textChanged && lastChange > DateTime.Now.AddSeconds(-2)) // wait 2 second for changes
           {
              UpdateList(); // or the method for searching.
              textChanged = false;
              lastChange = DateTime.Now;
           }
        }
    }
