using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLibrary
{
    class Treasures
    {
        private string _id;
        private string _name;
        private string _description;
        


        public Treasures(string id, string name, string desc)
        {
            _id = id;
            _name = name;
            _description = desc;
            

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

       
    }
}
