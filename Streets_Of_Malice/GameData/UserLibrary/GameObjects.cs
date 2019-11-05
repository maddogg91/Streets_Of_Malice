using System;
using System.Collections.Generic;
using System.Text;
using ItemLibrary;


namespace CharacterLibrary
{
    

   public class GameObjects
    {
        public List<Mobs> Mobs { get; set; }
        public List<Rooms> Rooms { get; set; }
        public List<Items> Items { get; set; }
        public List<Potions> Potions { get; set; }
        public List<Treasures> Treasures { get; set; }
        public List<Weapons> Weapons { get; set; }

        public Player Player { get; set; }

        public static GameObjects GetObjects(List<Mobs> mobs, List<Rooms> rooms, List<Items> items, List<Potions> potions, List<Treasures> treasures, List<Weapons> weapons, Player player)
        {
            return new GameObjects
            {
                Mobs = mobs,
                Rooms = rooms,
                Items = items,
                Potions = potions,
                Treasures = treasures,
                Weapons = weapons,
                Player = player
            };
        }
    }
}
