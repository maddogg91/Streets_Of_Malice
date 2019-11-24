using System;
using InterfaceLibrary;

namespace ItemLibrary
{
    public class Weapons : IEnvironment, IExistsinRoom
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Damage { get; set; }

        public bool IsEquipped { get; set; }

        public string Type { get; set; }

        public string RoomID { get; set; }



        public static Weapons GetWeapons(string id, string name, string desc, int damage, string room)
        {
            return new Weapons
            {
                ID = id,
                Name = name,
                Description = desc,
                Damage = damage,
                IsEquipped = false,
                Type = "Weapon",
                RoomID = room

            };
        }

    }
}
