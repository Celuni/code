Area = Radius* Radius * Math.PI;
...is a statement but not a declaration.
It needs to go in *some sort* of method. 
To whomever downvoted this I am **choosing** to leave some work to the OP. The following merely illustrates placing a statement in a method, which is part of what's at stake.
    class Circle : Shape
    {
        public string Colour { get; set; }
        public double Radius { get; set; }
        void DoSomething()
        {    
           //Assume Radius has a value at this point...
           Area = Radius * Radius * Math.PI;
        }
     }
