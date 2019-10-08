using System;
using System.Collections.Generic;
using System.Text;
using PlayerLibrary;
using ItemLibrary;

namespace OptionsLibrary
{
    public class SearchCommands
    {
        public static void ViewAll(string[] data, Player player)

        {

            foreach (string element in data)
            {
                StandardMessages.DisplayAll(element);


            }


            GeneralCommands.CommandInput(player);

        }

        public static void ViewAll(List<Rooms> data, Player player)
        {
            foreach (Rooms element in data)
            {
                StandardMessages.DisplayAll(element.RoomName.ToString());


            }


            GeneralCommands.CommandInput(player);
        }

        public static void ViewAll(List<Items> data, Player player)
        {
            foreach (Items element in data)
            {
                StandardMessages.DisplayAll(element.Name.ToString());


            }


            GeneralCommands.CommandInput(player);
        }

        public static void ViewAll(List<Potions> data, Player player)
        {
            foreach (Potions element in data)
            {
                StandardMessages.DisplayAll(element.Name.ToString());


            }


            GeneralCommands.CommandInput(player);
        }



        public static void ViewAll(List<string> data, Player player)
        {
            foreach (string element in data)
            {
                StandardMessages.DisplayAll(element);


            }


            GeneralCommands.CommandInput(player);
        }


        public static void ViewRoom(string room)
        {
            Console.WriteLine("Current Location: " + room.ToUpper());
        }

    }
}
