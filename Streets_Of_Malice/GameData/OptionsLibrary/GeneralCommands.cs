using System;
using System.Collections.Generic;
using System.Text;
using CharacterLibrary;
using ItemLibrary;
using System.Linq;

namespace OptionsLibrary
{
    class GeneralCommands
    {
        public static void ControlMap(string function, string obj, GameObjects options)
        {


            switch (function)
            {
                //Displays a list of rooms
                case "room":
                case "rooms":
                    StandardMessages.DisplayThis("rooms");
                    SearchCommands.ViewAll(options.Rooms);
                    break;

                //Displays a list of weapons

                case "look":
                    SearchCommands.LookObject(obj, options);
                    break;

                case "fight":
                case "attack":
                    CombatCommands.StartCombat(options, obj);
                    break;


                case "weapon":
                case "weapons":


                    //Standard_Messages.DisplayThis("weapons");
                    //ViewAll(roomid, weaponsList);
                    options.Weapons.OrderBy(x => x.Name);
                    foreach (Weapons weapon in options.Weapons)
                    {
                        Console.WriteLine(weapon.Name + " (" + weapon.Damage + " " + weapon.Description + ")\n");
                    }

                    break;

                case "potion":
                case "potions":

                    StandardMessages.DisplayThis("potions");
                    SearchCommands.ViewAll(options.Potions);

                    break;

                default:


                    break;


            }
          



        }

        public static void CommandInput(GameObjects options)
        {
            options.Mobs = MovementCommands.MobMovement(options);
            string[] commands = { };
            bool run = true;
            do
            {
                
                string input = GetCommand();
                
                commands = input.Split(' ');
                string text = commands[0];
                if (commands.Length == 0)
                {
                    Console.WriteLine("Your command is invalid");
                }

                else
                {

                    if (IsValidCommand(commands[0]))
                    {

                        run = false;

                        if (IsMovement(commands[0]))
                        {
                            MovementCommands.UserMove(commands[0],options.Player, options.Rooms);
                        }


                        //Simplify code here to fix Multiple If/Else statements.
                        else
                        {
                            if (commands.Length == 1)
                            {
                                ControlMap(commands[0], "", options);
                            }

                            else
                            {
                                int i = 0;
                                List<string> objects = new List<string>();
                                string word = "";
                                StringBuilder builder = new StringBuilder();
                                foreach (string command in commands)
                                {
                                    
                                    if(i!=0 && i < commands.Length)
                                    {
                                        word = word + command + " ";
                                        
                                    }
                                    if(i== commands.Length)
                                    {
                                        word = word + command;
                                    }
                                    i++;
                                }

                              
                                
                                ControlMap(commands[0], word, options);
                            }

                        }
                    }

                    else
                    {
                        Console.WriteLine("\nInvalid entry!\n\n\n\n\n");
                    }

                }
                CommandInput(options);
            }
            while (run == true);
            
        }

       

        public static bool IsValidCommand(string command)
        {
            bool check = false;
            string[] commandList = { "n", "north", "s", "south", "e", "east", "west", "w", "room", "rooms", "weapon", "weapons", "potion", "potions", "look", "attack", "fight" };
            if (commandList.Contains(command))
            {
                check = true;
            }


            return check;
        }

        public static bool IsMovement(string command)
        {
            bool check = false;
            string[] commandList = { "n", "north", "s", "south", "e", "east", "west", "w" };
            if (commandList.Contains(command))
            {
                check = true;
            }


            return check;
        }


        public static string GetCommand()
        {
            Console.Write("\n>");

            string input = Console.ReadLine();
            return input.ToLower();
        }

    }
}

