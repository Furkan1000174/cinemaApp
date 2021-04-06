using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cinemaApp
{
    class Program
    {

        public class Account
        {
            public string ID { get; set; }
            public string username { get; set; }
            public string password { get; set; }

            public override string ToString()
            {
                return string.Format("Account information:\n\tID: {0}, Username: {1}, Password: {2}", ID, username, password);
            }
        }

        private static bool accountchecker(string enteredUsername, string enteredPassword, Account accountToCheck) { //checks the login info
            if (accountToCheck.username == enteredUsername && accountToCheck.password == enteredPassword)
            {
                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            //Welcome screen
            while (true) {
                Console.WriteLine("Welcome to Pathé Movie Theatre!\n What would you like to do? \n1. Login \n2. Register\n3. Continue as guest\n");
                string options = Console.ReadLine();
               try {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            loginScreen();
                            break;
                        case 2:
                            //Register moet nog maken
                            //registerScreen();
                            break;
                        case 3:
                            mainScreen();
                            break;
                        default:
                            Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception) {
                    Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                }
            }
        }
        private static void createAccountScreen() //creates an account and adds it to the json file
        {
            Console.WriteLine("Please enter your first name: ");
            string accountID = Console.ReadLine();
            Console.WriteLine("Please choose your username: ");
            string accountUsername = Console.ReadLine();
            Console.WriteLine("Please choose your password: ");
            string accountPassword = Console.ReadLine();

            Account newAccount = new Account()
            {
                ID = accountID,
                username = accountUsername,
                password = accountPassword

            };

            string strNewaccountJson = JsonConvert.SerializeObject(newAccount);
            using (StreamWriter sw = File.AppendText(@"accounts.json"))
            {
                sw.WriteLine(strNewaccountJson);
                sw.Close();

            }
            Console.WriteLine("Account created!");

            loginScreen();
        }

        private static void loginScreen()
        {
            var logginIn = true;
            while (logginIn)
            {
                Console.WriteLine("Please enter your username: ");
                string enteredUsername = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                string enteredPassword = Console.ReadLine();

                Account tempAccount = new Account()
                {
                    ID = "firstID",
                    username = "firstUser",
                    password = "firstPass"

                };//Dont delete, this becomes a placeholder in the next line
                Account accountToCheck = tempAccount;
                List<String> jsonContents = new List<String> { };
                foreach (string line in File.ReadLines(@"accounts.json")) //Creates a list with every object from json file
                {
                    jsonContents.Add(line);
                }
                var accountList = new List<Account> { };
                foreach (String account in jsonContents)
                { //converts previous string list to account list
                    accountList.Add(JsonConvert.DeserializeObject<Account>(account));

                }


                foreach (var account in accountList) //looks up the account that the user is trying to login with...
                {
                    if (account.username == enteredUsername)
                    {
                        accountToCheck = account;//...and stores it in accountToCheck when found
                    }
                }
                //Console.WriteLine(accountToCheck); //can be used to check what account is found

                if (accountchecker(enteredUsername, enteredPassword, accountToCheck) == true)
                { //gives accountToCheck to the accountchecker
                    if (enteredUsername == "admin" && enteredPassword == "adminPass")
                    {
                        //adminScreen();
                        break;

                    }
                    else if (enteredUsername != "admin")
                    {
                        Console.WriteLine("Login Successful, welcome! c:");
                        mainScreen();
                        logginIn = false;
                    }

                }
                else
                {
                    Console.WriteLine("Password or Username is incorrect...");
                }
            }
        }
        private static void mainScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            //TODO: Maak functie dat checkt of je user of guest bent, als je user bent zeg je hoi user anders zeg je gwn hoi
            string h = "/// Hello, user  ///\n";
            Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
            Console.WriteLine(h);
            Console.ResetColor();
            Console.WriteLine("Please enter the number of what you would like to do:\n1. View movies\n2. View reviews\n3. View catering\n4. View Schedule\n");
            //TODO: Maak Admin opties (if statement om te checken of de ingelogde gebruiker een admin is, dan deze opties laten zien)
            //Console.Writeline("5. Manage movies\n6. Manage reservations\n7. Manage catering\n8.  Manage Schedule");
            string options = Console.ReadLine();
            try {
                int number = Int32.Parse(options);
                switch (number)
                {
                    case 1:
                        //movieScreen();
                        break;
                    case 2:
                        //TODO: Maak review screen
                        //reviewScreen();
                        break;
                    case 3:
                        //TODO: Maak Catering Screen
                        //cateringScreen();
                        break;
                    case 4:
                        Schedule();
                        break;
                    case 5:
                    //TODO: Maak Manage Movies Scherm
                    //adminMovieScreen();
                    //break;
                    case 6:
                    //TODO: Maak Manage Reservation Scherm
                    //adminReservationScreen();
                    //break;
                    case 7:
                    //TODO: Maak Catering Manage Scherm
                    //adminCateringScreen();
                    //break;
                    case 8:
                    //TODO: Maak Schedule Manage Scherm
                    //adminScheduleScreen();
                    //break;
                    default:
                        Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                        break;
                }
            }
            catch (Exception) {
                Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
            }
        }

        //Voor nu is dit wel oké maar dit gaan we met Json + classes doen zodat ik er geen ziektes meer van oploop
        private static void Schedule()
        {
            Console.Clear();
            Console.WriteLine("Minari:\n 19:00 | 21:00 | 23:00 | 01:00 | 03:00\n");
            Console.WriteLine("Sound of metal:\n 18:30 | 20:30 | 22:30 | 00:30 | 02:00\n");
            Console.WriteLine("Normadland:\n 18:00 | 22:00 | 22:30 | 01:00 | 02:00\n");
            Console.WriteLine("Another round:\n 13:00| 15:30 | 19:00 | 21:00 | 23:00 | 03:00 |\n");
            Console.WriteLine("The Father:\n 12:45 | 15:00 | 19:00 | 21:00 | 23:00\n");




            Console.WriteLine("Do you want to go to the film selection screeen? y/n: ");

            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "y")
            {

                //FilmInfoScreen();
            }
            else if (confirmation.ToLower() == "n")
            {
                //mainScreen();
            }
            else
            {
                //Schedule();
            }

        }
           private static void FilmInfoScreen()
            {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// FILM SELECTION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
                    while (true)
                                {

                Console.WriteLine(@"These are the available movies of our theatre:
                1. Minari
                2. Sound of Metal
                3. Nomadland
                4. Another round
                5. The Father
                Enter the number of the movie you would like to get more information of: ");

                var options = Console.ReadLine();
                if (options == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    string s = "/// MINARI ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama\nLanguage: Korean/English\nRuntime: 2h(120min)\nAge Rating: 12\nIMDb: 7.6\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("A Korean family starts a farm in 1980s Arkansas.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet");
                        Console.Read();
                        FilmInfoScreen();
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        FilmInfoScreen();
                    }

                }
                else if (options == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string s = "/// SOUND OF METAL ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama/Music\nLanguage: English/American Sign Language/French\nRuntime: 2h(120min)\nAge Rating: 16\nIMDb: 7.8\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("A heavy-metal drummer's life is thrown into freefall when he begins to lose his hearing.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet");
                        Console.Read();
                        FilmInfoScreen();
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        FilmInfoScreen();
                    }

                }
                else if (options == "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string s = "/// NOMADLAND ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama\nLanguage: English\nRuntime: 1h47m (107min)\nAge Rating: 12\nIMDb: 7.6\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("After losing everything in the Great Recession,\na woman embarks on a journey through the American West,\nliving as a van-dwelling modern-day nomad.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet");
                        Console.Read();
                        FilmInfoScreen();
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        FilmInfoScreen();
                    }
                }

                else if (options == "4")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string s = "/// ANOTHER ROUND ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama/Comedy\nLanguage: Danish/Swedish\nRuntime: 1h57m (117min)\nAge Rating: 12\nIMDb: 7.8\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("Four friends, all high school teachers,\ntest a theory that they will improve their lives by maintaining a constant level of alcohol in their blood.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet");
                        Console.Read();
                        FilmInfoScreen();
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        FilmInfoScreen();
                    }
                }
                else if (options == "5")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string s = "/// THE FATHER ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama\nLanguage: English\nRuntime: 1h37m (97min)\nAge Rating: 12\nIMDb: 8.3\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("A man refuses all assistance from his daughter as he ages.\nAs he tries to make sense of his changing circumstances, he begins to doubt his loved ones,\nhis own mind and even the fabric of his reality.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet");
                        Console.Read();
                        FilmInfoScreen();
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        FilmInfoScreen();
                    }

                } 
            }
        }
            
    }
        
}

