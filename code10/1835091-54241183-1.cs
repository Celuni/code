    static void AddCustomer()
    {
        Database db = new Database();
        // declare the variable - populate its value later
        bool alreadyExists;
        do
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            // check the value the user just entered
            alreadyExists = db.Customer.Any(item => item.Username == username);
            if (alreadyExists)
            {
                Console.WriteLine("Username already exists");
            }
        }
        // if alreadyExists is true, repeat
        while (alreadyexists);
        // add a new customer to the list, using the username variable
    }
