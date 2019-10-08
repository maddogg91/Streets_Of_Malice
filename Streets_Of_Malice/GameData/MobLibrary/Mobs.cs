using System;

namespace MobLibrary
{
    public class Mobs
    {
        private string _id;
        private string _name;
        private string _desc;
        private int _hp;
        private int _attack;
        private string _roomID;

        public Mobs(string id, string name, string desc, int hp, int attack, string roomID)
        {
            _id = id;
            _name = name;
            _desc = desc;
            _hp = hp;
            _attack = attack;
            _roomID = roomID;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = value;
            }

        }

        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }

        }

        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
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
