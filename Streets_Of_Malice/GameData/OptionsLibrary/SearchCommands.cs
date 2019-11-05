using System;
using System.Collections.Generic;
using System.Text;
using PlayerLibrary;
using ItemLibrary;
using MobLibrary;

namespace OptionsLibrary
{
    public class SearchCommands
    {
        public static void LookObject(string obj, Player player, List<Rooms> rooms, List<Items> items, List<Potions> potions, List<Treasures> treasures,
            List<Weapons> weapons, List<Mobs> mobs)
        {
            

            

            foreach (Items element in items)
            {
                string item = element.Name.ToString();
                item = item.ToLower();
                if (obj.Contains(item))
                {
                    
                    Console.WriteLine("Item ID: " + element.ID + "\n" + "Item Name: " + element.Name + "\n" + "Item Description: " + element.Description + "\n");
                }
            }

            foreach (Weapons element in weapons)
            {
                string weapon = element.WeaponName.ToString();
                weapon = weapon.ToLower();
                if (obj.Contains(weapon))
                {
                  
                    Console.WriteLine("Weapon ID: " + element.ID + "\n" + "Weapon Name: " + element.WeaponName + "\n" + "Weapon Description: " + element.Description + 
                        "\n" + "Weapon Power: " + element.Damage + "\n");
                }
            }

            foreach (Potions element in potions)
            {
                string potion = element.Name.ToString();
                potion = potion.ToLower();
                if (obj.Contains(potion))
                {
                    
                    Console.WriteLine("Potion ID: " + element.ID + "\n" + "Potion Name:" +element.Name + "\n" + "Potion Description: "+ element.Description + "\n");
                }
            }

            foreach (Mobs element in mobs)
            {
                string mob = element.Name.ToString();
                mob = mob.ToLower();
                if (obj.Contains(mob))
                {
                    
                    Console.WriteLine("Mob ID: " + element.ID + "\n" + "Mob Name: " + element.Name + "\nMob Description: " + element.Description + "\n");
                }
            }

            //if (compare == " ")
            //{
            //    Console.WriteLine("Command not found");
            //}

            
        }



        public static void ViewAll(string[] data, Player player)

        {

            foreach (string element in data)
            {
                StandardMessages.DisplayAll(element);


            }


            

        }

        public static void ViewAll(List<Rooms> data, Player player)
        {
            foreach (Rooms element in data)
            {
                StandardMessages.DisplayAll(element.RoomName.ToString());


            }


         
        }

       

        public static void ViewAll(string[] data)

        {

            foreach (string element in data)
            {
                StandardMessages.DisplayAll(element);


            }


            

        }

        public static void ViewAll(List<Rooms> data)
        {
            foreach (Rooms element in data)
            {
                StandardMessages.DisplayAll(element.RoomName.ToString());


            }


        
        }

        public static void ViewAll(List<Items> data)
        {
            foreach (Items element in data)
            {
                StandardMessages.DisplayAll(element.Name.ToString());


            }


           
        }

        public static void ViewAll(List<Potions> data)
        {
            foreach (Potions element in data)
            {
                StandardMessages.DisplayAll(element.Name.ToString());


            }


            
        }



        public static void ViewAll(List<string> data)
        {
            foreach (string element in data)
            {
                StandardMessages.DisplayAll(element);


            }


            
        }


        public static void ViewRoom(string room)
        {
            Console.WriteLine("Current Location: " + room.ToUpper());
        }

    }
}
