using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace ItemLibrary
{
    public class Treasures : IEnvironment
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public static Treasures GetTreasures(string id, string name, string desc)
        {
            return new Treasures
            {
                ID = id,
                Name = name,
                Description = desc,
                

            };
        }





    }
}
