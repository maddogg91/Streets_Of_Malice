using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streets_Of_Malice
{
    public class Options
    {
        public static string[] SetRooms()
        {
            string[] Rooms = { "Your apartment", "Main Street", "Store Front", "Tunnel", "Dimly lit room", "Mayor's Office" };
            return Rooms;
        }

        public static List<string> SetWeapons()
        {
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

            return weaponsList;
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
