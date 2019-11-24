using System;
using System.Collections.Generic;
using System.Text;
using CharacterLibrary;
using ItemLibrary;


namespace OptionsLibrary
{
    public class MovementCommands
    {
        public static void UserMove(string direction, Player player, List<Rooms> rooms)
        {


            Rooms room = GameOptions.MakeRoom(rooms, player.RoomID);



            string returnID = player.RoomID;

            switch (direction)
            {
                case "n":
                    if (room.North == "N/A" && player.RoomID == "R3")
                    {
                        Console.WriteLine("\nYou ran into the cash register...too bad it's empty.\n");
                    }

                    if (room.North == "N/A" && player.RoomID == "R5")
                    {
                        Console.WriteLine("\nYou walked into the mayor's desk...\n");
                    }



                    player.RoomID = room.North;

                    break;

                case "s":
                    if (room.North == "N/A" && player.RoomID == "R3")
                    {
                        Console.WriteLine("\nClean up on Aisle 1...\n");
                    }
                    if (room.North == "N/A" && player.RoomID == "R4")
                    {
                        Console.WriteLine("\nPretty sure that's not chocolate...\n");
                    }

                    player.RoomID = room.South;
                    break;

                case "e":
                    if (room.East == "N/A" && player.RoomID == "R1")
                    {
                        Console.WriteLine("\nYou walked into your wall...\n");
                    }
                    if (room.East == "N/A" && player.RoomID == "R4")
                    {
                        Console.WriteLine("\nYou're a tough guy but that Alligator is tougher...\n");
                    }
                    if (room.East == "N/A" && player.RoomID == "R5")
                    {
                        Console.WriteLine("\nNothing but trash bin.\n");
                    }
                    player.RoomID = room.East;
                    break;

                case "w":
                    if (room.West == "N/A" && player.RoomID == "R2")
                    {
                        Console.WriteLine("\nThis is West street territory, even a tough S.O.B like you can't enter a made up territory.\n");
                    }
                    if (room.West == "N/A" && player.RoomID == "R5")
                    {
                        Console.WriteLine("\nNothing but trash bin.\n");
                    }

                    player.RoomID = room.West;
                    break;
            }

            if (player.RoomID == "R6")
            {
                //rooms.RemoveAt(6);
                player.RoomID = "R1";
            }

            if (player.RoomID == "R6")
            {
                player.RoomID = "N/A";
            }


            if (player.RoomID == "N/A")
            {
                Console.WriteLine("There is no exit this way");
                player.RoomID = returnID;


            }





            room = GameOptions.MakeRoom(rooms, player.RoomID);
            SearchCommands.ViewRoom(room.Name);



        }

        public static List<Mobs> MobMovement(GameObjects options)
        {

            foreach (Mobs mob in options.Mobs)
            {
                Rooms loadedRoom = GameOptions.MakeRoom(options.Rooms, mob.RoomID);

                if (mob.Cooldown > 0)
                {
                    mob.Cooldown = mob.Cooldown--;
                }

                else
                {
                    switch (GetMovement())
                    {
                        case "n":
                            if (loadedRoom.North != "N/A")
                            {
                                mob.RoomID = loadedRoom.North;
                            }
                            break;

                        case "s":
                            if (loadedRoom.South != "N/A")
                            {
                                mob.RoomID = loadedRoom.South;
                            }
                            break;

                        case "e":
                            if (loadedRoom.East != "N/A")
                            {
                                mob.RoomID = loadedRoom.East;
                            }
                            break;

                        case "w":
                            if (loadedRoom.West != "N/A")
                            {
                                mob.RoomID = loadedRoom.West;
                            }
                            break;
                        case "x":

                            break;
                    }

                    if (mob.RoomID == options.Player.RoomID)
                    {
                        Console.WriteLine($"{mob.Name} lurking about...");
                    }
                }



            }
            return options.Mobs;
        }

        private static string GetMovement()
        {
            Random rand = new Random();
            int roulette = rand.Next(1, 24);
            switch (roulette)
            {
                case 1:
                    return "n";

                case 8:
                    return "s";

                case 16:
                    return "e";

                case 24:
                    return "w";

                default:
                    return "x";
            }
        }
    }
}
