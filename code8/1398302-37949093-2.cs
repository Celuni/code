    [Fact]
    public async Task Test_My_Method()
    {
        IMyService serviceInterface = service;
        var result = await serviceInterface.MyMethodToTest("");
    }
