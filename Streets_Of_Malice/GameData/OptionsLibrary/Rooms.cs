using System;
using System.Collections.Generic;
using System.Text;

namespace OptionsLibrary
{
    public class Rooms
    {
        private string _roomID;
        private string _roomName;
        private string _exitN;
        private string _exitS;
        private string _exitW;
        private string _exitE;
        private string _desc;




        public Rooms(string roomId, string roomName, string exitN, string exitS, string exitW, string exitE, string desc)
        {
            _roomID = roomId;
            _roomName = roomName;
            _exitN = exitN;
            _exitS = exitS;
            _exitW = exitW;
            _exitE = exitE;
            _desc = desc;
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

        public string RoomName
        {
            get
            {
                return _roomName;
            }
            set
            {
                _roomName = value;
            }
        }

        public string ExitN
        {
            get
            {
                return _exitN;
            }
            set
            {
                _exitN = value;
            }
        }
        public string ExitS
        {
            get
            {
                return _exitS;
            }
            set
            {
                _exitS = value;
            }
        }

        public string ExitW
        {
            get
            {
                return _exitW;
            }
            set
            {
                _exitW = value;
            }
        }

        public string ExitE
        {
            get
            {
                return _exitE;
            }
            set
            {
                _exitE = value;
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
    }
}
