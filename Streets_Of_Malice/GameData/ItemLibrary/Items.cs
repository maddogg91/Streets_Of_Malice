﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLibrary
{
    public class Items : IPlayerItems
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Uses { get; set; }

        public static Items GetItems(string id, string name, string desc, int uses)
        {
            return new Items
            {
                ID = id,
                Name = name,
                Description = desc,
                Uses = uses

            };
        }
    }


}
