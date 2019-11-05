using System;
using ItemLibrary;
using InterfaceLibrary;

namespace CharacterLibrary
{
    public class Player : IEnvironment, ICombatant
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
            return new Player
            {
                ID = "Player",
                Name = user,
                Description = $"{user}... a {type} {userClass} with a score to settle",
                HP = 50,
                Attack = 10,
                RoomID = roomID,
                Class = userClass,
                BodyType= type
            };
            
        }

        
    }
}
