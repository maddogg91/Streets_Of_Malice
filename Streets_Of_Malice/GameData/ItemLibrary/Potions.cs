using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLibrary
{
    public class Potions
    {
        private string _id;
        private string _name;
        private string _description;
        private int _hp;
        

        public Potions(string id, string name, string desc, int hp)
        {
            _id = id;
            _name = name;
            _description = desc;
            _hp = hp;
          
        }

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
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
                return _description;
            }
            set
            {
                _description = value;
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



    }
}
