    Random rnd = new Random();
    public enum PegColour
    {
        Red, Green, Blue, Yellow, Black = 100, White = 101
    }
    private PegColour GetRandomColoredPeg()
    {
    	PegColour color = (PegColour)rnd.Next(0, Enum.GetNames(typeof(PegColour)).Length - 2);
        return color;
    }
