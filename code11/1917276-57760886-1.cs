csharp
public static class RandomExtensions
{
    public static IEnumerable<double> GenerateTrend(this Random random, double from, double to, double delta)
    {
        var last = random.NextDouble(from, to);
        while (true)
        {
            yield return last;
            last = random.NextDouble(Math.Max(from, last - delta), Math.Min(to, last + delta));
        }
    }
    public static double NextDouble(this Random random, double from, double to)
        => random.NextDouble() * (to - from) + from;
}
Use like this:
csharp
var random = new Random();
var numbers = random.GenerateTrend(0, 2.2, 0.2).Take(20).ToArray();
As you can see, this being an infinite generator, the calling code is responsible for limiting the amount of random numbers it's taking. In this example, I limit the generation to 20 items by using `Take(20)`.
