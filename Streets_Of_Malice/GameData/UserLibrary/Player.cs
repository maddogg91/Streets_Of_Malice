using System;
using ItemLibrary;
using InterfaceLibrary;

namespace CharacterLibrary
{
    public class Player : IEnvironment, ICombatant, IExistsinRoom
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public string RoomID { get; set; }

        //User interface
        public string UserName { get; set; }

        public string Password { get; set; }

        public Classes Class { get; set; }

        public Type BodyType { get; set; }



        public enum Classes
        {
            Brawler,
            MartialArtist,
            Soldier
        }

        public enum Type
        {
            Athletic,
            BodyBuilder,
            Fat,
            Skinny
        }

        public static Player GetPlayer(string user, string password, Classes userClass, Type type, string roomID)
        {
            int attack = 0;
            int hp = 0;

            switch (userClass)
            {
                case Classes.Brawler:

                    attack = 7;
                    hp = 20;
                    break;

                case Classes.MartialArtist:

                    attack = 5;
                    hp = 25;
                    break;

                case Classes.Soldier:

                    attack = 2;
                    hp = 30;
                    break;

            }

            switch (type)
            {
                case Type.Athletic:
                    attack += 3;
                    hp += 8;

                    break;

                case Type.BodyBuilder:
                    attack += 5;

                    break;

                case Type.Skinny:
                    attack += 1;
                    hp += 10;

                    break;

                case Type.Fat:
                    hp += 15;

                    break;

            }
            return new Player
            {
                ID = "Player",
                Name = user,
                Description = $"{user}... a {type} {userClass} with a score to settle",



                HP = hp,
                Attack = attack,
                RoomID = roomID,
                Class = userClass,
                BodyType = type
            };

        }


    }
}
