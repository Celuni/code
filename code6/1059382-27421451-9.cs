    public interface ISessionContainer{}
    
    public static class SessionExtensions
    {
        public SessionObject GetSessionObject(this ISessionContainer session)
        {
            return session["SessionObject"] as SessionObject;
        }
    
        public SessionObject SetSessionObject(this ISessionContainer session, 
                                                    SessionObject obj)
        {
            session["SessionObject"] = obj;
        }
    
    }
    
    public class YourClass1 : ISessionContainer{}
    public class YourClass2 : ISessionContainer{}
