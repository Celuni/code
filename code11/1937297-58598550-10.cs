    private class Closure
    {
      public string head;
      public double tail;
      public op Helper(op op)
      {
        return op == op.add ? Int32.Parse(head) + Convert.ToInt32(tail) : 
        Int32.Parse(head) - Convert.ToInt32(tail);
      }
    }
    Func<op, int> combo(string head, double tail)
    {
      Closure c = new Closure();
      c.head = head;
      c.tail = tail;
      return c.Helper;
    }
