    var sw = new Stopwatch();
    sw.Start();
    bool b = list.Any(i => list.Where(j => i != j).Any(j => j.ID == i.ID));
    Console.WriteLine(b);
    Console.WriteLine(sw.ElapsedTicks);
    sw.Reset();
    sw.Start();
    b = (list.GroupBy(i => i.ID).Count() != list.Count);
    Console.WriteLine(b);
    Console.WriteLine(sw.ElapsedTicks);
