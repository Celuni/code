    private static int GetDecimalScale(Random r)
    {
      for(int i=0;i<=28;i++){
        if(r.NextDouble() >= 0.1)
          return i;
      }
      return 0;
    }
    public static decimal NextDecimal(this Random r)
    {
        var s = GetDecimalScale(r);
        var a = (int)(uint.MaxValue * r.NextDouble());
        var b = (int)(uint.MaxValue * r.NextDouble());
        var c = (int)(uint.MaxValue * r.NextDouble());
        var n = r.NextDouble() >= 0.5;
        return new Decimal(a, b, c, n, s);
    }
