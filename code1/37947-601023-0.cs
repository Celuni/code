    class MyClass<T> {
      public int Foo { get { return 10; } }
    }
    static class MyClassSpecialization {
      public static void Bar(this MyClass<int> cls) {
        return cls.Foo + 20;
      }
    }
