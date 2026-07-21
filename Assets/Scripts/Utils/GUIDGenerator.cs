using System;

namespace Utils
{
	public static class GUIDGenerator
	{
		public static string GenerateGuid()
		{
			return Guid.NewGuid().ToString();
		}
	}
}