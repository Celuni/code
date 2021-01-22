    delegate void ParamsDelegate(params object[] args);
    static void Main()
    {  
       ParamsDelegate paramsDelegate = x => Console.WriteLine(x.Length);
       
       paramsDelegate(1,2,3); //output: "3"
       paramsDelegate();      //output: "0"
    }
