    Course course = db.Courses.Include(c => c.Modules)
                              .Include(c => c.Lab)
                              .Single(c => c.Id == id && 
                                           c.Module.IsDeleted == false &&
                                           c.Chapter.IsDeleted == false);
                              
