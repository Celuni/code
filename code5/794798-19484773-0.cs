        class my_class
        {
            [CategoryAttribute("Category One")]
            public int property_1
            {
                    get { return _property_1; }
                    set { _property_1 = value; }
            }
        }
        void ClearCatagory(string category_name)
        {
            Type my_class_type = my_class.GetType();
            PropertyInfo[] prop_info_array = my_class_type.GetProperties();
            foreach (PropertyInfo prop_info in prop_info_array)
            {
        		CategoryAttribute[] attributes = (CategoryAttribute[]) code_property_info.GetCustomAttributes(typeof(CategoryAttribute), false);
        		if (attributes.Length == 1)
        		{
        			if (attributes[0].Category == category_name)
        			{
        				prop_info.SetValue(my_class, 0, null);
        			}
        		}
            }
        }
