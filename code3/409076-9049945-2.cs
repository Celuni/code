    public override Problem Generate(IConfiguration configuration)
    {
        int x = new Random().Next(configuration.Bound1.Max); //use value from configuration
        int y = new Random().Next(configuration.Bound2.Min); //use value from configuration
        Operators op = Operator.Addition
        return BinaryProblem.CreateProblem(x, y, op);
    }
