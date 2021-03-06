    class Mammal {
        public void Nurse() { /* */ }
    }
    class Dog : Mammal {
        public void ChaseCar() { /* */ }
    }
    class Cat : Mammal {
        public void ClimbTree() { /* */ }
    }
    Mammal myPet = new Cat();
    //  The actual THING that mamal refers to may not be a Dog, so the 
    //  compiler won't let you do this. 
    myPet.ChaseCar();
    //  You can force it to try, but in this case, myPet does not refer
    //  to a Dog, so this call will fail at runtime and throw an exception. 
    ((Dog)myPet).ChaseCar();
    //  But C# does let you find out what you've really got. In this case, 
    //  myPet is not Dog, so this block won't execute. But if it were a 
    //  Dog, it would. 
    if ( myPet is Dog ) {
        var myDog = myPet as Dog;
        myDog.ChaseCar();
    }
