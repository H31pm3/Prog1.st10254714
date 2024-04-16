using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1.st10254714
{
    class stuff : recipe
    {
        public static void recipeScale(string quantity)
        {
            double nummb;
            if (double.TryParse(quantity, out nummb))
            {
                Console.WriteLine("what would you like to scale the recipe to? half, double or triple?");
                string scaleChoice = Console.ReadLine();

                switch (scaleChoice.ToLower())
                {
                    case "half":
                        nummb *= 0.5;
                        break;

                    case "double":
                        nummb *= 2;
                        break;

                    case "triple":
                        nummb *= 3;
                        break;



                }
                Console.WriteLine($"Scaled quantity: {nummb}");
            }
        }

    }
}
