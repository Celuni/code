    if (!String.IsNullOrWhiteSpace(searchValue))
    {
         expheadlist = expheadlist.Where(e => (string.IsNullOrWhiteSpace(dc.Name) || dc.Name.ToLower().Contains(searchValue))
                        || (string.IsNullOrWhiteSpace(dc.Description) || dc.Description.ToLower().Contains(searchValue))
                        ).ToList<GenExpenseHead>();
    }
