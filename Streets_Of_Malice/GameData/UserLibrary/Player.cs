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

        public Body BodyType { get; set; }

        public string Type { get; set; }

       


        public enum Classes
        {
            Brawler,
            MartialArtist,
            Soldier
        }

        public enum Body
        {
            Athletic,
            BodyBuilder,
            Fat,
            Skinny
        }

        public static Player GetPlayer(string user, string password, Classes userClass, Body body, string roomID)
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

            switch (body)
            {
                case Body.Athletic:
                    attack += 3;
                    hp += 8;

                    break;

                case Body.BodyBuilder:
                    attack += 5;

                    break;

                case Body.Skinny:
                    attack += 1;
                    hp += 10;

                    break;

                case Body.Fat:
                    hp += 15;

                    break;

            }
            return new Player
            {
                ID = "Player",
                UserName= user,
                Password = password,
                Name = user,
                Description = $"{user}... a {body} {userClass} with a score to settle",



                HP = hp,
                Attack = attack,
                RoomID = roomID,
                Class = userClass,
                BodyType = body
            };

        }


    }
}
