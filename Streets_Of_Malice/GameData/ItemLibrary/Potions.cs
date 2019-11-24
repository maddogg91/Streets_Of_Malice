using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ItemLibrary
{
    public class Potions : IEnvironment, IExistsinRoom
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int HP { get; set; }

        public string Type { get; set; }

        public string RoomID { get; set; }

        public static Potions GetPotions(string id, string name, string desc, int hp, string room)
        {
            return new Potions
            {
                ID = id,
                Name = name,
                Description = desc,
                HP = hp,
                Type = "Potion",
                RoomID= room

            };
        }
    }
}
