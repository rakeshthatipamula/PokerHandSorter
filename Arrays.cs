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
		public static T[] CopyOf<T>(T[] original, int newLength)
		{
			T[] dest = new T[newLength];
			Array.Copy(original, dest, Math.Min(original.Length, newLength));
			return dest;
		}

		public static T[] CopyOfRange<T>(T[] original, int fromIndex, int toIndex)
		{
			int length = toIndex - fromIndex;
			T[] dest = new T[length];
			Array.Copy(original, fromIndex, dest, 0, length);
			return dest;
		}

		public static void Fill<T>(T[] array, T value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		public static void Fill<T>(T[] array, int fromIndex, int toIndex, T value)
		{
			for (int i = fromIndex; i < toIndex; i++)
			{
				array[i] = value;
			}
		}
	}
}
