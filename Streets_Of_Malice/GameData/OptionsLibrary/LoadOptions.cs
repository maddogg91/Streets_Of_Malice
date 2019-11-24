using System;
using System.IO;
using System.Linq;
using CharacterLibrary;
using ItemLibrary;
using System.Collections.Generic;

namespace OptionsLibrary
{
    public class LoadOptions
    {


        //LOAD PLAYER INFO
        public static GameObjects InitializeObjects(Player player)
        {
            return GameObjects.GetObjects(LoadMobs(player.Name), LoadRooms(player.Name), LoadItems(player.Name), LoadPotions(player.Name), LoadTreasures(player.Name), LoadWeapons(player.Name), player);
        }



        public static GameObjects LoadObjects(string name)
        {
            Player player = Player.GetPlayer(" ", " ", Player.Classes.Brawler, Player.Body.Athletic, "R1");
            StreamReader inputFile;
            string input = " ";
            GameObjects options = new GameObjects();
            if (name == " ")
            {

                Console.Write("\nEnter the player's name: ");
                input = Console.ReadLine();
                string inputFileName = input + ".save";
                string folder = Environment.CurrentDirectory;
                try
                {

                    inputFile = File.OpenText($"{folder}/save/{input}/{inputFileName}");
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
                    Player.Body type = Player.Body.Athletic;
                    switch (input)
                    {
                        case "Athletic":
                            type = Player.Body.Athletic;
                            break;

                        case "Body Builder":
                            type = Player.Body.BodyBuilder;
                            break;

                        case "Fat":
                            type = Player.Body.Fat;
                            break;

                        case "Skinny":
                            type = Player.Body.Skinny;
                            break;




                    }

                    player = Player.GetPlayer(user, password, userClass, type, "R1");
                    options = GameObjects.GetObjects(LoadMobs(user), LoadRooms(user), LoadItems(user), LoadPotions(user), LoadTreasures(user), LoadWeapons(user), player);
                    inputFile.Close();
                    return options;
                }
                catch (FileNotFoundException)
                {
                    Console.Write("\nFile not found\nWould you like to start a new game or exit?\n>");
                    input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "new game":
                            player = GameOptions.NewPlayer();
                            GameOptions.CreateUserOptions(player.Name);
                            options = LoadObjects(player.Name);
                            break;

                        default:
                            Environment.Exit(0);
                            break;

                    }

                  
                }
            }
           

            return options;
        }

        


        //LOAD ROOMS
        public static List<Rooms> LoadRooms(string user)
        {
            int i = 0;
            Rooms room = Rooms.GetRooms(" ", " ", " ", " ", " ", " ", " ");
            List<Rooms> rooms = new List<Rooms>();
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText($"{Environment.CurrentDirectory}/save/{user}/{user}-Rooms.data");
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
                        room = Rooms.GetRooms(roomID, roomName, exitN, exitS, exitW, exitE, words[6]);
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
                    room = Rooms.GetRooms(roomIDs[i], roomNames[i], exitN[i], exitS[i], exitW[i], exitE[i], "filler");
                    rooms.Add(room);
                }
                return rooms;
            }

        }



        //LOAD WEAPON INFO
        public static List<Weapons> LoadWeapons(string user)
        {
            List<Weapons> weaponList = new List<Weapons>();


            StreamReader inputFile;
            inputFile = File.OpenText($"{Environment.CurrentDirectory}/save/{user}/{user}-Weapons.data");
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
                    string room = words[4];
                    Weapons loadedWeapon = Weapons.GetWeapons(id, weapon, desc, damage, room );
                    
                    weaponList.Add(loadedWeapon);
                    weaponList.OrderBy(x => x.Name);



                }

                i++;

            }
            
            return weaponList;
        }

       


        //LOAD ITEMS INFO
        public static List<Items> LoadItems(string user)
        {
            List<Items> itemsList = new List<Items>();


            StreamReader inputFile;
            inputFile = File.OpenText($"{Environment.CurrentDirectory}/save/{user}/{user}-Items.data");
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
                    string room = words[4];

                    Items loadedItem = Items.GetItems(id, name, desc, uses, room);
                    itemsList.Add(loadedItem);




                }

                i++;

            }
            return itemsList;
        }
        public static List<Potions> LoadPotions(string user)
        {
            List<Potions> potionsList = new List<Potions>();


            StreamReader inputFile;
            inputFile = File.OpenText($"{Environment.CurrentDirectory}/save/{user}/{user}-Potions.data");
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
                    string room = words[4];

                    Potions loadedPotion = Potions.GetPotions(id, name, desc, hp, room);
                    potionsList.Add(loadedPotion);




                }

                i++;

            }
            return potionsList;
        }

        public static List<Mobs> LoadMobs(string user)
        {
            List<Mobs> mobsList = new List<Mobs>();


            StreamReader inputFile;
            inputFile = File.OpenText($"{Environment.CurrentDirectory}/save/{user}/{user}-Mobs.data");
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

                    Mobs loadedMobs = Mobs.GetMobs (id, name, desc, hp, attack, words[5]) ;
                    mobsList.Add(loadedMobs);




                }

                i++;

            }
            return mobsList;
        }

        public static List<Treasures> LoadTreasures(string user)
        {
            List<Treasures> treasureList = new List<Treasures>();


            StreamReader inputFile;
            inputFile = File.OpenText($"{Environment.CurrentDirectory}/save/{user}/{user}-Treasures.data");
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
                    string room = words[3];

                    

                    Treasures loadedTreasures = Treasures.GetTreasures(id, name, desc, room);
                    treasureList.Add(loadedTreasures);




                }

                i++;

            }
            return treasureList;
        }
    }
}
