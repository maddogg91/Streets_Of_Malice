using System;
using System.Collections.Generic;
using System.Text;
using CharacterLibrary;
using ItemLibrary;
using InterfaceLibrary;


namespace OptionsLibrary
{
    public class SearchCommands
    {
        public static void LookObject(string obj, List<IExistsinRoom> options)
        {

            


            foreach (IExistsinRoom element in options)
            {
                string item = element.Name.ToString();
                item = item.ToLower();
                if (obj.Contains(item))
                {

                    Console.WriteLine($"{element.Type} ID: {element.ID}\n {element.Type} Name: {element.Name}\n{element.Type} Description: {element.Description}\n");
                }
            }



           

        }

        public static void ViewAll(List<Rooms> data)
        {
            foreach (Rooms element in data)
            {
                StandardMessages.DisplayAll(element.Name.ToString());


            }



        }

        
       


        public static void ViewRoom(string room)
        {
            Console.WriteLine("Current Location: " + room.ToUpper());
        }

    }
}
