    public interface ImyInterface
    {
        T GetEntity<T>(T t,int MasterID) where T : Entity;
    }    
  
    public class BL_Temp : ImyInterface
    {
        public TGetEntity<T>(MyEntity t, int MasterID) where T : Entity
        {
            t.MyEntityProperty = "";
            return t;
        }
    }
