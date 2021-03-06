    public interface IDbAccess {
      String ConnectionString;
    
      Collection<Account> GetAccountsById(Int32 id);
      Boolean StoreAccount(Account acct);
    }
    
    public class SqlDatabase : IDbAccess {
      public String ConnectionString {get; set;}
    
      public SqlDatabase(String connection) {
        ConnectionString = connection;
      }
    
      public Collection<Account> GetAccountsById(Int32 id) {
        using (SqlConnection connect = new SqlConnection(ConnectionString)) { 
    	   using (SqlCommand cmd = new SqlCommand(connect)) {
              /// etc.
            }
        }
      }
    }
