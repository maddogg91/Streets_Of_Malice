using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ItemLibrary
{
    public class Treasures : IEnvironment, IExistsinRoom
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }

        public string RoomID { get; set; }


        public static Treasures GetTreasures(string id, string name, string desc, string room)
        {
            return new Treasures
            {
                ID = id,
                Name = name,
                Description = desc,
                Type= "Treasure",
                RoomID= room

            };
        }





    }
}
