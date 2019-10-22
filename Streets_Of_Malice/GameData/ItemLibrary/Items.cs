﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLibrary
{
    public class Items
    {
        private string _id;
        private string _name;
        private string _description;
        private int _uses;
        


        public Items(string id, string name, string desc, int uses)
        {
            _id = id;
            _name = name;
            _description = desc;
            _uses = uses;

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

        public int Uses
        {
            get
            {
                return _uses;
            }
            set
            {
                _uses = value;
            }

        }
    }
}