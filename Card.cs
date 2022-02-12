using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter
{
    public class Card : IComparable<Card>
    {
        private int value;
        private char suit;

        public Card(string str)
        {
            char v = str[0];
            switch (v)
            {
                case 'T':
                    this.value = 10;
                    break;
                case 'J':
                    this.value = 11;
                    break;
                case 'Q':
                    this.value = 12;
                    break;
                case 'K':
                    this.value = 13;
                    break;
                case 'A':
                    this.value = 14;
                    break;
                default:
                    this.value = int.Parse("" + v);
                    break;
            }

            this.suit = str[1];

        }

        public virtual int CompareTo(Card compareCard)
        {

            int compareValue = ((Card)compareCard).getValue();

            // ascending order
            return this.value - compareValue;

        }

        public override string ToString()
        {
            string str = "";
            str = this.value.ToString() + this.suit;
            return str;
        }

        internal int getValue()
        {
            return this.value;
        }

        internal char getSuit()
        {
            return this.suit;
        }
    }
}
