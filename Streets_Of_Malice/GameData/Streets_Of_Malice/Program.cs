using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streets_Of_Malice
{/**

* September 15th, 2019

* CSC 253

* Jesse Watts 
* 
* Robert Charity

* Streets of Malice (Sprint #1)
* 
* Streets of Malice is an urban inspired dungeon crawler. Currently the build tests motion north, south, east, and west. Also allows user to see list of all available rooms and weapons.

*/
    class Program
    {

        static void Main(string[] args)
        {

            Standard_Messages.TitleCard();
            int roomid = Map.SwitchRoom("your apartment");
            
            Commands.CommandInput(roomid);
        }
        




     

        

        


        //Contains methods for user inputs
        

        //Determines where the user moves when certain directions are added in
        
        

    }
}
