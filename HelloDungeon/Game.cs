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
            float playerMagicDamage = 5.0f;
            float playerMeleeDamage = 5.0f;
            string playerRole = "Warrior";
            bool goblinEncounter = false;
            bool isDead = false;
            
          
            Console.WriteLine("Hello, " + playerName);
            Console.WriteLine("Welcome to my dungeon!");
            Console.WriteLine();
            Console.WriteLine("Health: " + playerHealth);
            Console.WriteLine("Armor: " + playerArmor);
            Console.WriteLine("Mana: " + playerMana);
            Console.WriteLine("Gold: " + playerGold);
            
            int input = GetInput("Are you a warrior or a wizard?", "Warrior", "Wizard");
            
            
            if (input == 1)
            {
                    playerRole = "Warrior";
                    playerHealth += 3; 
                    playerMana -= 2;
                    playerArmor += 5;
                    playerMagicDamage -= 4;
            }
            else if (input == 2)
            {
                    playerRole = "Wizard";
                    playerHealth -= 3;
                    playerMana += 5;
                    playerArmor -= 2;
                    playerMeleeDamage -= 4;
            }

            if (playerRole == "Wizard")
            {
                Console.WriteLine("Here are your new stats");
                Console.WriteLine();
                Console.WriteLine("Health: " + playerHealth);
                Console.WriteLine("Armor: " + playerArmor);
                Console.WriteLine("Mana: " + playerMana);
                Console.WriteLine("Gold: " + playerGold);
                Console.WriteLine("Player Role: " + playerRole);
                Console.WriteLine("Magic damage: " + playerMagicDamage);
                Console.WriteLine("Melee damage:" + playerMeleeDamage);
                Console.WriteLine();
                Console.WriteLine("Oh one more thing i forgot to tell you. It is not that important but you do not have a weapon.");
                Console.WriteLine("You must have been an apprentice");
                Console.WriteLine("I believe you will make it out alive. *Cough* *Cough*");

            }
            else if (playerRole == "Warrior")
            {
                Console.WriteLine("Here are your new stats");
                Console.WriteLine();
                Console.WriteLine("Health: " + playerHealth);
                Console.WriteLine("Armor: " + playerArmor);
                Console.WriteLine("Mana: " + playerMana);
                Console.WriteLine("Gold: " + playerGold);
                Console.WriteLine("Player Role: " + playerRole);
                Console.WriteLine("Magic damage: " + playerMagicDamage);
                Console.WriteLine("Melee damage:" + playerMeleeDamage);
                Console.WriteLine();
                Console.WriteLine("Oh one more thing i forgot to tell you. It is not that important but you do not have a weapon."); 
                Console.WriteLine("You must have been an apprentice");
                Console.WriteLine("I believe you will make it out alive. *Cough* *Cough*");
            }
            Console.WriteLine();
            
           

            // Wizard Path
            if(playerRole == "Wizard")
            {

                // First Option

                GetInput("As you enter the dungeon you run into your first option. There are two doors before you. Which do you choose.", "1 Left", "2 Right");
                    
                    

            if (input == 1)
                    {
                        Console.WriteLine("You find a old wooden staff. As you knock off the dust you feel stronger");
                        playerMagicDamage += 5;
                        Console.WriteLine();
                        Console.WriteLine("Magic damage: " + playerMagicDamage);
                        
            }
            else if (input == 2)
            {
                        Console.WriteLine("How unlucky. You find yourself faced with a goblin. Do you coward in fear or fight it head on.");
                        Console.WriteLine(" 1 Coward like a baby | 2 Fight it head on ");
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
                     Console.WriteLine("You hear the voice of the goblin grow more and more distance as it falls.");
                     Console.WriteLine("You survive the encounter");

                    }
                    else if (input == 2)
                    {
                     Console.WriteLine("You try your best to fight the goblin but you remembered that you have no weapons.");
                     Console.WriteLine();
                     Console.WriteLine("You are defeated");
                     isDead = true;
                    }

                }
              
                   
              
              
              
              
              
              
              
              
              
              
              // End of wizard Path
            }


            // Warrior Path
            else if (playerRole == "Warrior")
            {
                Console.WriteLine("As you enter the dungeon you run into your first option. There are two doors before you. Which do you choose.");
                Console.WriteLine("1 | 2");
                

            }







        }
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
