	interface IFoo
	{
		int Offset { get; }
	}
	interface IBar : IFoo
	{
		new int Offset { set; }
	}
	class Thing : IBar
	{
		public int Offset { get; set; }
	}
