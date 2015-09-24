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
        static string Line ="----------------------- \n \n \n";
        decimal NumOf50s, NumOf20s, NumOf10s, NumOf5s, NumOf2s, NumOf1s, 
            NumOfQuarters, NumOfDimes, NumOfNickels, NumOfPennies;

        static List<string> Transactions = new List<string>()
        {
            "Your Transactions",
            Line,

        };

        static void DetermineChange(decimal SaleAmout)
        {



        }

        static decimal TotalRegisterCash = 100.00;

        static void OutputCash(decimal ChangeAmount)
        {
            TotalRegisterCash = TotalRegisterCash - ChangeAmount;

        }

        static void InputCash(decimal SaleAmount)
        {

            TotalRegisterCash = TotalRegisterCash + SaleAmount;

        }

        static void SaveTransactionsFile(List<string> myList)
        {
            if (Directory.Exists("C:\\ChangeCalculator\\Transactions"))
            {
                Directory.CreateDirectory("C:\\ChangeCalculator\\Transactions");
            }

            string contents = JeffToolBox.ListToString(myList);
          
            File.WriteAllText("C:\\ChangeCalculator\\Transactions", (contents));

            string fileContents = File.ReadAllText("C:\\ChangeCalculator\\Transactions");

            Console.WriteLine(Line+"Save file created Here: " + "C:\\ChangeCalculator\\Transactions \n \n " +
                "Here are your file contents:  \n \n "+fileContents);
       
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




            }
            catch (Exception e)
            {
                Console.WriteLine(Line+ "An error has occured.. Please contact technical support immediatly.");
                Console.ReadLine();
                
            }



        }
    }
}
