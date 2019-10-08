using System;
using System.Collections.Generic;
using System.Text;
using PlayerLibrary;
using ItemLibrary;
using System.IO;
using MobLibrary;
using System.Linq;

namespace OptionsLibrary
{
    public class GameOptions
    {
        public static void Startup()
        {
            Player player = new Player(" ", " ", Player.Classes.Brawler, Player.Type.Athletic, "R1");
            bool run = true;

            do
            {
                Console.WriteLine("Enter new game or load game");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
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
            List<Rooms> rooms = LoadOptions.LoadRooms();
            Rooms room = MakeRoom(rooms, player.RoomID);
            SearchCommands.ViewRoom(room.RoomName);
            GeneralCommands.CommandInput(player);
        }

     
      
        
        //Swap Rooms
        public static Rooms MakeRoom(List<Rooms> rooms, string roomID)
        {
            Rooms room = new Rooms(" ", " ", " ", " ", " ", " ", " ");
            foreach (Rooms element in rooms)
            {

                if (roomID == element.RoomID)
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
            Player player = new Player(user, password, userClass, type, "R1");
            SavePlayerInfo(player, player.RoomID);
            Console.WriteLine("\nConfirmed! \nPlayer: " + player.Username + "\nJob: " + player.UserClass);
            Console.ReadLine();
            return player;
        }


        public static void SavePlayerInfo(Player player, string roomID)
        {
            StreamWriter outputFile;
            string userClass = " ";
            string type = " ";
            switch (player.UserClass.ToString())
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

            switch (player.UserType.ToString())
            {
                case "Athletic":
                case "Skinny":
                case "Fat":
                    type = player.UserType.ToString();
                    break;

                case "BodyBuilder":
                    type = "Body Builder";
                    break;
            }


            string path = player.Username + ".txt";
            outputFile = File.CreateText(path);
            outputFile.WriteLine(player.Username);
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
