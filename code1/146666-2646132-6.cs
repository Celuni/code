        MyObject MyObject {get; private set; }
        bool Enabled; {get; set; }
        public MyObjectViewModel(MyObject obj)
        {
            MyObject = obj;
        }
        string IsEnabled
        {
            get
            {
                 if (Enabled)
                 {
                     return "";
                 }
                 else return "disabled=disabled";
            }
        }
