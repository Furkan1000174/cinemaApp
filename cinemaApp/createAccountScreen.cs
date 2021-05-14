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
        public static void Create(Account CurrentAccount) //creates an account and adds it to the json file
        {
           var creatingAccount = true;
            while (creatingAccount)
            {
                int id = 1;


                List<string> jsonContents = new List<String> { };
                foreach (string line in File.ReadLines(@"accounts.json")) //Creates a list with every object from json file
                {
                    jsonContents.Add(line);
                }
                var accountList = new List<Account> { };
                foreach (String account in jsonContents)
                { //converts previous string list to account list
                    accountList.Add(JsonConvert.DeserializeObject<Account>(account));

                }
                foreach (var account in accountList)
                {
                 if (account.ID >= id)
                 {
                  id = account.ID + 1;
                 }
                }
                Console.WriteLine("Please choose your username: ");
                string accountUsername = Console.ReadLine();
                    foreach (var account in accountList)
                    {
                        while (account.UserName == accountUsername)
                        {
                            Console.WriteLine("This username already exists. Please enter a different one.\nPlease choose your username:");
                            accountUsername = Console.ReadLine();
                        }   
                    }
                Console.WriteLine("Please choose your password. Enter a password containing at least 6 characters: ");

                string accountPassword = Console.ReadLine();
                while (accountPassword.Length < 6)
                {
                    Console.WriteLine("That was incorrect.\nPlease choose your password.Enter a password containing at least 6 characters:");
                    accountPassword = Console.ReadLine();

                }
                string accountRole = "User";
                Account newAccount = new Account(id, accountUsername, accountPassword, accountRole);

                string strNewaccountJson = JsonConvert.SerializeObject(newAccount);
                using (StreamWriter sw = File.AppendText(@"accounts.json"))
                {
                    sw.WriteLine(strNewaccountJson);
                    sw.Close();

                }
                Console.WriteLine("Account created!");

                loginScreen.Login(CurrentAccount);
            }
        }
    }
}
