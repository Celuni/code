        Mapper.CreateMap<IDataReader, Person>()
              .AfterMap((source, dest) =>
                           {
                             if (ColumnExists(source, "HowManyOrders"))
                             {
                                 dest.NumberOfOrders = 
                                         Convert.ToInt32(source["HowManyOrders"]);
                             }
                           });
        ... 
        
        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                {
                    return true;
                }
            }
            return false;
        }
