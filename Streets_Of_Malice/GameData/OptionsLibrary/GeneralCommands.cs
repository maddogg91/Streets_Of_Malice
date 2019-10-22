using System;
using System.Collections.Generic;
using System.Text;
using PlayerLibrary;
using ItemLibrary;
using MobLibrary;
using System.Linq;

namespace OptionsLibrary
{
    class GeneralCommands
    {
        public static void ControlMap(string function, string obj, Player player)
        {


            switch (function)
            {
                //Displays a list of rooms
                case "room":
                case "rooms":
                    StandardMessages.DisplayThis("rooms");
                    SearchCommands.ViewAll(LoadOptions.LoadRooms(), player);
                    break;

                //Displays a list of weapons


                case "weapon":
                case "weapons":
                    List<Weapons> weaponsList = LoadOptions.LoadWeapons();
                    weaponsList.Sort();
                    //Standard_Messages.DisplayThis("weapons");
                    //ViewAll(roomid, weaponsList);

                    foreach (Weapons weapon in weaponsList)
                    {
                        Console.WriteLine(weapon.WeaponName + " (" + weapon.Damage + " " + weapon.Description + ")\n");
                    }

                    break;

                case "potion":
                case "potions":

                    StandardMessages.DisplayThis("potions");
                    SearchCommands.ViewAll(LoadOptions.LoadPotions(), player);

                    break;

                default:


                    break;


            }
            CommandInput(player);



        }

        public static void CommandInput(Player player)
        {
            string[] commands = { };
            bool run = true;
            while (run == true)
            {
                string input = GetCommand();
                commands = input.Split(' ');

                if (commands.Length > 2)
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
                            MovementCommands.UserMove(commands[0], player);
                        }


                        //Simplify code here to fix Multiple If/Else statements.
                        else
                        {
                            if (commands.Length < 2)
                            {
                                ControlMap(commands[0], "", player);
                            }

                            else
                            {
                                ControlMap(commands[0], commands[1], player);
                            }

                        }
                    }

                    else
                    {
                        Console.WriteLine("\nInvalid entry!\n\n\n\n\n");
                    }

                }

            }


        }

        public static bool IsValidCommand(string command)
        {
            bool check = false;
            string[] commandList = { "n", "north", "s", "south", "e", "east", "west", "w", "room", "rooms", "weapon", "weapons", "potion", "potions" };
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

