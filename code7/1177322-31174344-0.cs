    public static List<string> Sort(List<string> MyList, char MyChar)
	{
		return MyList
			.OrderByDescending(i => i.StartsWith(MyChar.ToString()))
			.ToList();
	}
