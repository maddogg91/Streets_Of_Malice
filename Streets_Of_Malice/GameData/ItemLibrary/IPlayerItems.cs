using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLibrary
{
    public interface IPlayerItems
    {


        string ID
        {
            get;set;  
        }

        string Name
       
            {
                get; set;
            }
       
        string Description
        {
            get; set;
        }

    }
}
