    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            Class1 myClass = new Class1();
            myClass.RaiseCustomEvent += new EventHandler<CustomEventArgs>(myClass_RaiseCustomEvent);
        }
        void myClass_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            this.Text = e.Message;
        }
        
    }
