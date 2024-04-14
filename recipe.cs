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
            Console.WriteLine("number of ingredients:");
            string ingred = Console.ReadLine();
            if (ingred == "")
            { Console.WriteLine("please enter in the number of ingredients"); }
            else
            Console.WriteLine("Number of ingredients:"+ ingred);

        }
    }
}
