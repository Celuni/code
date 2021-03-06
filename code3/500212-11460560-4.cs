    [CustomTable("QMFILES.PBMASTP")]
    public class QMFILESPBMASTP
    {
        [Column("DDATE")]
        public DateTime DueDate { get; set; }
    }
    public bool AddRecord<T>(T model)
    {
      var tlbInfo = System.Attribute
                          .GetCustomAttribute(typeof(T), 
                                              typeof(CustomTableAttribute)) 
                          as CustomTableAttribute;
      var cols = typeof(T).GetProperties()
                          .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute),
                                                            true)
                                       .Count() == 1)
                          .Select(p => p.GetCustomAttributes(typeof(ColumnAttribute),
                                                             true)
                                        .First() as ColumnAttribute);
      var colNames = cols.Select(c => c.Name);
      if (tblInfo != null && cols.Count() > 0)
      {
        StringBuilder sb = new StringBuilder();
        sb.Append("INSERT INTO ");
        sb.Append(tlbInfo.Name);
        sb.Append("VALUES(@");
        sb.Append(string.Join(", @", colNames.ToArray()));
        // etc
      }
    }
