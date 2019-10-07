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

        public Player(string user, string password, Classes userClass, Type type)
        {
            
            _username = user;
            _password = password;
            _class = userClass;
            _type = type;
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
    }
}
