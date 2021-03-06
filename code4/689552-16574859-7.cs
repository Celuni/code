       public IEnumerable<Employee> QueryEmployees(EmployeeCriteria criteria) {
            var query = new EmployeeQuery(); 
            query.ByLastName(criteria.LastName);
            query.ByFirstName(criteria.FirstName); 
            //etc.
            using(var dbContext = new MyContext()){
                return dbContext.SqlQuery<Employee>(query.Statement, query.Parameters);
            }
       }
