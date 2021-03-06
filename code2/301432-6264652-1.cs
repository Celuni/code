    public class ImmutablePerson
    {
        private readonly string name; //readonly ensures the field can only be set in the object's constructor(s).
        private readonly int age;
        public ImmutablePerson(string name, int age)
        {
             this.name = name;
             this.age = age;
        }
        public int Age { get { return this.age; } } //no setter
        public string Name { get { return this.name; } }
        public ImmutablePerson GrowUp(int years)
        { 
             return new ImmutablePerson(this.name, this.age + years); //does not modify object state, it returns a new object with the new state.
        }
    }
