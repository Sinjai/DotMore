using System.Collections.Generic;
using System.Linq;

namespace DotMore.Extensions
{
	public static class Int32Extensions
	{
		public static IEnumerable<int> RangeTo(this int minValue, int maxValue, bool inclusive = true)
		{
			int factor = inclusive ? 1 : 0;
			return Enumerable.Range(minValue, (maxValue - minValue) + factor);
		}
	}
}
