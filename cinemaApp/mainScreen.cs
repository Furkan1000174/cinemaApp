﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class mainScreen
    {

    
    public static void Show(Account CurrentAccount)
    {
            Console.Clear();
            string h;
            Console.WriteLine(CurrentAccount.Role);
            Console.ForegroundColor = ConsoleColor.Red;
        //TODO: Maak functie dat checkt of je user of guest bent, als je user bent zeg je hoi user anders zeg je gwn hoi
        if(CurrentAccount.UserName == "")
            {
                h = "/// Hello, guest  ///\n";
            }
            else
            {
                h = "/// Hello, " + CurrentAccount.username + " ///\n";
            }
            Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
        Console.WriteLine(h);
        Console.ResetColor();
            if (CurrentAccount.UserName == "")
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n\n[1] View movies\n[2] View reviews\n[3] View catering\n[4] View Schedule\n[5] Go Back");
            }
            else
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n\n[1] View movies\n[2] View reviews\n[3] View catering\n[4] View Schedule\n[5] Log Out");
            }

            if(CurrentAccount.Role == "Admin")
            {
                Console.WriteLine("[6] Add movies\n[7] Manage reservations\n[8] Manage catering\n[9] Manage Schedule");
            }
        bool choosing = true;
            while (choosing)
            {
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            MovieInfoScreen.showMovies();
                            choosing = false;
                            break;
                        case 2:
                            //TODO: Maak review screen
                            //reviewScreen();
                            Console.WriteLine("Reviews are coming soon!");
                            break;
                        case 3:
                            CateringScreen.showCatering();
                            choosing = false;
                            break;
                        case 4:
                            Schedule.showSchedule();
                            choosing = false;
                            break;

                        case 5:
                            Console.Clear();
                            if (CurrentAccount.username == "")
                            {
                                choosing = false;
                                Console.WriteLine("See you, guest!");
                            }
                            else
                            {
                                choosing = false;
                                Console.WriteLine("See you," + CurrentAccount.username);
                            }
                            Program.Main();
                            break;
                        case 6:
                            createMovieScreen.createMovie();
                            choosing = false;
                            break;
                        case 7:
                            //TODO: Maak Manage Reservation Scherm
                            //adminReservationScreen();
                            //break;
                            Console.WriteLine("Reservations are coming soon!");
                            break;
                        case 8:
                            createCateringScreen.CateringCreate();
                            choosing = false;
                            break;
                        case 9:
                        //TODO: Maak Schedule Manage Scherm
                        //adminScheduleScreen();
                        //break;
                        default:
                            choosing = false;
                            Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                }
            }
    }
    }
}
