using System;
using ItemLibrary;

namespace UserLibrary
{
    public class User
    {
        private string _username;
        private Weapons _weapon;


        public User(string user, Weapons weapon)
        {
            _username = user;
            _weapon = weapon;
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

        public Weapons Weapon
        {
            get
            {
                return _weapon;
            }

            set
            {
                _weapon = value;
            }
        }
    }
}
