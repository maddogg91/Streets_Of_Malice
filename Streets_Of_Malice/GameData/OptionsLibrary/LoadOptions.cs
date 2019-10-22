using System;

using System.IO;
using PlayerLibrary;
using ItemLibrary;
using System.Collections.Generic;
using MobLibrary;

namespace OptionsLibrary
{
    public class LoadOptions
    {

        //LOAD PLAYER INFO

        public static Player LoadPlayer()
        {
            Player player = new Player(" ", " ", Player.Classes.Brawler, Player.Type.Athletic, "R1");
            StreamReader inputFile;

            Console.Write("\nEnter the player's name: ");
            string input = Console.ReadLine();
            string inputFileName = input + ".txt";

            try
            {
                inputFile = File.OpenText(inputFileName);
                string user = inputFile.ReadLine();
                string password = inputFile.ReadLine();
                bool run = true;
                int i = 0;
                do
                {
                    if (i == 3)
                    {
                        Console.WriteLine("\nToo many wrong passwords\n");
                        GameOptions.Startup();
                    }
                    Console.Write("\nEnter your password: ");
                    string check = Console.ReadLine();
                    if (password == check)
                    {
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Password, Please try again\n");
                        i++;
                    }

                }

                while (run == true);

                input = inputFile.ReadLine();
                Player.Classes userClass = Player.Classes.Brawler;
                switch (input)
                {
                    case "Brawler":
                        userClass = Player.Classes.Brawler;
                        break;

                    case "Martial Artist":
                        userClass = Player.Classes.MartialArtist;
                        break;

                    case "Soldier":
                        userClass = Player.Classes.Soldier;
                        break;


                }
                input = inputFile.ReadLine();
                Player.Type type = Player.Type.Athletic;
                switch (input)
                {
                    case "Athletic":
                        type = Player.Type.Athletic;
                        break;

                    case "Body Builder":
                        type = Player.Type.BodyBuilder;
                        break;

                    case "Fat":
                        type = Player.Type.Fat;
                        break;

                    case "Skinny":
                        type = Player.Type.Skinny;
                        break;




                }

                player = new Player(user, password, userClass, type, "R1");
                inputFile.Close();
                return player;
            }
            catch (FileNotFoundException)
            {
                Console.Write("\nFile not found\nWould you like to start a new game or exit?\n>");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "new game":
                        player = GameOptions.NewPlayer();
                        break;

                    default:
                        System.Environment.Exit(0);
                        break;

                }

                return player;
            }
        }




        //LOAD ROOMS
        public static List<Rooms> LoadRooms()
        {
            int i = 0;
            Rooms room = new Rooms(" ", " ", " ", " ", " ", " ", " ");
            List<Rooms> rooms = new List<Rooms>();
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText("Rooms.csv");
                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    if (i != 0)
                    {
                        string[] words = line.Split(',');
                        string roomID = words[0];
                        string roomName = words[1];
                        string exitN = words[2];
                        string exitS = words[3];
                        string exitW = words[4];
                        string exitE = words[5];
                        room = new Rooms(roomID, roomName, exitN, exitS, exitW, exitE, words[6]);
                        rooms.Add(room);
                    }
                    i++;
                }
                inputFile.Close();
                return rooms;
            }

            catch (FileNotFoundException)
            {
                string[] roomIDs = { "R1", "R2", "R3", "R4", "R5", "R6" };
                string[] roomNames = { "Your apartment", "Main Street", "Store Front", "Tunnel", "Mayor's Office", "Dimly Lit Room" };
                string[] exitN = { "R2", "R5", "N/A", "R1", "N/A", "N/A" };
                string[] exitS = { "R4", "R1", "N/A", "N/A", "R2", "N/A" };
                string[] exitW = { "R6", "N/A", "R2", "R3", "N/A", "N/A" };
                string[] exitE = { "N/A", "R3", "R4", "N/A", "N/A", "N/A" };
                Console.WriteLine("Creating rooms...");
                for (i = 0; i < 6; i++)
                {
                    room = new Rooms(roomIDs[i], roomNames[i], exitN[i], exitS[i], exitW[i], exitE[i], "filler");
                    rooms.Add(room);
                }
                return rooms;
            }

        }



        //LOAD WEAPON INFO
        public static List<Weapons> LoadWeapons()
        {
            List<Weapons> weaponList = new List<Weapons>();


            StreamReader inputFile;
            inputFile = File.OpenText("Weapons.csv");
            int i = 0;
            while (!inputFile.EndOfStream)
            {
                string line = inputFile.ReadLine();
                if (i != 0)
                {

                    string[] words = line.Split(',');

                    string id = words[0];
                    string weapon = words[1];
                    string input = words[2];
                    int damage = int.Parse(input);
                    string desc = words[3];
                    Weapons loadedWeapon = new Weapons(id, weapon, desc, damage);
                    weaponList.Add(loadedWeapon);




                }

                i++;

            }
            return weaponList;
        }


        //LOAD ITEMS INFO
        public static List<Items> LoadItems()
        {
            List<Items> itemsList = new List<Items>();


            StreamReader inputFile;
            inputFile = File.OpenText("Items.csv");
            int i = 0;
            while (!inputFile.EndOfStream)
            {
                string line = inputFile.ReadLine();
                if (i != 0)
                {

                    string[] words = line.Split(',');

                    string id = words[0];
                    string name = words[1];
                    string desc = words[2];
                    string input = words[3];
                    int uses = int.Parse(input);

                    Items loadedItem = new Items(id, name, desc, uses);
                    itemsList.Add(loadedItem);




                }

                i++;

            }
            return itemsList;
        }
        public static List<Potions> LoadPotions()
        {
            List<Potions> potionsList = new List<Potions>();


            StreamReader inputFile;
            inputFile = File.OpenText("Potions.csv");
            int i = 0;
            while (!inputFile.EndOfStream)
            {
                string line = inputFile.ReadLine();
                if (i != 0)
                {

                    string[] words = line.Split(',');

                    string id = words[0];
                    string name = words[1];
                    string desc = words[2];
                    string input = words[3];
                    int hp = int.Parse(input);

                    Potions loadedPotion = new Potions(id, name, desc, hp);
                    potionsList.Add(loadedPotion);




                }

                i++;

            }
            return potionsList;
        }

        public static List<Mobs> LoadMobs()
        {
            List<Mobs> mobsList = new List<Mobs>();


            StreamReader inputFile;
            inputFile = File.OpenText("Mobs.csv");
            int i = 0;
            while (!inputFile.EndOfStream)
            {
                string line = inputFile.ReadLine();
                if (i != 0)
                {

                    string[] words = line.Split(',');

                    string id = words[0];
                    string name = words[1];
                    string desc = words[2];
                   
                    int hp = int.Parse(words[3]);
                    
                    int attack = int.Parse(words[4]);

                    Mobs loadedMobs = new Mobs(id, name, desc, hp, attack, words[5]) ;
                    mobsList.Add(loadedMobs);




                }

                i++;

            }
            return mobsList;
        }
    }
}
