using System;
using System.Collections.Generic;
using System.Text;

namespace FindTheKitties
{
    class Kitty
    {
        private string name;
        private bool hiding;
        private bool wantsPet;
        private bool picky;
        private int hunger;
        private int age;
        private FoodBowl bowl;
        private bool meowed;
        private static Random random = new Random();

        public Kitty(string name, bool hiding, bool wantsPet, bool picky, int hunger, int age, FoodBowl bowl)
        {
            this.name = name;
            this.hiding = hiding;
            this.wantsPet = wantsPet;
            this.picky = picky;
            this.hunger = hunger;
            this.age = age;
            meowed = false;
        }

        //Pet the kitty until it no longer needs petting
        public void PetKitty()
        {
            if (wantsPet)
            {
                Console.WriteLine(name + " purrs!");
                PetKitty();
                wantsPet = false;
            }
            else
            {
                Meow();
            }
        }

        //Gets the kitty out of hiding
        public void GetKittyOutOfHiding()
        {
            int numberOfTreats = 0;
            do
            {
                Console.WriteLine(name + " is hiding, how many treats do you want to give them?");
                numberOfTreats = int.Parse(Console.ReadLine());
                CoaxKitty(numberOfTreats);
            } while (hiding);
            Meow();
        }

        //Should get the kitty out of hiding if you give them 4 or more treats.
        public bool CoaxKitty(int numTreats)
        {
            if (hiding)
            {
                if (numTreats > 3)
                {
                    Console.WriteLine(name + " comes out of hiding!");
                    return false;
                }
                else
                {
                    Console.WriteLine(name + " is still hiding!");
                    return true;
                }
            }
            return false;
        }

        //Should feed the kitty until hunger is less than 0
        public void FeedKitty()
        {

            Console.WriteLine("You go to feed " + name + ".");
            while (hunger > 0)
            {
                hunger -= bowl.Eat(random.Next(1, 6), picky, name);
            }
            Console.WriteLine(name + " is now full.");
            Meow();
        }

        //The kitty meows, indicating success.
        public void Meow()
        {
            Console.WriteLine(name + " meows!");
            meowed = true;
        }

        public bool Meowed
        {
            get
            {
                return meowed;
            }
        }
    }
}
