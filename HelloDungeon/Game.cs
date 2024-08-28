using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    internal class Game
    {
        public void Run()
        {
            string playerName = "Boblius";
            float playerHealth = 10.0f;
            float playerMana = 5.0f;
            int playerGold = 3;
            float playerArmor = 5.0f;
            bool playerAlive = true;
           

            Console.WriteLine("Do you want enter the dungeon? 1 | 2");
            string input = Console.ReadLine();

            if (input == "1")
            {
              
                Console.WriteLine("Hello, " + playerName);
                Console.WriteLine("Welcome to my dungeon!");
                Console.WriteLine();
                Console.WriteLine("Alive? " + playerAlive);
                Console.WriteLine("Health: " + playerHealth);
                Console.WriteLine("Armor: " + playerArmor);
                Console.WriteLine("Mana: " + playerMana);
                Console.WriteLine("Gold: " + playerGold);
            }
            else
            {
                Console.WriteLine("As you leave you have a sense of shame hits you.");
                Console.WriteLine();
                Console.WriteLine("You Lose");
            }
            

          
            Console.WriteLine();

            Console.WriteLine("You find yourself in a generic dungeon with two doors. " + "Which door do you choose?");

          

        }
    }
}
