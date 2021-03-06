    //use the BindableBase class as base class
    public class UserViewModel : BindableBase
    {
        //use the correct Model class (the newly created or Database.User if it
        //is sufficient). 
        //also IEnumerable is sufficient
        //there is no need for an private field
        public IEnumerable<User> UserList { get; private set; } 
        //wrapper for SelectedUser.Name
        public string SelectedUserName
        {
            get { return SelectedUser.Name; }
            set
            {
                SelectedUser.Name = value;
                OnPropertyChanged(nameof(SelectedUserName));
            }
        }
        //add wrappers for the other properties like 
        //SelectedUserPassword, SelectedUserContact, ...
        //use the correct Model class 
        //(the newly created or Database.User if it is sufficient)
        private User _selectedUser;
        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                // call the OnPropertyChanged of BindableBase 
                // (I would also recommend using nameof)
                OnPropertyChanged(nameof(SelectedUser));
                // call OnPropertyChanged for the other wrapper properties like
                // SelectedUserPassword, SelectedUserContact, ...
                OnPropertyChanged(nameof(SelectedUserName));
                // ...
            }
        }
        public UserViewModel()
        {
            UserManager manager = new UserManager();
            var FilterCombo = new List<ComboItem> { 
                new ComboItem{Text = "Name", Value = "Name"},
                new ComboItem{Text = "Owner", Value = "Owner"},
                new ComboItem{Text = "Email", Value = "Email"},
                new ComboItem{Text = "Contact Number", Value = "Contact"},
                new ComboItem{Text = "Address", Value = "Address"},
            };
            var filter = new FilterModel
            {
                FilterItems = FilterCombo,
                FilterSelected = FilterCombo.Where(t => t.Text == "Name").FirstOrDefault(),
                FilterValue = ""
            };
            
            //this uses now the extension method 
            //(your manager should be doing the converting and return the model
            //instead of the database user if the database user class is 
            //not sufficient)
            _userList = manager.GetList(filter).ToModels();
        }
    }
