    // ...
    context.Save();
    int newStudentId = student.Id;
    // because the Id generated by the DB is available after SaveChanges
    bool exists = context.Accounts.Any(a => a.Id == newStudentId);
    Assert.IsTrue(exists);
