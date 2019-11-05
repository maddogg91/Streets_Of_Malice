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
            Player player = Player.GetPlayer(" ", " ", Player.Classes.Brawler, Player.Type.Athletic, "R1");
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
                        run = false;
                        break;

                    case "load game":
                        player = LoadOptions.LoadPlayer();
                        run = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter only new game or load game");
                        break;
                }
            }
            while (run == true);

            StandardMessages.TitleCard();

            //int roomid = Map.SwitchRoom(room);
            
            
            
           
           
            GameObjects options= GameObjects.GetObjects(LoadOptions.LoadMobs(), LoadOptions.LoadRooms(), LoadOptions.LoadItems(), LoadOptions.LoadPotions(), LoadOptions.LoadTreasures(), LoadOptions.LoadWeapons(), player);
            Rooms room = MakeRoom(options.Rooms, options.Player.RoomID);
            SearchCommands.ViewRoom(room.Name);

            GeneralCommands.CommandInput(options);
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
            Player.Type type = Player.Type.Athletic;
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
                        type = Player.Type.Athletic;
                        validType = true;
                        break;

                    case "body builder":
                        type = Player.Type.BodyBuilder;
                        validType = true;
                        break;
                    case "fat":
                        type = Player.Type.Fat;
                        validType = true;
                        break;
                    case "skinny":
                        type = Player.Type.Skinny;
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


            string path = player.UserName + ".txt";
            outputFile = File.CreateText(path);
            outputFile.WriteLine(player.UserName);
            outputFile.WriteLine(player.Password);
            outputFile.WriteLine(userClass);
            outputFile.WriteLine(type);
            outputFile.WriteLine(roomID);
            outputFile.Close();

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
