    public interface IBaseClass
    {
        int Id { get; set; }
        object Value { get; set; }
    }
    public abstract class BaseClass<T> : IBaseClass
    {
        public int Id { get; set; }
        public T Value { get; set; }
        object IBaseClass.Value
        {
            get { return Value; }
            set
            {
                // put some type checking and error handling here
                Value = (T)value;
            }
        }
    }
    public class ClassInt : BaseClass<int>
    {
        // IDK, something O.o
    }
