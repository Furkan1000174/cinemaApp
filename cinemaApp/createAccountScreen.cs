using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class createAccountScreen
    {
        public static void Create() //creates an account and adds it to the json file
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

            loginScreen.Login(Program.CurrentAccount);
        }
    }
}
