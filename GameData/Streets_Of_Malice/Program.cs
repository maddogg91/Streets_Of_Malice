using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streets_Of_Malice
{/**

* September 15th, 2019

* CSC 253

* Jesse Watts 
* 
* Robert Charity

* Streets of Malice (Sprint #1)
* 
* Streets of Malice is an urban inspired dungeon crawler. Currently the build tests motion north, south, east, and west. Also allows user to see list of all available rooms and weapons.

*/
    class Program
    {

        static void Main(string[] args)
        {

            StartGame();

        }


        //Start Menu without Standard Messages Classes
        //Place text in standard messages and call them to create cleaner code.
        static void StartGame()
        {
            Console.WriteLine("Welcome to Streets of Malice!\n\nType start to play the game\nType exit to exit the game");
            Console.Write("\n\n\n\n>");
            string input = Console.ReadLine();

            Selection(input.ToLower());
        }



        static void Selection(string input)
        {
            //Gonna put this in standard messages when it's created.
            string title = " .oooooo..o     .                                    .            \n" +
                "d8P'    `Y8   .o8                                  .o8            \n" +
                "Y88bo.      .o888oo oooo d8b  .ooooo.   .ooooo.  .o888oo  .oooo.o \n" +
                " `^Y8888o.    888   `888^^8P d88' `88b d88' `88b   888   d88(^8\n" +
                "     `^Y88b   888    888     888ooo888 888ooo888   888   `^Y88b.  \n" +
                "oo     .d8P   888 .  888     888    .o 888    .o   888 . o.  )88b \n" +
                "8^^88888P^    ^888^ d888b    `Y8bod8P' `Y8bod8P'   ^888^ 8^^888P^^ \n" +
                "";

            string title2 = 
                "\n\n            .o88o. \n" +
                "           888 `^ \n" +
                ".ooooo.  o888oo  \n" +
                "d88' `88b  888   \n " +
                "888   888 888\n" +
                "888   888  888\n" +
                "`Y8bod8P' o888o \n";

            string title3 =
                "\n\nooo        ooooo           oooo   o8o                     \n" +
                "`88.       .888'           `888   `^'\n" +
                " 888b     d'888   .oooo.    888  oooo   .ooooo.   .ooooo. \n" +
                " 8 Y88. .P  888  `P  )88b   888  `888  d88' `'Y8 d88' `88b\n" +
                " 8  `888'   888   .oP'888   888   888  888       888ooo888 \n" +
                " 8    Y     888  d8(  888   888   888  888   .o8 888    .o \n" +
                "o8o        o888o `Y888^^8o o888o o888o `Y8bod8P' `Y8bod8P' \n";
            switch (input)
            {
                case "start":
                    //Placeholder text
                    Console.WriteLine("Let's Play");

                    int roomid = SwitchRoom("your apartment");
                  
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n"+ title + title2 + title3 +  "\nPress Enter to continue");
                    Console.ReadLine();
                    Console.WriteLine("\n\n\n\n\n\n\n");
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nYou wake up in your dirty apartment... It's loud outside... sounds like the manics are out causing chaos on main street.");
                    ControlMap(roomid, "");

                    Console.ReadLine();
                    break;

                case "exit":
                    //Placeholder text
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid entry");
                    StartGame();
                    break;
            }
        }


        static void ControlMap(int roomid, string function)
        {
           
            string[] Rooms = { "Your apartment", "Main Street", "Store Front", "Tunnel", "Dimly lit room", "Mayor's Office" };
            //Weapon Array 
            string[] Weapons = { "Sword", "Mace", "Baton","Club", "Axe", "Dagger", "Brass Knuckles", "Pistol", "Knife", "Bat" };

            /*In Case List is more effective in the long run.
             * //Add weapons to the list.
            List<string> weaponsList = new List<string>();
            weaponsList.Add("Sword");
            weaponsList.Add("Mace");
            weaponsList.Add("Baton");
            weaponsList.Add("Dagger");
            weaponsList.Add("Club");
            weaponsList.Add("Knife");
            weaponsList.Add("Bat");
            weaponsList.Add("Axe");
            weaponsList.Add("Pistol");
            weaponsList.Add("Brass knuckles");
             *
             */

            string[] Potions = { "Milk", "Energy" };
            string[] Treasure = { "Gold Medal", "Silver Trophy", "Bronze Stamp"};
            List<string> Items = new List<string>() { "Store Front Key", "Golden Key", "Key to the City", "Smokebomb" };
            List<string> Mobs = new List<string>() { "Computer Programmers", "Main Street Manics", "Thieves", "Underground Gang", "Police" };

            switch (function)
            {
                //Displays a list of rooms
                case "room":
                    Console.WriteLine("\nHere are the list of rooms: ");
                    foreach (string element in Rooms)
                    {
                        Console.WriteLine(">>>>> " + element + "\n");

                    }
                    UserMap(roomid);
                    break;

                //Displays a list of weapons (Unsure if he means in the player's invetory or available in general). I just added generic data here until we can work the code in.
                //Refactored List into Array as per instructions. List will remain in game data as backup.



                case "weapon":
                    Array.Sort(Weapons);
                    //weaponsList.Sort();


                    Console.WriteLine("\nHere are the list of weapons: ");
                    foreach (string weapon in Weapons)
                    {
                        Console.WriteLine(">>>>> " + weapon + "\n");

                    }
                    UserMap(roomid);
                    break;

                case "potion":
                    Array.Sort(Potions);
                    Console.WriteLine("\nHere are the list of potions: ");
                    foreach (string element in Potions)
                    {
                        Console.WriteLine(">>>>> " + element + "\n");

                    }
                    UserMap(roomid);
                    break;

                default:
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
                    UserMap(roomid);
                    break;


            }




        }

        static void ViewRoom(string room)
        {
            Console.WriteLine(room.ToUpper());
        }



        //Contains methods for user inputs
        static void UserMap(int roomid)
        {
            bool run = true;
            while (run == true)
            {
                Console.Write("\n>");

                string input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case "n":
                    case "north":
                        Console.WriteLine("You walk north\n");
                        input = "n";


                        break;
                    case "s":
                    case "south":
                        Console.WriteLine("You walk south\n");
                        input = "s";

                        break;

                    case "w":
                    case "west":
                        Console.WriteLine("You walk west\n");
                        input = "w";

                        break;

                    case "e":
                    case "east":
                        Console.WriteLine("You walk east\n");
                        input = "e";

                        break;

                    case "room":
                    case "weapon":
                    case "potion":
                        ControlMap(roomid, input);
                        break;
                    default:
                        Console.WriteLine("\nInvalid entry!\n\n\n\n\n");
                        ControlMap(roomid, input);
                        break;


                        
                        
                }

                roomid = UserMove(roomid, input);



            }

        }

        //Determines where the user moves when certain directions are added in
        static int UserMove(int roomid, string direction)
        {


            string selection = "";
            int x = 5;
            string[] Rooms = { "main street", "tunnel", "dimly lit room", "mayor's office", "store front", "your apartment" };
            switch (roomid)
            {

                //Starting point
                case 1:
                    switch (direction)
                    {
                        case "n":
                            //To Main Street
                            x -= 5;

                            break;

                        case "s":
                            //To Tunnel
                            x -= 4;
                            break;

                        case "w":
                            //To Dimly Lit Room
                            //Should only be able to travel here once per game.
                            x -= 3;

                            Console.WriteLine("\nEvent happens\n");


                            break;

                        case "e":
                            //standard message walked into a wall

                            Console.WriteLine("\nYou walked into a wall, genius...\n");

                            break;


                    }
                    break;
                //Main Street
                case 2:
                    switch (direction)
                    {
                        case "n":
                            //To Mayor's Office
                            //Will require key later in build.
                            x -= 2;
                            break;

                        case "s":
                            //To Apartment
                            //If Mob is defeated in main street, holding treasure will allow mob bypass (later build)

                            break;

                        case "w":
                            //Standard message for unmarked area.
                            Console.WriteLine("\nThis is West street territory, even a tough S.O.B like you can't enter a made up territory.\n");
                            //If treasure is held, no mob will appear this time.

                            //Else mob reappears with standard message asking if they are trying to run, user also receives a bit of damage (later build)

                            x -= 5;
                            break;

                        case "e":
                            //To Store Front

                            //If No Key returns to main street

                            //Else enter store front


                            x -= 1;
                            break;


                    }

                    break;
                //Store Front
                case 3:
                    switch (direction)
                    {
                        case "n":
                            //To Unmarked area
                            Console.WriteLine("\nYou ran into the cash register, too bad there's no money in it.\n");
                            x -= 1;
                            break;

                        case "s":
                            //To Unmarked area

                            Console.WriteLine("\nClean up on aisle 1\n");
                            x -= 1;

                            break;

                        case "w":
                            //To Main Street
                            x -= 5;
                            break;

                        case "e":
                            //To Tunnel
                            x -= 4;
                            break;


                    }
                    break;
                //Tunnel
                case 4:
                    switch (direction)
                    {
                        //To Apartment
                        case "n":

                            break;

                        //To Unmarked Area

                        case "s":
                            Console.WriteLine("\nPretty sure that's not chocolate you stepped in...\n");
                            x -= 4;
                            break;


                        //To Store Front
                        case "w":
                            x -= 1;

                            break;

                        //To Unmarked Area
                        case "e":
                            Console.WriteLine("\nAligators everywhere... just turn back.\n");
                            x -= 4;
                            break;


                    }
                    break;
                //Mayor's Office
                case 5:
                    switch (direction)
                    {
                        case "n":
                            //To Unmarked Area
                            x -= 2;
                            break;

                        case "s":
                            //To Main Street
                            x -= 5;
                            break;

                        case "w":
                            //To Unmarked Area
                            x -= 2;

                            break;

                        case "e":
                            //To Unmarked Area
                            x -= 2;
                            break;


                    }
                    break;
                default:

                    selection = Rooms[5];

                    break;



            }
            selection = Rooms[x];
            roomid = SwitchRoom(selection);
            ControlMap(roomid, "");
            return roomid;

        }

        static int SwitchRoom(string Room)
        {
            int number = 0;

            switch (Room)
            {
                case "dimly lit room":
                    number = 0;
                    break;


                case "your apartment":
                    number = 1;
                    break;

                case "main street":
                    number = 2;
                    break;

                case "store front":
                    number = 3;
                    break;

                case "tunnel":
                    number = 4;
                    break;

                case "mayor's office":
                    number = 5;
                    break;

                default:
                    break;







            }
            int roomid = number;

            return roomid;

        }

    }
}
