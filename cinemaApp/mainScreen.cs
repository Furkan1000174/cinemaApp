using System;
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
                h = "/// Hello, " + CurrentAccount.UserName + " ///\n";
            }
            Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
        Console.WriteLine(h);
        Console.ResetColor();
            if (CurrentAccount.UserName == "")
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n\n[1] View movies\n[2] View reviews\n[3] View catering\n[4] View Schedule\n[5] View Cart\n[6] Go Back");
            }
            else
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n\n[1] View movies\n[2] View reviews\n[3] View catering\n[4] View Schedule\n[5] View Cart\n[6] Log Out");
            }

            if(CurrentAccount.Role == "Admin")
            {
                Console.WriteLine("[7] Add movies\n[8] Manage reservations\n[9] Manage catering\n[10] Manage Schedule");
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
                            MovieInfoScreen.showMovies(CurrentAccount);
                            choosing = false;
                            break;
                        case 2:
                            //TODO: Maak review screen
                            //reviewScreen();
                            Console.WriteLine("Reviews are coming soon!");
                            break;
                        case 3:
                            CateringScreen.showCatering(CurrentAccount);
                            choosing = false;
                            break;
                        case 4:
                            Schedule.showSchedule(CurrentAccount);
                            choosing = false;
                            break;
                        case 5:
                            cartScreen.showCart(CurrentAccount);
                            choosing = false;
                            break;
                        case 6:
                            Console.Clear();
                            if (CurrentAccount.UserName == "")
                            {
                                choosing = false;
                                Console.WriteLine("See you, guest!");
                            }
                            else
                            {
                                choosing = false;
                                Console.WriteLine("See you," + CurrentAccount.UserName);
                            }
                            Program.Main();
                            break;
                        case 7:
                            createMovieScreen.createMovie(CurrentAccount);
                            choosing = false;
                            break;
                        case 8:
                            //TODO: Maak Manage Reservation Scherm
                            //adminReservationScreen();
                            //break;
                            Console.WriteLine("admin manage Reservations are coming soon!");
                            break;
                        case 9:
                            createCateringScreen.CateringCreate(CurrentAccount);
                            choosing = false;
                            break;
                        case 10:
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
