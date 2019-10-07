using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ItemLibrary;
using PlayerLibrary;

namespace Streets_Of_Malice
{
    public class Options
    {

        public static void Startup()
        {
            Player player = new Player(" ", " ", Player.Classes.Brawler, Player.Type.Athletic);
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
                        player= LoadPlayer();
                        run = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter only new game or load game");
                        break;
                }
            }
            while (run == true);

            Standard_Messages.TitleCard();
            int roomid = Map.SwitchRoom("your apartment");

            Commands.CommandInput(roomid, player);
        }
        public static void SavePlayerInfo(Player player)
        {
            StreamWriter outputFile;
            string userClass= " ";
            string type= " ";
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
            outputFile.Close();

        }
        public static Player LoadPlayer()
        {
            Player player = new Player(" ", " ", Player.Classes.Brawler, Player.Type.Athletic);
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
                        Startup();
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
                Player.Classes userClass= Player.Classes.Brawler;
                switch(input)
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
                Player.Type type= Player.Type.Athletic;
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

               player = new Player(user, password, userClass, type);
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
                        player = NewPlayer();
                        break;

                    default:
                        System.Environment.Exit(0);
                        break;

                }
               
                return player;
            }
        }


        public static Player NewPlayer()
        {
            bool validPassword = false;   
            Console.Write("What's your name: ");
            string user = Console.ReadLine();
            string password= " ";
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
            Player player = new Player(user, password, userClass, type);
            SavePlayerInfo(player);
            Console.WriteLine("\nConfirmed! \nPlayer: " + player.Username + "\nJob: " + player.UserClass);
            Console.ReadLine();
            return player;
        }


        public static bool ContainsUppercase(string input)
        {
            bool statement = false;
            char[] check = { 'A', 'B', 'C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            foreach (char letter in input)
            {
                if (check.Contains(letter))
                {

                    statement= true;
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
            char[] check = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '='};
            foreach (char letter in input)
            {
                if (check.Contains(letter))
                {

                    statement = true;
                }

            }
            return statement;
        }

        public static void LoadPlayer(string user)
        {
            string output = user + ".txt";

        }

        public static List<Weapons> LoadWeapons()
        {
            List<Weapons> weaponList= new List<Weapons>();
            

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
                    Weapons loadedWeapon = new Weapons(weapon, desc, damage);
                    weaponList.Add(loadedWeapon);




                }

                i++;

            }
            return weaponList;
        }


        public static string[] SetRooms()
        {
            string[] Rooms = { "Your apartment", "Main Street", "Store Front", "Tunnel", "Dimly lit room", "Mayor's Office" };
            return Rooms;
        }

        public static List<Weapons> SetWeapons(List<Weapons> weapons)
        {
            return weapons;
        }

        public static List<string> SetItems()
        {
            List<string> Items = new List<string>() { "Store Front Key", "Golden Key", "Key to the City", "Smokebomb" };
            return Items;
        }

        public static List<string> SetMobs()
        {
            List<string> Mobs = new List<string>() { "Computer Programmers", "Main Street Manics", "Thieves", "Underground Gang", "Police" };
            return Mobs;
        }

        public static string[] SetPotions()
        {
            string[] Potions = { "Milk", "Energy" };
            
           
            

            return Potions;
        }

        public static string[] SetTreasures()
        {
            string[] Treasure = { "Gold Medal", "Silver Trophy", "Bronze Stamp" };

            return Treasure;
        }
    }
}
