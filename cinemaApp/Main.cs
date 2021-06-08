using System;
using Newtonsoft.Json;
using System.IO;

namespace cinemaApp
{
    class Program
    {
        public static void Main()
        {
            try
            {
                if (new FileInfo(@"accounts.json").Length == 0)
                {
                    Account adminAccount = new Account(1, "Admin", "adminPass", "Admin");
                    string createAdminAcc = JsonConvert.SerializeObject(adminAccount);
                    using (StreamWriter sw = File.AppendText(@"accounts.json"))
                    {
                        sw.WriteLine(createAdminAcc);
                        sw.Close();

                    }
                }
            }
            catch(FileNotFoundException)
            {
                Account adminAccount = new Account(1, "Admin", "adminPass", "Admin");
                string createAdminAcc = JsonConvert.SerializeObject(adminAccount);
                using (StreamWriter sw = File.AppendText(@"accounts.json"))
                {
                    sw.WriteLine(createAdminAcc);
                    sw.Close();

                }
            }
            Account CurrentAccount = new Account(0, "Guest", "","");
            try
            {
                if (new FileInfo(@"room.json").Length == 0)
                {
                    int[] exlude = new int[] { 4, 3, 3, 3, 3, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 3, 3, 5, 7, 8 };
                    int[] exlude2 = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, };
                    int[] exlude3 = new int[] { 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, };
                    movieRooms.createRoom(30, 20, exlude,12.50);
                    movieRooms.createRoom(18, 19, exlude2, 15.00);
                    movieRooms.createRoom(12, 14, exlude3, 17.50);
                }
            }
            catch (FileNotFoundException)
            {
                int[] exlude = new int[] { 4, 3, 3, 3, 3, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 3, 3, 5, 7, 8 };
                movieRooms.createRoom(30,20,exlude,12.50);
            }
            //Welcome screen
            while (true)
            {
     
                Console.ForegroundColor = ConsoleColor.Cyan;
                string h = "Welcome to our Movie Theatre!\n\n";
                Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
                Console.WriteLine(h);
                Console.ResetColor();
                Console.WriteLine("What would you like to do?\n\n[1] Login \n[2] Create Account\n[3] Continue as guest\n");
                Console.WriteLine("Please enter a number on screen to perform the desired action.");
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            loginScreen.Login(CurrentAccount);
                            break;
                        case 2:
                            createAccountScreen.Create(CurrentAccount);
                            break;
                        case 3:
                            mainScreen.Show(CurrentAccount);
                            break;
                        default:
                            Console.WriteLine("The input you gave is incorrect.\nPlease try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\nThe input you gave is incorrect.\nPlease try a number that is shown on screen.");
                    System.Threading.Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }
      
        
        }

    }



