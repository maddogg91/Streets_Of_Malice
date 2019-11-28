using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterLibrary;
using OptionsLibrary;
using ItemLibrary;
using System.Windows;
using System.Windows.Controls;
using GameScreen;

namespace Streets_Of_Malice
{/**

 November 28th, 2019

* CSC 253

* Jesse Watts 
* 
* Robert Charity

* Streets of Malice (Sprint #4)
* 
* Streets of Malice is an urban inspired dungeon crawler. 
*
* This build adds a WPF screen for new game or load game functionality, among other smaller features.

*/
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {


            Window titleScreen = new Title();
            titleScreen.ShowDialog();
            
          

            
            //GameOptions.Startup();


           
        }
        




     

        

        


        //Contains methods for user inputs
        

        //Determines where the user moves when certain directions are added in
        
        

    }
}
