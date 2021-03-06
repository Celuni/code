    public class Book
    {
       public int Id {get; set;}
       public string title {get; set;}
       public string author {get; set;}
       public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; }
       // followed by whatever else you want or had
    }
    public class BorrwingRecord
    {
        public int BorrowingRecordId {get; set; }
        public DateTime DateBorrowed {get; set;}
        public DateTime DateReturned {get; set;}
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
