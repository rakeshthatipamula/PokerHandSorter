using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter
{
	using System;

	internal static class Arrays
	{
		public static T[] CopyOfRange<T>(T[] original, int fromIndex, int toIndex)
		{
			int length = toIndex - fromIndex;
			T[] dest = new T[length];
			Array.Copy(original, fromIndex, dest, 0, length);
			return dest;
		}
	}
}
