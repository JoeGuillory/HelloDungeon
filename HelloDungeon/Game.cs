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
        struct Player
        {
            public string name;
            public float health;
            public float mana;
            public int gold;
            public float armor;
            public float magicDamage;
            public float meleeDamage;
            public string role;
            public  Player(string name, float health, float mana, int gold, float armor, float magicDamage, float meleeDamage, string role)
                    {
                     this.name = name;
                     this.health = health;
                     this.mana = mana;
                     this.gold = gold;
                     this.armor = armor;
                     this.magicDamage = magicDamage;
                     this.meleeDamage = meleeDamage;
                     this.role = role;
                   
                    }
        }
        public void Run()
        {
            Player player1 = new Player("Bob", 10, 5, 3, 5, 5, 5, "");
            
            bool goblinEncounter = false;
            bool isDead = false;
            
          
            Console.WriteLine("Hello, " + player1.name);
            Console.WriteLine("Welcome to my dungeon!");
            Console.WriteLine();
            Console.WriteLine("Health: " + player1.health);
            Console.WriteLine("Armor: " + player1.armor);
            Console.WriteLine("Mana: " + player1.mana);
            Console.WriteLine("Gold: " + player1.gold);
            
            int input = GetInput("Are you a warrior or a wizard?", "Warrior", "Wizard");
            
            
            if (input == 1)
            {
                    player1.role = "Warrior";
                    player1.health += 3; 
                    player1.mana -= 2;
                    player1.armor += 5;
                    player1.magicDamage -= 4;
            }
            else if (input == 2)
            {
                    player1.role = "Wizard";
                    player1.health -= 3;
                    player1.mana += 5;
                    player1.armor -= 2;
                    player1.meleeDamage -= 4;
            }

            if (player1.role == "Wizard")
            {
                Console.WriteLine("Here are your new stats");
                Console.WriteLine();
                Console.WriteLine("Health: " + player1.health);
                Console.WriteLine("Armor: " + player1.armor);
                Console.WriteLine("Mana: " + player1.mana);
                Console.WriteLine("Gold: " + player1.gold);
                Console.WriteLine("Player Role: " + player1.role);
                Console.WriteLine("Magic damage: " + player1.magicDamage);
                Console.WriteLine("Melee damage:" + player1.meleeDamage);
                Console.WriteLine();
                Console.WriteLine("Oh one more thing i forgot to tell you. It is not that important but you do not have a weapon.");
                Console.WriteLine("You must have been an apprentice");
                Console.WriteLine("I believe you will make it out alive. *Cough* *Cough*");

            }
            else if (player1.role == "Warrior")
            {
                Console.WriteLine("Here are your new stats");
                Console.WriteLine();
                Console.WriteLine("Health: " + player1.health);
                Console.WriteLine("Armor: " + player1.armor);
                Console.WriteLine("Mana: " + player1.mana);
                Console.WriteLine("Gold: " + player1.gold);
                Console.WriteLine("Player Role: " + player1.role);
                Console.WriteLine("Magic damage: " + player1.magicDamage);
                Console.WriteLine("Melee damage:" + player1.meleeDamage);
                Console.WriteLine();
                Console.WriteLine("Oh one more thing i forgot to tell you. It is not that important but you do not have a weapon."); 
                Console.WriteLine("You must have been an apprentice");
                Console.WriteLine("I believe you will make it out alive. *Cough* *Cough*");
            }
            Console.WriteLine();
            
           

            // Wizard Path
            if(player1.role == "Wizard")
            {

               input = GetInput("As you enter the dungeon you run into your first option. There are two doors before you. Which do you choose.", "1 Left", "2 Right");


                // First Option
                if (input == 1)
                {
                        Console.WriteLine("You find a old wooden staff. As you knock off the dust you feel stronger");
                        player1.magicDamage += 5;
                        Console.WriteLine();
                        Console.WriteLine("Magic damage: " + player1.magicDamage);
                        
                }
                else if (input == 2)
                {
                    
                    input = GetInput("How unlucky. You find yourself faced with a goblin. Do you coward in fear or fight it head on", "Coward in fear", "Fight is head on");
                    goblinEncounter = true;
                }
                
               
                //Door 1
                if (goblinEncounter == false)
                {
                Console.WriteLine();
                Console.WriteLine("You take a easy stroll to the next door");
                }
                //Door 2
                else if (goblinEncounter == true)
                {
                
                    if (input == 1)
                    {
                        Console.WriteLine("As you duck in fear the golbin jumps over you and falls into a unexpected cavern that reaches deeper into the cave.");
                        Console.WriteLine();
                        Console.WriteLine("You hear the voice of the goblin grow more and more distance as it falls.");
                        Console.WriteLine();
                        Console.WriteLine("You survive the encounter");

                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("You try your best to fight the goblin but you remembered that you have no weapons.");
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.WriteLine("You are defeated");
                        Console.ReadKey();
                        isDead = true;
                    }

                }
                // Player death choice
                if (isDead == true)
                {
                    input = GetInput("Would you like to try again", "Yes", "No");

                    if (input == 1)
                    {
                        Console.Clear();
                        Run();
                    }
                    else if (input == 2)
                    {
                       
                    }
                }
              

              // End of wizard Path
            }


            // Warrior Path
            else if (player1.role == "Warrior")
            {
                Console.WriteLine("As you enter the dungeon you run into your first option. There are two doors before you. Which do you choose.");
                Console.WriteLine("1 | 2");
                

            }







        }
        // Get the input from Player
        int GetInput(string description, string option1, string option2)
        {
            string input = "";
            int inputRecieved = 0;
            // Input loop
            while (inputRecieved != 1 && inputRecieved != 2)
            {
                // Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");

                // Get input for player
                input = Console.ReadLine();

                // If player selected the first option
                if (input == "1" || input == option1)
                {
                    // Set inputRecieved to be the first option
                    inputRecieved = 1;
                }
                // Otherwise if the player selects the second option
                else if (input == "2" || input == option2)
                {
                    inputRecieved = 2;
                }
                //If neither are true
                else
                {
                    // Display a error Message
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }
                
            }
            Console.Clear();
            return inputRecieved;


        }

       

    }
}
