        protected class Columns
        {
            static Columns()
            {
                MaxFactCell = 7;
            }            
            public static int MaxFactCell {get; protected set;};
        };
        protected class Columns2 : Columns
        {
            static Columns2()
            {
                MaxFactCell = 13;
            }
        };
