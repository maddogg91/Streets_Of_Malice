﻿using System;

namespace ItemLibrary
{
    public class Weapons
    {
        private string _id;
        private string _weaponname;
        private string _description;
        private int _damage;
        private bool _isEquipped;

        public Weapons(string id, string weapon, string desc, int damage)
        {
            _id = id;
            _weaponname = weapon;
            _description = desc;
            _damage = damage;
            _isEquipped = false;
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
        public string WeaponName
        {
            get
            {
                return _weaponname;
            }
            set
            {
                _weaponname = value;
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

        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }

        }

        public bool IsEquipped
        {
            get
            {
                return _isEquipped;
            }

            set
            {
                _isEquipped = value;
            }
        }


    }
}
