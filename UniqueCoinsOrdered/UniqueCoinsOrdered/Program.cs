using System;

namespace UniqueCoinsOrdered
{
    class Program
    {

        static void Main(string[] args)
        {
            int target;
            int combos = 0;
            bool printingPaths = false;
            Penny myPenny = new Penny();
            Nickel myNickel = new Nickel();
            Dime myDime = new Dime();
            Quarter myQuarter = new Quarter();

            while (true)
            {
                Console.WriteLine("Hello!\r\nPlease enter the amount of change you would like combinations for!");
                Console.WriteLine("\r\nYour input should be an integer from 1 to 100. Type 'exit' to exit!");
                Console.WriteLine("\r\n(Values above 50 take a while to compute)");
                string inputStr = Console.ReadLine();
                bool isParseable = Int32.TryParse(inputStr, out target);

                if (isParseable == true)
                {
                    if (target < 1)
                    {
                        Console.WriteLine("Please enter a positive integer.");
                        continue;
                    }
                    else if (target > 100)
                    {
                        Console.WriteLine("Please enter a number less than or equal to 100.");
                        continue;
                    }
                    else
                    {
                        Initial(target);
                        if (combos == 1)
                        {
                            Console.WriteLine("There was 1 unique combination for making change.");
                        }
                        else
                        {
                            Console.WriteLine("There were " + combos + " unique combinations for making change.");
                        }
                    }
                }

                else if (isParseable == false)
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

            void Initial(int targetValue)
            {
                combos = 0;
                if (0 < targetValue) AddCoin(targetValue, 0, "", myPenny);
                if (4 < targetValue) AddCoin(targetValue, 0, "", myNickel);
                if (9 < targetValue) AddCoin(targetValue, 0, "", myDime);
                if (24 < targetValue) AddCoin(targetValue, 0, "", myQuarter);
            }

            void AddCoin(int targetValue, int currentValue, string path, Coin coin)
            {
                int tar = targetValue;
                int cur = currentValue + coin.value;
                string curPath = path + coin.letter;

                if (cur == tar)
                {
                    if (printingPaths == true) Console.WriteLine(curPath);
                    combos++;
                }
                if (cur < tar) AddCoin(tar, cur, curPath, myPenny);
                if (cur + 4 < tar) AddCoin(tar, cur, curPath, myNickel);
                if (cur + 9 < tar) AddCoin(tar, cur, curPath, myDime);
                if (cur + 24 < tar) AddCoin(tar, cur, curPath, myQuarter);


            }
        }
    }

    class Coin
    {
        public int value;
        public char letter;
        public Coin()
        {

        }
    }

    class Penny : Coin
    {
        public Penny()
        {
            value = 1;
            letter = 'P';
        }
    }

    class Nickel : Coin
    {
        public Nickel()
        {
            value = 5;
            letter = 'N';
        }
    }

    class Dime : Coin
    {
        public Dime()
        {
            value = 10;
            letter = 'D';
        }
    }

    class Quarter : Coin
    {
        public Quarter()
        {
            value = 25;
            letter = 'Q';
        }
    }
}
