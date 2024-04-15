using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1.st10254714
{
    public class recipe
    {
        static List<recipe> recipes = new List<recipe>();
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
                    recipe newRecipe = new recipe();
                    recipeDetails(newRecipe);
                    recipes.Add(newRecipe);
                }
                else if( userInput.ToLower() == "n")
                {
                    Console.WriteLine("ok, no worries. would you like to exit the application or display stored recipes? enter y to exit or n to display recipes.");
                    string chc = Console.ReadLine();
                    if (chc.ToLower() == "y")
                    {
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);
                    }
                    else if (chc.ToLower() == "n")
                    { displayListOfRecipes(); }

                } else
                {
                    Console.WriteLine("Invalid choice.Please enter in either Y or N");
                }

            }
        }
        public void newIngredients( string name, string quantity, string unitOfMeasure)
        {
            ingredient.Add($"{name},{quantity}, {unitOfMeasure}");
        }
        public void addStep(string nam, string description)
        {
            steps.Add($"{nam}: {description}");
        }
        private static void recipeDetails(recipe newRecipe)
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

                newRecipe.newIngredients(name, quantity, unitOfMes);
                Console.WriteLine("Do you want to enter in another ingredient? enter Y or N ");
                string slct = Console.ReadLine();
                if (slct.ToLower() == "y")
                {
                    opt = "y";
                } 
                else if (slct.ToLower() == "n")
                {
                    opt = "n";
                }
             
                   
            }

 
            //**********************************************************************************************************************************
            
            Console.WriteLine("add a step? Y or N");
            string choice = Console.ReadLine();

            while (choice.ToLower() == "y")
            {
                Console.WriteLine("enter name of step:");
                string nam = Console.ReadLine();
                Console.WriteLine("enter step description:");
                string description = Console.ReadLine();

                newRecipe.addStep(nam, description);
                Console.WriteLine("Do you want to enter in another step? enter Y or N ");
                string chois = Console.ReadLine();
                if (chois.ToLower() == "y")
                {
                    choice = "y";
                }
                else if (chois.ToLower() == "n")
                {
                    choice = "n";
                }
            }

        }
        public static void displayListOfRecipes()
        {
            Console.WriteLine("All recipes:");
            Console.WriteLine("*******************************************************************");
            foreach (var recipe in recipes)
            {
                Console.WriteLine("Recipe details:");
                Console.WriteLine("ingredients:");
                foreach (var ingredient in recipe.ingredient)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine("Steps:");
                foreach (var step in recipe.steps)
                {
                    Console.WriteLine(step);
                }
            }
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        }
    }

