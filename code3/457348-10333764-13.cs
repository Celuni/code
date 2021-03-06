    using System;
    
    public class MainClass {
    
        public static void Main() {
            
            Asset a = new House();
            
            Console.WriteLine("A");
            Foo((dynamic)a);  // there is a considerable delay here, 
            // the "B" string appears after two seconds
            
            Console.WriteLine ("B");        
            Type t = typeof(MainClass);
            t.InvokeMember("Foo", System.Reflection.BindingFlags.InvokeMethod, null, t, new object[] { a } ); 
                    
            Console.WriteLine("C");
            
        }
        
        
        public static void Foo(House h) { Console.WriteLine("House"); }
        public static void Foo(Asset a) { Console.WriteLine("Asset"); }
        public static void Foo(int i) { Console.WriteLine("int"); }
    }
    
    
    public class Asset {
    }
    
    public class House : Asset {
    }
