    public IList<UserDTO> GetUsers()
    {
      using (var db = new DbContext())
      {
        return (from u in db.tblUsers
               select new UserDTO()
               {
                   Name = u.Name
               }).ToList();
      }
    }
