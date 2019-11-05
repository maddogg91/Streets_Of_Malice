using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLibrary
{
    public interface ICombatant
    {
        int HP
        {
            get; set;
        }

        int Attack

        {
            get; set;
        }

        string RoomID
        {
            get; set;
        }
    }
}
