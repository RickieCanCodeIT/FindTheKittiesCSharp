using System;
using System.Collections.Generic;
using System.Text;

namespace FindTheKitties
{
    class FoodBowl
    {
        private int foodQuantity;
        private bool isOldFood;

        public FoodBowl(int foodQuantity, bool isOldFood)
        {
            this.foodQuantity = foodQuantity;
            this.isOldFood = isOldFood;
        }

        //The kitty eats if the conditions are right, returns the amount of food eaten.
        public int Eat(int amount, bool picky, String name)
        {
            if (isOldFood && picky)
            {
                Console.WriteLine("Do you expect " + name + " to eat old food? Replace it!");
                foodQuantity += 20;
                return 0;
            }
            else if (foodQuantity > 0)
            {
                Console.WriteLine(name + " eats their food.");
                if (foodQuantity < amount)
                {
                    amount = foodQuantity;
                }
                foodQuantity -= amount;
                isOldFood = true;
                return amount;
            }
            else
            {
                Console.WriteLine("The bowl is empty, refilling.");
                RefreshFood(20);
                return 0;
            }
        }

        //Add food to the bowl, making it not old food.
        public void RefreshFood(int amount)
        {
            Console.WriteLine("You add food to the bowl.");
            foodQuantity += amount;
            isOldFood = false;
        }
    }
}
