using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] usableNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Shuffle<int>(ref usableNumbers);
            int[] numberToFind = new int[4];
            Array.Copy(usableNumbers, numberToFind, 4);

            var message = "Welcome soldier! \nA corrupt high-up politcian with bad hair has armed a nuclear attack which will start World War 3, effectivly killing \n80% of the worlds population as well as make Ice Cream manufacturing impossible on this planet. \nYou need to figure out the four-digit sequence that will disarm the weapons and save millions of lives. \nOr the ice cream. Whichever you find more motivating. \nNo judgement.";
            var messageUpper = message.ToUpper();
            foreach (var character in messageUpper)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(20);
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);

            while (true)
            {
                var instructions = "You will have 10, and only 10 attempts to find the correct sequence. \nThe sequence consists of four digits, 1-9. \nWhen a code is entered you will be told if any digit is correct, and if any digit is correctly placed. \nGood luck! \nPress any key...";
                var instructionsUpper = instructions.ToUpper();
                foreach (var character in instructionsUpper)
                {
                    Console.Write(character);
                    System.Threading.Thread.Sleep(20);

                }
                Console.WriteLine();
                Console.ReadLine();

                int attempts = 10;

                Console.Clear();
                Console.WriteLine("Enter your sequence: ");


                while (attempts > 0 && !startGame(Console.ReadLine(), numberToFind))
                {
                    attempts--;
                    if (attempts != 0)
                    {
                        Console.WriteLine("You only have " + attempts + " attempts left.");
                        Console.WriteLine("Enter your sequence: ");
                    }
                    else
                    {
                        Console.WriteLine("\nYOU FAILED. NO MORE ICE CREAM.\n");
                    }
                }
                break;

            }

        }

        //Shuffle method
        public static void Shuffle<T>(ref T[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(array.Length);
                T temp = array[i]; array[i] = array[j]; array[j] = temp;
            }
        }
        //End shuffle method

        public static bool startGame(string guess, int[] num)
        {
            char[] guessedSequence = guess.ToCharArray();
            int correctPlacement = 0, correctNumber = 0;
            var empty = "----";
            char cow  = 'X';
            char bull  = 'O';
            char[] bulls = empty.ToCharArray();

            if (guessedSequence.Length != 4)
            {
                Console.WriteLine("NOT A VALID SEQUENCE.");
                return startGame(Console.ReadLine(), num);
            }

            for (int i = 0; i < 4; i++)
            {
                int currentGuess = (int)char.GetNumericValue(guessedSequence[i]);
                if (currentGuess < 1 || currentGuess > 9)
                {
                    Console.WriteLine("ONLY DIGITS 1-9 ALLOWED. THINK OF THE ICE CREAM! ... EH, I MEAN THE CHILDREN");
                    return startGame(Console.ReadLine(), num);
                }
                if (currentGuess == num[i])
                {
                    correctPlacement++;
                    bulls[i] = bull;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (currentGuess == num[j])
                        {
                            correctNumber++;
                            bulls[i] = cow;
                        }
                    }
                }

            }
            if (correctPlacement == 4)
            {
                Console.WriteLine("YAY! THE ICE CREAM IS SAFE! AND HUMANITY.. WHATEVER.");
                return true;
            }
            else
            {
                                                                                                    
            }
            {
                Console.WriteLine(bulls);
                Console.WriteLine("Your sequence has {0} correct numbers and {1} correctly placed numbers", correctNumber, correctPlacement);
                return false;
            }
        }
    }
}






















































