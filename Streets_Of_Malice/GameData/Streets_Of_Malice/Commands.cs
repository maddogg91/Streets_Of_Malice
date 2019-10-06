using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemLibrary;

namespace Streets_Of_Malice
{
    public class Commands
    {

        public static void CommandInput(int roomid)
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
                            Map.UserMove(roomid, commands[0]);
                        }


                        //Simplify code here to fix Multiple If/Else statements.
                        else
                        {
                            if (commands.Length < 2)
                            {
                                ControlMap(roomid, commands[0], "");
                            }

                            else
                            {
                                ControlMap(roomid, commands[0], commands[1]);
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






        //For now I have two ViewAll methods that views the requested input such as rooms or weapons. If allowed, all arrays will become lists and the first ViewAll will be deleted.
        public static void ViewAll(int roomid, string[] data)

        {

            foreach (string element in data)
            {
                Standard_Messages.DisplayAll(element);


            }


            CommandInput(roomid);

        }

        public static void ViewAll(int roomid, List<string> data)
        {
            foreach (string element in data)
            {
                Standard_Messages.DisplayAll(element);


            }


            CommandInput(roomid);
        }
        public static void ControlMap(int roomid, string function, string obj)
        {


            switch (function)
            {
                //Displays a list of rooms
                case "room":
                case "rooms":
                    Standard_Messages.DisplayThis("rooms");
                    ViewAll(roomid, Options.SetRooms());
                    break;

                //Displays a list of weapons


                case "weapon":
                case "weapons":
                    List<Weapons> weaponsList = Options.LoadWeapons();
                    //weaponsList.Sort();
                    //Standard_Messages.DisplayThis("weapons");
                    //ViewAll(roomid, weaponsList);
                    
                    foreach (Weapons weapon in weaponsList)
                    {
                        Console.WriteLine(weapon.WeaponName + " (" + weapon.Damage + " " + weapon.Description + ")\n");
                    }
                    
                    break;

                case "potion":
                case "potions":

                    Standard_Messages.DisplayThis("potions");
                    ViewAll(roomid, Options.SetPotions());

                    break;

                default:


                    break;


            }
            CommandInput(roomid);



        }

        public static void ViewRoom(string room)
        {
            Console.WriteLine("Current Location: " + room.ToUpper());
        }


    }
}
