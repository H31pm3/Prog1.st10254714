using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// Caleb Searle
//ST10254714
//Bcad2 group 2
/*//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
                                                                References:
Anthropic, 2024. Claude. [Online]
Available at: https://claude.ai
[accessed 28 May 2024].

Phind, 2024. Phind. [Online]
Available at: https://phind.com/
[accessed 28 May 2024].

Refsnes Data, 1999. W3schools. [Online]
Available at: https://www.w3schools.com/
[accessed 28 May 2024].

 https://sweetlife.org.za/what-are-the-different-food-groups-a-simple-explanation/ 
[accessed on 28 May 2024]
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/

namespace Prog1.st10254714
{
    public class recipe //Main class containing all of the methods
    {
        static List<recipe> recipes = new List<recipe>();
        public List<string> ingredient { get; set; } = new List<string>();
        public List<string> originalIngredients { get; set; } = new List<string>();
        public List<string> steps { get; set; } = new List<string>();

       static List<string> validFoodGroups = new List<string> { "starch", "vegetables","fruits", "beans", "meat", "dairy", "fats", "water" };
        public string recipeName { get; set; }
        public double calouriesPerIngredient { get; set; }
        //initiliazing lists
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void intro()// the faux main method that stores all of the important parts of the code including the user menu
        {
            bool continueProgram = true;
            
            recipe currentRecipe = null;



            while (continueProgram) //whileloop with the main switch case
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("**************************************************");
                Console.WriteLine("");

                Console.WriteLine("enter in 1 to create a new recipe");
                Console.WriteLine("enter in 2 to display all recipes");
                Console.WriteLine("enter in 3 to display specific recipe");
                Console.WriteLine("enter in 4 to scale recipe");
                Console.WriteLine("enter in 5 to clear recipes");
                Console.WriteLine("enter in 6 to exit program");
                int userInput;
                bool selectNumber;
                selectNumber = int.TryParse(Console.ReadLine(), out userInput);

                switch (userInput) //switch case
                {
                    case 1: //creates a new recipe

                        currentRecipe = new recipe();
                        recipeDetails(currentRecipe);
                        recipes.Add(currentRecipe);
                        break;

                    case 2: //displays created recipes if there are any
                        Console.WriteLine("displaying recipes");
                        displayListOfRecipes();

                        break;
                    case 3: //displays a specific recipe that the user specifies
                        displaySpecificRecipe();



                        break;
                    case 4: //opens the scaling sub menu
                        if (currentRecipe != null)
                        {
                            recipeScale(currentRecipe);
                        }
                        else
                        {
                            Console.WriteLine("No recipe has been created yet.");
                        }

                        break;
                    case 5: //clears all created recipes from program
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
                    case 6: //closes program
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);

                        break;
                }


            }

        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public void clearRecipes() //simple function to clear stored recipes
        {
            //List<recipe> tempRecipe = recipes.ToList();
            foreach (var recipe in recipes)
            {
                recipe.ingredient.Clear();
                recipe.steps.Clear();
                
            }
            recipes.Clear();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public enum foodGroup
        {
            Starch,
            Vegetables,
            Fruits,
            Beans,
            Meat,
            Dairy,
            Fats,
            Water


        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public void newIngredients(string name, string quantity, string unitOfMeasure, double calories, string group) //intialise ingredients list
        {
            string lowerCaseGrp = group.ToLower();
            if (!validFoodGroups.Contains(lowerCaseGrp))
            {
                Console.WriteLine("Invalid food group entered. Please enter a valid food group.");
                return; // Exit the method if the group is invalid
            }

            ingredient.Add($"{quantity},{unitOfMeasure}, of {name}, contains {calories} cal and belongs to the group {group}");
            //ingredient.Add($"{quantity} ,{unitOfMeasure}, of {name}, contains {calories} cal and belongs tothe group {group}");
            originalIngredients.Add($"{name}|{calories}|{lowerCaseGrp}");
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public void addStep(string nam, string description) //initiliaze steps list
        {
            steps.Add($"{nam}: {description}");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void recipeDetails(recipe newRecipe) //method to create and store a new recipe including ingredients and steps
        {
            Console.WriteLine("create new recipe");
            string name;
            string recipeName;
            string quantity;
            string unitOfMes;
            string numOfIngred;
            string numOfSteps;
           
            Console.WriteLine("Please enter in your details for your recipe");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Please enter in the name of the recipe");
            recipeName = Console.ReadLine();
            newRecipe.recipeName = recipeName;
            Console.WriteLine("how many ingredients in the recipe?:");
            numOfIngred = Console.ReadLine();
            Console.WriteLine("add an ingredient? Y or N");
            string opt = Console.ReadLine();


            while (opt.ToLower() == "y") //while loop detailing the creating of a recipe
            {
                
                Console.WriteLine("enter name of ingredient:");
                name = Console.ReadLine();
                Console.WriteLine("enter quantity of the ingredient:");
                quantity = Console.ReadLine();
                Console.WriteLine("enter the unit of measurement of the ingredient:");
                unitOfMes = Console.ReadLine();
                Console.WriteLine("enter the amount of calories of the ingredient:");
                double cal = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("enter the food group(Starch,Vegetables,Fruits,Beans,Meat,Dairy,Fats,Water):");
                string group = Console.ReadLine().ToLower();
               




                newRecipe.originalIngredients.Add($"{quantity} ,{unitOfMes}, of {name}, contains {cal} cal and belongs to the group {group}");



               
                newRecipe.newIngredients(name, quantity, unitOfMes, cal,group);

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
            Console.WriteLine("enter number of steps:");
            numOfSteps = Console.ReadLine();
            Console.WriteLine("add a step? Y or N");
            string choice = Console.ReadLine();

            while (choice.ToLower() == "y") // while loop for the steps sub menu
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
                    case "half": //scales recipe by half
                        nummb = 0.5;
                        validInput = true;
                        break;
                    case "double": //scales recipe by x2
                        nummb = 2;
                        validInput = true;
                        break;
                    case "triple": //scales recipe by x3
                        nummb = 3;
                        validInput = true;
                        break;
                    case "revert": //reverts recipe back to original amount

                        recipeToScale.revertScaling();
                        int index = recipes.IndexOf(recipeToScale);
                        if (index >= 0)
                        {
                            recipes[index] = recipeToScale;
                        }
                        Console.WriteLine("recipe scaling has been reverted");

                        validInput = true;
                        break;
                    default: //default value if wrong input or nothing is entered
                        Console.WriteLine("Invalid scaling choice.");
                        return;
                }
            }


            for (int i = 0; i < recipeToScale.ingredient.Count; i++) // for loop for the scaling and reverting features
            {
                string[] parts = recipeToScale.ingredient[i].Split(',');
                double originalAmount = double.Parse(parts[0].Trim());
                double newQuantity = originalAmount * nummb;
                recipeToScale.ingredient[i] = ($"{newQuantity.ToString()}, {parts[1].Trim()}, {parts[2].Trim()}");
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
        public double GettotalCalories() //method for calculating the total calories of recipe
        {
            double totalCalories = 0;
            foreach (var originalIngredient in originalIngredients)
            {
                string[] parts = originalIngredient.Split('|');
                if (parts.Length == 3)
                {
                    double calories = double.Parse(parts[1]);
                    totalCalories += calories;
                }
                else
                {
                    
                }
            }
            return totalCalories;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        public static void displayListOfRecipes() //method to display the details of recipes entered by the user 
        {
            recipes.Sort((x,y) => string.Compare(x.recipeName, y.recipeName));
            Console.WriteLine("All recipes:");
            Console.WriteLine("*******************************************************************");
            foreach (var recipe in recipes) // foreach that dsplays each recipe inside the recipes list
            {
                Console.WriteLine("Recipe details:");
                Console.WriteLine("Name:"+ recipe.recipeName);

                Console.WriteLine("ingredients:");
                foreach (var ingredient in recipe.ingredient)
                {
                    Console.WriteLine(ingredient);
                    var originalIngredient = recipe.originalIngredients.FirstOrDefault(i => i.StartsWith(ingredient.Split(',')[2].Trim()));
                    if (!string.IsNullOrEmpty(originalIngredient))
                    {
                        string[] parts = originalIngredient.Split('|');
                        string name = parts[0];
                        double calories = double.Parse(parts[1]);
                        string group = parts[2];
                        Console.WriteLine($"Calories: {calories}, Food Group: {group}");
                    }
                }

                Console.WriteLine("Steps:");
                foreach (var step in recipe.steps)
                {
                    Console.WriteLine(step);
                }
                double totalCalories = recipe.GettotalCalories();
                Console.WriteLine($"Total Amount of Calories: {totalCalories}");

                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: Total calories exceeds 300!");
                }

                Console.WriteLine("*******************************************************************");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        private static void displaySpecificRecipe() // displays a recipe as specified by the user using the recipes name
        {
            Console.WriteLine("Please search for a recipe by name");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.recipeName == recipeName);
            if (recipe!= null)
            {
                Console.WriteLine("Showing Recipe:"+recipe.recipeName);
                displayDetailsForRecipe(recipe);
            }
            else
            {
                Console.WriteLine("No recipe found with this name. Please check your spelling and try again");
            }

        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        private static void displayDetailsForRecipe(recipe recipe)
        {
            Console.WriteLine("Recipe Details:");
            Console.WriteLine("****************************************");
            Console.WriteLine("Name:" + recipe.recipeName);
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.ingredient)
            {
                Console.WriteLine(ingredient);
                var originalIngredient = recipe.originalIngredients.FirstOrDefault(i => i.StartsWith(ingredient.Split(',')[2].Trim()));
                if (!string.IsNullOrEmpty(originalIngredient))
                {
                    string[] parts = originalIngredient.Split('|');
                    string name = parts[0];
                    double calories = double.Parse(parts[1]);
                    string group = parts[2];
                    Console.WriteLine($"Calories: {calories}, Food Group: {group}");
                }
            }
            Console.WriteLine("Steps:");
            foreach (var step in recipe.steps)
            {
                Console.WriteLine(step);
            }
            double totalCalories = recipe.GettotalCalories();
            Console.WriteLine($"Total Amount of Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceeds 300!");
            }
        }
    }
}

