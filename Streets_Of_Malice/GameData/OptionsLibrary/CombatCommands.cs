using System;
using System.Collections.Generic;
using System.Text;
using CharacterLibrary;
using InterfaceLibrary;

namespace OptionsLibrary
{
    public class CombatCommands
    {
        public static void StartCombat(GameObjects options, string obj)
        {

            foreach (Mobs mob in options.Mobs)
            {
                if (obj.Contains(mob.Name.ToLower()))
                {
                    Mobs cloneMob = mob;

                    options = FightTarget(options, options.Player, mob);


                    if (mob.HP <= 0)
                    {
                        mob.HP = cloneMob.HP;
                        mob.RoomID = "R6";
                        mob.Cooldown = 3;
                    }
                }





            }
            if (options.Player.HP <= 0)
            {
                Console.WriteLine("Game Over");
                Console.ReadLine();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                GameOptions.Startup();
            }

        }

        private static GameObjects FightTarget(GameObjects options, ICombatant player, ICombatant mob)
        {



            Random rand = new Random();

            while (player.HP > 0 && mob.HP > 0)
            {
                Console.WriteLine("\n\n\n\n\n");
                Console.WriteLine($"\t\t\tCombat Results: " +
                    $"\nPlayer HP: {player.HP}                  {mob.Name}: {mob.HP}\n");


                int coin = rand.Next(1, 2);
                switch (coin)
                {
                    //Player attacks first
                    case 1:
                        mob.HP = mob.HP - DamageCalc(player);
                        if (mob.HP > 0)
                        {
                            player.HP = player.HP - DamageCalc(mob);
                        }

                        break;

                    //Mob attacks first
                    case 2:
                        player.HP = player.HP - DamageCalc(mob);
                        if (player.HP > 0)
                        {
                            mob.HP = mob.HP - DamageCalc(player);
                        }

                        break;
                }

            }

            if (player.HP <= 0)
            {
                options.Player.HP = 0;

            }
            if (mob.HP <= 0)
            {
                Console.WriteLine($"{mob.Name} has been defeated");
            }

            return options;


        }

        private static int DamageCalc(ICombatant attacker)
        {
            Random rand = new Random();
            int accuracy = rand.Next(1, 8);
            if (accuracy == 2 || accuracy == 5)
            {
                Console.WriteLine($"{attacker.Name} missed!");
                return 0;
            }
            else
            {
                Console.WriteLine($"{attacker.Name} dealt {attacker.Attack} damage!");
                return attacker.Attack;
            }
        }
    }
}
