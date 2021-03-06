    public interface ICopyTo<T>
    {
    	T CopyTo(T target);
    }
    
    public abstract class Person : ICopyTo<Person>, ICloneable
    {
    	public virtual Person CopyTo(Person person)
    	{
    		person.Age = Age;
    		person.Country = Country;
    		return person;
    	}
    
    	public abstract object Clone();
    
    	public int Age { get; set; }
    	public string Country { get; set; }
    }
    
    public abstract class Adult : Person, ICopyTo<Adult>, ICloneable
    {
    	public virtual Adult CopyTo(Adult adult)
    	{
    		base.CopyTo(this);
    		adult.Car = Car;
    		return adult;
    	}
    
    	public string Car { get; set; }
    }
    
    public class Man : Adult, ICopyTo<Man>,  ICloneable
    {
    	public virtual Man CopyTo(Man man = null)
    	{
    		if (man != null)
    		{
    			man = new Man();
    		}
    		base.CopyTo(this);
    		man.Beer = Beer;
    
    		return man;
    	}
    
    	public override object Clone()
    	{
    		return CopyTo();
    	}
    
    	public string Beer { get; set; }
    }
    
    public class Woman : Adult, ICopyTo<Woman>, ICloneable
    {
    	public virtual Woman CopyTo(Woman woman = null)
    	{
    		if (woman == null)
    		{
    			woman = new Woman();
    		}
    		base.CopyTo(this);
    		woman.Purse = Purse;
    		return woman;
    	}
    
    	public override object Clone()
    	{
    		return CopyTo();
    	}
    
    	public string Purse { get; set; }
    }
    
    public class Test
    {
    	public void Go()
    	{
    		Man man1 = new Man() {Age = 10, Beer = "Bud", Country = "Canada"};
    		Man man2 = new Man();
    		man1.CopyTo(man2); // Real copy
    
    		Woman woman1 = new Woman() {Age = 32, Country = "USA", Purse = "Anything"};
    		Woman woman2 = woman1.CopyTo(); // Cloning
    
    		List<Person> adults = new List<Person>();
    		adults.Add(man1);
    		adults.Add(man2);
    		adults.Add(woman2);
    
    		Person person0 = adults[0].Clone() as Person;
    		Person person1 = adults[1].Clone() as Person;
    		Person person2 = adults[2].Clone() as Person;
    	}
    }
