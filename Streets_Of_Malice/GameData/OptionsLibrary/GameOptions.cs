using System;
using System.Collections.Generic;
using System.Text;
using CharacterLibrary;
using InterfaceLibrary;
using ItemLibrary;
using System.IO;
using System.Linq;

namespace OptionsLibrary
{
    public class GameOptions
    {
        public static void Startup()
        {
            Player player = Player.GetPlayer(" ", " ", Player.Classes.Brawler, Player.Body.Athletic, "R1");
            GameObjects options = new GameObjects();
            bool run = true;

            do
            {
                
                Console.WriteLine("Enter new game or load game");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {

                    case "skip":
                        run = false;
                        
                        break;
                    case "new game":
                        player = NewPlayer();
                        CreateUserOptions(player.Name);
                        options = LoadOptions.InitializeObjects(player);
                        run = false;
                        break;

                    case "load game":
                        options = LoadOptions.LoadObjects(" ");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter only new game or load game");
                        break;
                }
            }
            while (run == true);

            StandardMessages.TitleCard();

          
            
            
            
           
           
            
            Rooms room = MakeRoom(options.Rooms, options.Player.RoomID);
            SearchCommands.ViewRoom(room.Name);

            GeneralCommands.CommandInput(options);
        }

        public static void CreateUserOptions(string user)
        {

           

            File.Copy($"{Environment.CurrentDirectory}/data/Weapons/Weapons.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Weapons.data", true);
            File.Copy($"{Environment.CurrentDirectory}/data/Items/Items.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Items.data", true);
            File.Copy($"{Environment.CurrentDirectory}/data/Weapons/Weapons.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Weapons.data", true);
            File.Copy($"{Environment.CurrentDirectory}/data/Potions/Potions.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Potions.data", true);
            File.Copy($"{Environment.CurrentDirectory}/data/Rooms/Rooms.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Rooms.data", true);
            File.Copy($"{Environment.CurrentDirectory}/data/Treasures/Treasures.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Treasures.data", true);
            File.Copy($"{Environment.CurrentDirectory}/data/Mobs/Mobs.csv", $"{Environment.CurrentDirectory}/save/{user}/{user}-Mobs.data", true);

        }
     
      
        
        //Swap Rooms
        public static Rooms MakeRoom(List<Rooms> options, string roomID)
        {
            Rooms room = Rooms.GetRooms(" ", " ", " ", " ", " ", " ", " ");
            foreach (Rooms element in options)
            {

                if (roomID == element.ID)
                {
                    room = element;
                }


            }

            return room;
        }



        //Create New Player
        public static Player NewPlayer()
        {
            bool validPassword = false;
            Console.Write("What's your name: ");
            string user = Console.ReadLine();
            string password = " ";
            Player.Classes userClass = Player.Classes.Brawler;
            Player.Body type = Player.Body.Athletic;
            do
            {
                Console.Write("\nEnter a password to load your game when you save your progress: ");
                string input = Console.ReadLine();
                if (input.Length < 7)
                {
                    Console.WriteLine("\nPassword needs to be at least seven characters");
                }

                else
                {
                    if (ContainsSpecialCharacter(input) == false)
                    {
                        Console.WriteLine("\nPassword must contain a special character: !@#$%^&*^&*()_-=`~+'");
                    }

                    else if (ContainsUppercase(input) == false)
                    {
                        Console.WriteLine("\nPassword must contain at least 1 uppercase letter");
                    }

                    else if (ContainsLowercase(input) == false)
                    {
                        Console.WriteLine("\nPassword must contain at least 1 lower letter");
                    }


                    else
                    {

                        password = input;
                        validPassword = true;

                    }
                }



            }
            while (validPassword == false);

            bool validClass = false;
            do
            {
                Console.Write("\nWhat's your class\nBrawler, Martial Artist, Soldier: ");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "brawler":
                        userClass = Player.Classes.Brawler;
                        validClass = true;
                        break;
                    case "martial artist":
                        userClass = Player.Classes.MartialArtist;
                        validClass = true;
                        break;
                    case "soldier":
                        userClass = Player.Classes.Soldier;
                        validClass = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid class please choose between Brawler, Martial Artist, or Soldier");
                        break;


                }
            }
            while (validClass == false);

            bool validType = false;
            do
            {
                Console.Write("\nWhat's your body type\nAthletic, Body Builder, Fat, or Skinny: ");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "athletic":
                        type = Player.Body.Athletic;
                        validType = true;
                        break;

                    case "body builder":
                        type = Player.Body.BodyBuilder;
                        validType = true;
                        break;
                    case "fat":
                        type = Player.Body.Fat;
                        validType = true;
                        break;
                    case "skinny":
                        type = Player.Body.Skinny;
                        validType = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid class please choose between Brawler, Martial Artist, or Soldier");
                        break;


                }
            }
            while (validType == false);
            Player player = Player.GetPlayer(user, password, userClass, type, "R1");
            SavePlayerInfo(player, player.RoomID);
            Console.WriteLine("\nConfirmed! \nPlayer: " + player.Name + "\nJob: " + player.Class);
            Console.ReadLine();
            return player;
        }


        public static void SavePlayerInfo(Player player, string roomID)
        {
            StreamWriter outputFile;
            string userClass = " ";
            string type = " ";
            switch (player.Class.ToString())
            {
                case "Brawler":
                    userClass = "Brawler";
                    break;

                case "Soldier":
                    userClass = "Soldier";
                    break;

                case "MartialArtist":
                    userClass = "Martial Artist";
                    break;


            }

            switch (player.BodyType.ToString())
            {
                case "Athletic":
                case "Skinny":
                case "Fat":
                    type = player.BodyType.ToString();
                    break;

                case "BodyBuilder":
                    type = "Body Builder";
                    break;
            }


            string path = player.UserName + ".save";
            string folder = Environment.CurrentDirectory;
            try
            {
                string[] files = Directory.GetFiles($"{Environment.CurrentDirectory}/save/{player.UserName}");
                bool prompt = true;

                do
                {
                    Console.Write("User exists, would you like to overwrite user or load user\n>");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "overwrite":
                            prompt = false;

                            Directory.CreateDirectory($"{folder}/save/{player.UserName}");
                            outputFile = File.CreateText($"{folder}/save/{player.UserName}/{path}");
                            outputFile.WriteLine(player.UserName);
                            outputFile.WriteLine(player.Password);
                            outputFile.WriteLine(userClass);
                            outputFile.WriteLine(type);
                            outputFile.WriteLine(roomID);
                            outputFile.Close();
                            break;

                        case "load":
                        case "load user":
                            Startup();
                            break;

                        default:
                            Console.WriteLine("Invalid entry");
                            break;

                    }
                } while (prompt == true);
               
            }
            catch(DirectoryNotFoundException)
            {
                Directory.CreateDirectory($"{folder}/save/{player.UserName}");
                outputFile = File.CreateText($"{folder}/save/{player.UserName}/{path}");
                outputFile.WriteLine(player.UserName);
                outputFile.WriteLine(player.Password);
                outputFile.WriteLine(userClass);
                outputFile.WriteLine(type);
                outputFile.WriteLine(roomID);
                outputFile.Close();
            }
            

        }






        public static bool ContainsUppercase(string input)
        {
            bool statement = false;
            char[] check = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            foreach (char letter in input)
            {
                if (check.Contains(letter))
                {

                    statement = true;
                }


            }
            return statement;


        }

        public static bool ContainsLowercase(string input)
        {
            bool statement = false;
            char[] check = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (char letter in input)
            {
                if (check.Contains(letter))
                {

                    statement = true;
                }


            }
            return statement;
        }

        public static bool ContainsSpecialCharacter(string input)
        {



            bool statement = false;
            char[] check = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=' };
            foreach (char letter in input)
            {
                if (check.Contains(letter))
                {

                    statement = true;
                }

            }
            return statement;
        }
    }

}
