	public class MethodInfoComparer : IEqualityComparer<MethodInfo>
	{
		public bool Equals(MethodInfo x, MethodInfo y)
		{
			if (ReferenceEquals(x, y))
				return true;
			if (x == null || y == null)
				return false;
			return x.MetadataToken.Equals(y.MetadataToken) && x.MethodHandle.Equals(y.MethodHandle);
		}
		public int GetHashCode(MethodInfo obj)
		{
			return obj.MetadataToken.GetHashCode();
		}
	}
