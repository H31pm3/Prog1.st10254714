using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1.st10254714
{
    public class recipe
    {
        public List<string> ingredient { get; set; } = new List<string>();
        public List<string> steps { get; set; } = new List<string>();
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
            
            while (opt.ToLower() == "y")
            {
                Console.WriteLine("enter name of ingredient:");
                string name = Console.ReadLine();
                Console.WriteLine("enter quantity of the ingredient:");
                string quantity = Console.ReadLine();
                Console.WriteLine("enter the unit of measurement of the ingredient:");
                string unitOfMes = Console.ReadLine();

                Console.WriteLine("Do you want to enter in another ingredient? enter Y or N ");
                opt = Console.ReadLine();
            }
 

            //**********************************************************************************************************************************
            Console.WriteLine("add a step? Y or N");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                Console.WriteLine("enter name of step:");
                string nam = Console.ReadLine();
                Console.WriteLine("enter step description:");
                string description = Console.ReadLine();
            }
            else if (choice.ToLower() == "n")
            { }

        }
        
        }
    }

