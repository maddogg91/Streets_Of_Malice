using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IExistsinRoom

        
    {
        string Name
        {
            get; set;
        }

        string ID
        {
            get; set;
        }

        string Description
        {
            get; set;
        }

        string Type
        {
            get; set;
        }
        string RoomID
        {
            get; set;
        }
    }
}
