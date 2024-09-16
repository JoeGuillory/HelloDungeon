using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloDungeon
{
    internal class Game
    {
        /// <summary>
        /// Player stats
        /// </summary>
        struct Player
        {
            public string name;
            public float health;
            public float mana;
            public int gold;
            public float armor;
            public float damage;
            public string role;
            public  Player(string name, float health, float mana, int gold, float armor, float damage, string role)
            {
             this.name = name;
             this.health = health;
             this.mana = mana;
             this.gold = gold;
             this.armor = armor;
             this.damage = damage;
             this.role = role;
                   
            }
        }
        /// <summary>
        /// Weapon blueprint
        /// </summary>
        struct Equipment
        {
            public string name;
            public int damage;
            public Equipment(string name,int damage)
            {
                this.name = name;
                this.damage = damage;
            }
        }

        /// <summary>
        /// Enemy bluprint
        /// </summary>
        struct Enemy
        {
            public string name;
            public float health;
            public float armor;
            public float damage;
            public Enemy(string name, float health, float armor, float damage)
            {
                this.name = name;
                this.health = health;
                this.armor = armor;
                this.damage = damage;
            }
        }
        public void Run()
        {
            // Weapons and armor
            Equipment spellBook1 = new Equipment("Apprentic Spellbook", 3);
            Equipment wand1 = new Equipment("Apprentice Wand", 3);
            Equipment wand2 = new Equipment("Wand", 3);
            Equipment shortStaff1 = new Equipment("Shortstaff", 9);
            Equipment staff = new Equipment("Staff", 12);
            Equipment dagger = new Equipment("Dagger", 8);
            Equipment sword = new Equipment("Sword", 12);
            Equipment greatSword = new Equipment("Greatsword", 16);
            Equipment robe1 = new Equipment("Apprentice Robe", 4);
            Equipment helmet = new Equipment("Helmet", 6);
            //Enemies Weakest to Strongest
            Enemy goblin = new Enemy("Goblin", 15, 3, 7);
            Enemy imp = new Enemy("Imp", 25, 3, 9);
            Enemy orc = new Enemy("Orc", 40, 6, 12);

            //Player
            Player player1 = new Player("Scarletta", 50, 5, 3, 5, 5, "");
            // Array of Enemies Weakest[0]
            Enemy[] enemies = new Enemy[3];
            enemies[0] = goblin;
            enemies[1] = imp;
            enemies[2] = orc;



            Console.WriteLine("Hello, " + player1.name);
            Console.WriteLine("Welcome to my dungeon!");
            Console.WriteLine();
            Console.WriteLine("Health: " + player1.health);
            Console.WriteLine("Mana: " + player1.mana);
            Console.WriteLine("Armor: " + player1.armor);
            Console.WriteLine("Damage: " + player1.damage);
            Console.WriteLine("Gold: " + player1.gold);
            Console.WriteLine();

            int input = GetInput("Are you a warrior or a wizard?", "Warrior", "Wizard");


            if (input == 1)
            {
                player1.role = "Warrior";
                player1.health += 20;
                player1.mana -= 2;
                player1.armor += 5;
                player1.damage += 2;
            }
            else if (input == 2)
            {
                player1.role = "Wizard";
                player1.health -= 10;
                player1.mana += 5;
                player1.armor -= 2;
                player1.damage += 6;
            }

            if (player1.role == "Wizard")
            {
                Console.WriteLine("Here are your new stats");
                Console.WriteLine();
                Console.WriteLine("Player Role: " + player1.role);
                Console.WriteLine("Health: " + player1.health);
                Console.WriteLine("Armor: " + player1.armor);
                Console.WriteLine("Damage: " + player1.damage);
                Console.WriteLine("Mana: " + player1.mana);
                Console.WriteLine("Gold: " + player1.gold);
                Console.WriteLine();

            }
            else if (player1.role == "Warrior")
            {
                Console.WriteLine("Here are your new stats");
                Console.WriteLine();
                Console.WriteLine("Player Role: " + player1.role);
                Console.WriteLine("Health: " + player1.health);
                Console.WriteLine("Armor: " + player1.armor);
                Console.WriteLine("Damage: " + player1.damage);
                Console.WriteLine("Mana: " + player1.mana);
                Console.WriteLine("Gold: " + player1.gold);
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.WriteLine("As you walk through you are faced with your first battle");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("A goblin has appeared");
            //First encounter

            Console.ReadKey();
            Battleloop(ref player1, enemies[1]);
            Displaystats(player1);

            //Path choice
            input = GetInput("Which path would you like to take", "1. Path one ", "2. Path two");
            if (input == 1)
            {
                Path1(ref player1, enemies[0], enemies[0], enemies[2], robe1);
            }
            else if (input == 2)
            {
                Path1(ref player1, enemies[0], enemies[0], enemies[2], robe1);

            }
            Console.ReadKey();
            Console.Clear();
            
            //Iteam Choice
            
            Console.WriteLine(player1.name + ", you have defeated your first enemy. Congrats. You deserve a reward.");
            // checks if player is a wizard or warrior
            if (player1.role == "Wizard")
            {
                input = GetInput("Choose your reward", wand1.name, spellBook1.name);

                if (input == 1)
                {
                player1.damage += wand1.damage;
                }
                else if (input == 2)
                {

                player1.damage += spellBook1.damage;
                }

            }
            else if (player1.role == "Warrior")
            {
                input = GetInput("Choose your reward", sword.name, dagger.name);
                if (input == 1)
                {
                    player1.damage += sword.damage;

                }
                else if (input == 2)
                {
                    player1.damage += dagger.damage;
                }



            }

            Console.Clear();
            Console.WriteLine("Here is your new stats");
            Displaystats(player1);
           

        }
        /// <summary>
        /// Get a 2 option choice from Player
        /// </summary>
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
        
        /// <summary>
        /// Get a 3 option choice from player
        /// </summary>
        int GetInput(string description, string option1, string option2, string option3)
        {
            string input = "";
            int inputRecieved = 0;
            // Input loop
            while (inputRecieved != 1 && inputRecieved != 2 && inputRecieved !=3)
            {
                // Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
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
                else if (input == "3" || input == option3)
                {
                    inputRecieved = 3;
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

        /// <summary>
        /// Request if the player wants to try again
        /// </summary>

        int Deathrequest()
        {
            int request;
            request = GetInput("Would you like to try again", "Yes", "Yes");

            if (request == 1)
            {
                Console.Clear();
                Run();
            }
            else if (request == 2)
            {
                Console.Clear();
                Run();
            }
            return request;
        }
        /// <summary>
        /// Battlesystem that will allow you to fight a monster
        /// </summary>
        /// <returns></returns>
         Player Battleloop(ref Player player, Enemy monster)
        {
            
            int input;
            int defend = 5;
            int heal = 20;
            float maxhealth = player.health;


            while (monster.health != 0)
            {
                Displaystats(player);
                Displaystats(monster);
                Console.WriteLine();

                /// Calculated player damage
                float playerdamage = player.damage - monster.armor;
                ///Calculated monster damage
                float monsterdamage = monster.damage - player.armor;

                input = GetInput("Select", "Attack", "Defend", "Heal");

                if (input == 1)
                {
                    monster.health -= playerdamage;
                    if (monster.health <= 0)
                    {
                        monster.health = 0;
                    }
                    if (monsterdamage <= 0)
                    {
                        monsterdamage = 0;
                    }
                    player.health -= monsterdamage;

                }
                else if (input == 2)
                {

                    float damage = monsterdamage - defend;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    player.health -= damage;



                }
                else if (input == 3)
                {
                    player.health -= monsterdamage;

                    if ((player.health + heal) <= player.health)
                    {

                        player.health = maxhealth;



                    }
                    else if ((player.health + heal) >= player.health)
                    {

                        player.health += heal;
                    }

                }

                if (player.health <= 0)
                {
                    player.health = 0;
                }


                if (player.health == 0)
                {
                    Deathrequest();
                }


            } 
                 return player;

        }
        /// <summary>
        /// Displays Player stats
        /// </summary>
        void Displaystats(Player player1)
        {
            
            
            Console.WriteLine();
            Console.WriteLine("Health: " + player1.health);
            Console.WriteLine("Armor: " + player1.armor);
            Console.WriteLine("Mana: " + player1.mana);
            Console.WriteLine("Gold: " + player1.gold);
            Console.WriteLine("Player Role: " + player1.role);
            Console.WriteLine("Damage: " + player1.damage);



            return;
        }
        /// <summary>
        /// Displays Monsters stats
        /// </summary>
        int Displaystats(Enemy monster)
        {

            int nothing = 0;
            Console.WriteLine();
            Console.WriteLine(monster.name);
            Console.WriteLine("Health: " + monster.health);
            Console.WriteLine("Armor: " + monster.armor);
            Console.WriteLine("Damage: " + monster.damage);



            return nothing;
        }
        void Path1(ref Player player, Enemy enemy1 ,Enemy enemy2 ,Enemy enemy3, Equipment iteam)
        {
            /// fight two goblins
            /// get two pieces of loot
            /// strong orc at the end
            Console.WriteLine("As you walk down the path you stumble across and iteam");
            Console.WriteLine("You find " + iteam.name);
            player.armor += iteam.damage;
            Displaystats(player);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("As you continue you run into a foe");

            Battleloop(ref player, enemy1);

            int input = GetInput("Would you like to rest or upgrade", "1. Rest", "2. Upgade");
            if(input == 1)
            {
                player.health += 20;

            }
            else if(input == 2)
            {
                player.damage += 5;

            }
            Displaystats(player);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Another foe appears");
            Battleloop(ref player, enemy2);

            Displaystats(player);

            Console.WriteLine("As you continue you spot the final foe. Can you defeat it?");
            Battleloop(ref player, enemy3);






















        }



    }
}
