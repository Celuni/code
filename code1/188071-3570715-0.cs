    public interface IFoo { }
    public class Foo : IFoo {}
    SomeMethod(object obj)
    {
        var list = new List<IFoo>();
        var foo = obj as IFoo;
        if(foo != null)
        {
            list.Add(foo);
        }
    }
