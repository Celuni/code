	static class DataRowHelper
	{
		public static int ToInt(this object item)
		{
			return Convert.ToInt32(item == null ? 0 : item);
		}
	}
