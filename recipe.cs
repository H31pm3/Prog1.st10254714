using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prog1.st10254714
{
    public class recipe //Main class containing all of the methods
    {
        static List<recipe> recipes = new List<recipe>();
        public List<string> ingredient { get; set; } = new List<string>();
        public List<string> originalIngredients { get; set; } = new List<string>();
        public List<string> steps { get; set; } = new List<string>();
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void intro()// the faux main method that stores all of the important parts of the code including the user menu
        {
            bool continueProgram = true;
            //string quantity = null;
            recipe currentRecipe = null;



            while (continueProgram) //whileloop with all of the choices
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("**************************************************");
                Console.WriteLine("");

                Console.WriteLine("enter in 1 to create a new recipe");
                Console.WriteLine("enter in 2 to display created recipes");
                Console.WriteLine("enter in 3 to scale recipe");
                Console.WriteLine("enter in 4 to clear recipes");
                Console.WriteLine("enter in 5 to exit program");
                int userInput;
                bool selectNumber;
                selectNumber = int.TryParse(Console.ReadLine(), out userInput);

                switch (userInput)
                {
                    case 1:

                        currentRecipe = new recipe();
                        recipeDetails(currentRecipe);
                        recipes.Add(currentRecipe);
                        break;

                    case 2:
                        Console.WriteLine("displaying recipes");
                        displayListOfRecipes();

                        break;
                    case 3:
                        if (currentRecipe != null)
                        {
                            recipeScale(currentRecipe);
                        }
                        else
                        {
                            Console.WriteLine("No recipe has been created yet.");
                        }

                        break;
                    case 4:
                        if (currentRecipe != null)
                        {
                            currentRecipe.clearRecipes();
                            Console.WriteLine("recipe cleared succesfully!");
                        }
                        else
                        {
                            Console.WriteLine("No recipe exists to be cleared");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);

                        break;
                }


            }

        }
        public void clearRecipes() //simple function to clear stored recipes
        {
            ingredient.Clear();
            steps.Clear();

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public void newIngredients(string name, string quantity, string unitOfMeasure) //intialise ingredients list
        {
            ingredient.Add($"{quantity} ,{unitOfMeasure}, {name}");
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public void addStep(string nam, string description) //initiliaze steps list
        {
            steps.Add($"{nam}: {description}");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void recipeDetails(recipe newRecipe) //method to create and store a new recipe including ingredients and steps
        {
            Console.WriteLine("create new recipe (1) or scale existing recipe (2)");
            string name;
            string quantity;
            string unitOfMes;
            Console.WriteLine("Please enter in your details for your recipe");
            Console.WriteLine("**************************************************");
            Console.WriteLine("add an ingredient? Y or N");
            string opt = Console.ReadLine();


            while (opt.ToLower() == "y")
            {
                Console.WriteLine("enter name of ingredient:");
                name = Console.ReadLine();
                Console.WriteLine("enter quantity of the ingredient:");
                quantity = Console.ReadLine();
                Console.WriteLine("enter the unit of measurement of the ingredient:");
                unitOfMes = Console.ReadLine();
                newRecipe.originalIngredients.Add($"{quantity}, {unitOfMes},{name}");




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
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void recipeScale(recipe recipeToScale) // method to scale the recipe according to whatever factor the user chooses
        {

            Console.WriteLine("What would you like to scale the recipe to? (half, double, triple)? or type revert to revert any scaling.");
            string scaleChoice = Console.ReadLine();
            double nummb = 1;
            bool validInput = false;
            recipe currentRecipe = recipeToScale;
            while (!validInput)
            {
                switch (scaleChoice.ToLower())
                {
                    case "half":
                        nummb = 0.5;
                        validInput = true;
                        break;
                    case "double":
                        nummb = 2;
                        validInput = true;
                        break;
                    case "triple":
                        nummb = 3;
                        validInput = true;
                        break;
                    case "revert":

                        recipeToScale.revertScaling();
                        int index = recipes.IndexOf(recipeToScale);
                        if (index >= 0)
                        {
                            recipes[index] = recipeToScale;
                        }
                        Console.WriteLine("recipe scaling has been reverted");

                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid scaling choice.");
                        return;
                }
            }


            for (int i = 0; i < recipeToScale.ingredient.Count; i++)
            {
                string[] parts = recipeToScale.ingredient[i].Split(',');
                double originalAmount = double.Parse(parts[0].Trim());
                double newQuantity = originalAmount * nummb;
                //recipeToScale.ingredient[i] = $"{parts[0]},{newQuantity.ToString()}, {parts[2]}";
                recipeToScale.ingredient[i] = ($"{newQuantity.ToString()}, {parts[1].Trim()}, {parts[2].Trim()}");
               // recipeToScale.originalIngredients[i] = ($"{newQuantity.ToString()}, {parts[1].Trim()}, {parts[2].Trim()}");


            }

            Console.WriteLine("************************************************");
            Console.WriteLine($"Scaled recipe successfully.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void revertScaling() //method to revert the scaled values to their original ones
        {
            
            ingredient.Clear();

            
            foreach (var originalIng in originalIngredients)
            {
                ingredient.Add(originalIng);
            }

            
        }

        
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        public static void displayListOfRecipes() //method to display the details of recipes entered by the user 
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
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
    }
}

