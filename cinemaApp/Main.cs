﻿using System;
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
            movieRooms.createRoom();
            Account CurrentAccount = new Account(0, "", "","");
            //Welcome screen
            while (true)
            {
     
                Console.ForegroundColor = ConsoleColor.Cyan;
                string h = "Welcome to our Movie Theatre!\n\n";
                Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
                Console.WriteLine(h);
                Console.ResetColor();
                Console.WriteLine("What would you like to do?\n\n[1] Login \n[2] Create Account\n[3] Continue as guest\n");
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



