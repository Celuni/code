    private bool? checkBox1IsChecked = false;
    public bool? CheckBox1IsChecked 
    { 
        get { return checkBox1IsChecked;
        set
        {
            UncheckAllCheckBoxes();
            checkBox1IsChecked = true;
        }
    }
    public bool? CheckBox2IsChecked { get; set; }
    ...
    // include 1 through 6 here
    private List<bool?> yourCheckStates = new List<bool> { checkBox1IsChecked, ... };
