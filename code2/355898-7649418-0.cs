	using System;
	
	public class MyClass
	{
		public static void Main()
		{
			string sql = "SELECT column_name1, column_name2, column_name3, column_name4 FROM table1 JOIN table2 ON table1.field1 = table2.field1";
			
			string[] parts = sql.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
			
			for (int i=1; i<parts.Length; i++)
			{
				if (parts[i].Equals("FROM")) break;
				
				Console.WriteLine(parts[i].Trim());
			}
		}
	}
