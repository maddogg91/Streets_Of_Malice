using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ItemLibrary
{
    public class Items : IEnvironment, IExistsinRoom
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Uses { get; set; }

        public string Type { get; set; }

        public string RoomID { get; set; }

        public static Items GetItems(string id, string name, string desc, int uses, string room)
        {
            return new Items
            {
                ID = id,
                Name = name,
                Description = desc,
                Uses = uses,
                Type = "Item",
                RoomID = room

            };
        }
    }


}
