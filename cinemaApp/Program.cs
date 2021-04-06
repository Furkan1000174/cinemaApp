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
            Console.WriteLine("Welcome to the cinema!");
            Console.WriteLine("Please enter what you would like to do: ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Continue as guest");
            Console.WriteLine("3. Create account");
            var options = Console.ReadLine();
            if (options == "1")
            {
                loginScreen();
            }
            else if (options == "2")
            {
                Console.WriteLine("Please enter your email");
                var guestMail = Console.ReadLine();
                mainScreen();
            }
            else if (options == "3")
            {
                createAccountScreen();
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

        private static void loginScreen() {
            var logginIn = true;
            while (logginIn) {
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
                foreach (String account in jsonContents ){ //converts previous string list to account list
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

            if (accountchecker(enteredUsername, enteredPassword, accountToCheck) == true) { //gives accountToCheck to the accountchecker
                if(enteredUsername == "admin" && enteredPassword == "adminPass")
                {
                    adminScreen();
                    break;
                        
                }
                else if (enteredUsername != "admin") {
                    Console.WriteLine("accountChecker returns true, going to mainscreen...");
                    mainScreen();
                    logginIn = false;
                }
                        
            }
            else {
                Console.WriteLine("pass or username is incorrect...");
            }
            }
        }
        private static void mainScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string h = "/// Welcome to our Cinema App ///\n";
            Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
            Console.WriteLine(h);
            Console.ResetColor();
            Console.WriteLine("Please enter the number of what you would like to do:\n");
            Console.WriteLine("1. View movies");
            Console.WriteLine("2. View reviews");
            Console.WriteLine("3. View catering");
            Console.WriteLine("4. View Schedule");
            var options = Console.ReadLine();
            if (options == "1")
            {
                FilmInfoScreen();
            }
            else if (options == "2")
            {
                Console.WriteLine("The review section is not available yet");
                Console.Read();
            }
            else if (options == "3")
            {
                Console.WriteLine("The catering section is not available yet");
                Console.Read();
            }
            else if (options == "4")
            {
                Schedule();
            }
            Console.WriteLine("4. Check Schedule");
            Console.WriteLine("5. Log Out");

            var option = Console.ReadLine();
            switch(option)
            {
                case "1":
                   // viewMovies();
                    break;
                case "2":
                  //  viewReviews();
                    break;
                case "3":
                  //  viewCatering();
                    break;
                case "4":
                  //  checkSchedule();
                    break;
                case "5":
                    exit();
                    break;
            }
        }
        private static void adminScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome administrator\n");
            Console.WriteLine("Please select what you would like to do\n");
            Console.WriteLine("1. Manage movies");
            Console.WriteLine("2. Manage reservations");
            Console.WriteLine("3. Manage catering");
            Console.WriteLine("4. Manage Schedule");
            Console.WriteLine("4. Check Schedule");
            Console.WriteLine("5. Log Out");
             
            var options = Console.ReadLine();
            switch(options)
            {
                case "1":
                   // manageMovies();
                    break;
                case "2":
                   // manageReservations();
                    break;
                case "3":
                  //  manageCatering();
                    break;
                case "4":
                   // checkSchedule();
                    break;
                case "5":
                    exit();
                    break;
            }
        }
        private static void Schedule()
        {
            Console.Clear();
            Console.WriteLine("Minari:\n 19:00 | 21:00 | 23:00 | 01:00 | 03:00\n");
            Console.WriteLine("Sound of metal:\n 18:30 | 20:30 | 22:30 | 00:30 | 02:00\n");
            Console.WriteLine("Normadland:\n 18:00 | 22:00 | 22:30 | 01:00 | 02:00\n");
            Console.WriteLine("Another round:\n 13:00| 15:30 | 19:00 | 21:00 | 23:00 | 03:00 |\n");
            Console.WriteLine("The Father:\n 12:45 | 15:00 | 19:00 | 21:00 | 23:00\n");
            Console.WriteLine("Do you want to go to the film selection screeen? y/n: ");
            var nis = Console.ReadLine();
            if (nis == "Y" | nis == "y")
            {
                
                FilmInfoScreen();
            }
            else if (nis == "N" | nis == "n")
            {
                mainScreen();
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
            Console.WriteLine("These are the available films of our theater:\n1. Minari\n2. Sound of Metal\n3. Nomadland\n4. Another round\n5. The Father\n");         
            var Filminf = true;
            while (Filminf)
            {
                Console.WriteLine("Type the number of the film you want to see more information about: ");
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

        private static void exit()
        {
            Console.WriteLine("Press enter to continue");
            string test = Console.ReadLine();
        }
    }
}