    static void Main(string[] args)
    {
        var test = new TestClass();
        Task<int>[] addData = Enumerable.Range(0, 4)
                                        .Select(_ => Task.Run(() => test.GetRandomNumber()))
										.ToArray();
        Task.WaitAll(addData);
        foreach (var result in addData)
        {
            Console.WriteLine("The values that will be added are :{0}", result.Result);
        }
        Console.WriteLine("The value is :{0}", adddata.Select(x => x.Result).Sum());
    }
