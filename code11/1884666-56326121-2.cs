    public class Library
    {
        private List<Book> Books = new List<Book>();       
    
        public void AddBook()
        {
        }
    
        public void ShowBooks()
        {
            var library = new Library();
            foreach (Book item in Books)  
            {
                //This foreach-loop doesn't work since its a private list.
                library.Books.Add(item);
                Console.WriteLine("Books found");
            }
        }
    }
