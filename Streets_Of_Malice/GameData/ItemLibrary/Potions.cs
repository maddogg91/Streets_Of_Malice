using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLibrary
{
    public class Potions : IPlayerItems
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int HP { get; set; }

        public static Potions GetPotions(string id, string name, string desc, int hp)
        {
            return new Potions
            {
                ID = id,
                Name = name,
                Description = desc,
                HP= hp

            };
        }
    }
}
