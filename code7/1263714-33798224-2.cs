    public Window1()
    {
            InitializeComponent();
            MyInfo myinfo = new MyInfo();
            myinfo.Name = name.Content.ToString();
            myinfo.Name = ssn.Content.ToString();
            myinfo.Name = dob.Content.ToString();
    }
    public class MyInfo
    {
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Dob { get; set; }
    }
