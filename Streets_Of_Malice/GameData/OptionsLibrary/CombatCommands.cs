using System;
using System.Collections.Generic;
using System.Text;
using CharacterLibrary;

namespace OptionsLibrary
{
    public class CombatCommands
    {
        public static void StartCombat(GameObjects options, string obj)
        {
           
            foreach(Mobs mob in options.Mobs)
            {
                if (mob.Name.ToLower().Contains(obj))
                {
                    Console.WriteLine($"You are now fighting {mob.Name}");
                }
                
                

              
                
            }

        }
    }
}
