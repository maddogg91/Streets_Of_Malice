using System;
using ItemLibrary;

namespace PlayerLibrary
{
    public class Player
    {
        private string _username;
        private string _password;
        private Classes _class;
        private Type _type;
        private string _roomID;

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

        public Player(string user, string password, Classes userClass, Type type, string roomID)
        {
            
            _username = user;
            _password = password;
            _class = userClass;
            _type = type;
            _roomID = roomID;
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public Classes UserClass
        {
            get
            {
                return _class;
            }

            set
            {
                _class = value;
            }
        }


        public Type UserType
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string RoomID
        {
            get
            {
                return _roomID;
            }

            set
            {
                _roomID = value;
            }
        }
    }
}
