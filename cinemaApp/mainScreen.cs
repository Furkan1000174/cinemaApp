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
        string h = "";
            Console.ForegroundColor = ConsoleColor.Red;
        //TODO: Maak functie dat checkt of je user of guest bent, als je user bent zeg je hoi user anders zeg je gwn hoi
        if(CurrentAccount.UserName == "")
            {
                h = "/// Hello, guest  ///\n";
            }
            else
            {
                h = "/// Hello, " + CurrentAccount.UserName + "///\n";
            }
            Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
        Console.WriteLine(h);
        Console.ResetColor();
            if (CurrentAccount.UserName == "")
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n1. View movies\n2. View reviews\n3. View catering\n4. View Schedule\n5. Go Back");
            }
            else
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n1. View movies\n2. View reviews\n3. View catering\n4. View Schedule\n5. Log Out");
            }

            if(CurrentAccount.UserName == "admin")
            {
                Console.WriteLine("5. Manage movies\n6. Manage reservations\n7. Manage catering\n8. Manage Schedule");
            }
        string options = Console.ReadLine();
        try
        {
            int number = Int32.Parse(options);
            switch (number)
            {
                case 1:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        //movieScreen();
                        break;
                case 2:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        //TODO: Maak review screen
                        //reviewScreen();
                        break;
                case 3:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        //TODO: Maak Catering Screen
                        //cateringScreen();
                        break;
                case 4:
                    Schedule.showSchedule(CurrentAccount);
                    break;
                    case 5:
                    Console.Clear();
                        if (CurrentAccount.UserName == "")
                        {
                            Console.WriteLine("See you, guest!");
                        }
                        else
                        {
                            Console.WriteLine("See you," + CurrentAccount.UserName);
                        }
                    Program.Main();
                    break;
                    case 6:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        break;
                    //TODO: Maak Manage Movies Scherm
                    //adminMovieScreen();
                    //break;
                    case 7:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        break;
                    //TODO: Maak Manage Reservation Scherm
                    //adminReservationScreen();
                    //break;
                    case 8:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        break;
                    //TODO: Maak Catering Manage Scherm
                    //adminCateringScreen();
                    //break;
                    case 9:
                        Console.WriteLine("This functionality has yet to be implemented, stay tuned!");
                        System.Threading.Thread.Sleep(2000);
                        Show(CurrentAccount);
                        break;
                    //TODO: Maak Schedule Manage Scherm
                    //adminScheduleScreen();
                    //break;
                    default:
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
