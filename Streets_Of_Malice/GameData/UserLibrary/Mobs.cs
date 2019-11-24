using System;
using InterfaceLibrary;

namespace CharacterLibrary
{
    public class Mobs : IEnvironment, ICombatant, IExistsinRoom
    {

        //Enviroment Interface
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Combatant Interface
        public int HP { get; set; }

        public int Attack { get; set; }

        public int Cooldown { get; set; }

        public string RoomID { get; set; }

        public string Type { get; set; }


        public static Mobs GetMobs(string id, string name, string desc, int hp, int attack, string roomID)
        {


            return new Mobs
            {
                ID = id,
                Name = name,
                Description = desc,
                HP = hp,
                Attack = attack,

                Cooldown = 0,





                RoomID = roomID
               
            };


        }


    }
}
