    public class MyMembershipProvider : MembershipProvider
    { 
            public override bool ValidateUser(string username, string password)
            {    
              // this is where u should validate your user credentials against your database.
              // i've made an extra class so i can send more parameters 
              //(in this case it's the CurrentTerritoryID parameter which i used as 
              //one of the MyMembershipProvider class properties). 
             
                var oUserProvider = new MyUserProvider();  
                return oUserProvider.ValidateUser(username,password,CurrentTerritoryID);
            }
    }
