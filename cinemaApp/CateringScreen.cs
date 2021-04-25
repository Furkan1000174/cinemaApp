﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class CateringScreen
    {
        public static void showCatering()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string a = "/// CATERING ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string b = "Choose one of the available combo deals!!\n";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();
            int counter = 1;
            bool choosing = true;
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"catering.json")) 
                {
                    jsonContents.Add(line);
                }
                var cateList = new List<CateringJSN> { };
                foreach (String cate in jsonContents)
                {
                    cateList.Add(JsonConvert.DeserializeObject<CateringJSN>(cate));
                }
                foreach (var cate in cateList)
                {
                    Console.Write("[" + counter + "]");
                    counter++;
                    Console.WriteLine(cate);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo catering information found!\nPlease create a listing first!\n");
                System.Threading.Thread.Sleep(2000);
                Program.Main();
            }
            while (choosing)
            {
                Console.WriteLine("Would you like to reserve a combo deal?\n1. Yes\n2. No\n");
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("\nPlease enter the combo deal number\n");
                                string choice = Console.ReadLine();
                                int result = Int32.Parse(choice);
                                cateSelecter(result);
                                choosing = false;
                                break;
                            }
                            catch
                            {
                                showCatering();
                            }
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nYou will be send back to the mainscreen\n");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            mainScreen.Show(Program.CurrentAccount);
                            break;
                        default:
                            Console.WriteLine("The input you gave is incorrect.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number");
                }

            }
        }
        public static void cateSelecter(int option)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            string a = "/// YOUR COMBO DEAL ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            List<String> jsonContents = new List<String> { };
            try
            {

                foreach (string line in File.ReadLines(@"catering.json")) 
                {
                    jsonContents.Add(line);
                }
                var cateList = new List<CateringJSN> { };
                foreach (String cate in jsonContents)
                {
                    cateList.Add(JsonConvert.DeserializeObject<CateringJSN>(cate));
                }
                Console.WriteLine(cateList[option - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a number");
            }
        }
    }
}