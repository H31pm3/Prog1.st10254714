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

                Console.WriteLine("enter in 1 to create a new recipe");
                Console.WriteLine("enter in 2 to display created recipes");
                Console.WriteLine("enter in 3 to scale recipe");
                Console.WriteLine("enter in 4 to exit program");
                int userInput;
                bool selectNumber;
                selectNumber = int.TryParse(Console.ReadLine(), out userInput);
                //string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case 1:
                        recipe newRecipe = new recipe();
                        recipeDetails(newRecipe);
                        recipes.Add(newRecipe);
                        break;

                    case 2:
                        Console.WriteLine("displaying recipes");
                        displayListOfRecipes();
                  
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);
                        break;


                }


            }

        }

        public void newIngredients(string name, string quantity, string unitOfMeasure)
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

