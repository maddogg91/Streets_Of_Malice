using System;
using System.Collections.Generic;
using System.Text;
using PlayerLibrary;
using ItemLibrary;
using MobLibrary;

namespace OptionsLibrary
{
    public class MovementCommands
    {
        public static void UserMove(string direction, Player player)
        {
            List<Rooms> rooms = LoadOptions.LoadRooms();

            Rooms room = GameOptions.MakeRoom(rooms, player.RoomID);



            string returnID = player.RoomID;

            switch (direction)
            {
                case "n":
                    if (room.ExitN == "N/A" && player.RoomID == "R3")
                    {
                        Console.WriteLine("\nYou ran into the cash register...too bad it's empty.\n");
                    }

                    if (room.ExitN == "N/A" && player.RoomID == "R5")
                    {
                        Console.WriteLine("\nYou walked into the mayor's desk...\n");
                    }



                    player.RoomID = room.ExitN;

                    break;

                case "s":
                    if (room.ExitS == "N/A" && player.RoomID == "R3")
                    {
                        Console.WriteLine("\nClean up on Aisle 1...\n");
                    }
                    if (room.ExitN == "N/A" && player.RoomID == "R4")
                    {
                        Console.WriteLine("\nPretty sure that's not chocolate...\n");
                    }

                    player.RoomID = room.ExitS;
                    break;

                case "e":
                    if (room.ExitE == "N/A" && player.RoomID == "R1")
                    {
                        Console.WriteLine("\nYou walked into your wall...\n");
                    }
                    if (room.ExitE == "N/A" && player.RoomID == "R4")
                    {
                        Console.WriteLine("\nYou're a tough guy but that Alligator is tougher...\n");
                    }
                    if (room.ExitE == "N/A" && player.RoomID == "R5")
                    {
                        Console.WriteLine("\nNothing but trash bin.\n");
                    }
                    player.RoomID = room.ExitE;
                    break;

                case "w":
                    if (room.ExitW == "N/A" && player.RoomID == "R2")
                    {
                        Console.WriteLine("\nThis is West street territory, even a tough S.O.B like you can't enter a made up territory.\n");
                    }
                    if (room.ExitW == "N/A" && player.RoomID == "R5")
                    {
                        Console.WriteLine("\nNothing but trash bin.\n");
                    }

                    player.RoomID = room.ExitW;
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
            SearchCommands.ViewRoom(room.RoomName);
            GeneralCommands.CommandInput(player);


        }
    }
}
