 class Map
    {
        public static int UserMove(int roomid, string direction)
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

            Commands.CommandInput(roomid);
            return roomid;

        }
        public static int SwitchRoom(string Room)
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

            Commands.ViewRoom(Room);
         
            int roomid = number;

            return roomid;

        }
    }