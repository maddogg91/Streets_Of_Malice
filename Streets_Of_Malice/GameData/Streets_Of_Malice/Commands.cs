using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string[] commandList = { "n", "north", "s", "south", "e", "east","west", "w", "room", "rooms", "weapon","weapons" , "potion", "potions" };
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

        //public static void UserMap(int roomid, string input)
        //{
        //        switch (input)
        //        {
        //            case "n":
        //            case "north":
        //                Console.WriteLine("You walk north\n");
        //                input = "n";


        //                break;
        //            case "s":
        //            case "south":
        //                Console.WriteLine("You walk south\n");
        //                input = "s";

        //                break;

        //            case "w":
        //            case "west":
        //                Console.WriteLine("You walk west\n");
        //                input = "w";

        //                break;

        //            case "e":
        //            case "east":
        //                Console.WriteLine("You walk east\n");
        //                input = "e";

        //                break;

                  
        //            default:
                       
        //                ControlMap(roomid, input);
        //                break;




        //        }

        //        roomid = Map.UserMove(roomid, input);



            



        //}
       

        

        public static void ControlMap(int roomid)
        {
            string[] Rooms = Options.SetRooms();
            switch (roomid)
            {
                //Descriptions will be added for further user functionality in a later build, for now code is commented out.
                case 0:
                    //Console.WriteLine("\nDark room. \nYou can smell an aura of hardwork and poor hygeine practices...");
                    ViewRoom(Rooms[4]);

                    break;

                case 1:
                    //Console.WriteLine("\nYour apartment. \nIt's pretty dirty in here, you should probably clean once in a while.");

                    ViewRoom(Rooms[0]);
                    break;

                case 2:
                    //Console.WriteLine("\nMain street. \nLook around and take a good gander. This place could be something much better but right now the streets are full of violence and malice.");
                    ViewRoom(Rooms[1]);
                    break;

                case 3:
                    //Console.WriteLine("\nStore front. \nA famous vendor on main street. It used to be the talk of the town, but now thieves and thugs fill the stores.");
                    ViewRoom(Rooms[2]);

                    break;

                case 4:
                    //Console.WriteLine("\nTunnel. \nDeep down in the underground, these tunnels connect basically everywhere. Though conveinent, it's one of the most dangerous places in the city.");
                    ViewRoom(Rooms[3]);
                    break;

                case 5:
                    //Console.WriteLine("\nMayor's Office. \nSome bad stuff is happening within these rooms... the source of the malice.");
                    ViewRoom(Rooms[5]);
                    break;


            }
        }
        

        //For now I have two ViewAll methods that views the requested input such as rooms or weapons. If allowed, all arrays will become lists and the first ViewAll will be deleted.
        public static void ViewAll(int roomid,  string[] data)
        
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
                    List<string> weaponsList = Options.SetWeapons();
                    weaponsList.Sort();
                    Standard_Messages.DisplayThis("weapons");
                    ViewAll(roomid, weaponsList);
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

        static void ViewRoom(string room)
        {
            Console.WriteLine(room.ToUpper());
        }


    }
}
