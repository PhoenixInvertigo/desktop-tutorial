using System;

namespace CoinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                //Prompting the user for input
                Console.WriteLine("How many cents would you like to make change for? \r\n(Limited to 50 because that's over 1.9 million combinations \r\nand memory starts crying shortly thereafter) \r\n(Type exit to exit)");
                string targetStr = Console.ReadLine();
                int target;
                bool isParsable = Int32.TryParse(targetStr, out target);
                //Testing the input for validity
                if (isParsable)
                {
                    if(target <= 0)
                    {
                        Console.WriteLine("Please input a positive integer.");
                        continue;
                    }
                    if(target > 50)
                    {
                        Console.WriteLine("Please input an integer smaller than 50.");
                        continue;
                    }
                    //Creating the tree
                    CoinNode coins = new CoinNode(target, 0, "");
                    //Recursively printing the strings of combinations
                    coins.PrintCoinStacks();
                    //Recursively counting the total combinations
                    int combinations = coins.CountCombinations();
                    if (combinations == 1) Console.WriteLine("There was 1 combination of coins.");
                    else Console.WriteLine("There were " + combinations + " combinations of coins");
                }
                else
                {
                    if (targetStr == "exit") break;
                    Console.WriteLine("Please input an integer.");
                    continue;
                }
        }
        }
    }

    class CoinNode
    {
        
        protected int sValue; //Stack value. The "running total" of the node.
        protected int tValue; //Target value. What we're trying to reach.
        protected string cStack = ""; //The string representing the combination of this node.
        protected bool complete = false; //Whether the node has achieved its target value.
        protected int cValue = 0; //Value this cointype adds to the stack value. (Root adds none, so zero here)

        //The branches of each node
        protected Penny penny;
        protected Nickel nickel;
        protected Dime dime;
        protected Quarter quarter;

        public CoinNode()
        {

        }
        public CoinNode(int targetValue, int stackValue, string coinStack)
        {
            tValue = targetValue;
            sValue = stackValue + cValue;
            cStack = coinStack;

            //Checks if the node is complete, and if not, generates its branches
            if (sValue == tValue) complete = true;
            else complete = false;

            if (complete == false)
            {
                CreateCoins();
            }
        }

        //Methods for creating the branches
        protected void CreateCoins()
        {
            if (sValue < tValue)
            {
                CreatePenny();
            }

            if (sValue + 4 < tValue)
            {
                CreateNickel();
            }

            if (sValue + 9 < tValue)
            {
                CreateDime();
            }

            if (sValue + 24 < tValue)
            {
                CreateQuarter();
            }
        }
        protected void CreatePenny()
        {
            penny = new Penny(tValue, sValue, cStack);
        }

        protected void CreateNickel()
        {
            nickel = new Nickel(tValue, sValue, cStack);
        }

        protected void CreateDime()
        {
            dime = new Dime(tValue, sValue, cStack);
        }

        protected void CreateQuarter()
        {
            quarter = new Quarter(tValue, sValue, cStack);
        }

        /*
         If the node is complete (ie, is a leaf), this prints its coin combination string.
         If the node is incomplete, it recursively tells its branches to repeat the process.
         */
        public void PrintCoinStacks()
        {
            if(complete == true)
            {
                Console.WriteLine(cStack);
            }
            else
            {
                if (penny != null) penny.PrintCoinStacks();
                if (nickel != null) nickel.PrintCoinStacks();
                if (dime != null) dime.PrintCoinStacks();
                if (quarter != null) quarter.PrintCoinStacks();
            }
        }

        //Recursively counts the number of complete nodes
        public int CountCombinations()
        {
            int pVal = 0;
            int nVal = 0;
            int dVal = 0;
            int qVal = 0;

            if (complete == true)
            {
                return 1;
            }
            else
            {
                if (penny != null)
                {
                    pVal = penny.CountCombinations();
                }
                if (nickel != null)
                {
                    nVal = nickel.CountCombinations();
                }
                if (dime != null)
                {
                    dVal = dime.CountCombinations();
                }
                if (quarter != null)
                {
                    qVal = quarter.CountCombinations();
                }
                return pVal + nVal + dVal + qVal;
            }
        }
    }

    class Penny : CoinNode
    {

        public Penny(int targetValue, int stackValue, string coinStack)
        {
            cValue = 1;
            tValue = targetValue;
            sValue = stackValue + cValue;
            cStack = coinStack + "P";

            if (sValue == tValue) complete = true;
            else complete = false;

            if (complete == false)
            {
                CreateCoins();
            }
        }
    }

    
    class Nickel : CoinNode
    {
        public Nickel(int targetValue, int stackValue, string coinStack)
        {
            cValue = 5;
            tValue = targetValue;
            sValue = stackValue + cValue;
            cStack = coinStack + "N";

            if (sValue == tValue) complete = true;
            else complete = false;

            if (complete == false)
            {
                CreateCoins();
            }
        }
    }

    class Dime : CoinNode
    {
        public Dime(int targetValue, int stackValue, string coinStack)
        {
            cValue = 10;
            tValue = targetValue;
            sValue = stackValue + cValue;
            cStack = coinStack + "D";

            if (sValue == tValue) complete = true;
            else complete = false;

            if (complete == false)
            {
                CreateCoins();
            }
        }
    }

    class Quarter : CoinNode
    {
        public Quarter(int targetValue, int stackValue, string coinStack)
        {
            cValue = 25;
            tValue = targetValue;
            sValue = stackValue + cValue;
            cStack = coinStack + "Q";

            if (sValue == tValue) complete = true;
            else complete = false;

            if (complete == false)
            {
                CreateCoins();
            }
        }
    }

}
