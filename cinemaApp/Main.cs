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
                    int[] exludeLarge = new int[] { 4, 3, 3, 3, 3, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 3, 3, 5, 7, 8 };
                    int[] vipExcludeLarge = { 30, 9, 8, 8, 7, 7, 6, 6, 5, 5, 6, 7, 8, 8, 9, 10, 12, 30, 30, 30 };
                    int[] excludeLarge = { 30, 30, 30, 30, 13, 12, 11, 11, 11, 11, 11, 11, 13, 30, 30, 30, 30, 30, 30, 30 };
                    movieRooms.createRoom(30, 20, exludeLarge, vipExcludeLarge, excludeLarge, 12.50);
                    int[] exludeMedium = { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3 };
                    int[] vipExcludeMedium = { 18, 6, 5, 5, 4, 4, 3, 3, 2, 2, 2, 3, 4, 5, 6, 6, 18, 18, 18 };
                    int[] excludeMedium = { 18, 18, 18, 18, 18, 8, 7, 6, 6, 6, 6, 7, 8, 18, 18, 18, 18, 18, 18 };
                    movieRooms.createRoom(18, 19, exludeMedium, vipExcludeMedium, excludeMedium, 12.50);
                    int[] exludeSmall = { 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2 };
                    int[] vipExcludeSmall = { 12, 12, 12, 5, 4, 3, 3, 3, 3, 4, 5, 12, 12, 12 };
                    int[] excludeSmall = { 12, 12, 12, 12, 12, 5, 5, 5, 5, 12, 12, 12, 12, 12 };
                    movieRooms.createRoom(12, 14, exludeSmall, vipExcludeSmall, excludeSmall, 12.50);
                }
            }
            catch (FileNotFoundException)
            {
                int[] exludeLarge = new int[] { 4, 3, 3, 3, 3, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 3, 3, 5, 7, 8 };
                int[] vipExcludeLarge = { 30, 9, 8, 8, 7, 7, 6, 6, 5, 5, 6, 7, 8, 8, 9, 10, 12, 30, 30, 30 };
                int[] excludeLarge = { 30, 30, 30, 30, 13, 12, 11, 11, 11, 11, 11, 11, 13, 30, 30, 30, 30, 30, 30, 30 };
                movieRooms.createRoom(30, 20, exludeLarge, vipExcludeLarge, excludeLarge, 12.50);
                int[] exludeMedium = { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3};
                int[] vipExcludeMedium = { 18, 6, 5, 5, 4, 4, 3, 3, 2, 2, 2, 3, 4, 5, 6, 6, 18, 18, 18 };
                int[] excludeMedium = { 18, 18, 18, 18, 18, 8, 7, 6, 6, 6, 6, 7, 8, 18, 18, 18, 18, 18, 18 };
                movieRooms.createRoom(18, 19, exludeMedium, vipExcludeMedium, excludeMedium, 12.50);
                int[] exludeSmall = { 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2 };
                int[] vipExcludeSmall = { 12, 12, 12, 5, 4, 3, 3, 3, 3, 4, 5, 12, 12, 12 };
                int[] excludeSmall = { 12, 12, 12, 12, 12, 5, 5, 5, 5, 12, 12, 12, 12, 12 };
                movieRooms.createRoom(12, 14, exludeSmall, vipExcludeSmall, excludeSmall, 12.50);
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The input you gave is incorrect.\nPlease try a number that is shown on screen.");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(2500);
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The input you gave is incorrect.\nPlease try a number that is shown on screen.");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }
      
        
        }

    }



