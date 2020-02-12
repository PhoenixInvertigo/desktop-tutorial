using System;

namespace UniqueCoinCombos
{
    /*
     * This program finds the total number of unique combinations for making change between 1 and 100 cents.
     * It functions on the idea that the first combination will use the largest denomination as many times
     * as possible, the next highest as many times as possible, and so on from quarters down to pennies. Once
     * that combination has been counted, an item of the lowest non-penny denomination will be removed, and the
     * next highest denomination will be filled out algorithmically. Each time a combination fills out its 
     * pennies, it completes the combination, incrementing the combos counter and removing a coin.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int target = 0;
            int pennies = 0;
            int nickels = 0;
            int dimes = 0;
            int quarters = 0;
            int current = 0;
            int combos = 0;



            while (true)
            {
                Console.WriteLine("Hello!\r\nPlease enter the amount of change you would like to see its unique combination count!");
                Console.WriteLine("\r\n(Your input should be an integer from 1 to 100. Type 'exit' to exit!)");
                string inputStr = Console.ReadLine();
                bool isParseable = Int32.TryParse(inputStr, out target);

                if (isParseable == true)
                {
                    if(target < 1)
                    {
                        Console.WriteLine("Please enter a positive integer.");
                        continue;
                    } else if (target > 100)
                    {
                        Console.WriteLine("Please enter a number less than or equal to 100.");
                        continue;
                    }
                    else
                    {
                        combos = 0;
                        CalculateCurrent();
                        FillQuarters();
                        if(combos == 1)
                        {
                            Console.WriteLine("There was 1 unique combination for making change.");
                        }
                        else
                        {
                            Console.WriteLine("There were " + combos + " unique combinations for making change.");
                        }
                    }
                }

                else if(isParseable == false)
                {
                    if (inputStr == "exit")
                    {
                        Console.WriteLine("Thanks for using my program!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive integer.");
                        continue;
                    }
                }

            }

            void FillQuarters()
            {
                while (current + 25 <= target)
                {
                    quarters++;
                    CalculateCurrent();
                }
                FillDimes();
            }
            void FillDimes()
            {
                while (current + 10 <= target) 
                { 
                    dimes++;
                    CalculateCurrent();
                }
                FillNickels();
            }
            void FillNickels()
            {
                while (current + 5 <= target)
                {
                    nickels++;
                    CalculateCurrent();
                }
                FillPennies();
            }
            void FillPennies()
            {
                while (current < target)
                {
                    pennies++;
                    CalculateCurrent();
                }
                
                    combos++;
                    if (nickels > 0) RemoveNickel();
                    else if (dimes > 0) RemoveDime();
                    else if (quarters > 0) RemoveQuarter();
                pennies = 0;
              
            }
            void RemoveQuarter()
            {
                quarters--;
                dimes = 0;
                nickels = 0;
                pennies = 0;
                CalculateCurrent();
                FillDimes();
            }
            void RemoveDime()
            {
                dimes--;
                nickels = 0;
                pennies = 0;
                CalculateCurrent();
                FillNickels();
            }
            void RemoveNickel()
            {
                nickels--;
                pennies = 0;
                CalculateCurrent();
                FillPennies();
            }

            void CalculateCurrent()
            {
                current = quarters * 25 + dimes * 10 + nickels * 5 + pennies * 1;
            }
        }
    }


}
