using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1.st10254714
{
    public class recipe
    {
        public static void intro()
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("**************************************************");
                Console.WriteLine("");
                Console.WriteLine("Would you like to record a new recipe? answer Y or N:");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    recipeDetails();
                }
                else if( userInput.ToLower() == "n")
                {
                    Console.WriteLine("ok, no worries. would you like to exit the application or return to the start? enter y to exit or n to return.");
                    string chc = Console.ReadLine();
                    if (chc.ToLower() == "y")
                    {
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);
                    }
                    else if (chc.ToLower() == "n")
                    { }

                } else
                {
                    Console.WriteLine("Invalid choice.Please enter in either Y or N");
                }

            }
        }
        
        private static void recipeDetails()
        {
            Console.WriteLine("Please enter in your details for your recipe");
            Console.WriteLine("**************************************************");
            Console.WriteLine("add an ingredient? Y or N");
            string opt = Console.ReadLine();
            
            if (opt.ToLower() == "y")
            {
                Console.WriteLine("enter name of ingredient:");
                string name = Console.ReadLine();
                Console.WriteLine("enter quantity of the ingredient:");
                string quantity = Console.ReadLine();
                Console.WriteLine("enter the unit of measurement of the ingredient:");
                string unitOfMes = Console.ReadLine();
            }
            else if (opt.ToLower() == "n")
            { }
            //**********************************************************************************************************************************
            Console.WriteLine("add a step? Y or N");
            string choice = Console.ReadLine();

            if (opt.ToLower() == "y")
            {
                Console.WriteLine("enter name of ingredient:");
                string name = Console.ReadLine();
                Console.WriteLine("enter quantity of the ingredient:");
                string quantity = Console.ReadLine();
                Console.WriteLine("enter the unit of measurement of the ingredient:");
                string unitOfMes = Console.ReadLine();
            }
            else if (opt.ToLower() == "n")
            { }

        }
        
        }
    }

