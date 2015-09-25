using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Change_Calculator
{
    class Program
    {
        //Varibles for Program
        static string Line ="-----------------------  \n";
        static decimal NumOf50s, NumOf20s, NumOf10s, NumOf5s, NumOf2s, NumOf1s, 
            NumOfQuarters, NumOfDimes, NumOfNickels, NumOfPennies, moneyAdded;

        static decimal itemCost, givenAmount;

        static List<string> Transactions = new List<string>()
        {
            

        };

        static void AddLastTransaction(string price)
        {
            int counter = 1;

            Transactions.Add(counter + "). " +price);
            counter++;

        }

        
            public static void displayListItems(List<string> items)
        {
            Console.Clear();
            int counter = 0;
            Console.WriteLine("The prices of the items you have sold are: \n \n ");
            foreach (object o in items)
            {
                counter++;

                Console.WriteLine(o);
            }

            Console.WriteLine("\n \n Press Enter to Proceed");
            Console.ReadLine();
            Restart();


        }

        static void getInput()
        {

            Console.WriteLine(Line);

            string RegisterTotal = TotalRegisterCash.ToString("C");
            Console.WriteLine("You Currently have : {0} in your register", RegisterTotal);

            itemCost = JeffToolBox.ReadCurrency("Enter the item cost", true, false);


            givenAmount = JeffToolBox.ReadCurrency("\n \n Mow much $$ has the customer given you?", true, false);


           


        }

        static void RemoveLastTransaction(List<string> myList)
        {

            var count = myList.Count;
            if (count > 0)
            {
                // remove that number of items from the start of the list
                myList.RemoveAt(count-1);
            }

        }

        static void Restart()
        {
            string userInput;
            Console.Clear();
                
            Console.WriteLine("Would you like to proceed with another transaction? (yes/quit) \n \n or \n \n type save to save your transactions \n \n type print to print your transactions to screen");
            userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            userInput = JeffToolBox.RemoveSpecialCharacters(userInput);
            
            switch (userInput)
            {
                case "yes":
                    Console.Clear();
                    ProgramIntro();
                    getInput();
                    DetermineChange(itemCost, givenAmount);
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;

                case "print":
                    // SaveTransactionsFile(Transactions);
                    displayListItems(Transactions);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please check your spelling and type yes, save or quit");
                    Restart();

                    break;

            }




        }

        static void DetermineChange(decimal itemCost, decimal givenAmount)
        {
            decimal change = givenAmount - itemCost;
            string customersChange = change.ToString("C");

            string ItemPrice = itemCost.ToString("C");


            if (givenAmount < itemCost)

            {
                Console.WriteLine("You did not pay enough money, get more money from the customer and try again \n \n Press Enter to Proceed...");
                Console.ReadLine();
                Restart();

            }



            InputCash(givenAmount, itemCost);
            OutputCash(change);

            NumOf50s = Math.Floor(change / 50.00M);
            NumOf20s = Math.Floor((change % 50.00M) / 20.00M);
            NumOf10s = Math.Floor(((change % 50.00M) % 20.00M) / 10.00M);
            NumOf5s = Math.Floor((((change % 50.00M) % 20.00M) % 10.00M) / 5.00M);
            NumOf1s = Math.Floor(((((change % 50.00M) % 20.00M) % 10.00M) % 5.00M) / 1.00M);

        
            NumOfQuarters = Math.Floor((((((change % 50.00M) % 20.00M) % 10.00M) % 5.00M) % 1.00M) / .25M);
            NumOfDimes = Math.Floor(((((((change % 50.00M) % 20.00M) % 10.00M) % 5.00M) % 1.00M) % .25M) / .10M);
            NumOfNickels = Math.Floor((((((((change % 50.00M) % 20.00M) % 10.00M) % 5.00M) % 1.00M) % .25M) % .10M) / .05M);
            NumOfPennies = Math.Floor(((((((((change % 50.00M) % 20.00M) % 10.00M) % 5.00M) % 1.00M) % .25M) % .10M) % .05M) / .01M);

            string your50s = NumOf50s.ToString("C");
            string your20s = NumOf20s.ToString("C");
            string your10s = NumOf10s.ToString("C");
            string your5s = NumOf5s.ToString("C");
            string your1s = NumOf1s.ToString("C");
            string yourQuarters = NumOfQuarters.ToString("C");
            string yourDimes = NumOfDimes.ToString("C");
            string yourNickels = NumOfNickels.ToString("C");
            string yourPenneis = NumOfPennies.ToString("C");

            Console.WriteLine(Line);
            Console.WriteLine("The Customers change is "+customersChange+".  \n \n Please give the customer: \n\n");

            Console.WriteLine("# of 50 Dollar Bills : {0}", NumOf50s);
            Console.WriteLine("# of 20 Dollar Bills : {0}", NumOf20s);
            Console.WriteLine("# of 10 Dollar Bills : {0}", NumOf10s);
            Console.WriteLine("# of 5 Dollar Bills : {0}", NumOf5s);
            Console.WriteLine("# of 1 Dollar Bills : {0}", NumOf1s);
            Console.WriteLine("# of Quarters : {0}", NumOfQuarters);
            Console.WriteLine("# of Dimes : {0}", NumOfDimes);
            Console.WriteLine("# of Nickels : {0}", NumOfNickels);
            Console.WriteLine("# of Pennies : {0}", NumOfPennies);
            Console.WriteLine(Line);
            Console.WriteLine("The total change you gave the customer is: " + customersChange);

            ShowCashRegisaterAmount();

            AddLastTransaction(ItemPrice);

            Console.WriteLine(Line);
            Restart();
            


        }



        static decimal TotalRegisterCash = 100.00M;

        static void OutputCash(decimal ChangeAmount)
        {
            TotalRegisterCash = TotalRegisterCash - ChangeAmount;
  

        }

        static void ShowCashRegisaterAmount()
        {

            string YourMoney = TotalRegisterCash.ToString("C");
            string newMoney = moneyAdded.ToString("C");
    


            Console.WriteLine(Line);
            Console.WriteLine("The Total amount of Money you have in your cash register is: " + YourMoney);
            Console.WriteLine("You added {0} to your cash register in this sale", newMoney);
        }



        static void InputCash(decimal SaleAmount, decimal PaidCash)
        {
            moneyAdded = PaidCash;

            TotalRegisterCash = TotalRegisterCash + SaleAmount;

        }

        static void SaveTransactionsFile(List<string> myList)
        {
            if (Directory.Exists("C:\\ChangeCalculator\\Transactions"))
            {
                Directory.CreateDirectory("C:\\ChangeCalculator\\Transactions");
                Console.WriteLine("New Directory Written Here:  C:\\ChangeCalculator\\Transactions ");
            }

            string contents = JeffToolBox.ListToString(myList);
          
            File.WriteAllText("C:\\ChangeCalculator\\Transactions", (contents));

            string fileContents = File.ReadAllText("C:\\ChangeCalculator\\Transactions");

            Console.WriteLine("\n \n Save file created Here: " + "C:\\ChangeCalculator\\Transactions \n \n " +
                "Here are your file contents:  \n \n "+fileContents);

            Console.WriteLine("Press enter to Restart");
            Console.ReadLine();
            Restart();
       
        }

        public static void ProgramIntro()
        {
            Console.WriteLine(Line);
            Console.WriteLine("Welcome to Cash Register 1.0");
            Console.WriteLine("Press Enter to Begin");
            Console.ReadLine();
            Console.Clear();
        }
      



        static void Main(string[] args)
        {
            try
            {
                ProgramIntro();
                getInput();
                DetermineChange(itemCost, givenAmount);


            }
            catch (Exception e)
            {
                Console.WriteLine(Line+ "An error has occured.. Please contact technical support immediatly.");
                Console.ReadLine();
                
            }



        }
    }
}
