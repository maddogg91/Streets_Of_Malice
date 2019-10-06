using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ItemLibrary;

namespace Streets_Of_Malice
{
    public class Options
    {
        public static List<Weapons> LoadWeapons()
        {
            List<Weapons> weaponList= new List<Weapons>();
            

            StreamReader inputFile;
            inputFile = File.OpenText("Weapons.csv");
            int i = 0;
            while (!inputFile.EndOfStream)
            {
                string line = inputFile.ReadLine();
                if (i != 0)
                {
                    
                    string[] words = line.Split(',');

                    string id = words[0];
                    string weapon = words[1];
                    string input = words[2];
                    int damage = int.Parse(input);
                    string desc = words[3];
                    Weapons loadedWeapon = new Weapons(weapon, desc, damage);
                    weaponList.Add(loadedWeapon);




                }

                i++;

            }
            return weaponList;
        }


        public static string[] SetRooms()
        {
            string[] Rooms = { "Your apartment", "Main Street", "Store Front", "Tunnel", "Dimly lit room", "Mayor's Office" };
            return Rooms;
        }

        public static List<Weapons> SetWeapons(List<Weapons> weapons)
        {
            return weapons;
        }

        public static List<string> SetItems()
        {
            List<string> Items = new List<string>() { "Store Front Key", "Golden Key", "Key to the City", "Smokebomb" };
            return Items;
        }

        public static List<string> SetMobs()
        {
            List<string> Mobs = new List<string>() { "Computer Programmers", "Main Street Manics", "Thieves", "Underground Gang", "Police" };
            return Mobs;
        }

        public static string[] SetPotions()
        {
            string[] Potions = { "Milk", "Energy" };
            
           
            

            return Potions;
        }

        public static string[] SetTreasures()
        {
            string[] Treasure = { "Gold Medal", "Silver Trophy", "Bronze Stamp" };

            return Treasure;
        }
    }
}
