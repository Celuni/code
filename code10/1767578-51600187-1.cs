    int x = 0;
    try
    {
        int divide = 12 / x;
    }
    catch (Exception ex)
    {
        int divide = 12 / x;   // no handled
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("I am finally block");
    }
    Console.ReadLine();
