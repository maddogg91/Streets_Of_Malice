using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLibrary;

namespace CharacterLibrary
{
    public class Rooms : IEnvironment
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string North { get; set; }

        public string South { get; set; }

        public string West { get; set; }

        public string East { get; set; }

       
       
       




        public static Rooms GetRooms (string roomId, string roomName, string exitN, string exitS, string exitW, string exitE, string desc)
        {
            return new Rooms
            {
                ID = roomId,
                Name = roomName,
                Description = desc,
                North= exitN,
                South = exitS,
                West = exitW,
                East = exitE


        };
           
        }

       
    }
}
