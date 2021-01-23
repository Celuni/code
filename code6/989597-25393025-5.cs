    public class StringItem : INamedItem
    {    //Local copy of the string.
        private string displayName;
        //Creates a new StringItem with the value provided.
        public StringItem(string displayName)
        {   //Sets the display name to the passed-in string.
            this.displayName = displayName;
        }
        public string DisplayName
        {   //Implement the property.  The implementer doesn't need
            //to provide an implementation for setting the property.
            get { return displayName; }
            set { }
        }
    }
