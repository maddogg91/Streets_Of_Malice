using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streets_Of_Malice
{
    public class Standard_Messages
    {
        public static void TitleCard()
        {
            //Gonna put this in standard messages when it's created.
            string title = " .oooooo..o     .                                    .            \n" +
                "d8P'    `Y8   .o8                                  .o8            \n" +
                "Y88bo.      .o888oo oooo d8b  .ooooo.   .ooooo.  .o888oo  .oooo.o \n" +
                " `^Y8888o.    888   `888^^8P d88' `88b d88' `88b   888   d88(^8\n" +
                "     `^Y88b   888    888     888ooo888 888ooo888   888   `^Y88b.  \n" +
                "oo     .d8P   888 .  888     888    .o 888    .o   888 . o.  )88b \n" +
                "8^^88888P^    ^888^ d888b    `Y8bod8P' `Y8bod8P'   ^888^ 8^^888P^^ \n" +
                "";

            string title2 =
                "\n\n            .o88o. \n" +
                "           888 `^ \n" +
                ".ooooo.  o888oo  \n" +
                "d88' `88b  888   \n " +
                "888   888 888\n" +
                "888   888  888\n" +
                "`Y8bod8P' o888o \n";

            string title3 =
                "\n\nooo        ooooo           oooo   o8o                     \n" +
                "`88.       .888'           `888   `^'\n" +
                " 888b     d'888   .oooo.    888  oooo   .ooooo.   .ooooo. \n" +
                " 8 Y88. .P  888  `P  )88b   888  `888  d88' `'Y8 d88' `88b\n" +
                " 8  `888'   888   .oP'888   888   888  888       888ooo888 \n" +
                " 8    Y     888  d8(  888   888   888  888   .o8 888    .o \n" +
                "o8o        o888o `Y888^^8o o888o o888o `Y8bod8P' `Y8bod8P' \n";

           

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n" + title + title2 + title3 + "\nPress Enter to continue");
            Console.ReadLine();
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nYou wake up in your dirty apartment... It's loud outside... sounds like the manics are out causing chaos on main street.");
           

            
        }

        public static void DisplayThis(string word)
        {
            Console.WriteLine("\nHere are the list of " + word +":");
        }

        public static void DisplayAll(object entry)
        {

            Console.WriteLine(">>>>> " + entry + "\n");
        }


    }
}
