    class Point
    {
        public double X { get; }
        public double Y { get; }
        ...
    }
    class Circle
    {
        public Point Center { get; }
        public double Radius { get; }
        ....
        public static IEnuerable<Point> Interstect(Circle first, Circle second) { ... }
    }
