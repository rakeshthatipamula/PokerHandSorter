using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PokerHandSorter
{
    public class Sorter
    {
        public const string TIE = "Unfortunately, the tie breaks were not enough. There is a tie.";
        public static void Main(string[] args)
        {
            int winsPlayer1 = 0;
            int winsPlayer2 = 0;

            StreamReader br = null;

            try
            {
                Console.WriteLine("Please Enter the File Name");
                br = new StreamReader(Console.ReadLine());
                // main loop for piping through stdin
                while (true)
                {
                    string input = br.ReadLine();
                    if (string.ReferenceEquals(input, null))
                    {
                        break;
                    }
                    //Input validation using regex
                    Regex expression = new Regex(@"(?:[2-9TJQKA][SCHD] ){9}[2-9TJQKA][SCHD]");
                    if (!expression.IsMatch(input))
                    {
                        Console.WriteLine("Wrong input format.");
                        break;
                    }
                    else
                    {
                        //Splitting the string with space Delimiter
                        string[] cards = input.Split(" ");

                        //Input String is split into 5 each for Player1 and Player2
                        string[] handOneStr = Arrays.CopyOfRange(cards, 0, 5);
                        string[] handTwoStr = Arrays.CopyOfRange(cards, 5, 10);
                        
                        //Adding Player1 and Player2 Hands to Hand Class
                        Hand handOne = new Hand(handOneStr);
                        Hand handTwo = new Hand(handTwoStr);
                        
                        //Cards are sorted out for both the Players
                        handOne.sortCards();
                        handTwo.sortCards();
                        
                        //Evaluating the player hands whether they fall under which category among the 
                        //given 10 combinations
                        handOne.evaluate();
                        handTwo.evaluate();

                        //Deciding the Winner among the two basis the Evaluation
                        int res = winner(handOne, handTwo);
                        if (res == 1)
                        {
                            winsPlayer1++;
                        }
                        else if (res == 2)
                        {
                            winsPlayer2++;
                        }
                        else
                        {
                            Console.WriteLine(TIE);
                        }
                    }
                }

                Console.WriteLine("Player 1: " + winsPlayer1 + " hands");
                Console.WriteLine("Player 2: " + winsPlayer2 + " hands");
                Console.ReadLine();
                Environment.Exit(0);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }

        }

        public static int winner(Hand hand1, Hand hand2)
        {


            if (hand1.getHandCategory().getValue() > hand2.getHandCategory().getValue())
            {
                return 1;
            }
            else if (hand1.getHandCategory().getValue() < hand2.getHandCategory().getValue())
            {
                return 2;
            }
            else if (hand1.getHandValue() > hand2.getHandValue())
            {
                return 1;
            }
            else if (hand1.getHandValue() < hand2.getHandValue())
            {
                return 2;
            }
            else
            {
                // final tie break!
                for (int i = 4; i >= 0; i--)
                {
                    if (hand1.getCard(i).getValue() > hand2.getCard(i).getValue())
                    {
                        return 1;
                    }
                    else if (hand1.getCard(i).getValue() < hand2.getCard(i).getValue())
                    {
                        return 2;
                    }
                }
                // theres a tie here...
                return -1;
            }

        }
    }

}
