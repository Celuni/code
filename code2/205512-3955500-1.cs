    class A
    {
      A()
      {
      }
      public B B
      {
        get
        {
          if(b == null)
            b = new B();
          return b;
        }
      }
      private B b;
    }
    class B
    {
      B()
      {
      }
      public A A
      {
        get
        {
          if(a == null)
            a = new A();
          return a;
        }
      }
      private A a;
    }
