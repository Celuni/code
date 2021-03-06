    static void Main(string[] args)
    {
        var items = new List<Item>
        {
            new Item { Priority = 0, Product = "a", Qty = 10 },
            new Item { Priority = 0, Product = "b", Qty = 20 },
            new Item { Priority = 1, Product = "c", Qty = 50 },
            new Item { Priority = 1, Product = "d", Qty = 20 },
            new Item { Priority = 1, Product = "e", Qty = 50 },
            new Item { Priority = 1, Product = "f", Qty = 10 },
            new Item { Priority = 1, Product = "g", Qty = 20 },
            new Item { Priority = 1, Product = "h", Qty = 10 }
        };
        foreach (var group in items.Where  (i => i.Priority == 0)
                                   .GroupBy(i => i, g => items
                                   .Where  (t => t.Qty == g.Qty && 
                                                 t.Product != g.Product)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(group.Key);                   // Priority == 0
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in group.SelectMany(i => i))  // dups
                Console.WriteLine("\t{0}", item);
        }
    }
    class Item
    {
        public int    Priority { get; set; }
        public string Product  { get; set; }
        public int    Qty      { get; set; }
        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}",
                                 this.Priority, this.Product, this.Qty);
        }
    }
