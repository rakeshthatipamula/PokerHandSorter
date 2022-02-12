using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter.enums
{
	public sealed class HandCategory
	{
		public static readonly HandCategory HIGH_CARD = new HandCategory("HIGH_CARD", InnerEnum.HIGH_CARD, 1, "HIGH_CARD");
		public static readonly HandCategory ONE_PAIR = new HandCategory("ONE_PAIR", InnerEnum.ONE_PAIR, 2, "ONE_PAIR");
		public static readonly HandCategory TWO_PAIRS = new HandCategory("TWO_PAIRS", InnerEnum.TWO_PAIRS, 3, "TWO_PAIRS");
		public static readonly HandCategory THREE_OF_A_KIND = new HandCategory("THREE_OF_A_KIND", InnerEnum.THREE_OF_A_KIND, 4, "THREE_OF_A_KIND");
		public static readonly HandCategory STRAIGHT = new HandCategory("STRAIGHT", InnerEnum.STRAIGHT, 5, "STRAIGHT");
		public static readonly HandCategory FLUSH = new HandCategory("FLUSH", InnerEnum.FLUSH, 6, "FLUSH");
		public static readonly HandCategory FULL_HOUSE = new HandCategory("FULL_HOUSE", InnerEnum.FULL_HOUSE, 7, "FULL_HOUSE");
		public static readonly HandCategory FOUR_OF_A_KIND = new HandCategory("FOUR_OF_A_KIND", InnerEnum.FOUR_OF_A_KIND, 8, "FOUR_OF_A_KIND");
		public static readonly HandCategory STRAIGHT_FLUSH = new HandCategory("STRAIGHT_FLUSH", InnerEnum.STRAIGHT_FLUSH, 9, "STRAIGHT_FLUSH");
		public static readonly HandCategory ROYAL_FLUSH = new HandCategory("ROYAL_FLUSH", InnerEnum.ROYAL_FLUSH, 10, "ROYAL_FLUSH");

		private static readonly List<HandCategory> valueList = new List<HandCategory>();

		static HandCategory()
		{
			valueList.Add(HIGH_CARD);
			valueList.Add(ONE_PAIR);
			valueList.Add(TWO_PAIRS);
			valueList.Add(THREE_OF_A_KIND);
			valueList.Add(STRAIGHT);
			valueList.Add(FLUSH);
			valueList.Add(FULL_HOUSE);
			valueList.Add(FOUR_OF_A_KIND);
			valueList.Add(STRAIGHT_FLUSH);
			valueList.Add(ROYAL_FLUSH);
		}

		public enum InnerEnum
		{
			HIGH_CARD,
			ONE_PAIR,
			TWO_PAIRS,
			THREE_OF_A_KIND,
			STRAIGHT,
			FLUSH,
			FULL_HOUSE,
			FOUR_OF_A_KIND,
			STRAIGHT_FLUSH,
			ROYAL_FLUSH
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private int value;
		private string desc;

		private HandCategory(string name, InnerEnum innerEnum, int value, string desc)
		{
			this.value = value;
			this.desc = desc;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int getValue()
		{

				return this.value;
			
		}

		public string getDesc()
		{

				return this.desc;
			
		}

		public static HandCategory[] values()
		{
			return valueList.ToArray();
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static HandCategory valueOf(string name)
		{
			foreach (HandCategory enumInstance in HandCategory.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}
