using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace cinemaApp
{
    class loginScreen
    {
        public static void Login(Account CurrentAccount)
        {
            var loggingIn = true;
            while (loggingIn)
            {
                Console.WriteLine("Please enter your username: ");
                string enteredUsername = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                string enteredPassword = null;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    enteredPassword += key.KeyChar;
                    
                }
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
                foreach (String account in jsonContents)
                { //converts previous string list to account list
                    accountList.Add(JsonConvert.DeserializeObject<Account>(account));

                }


                foreach (var account in accountList) //looks up the account that the user is trying to login with...
                {
                    if (account.username.ToLower() == enteredUsername.ToLower())
                    {
                        accountToCheck = account;//...and stores it in accountToCheck when found
                    }
                }
                //Console.WriteLine(accountToCheck); //can be used to check what account is found

                if (accountChecker.check(enteredUsername, enteredPassword, accountToCheck) == true)
                { //gives accountToCheck to the accountchecker
                        CurrentAccount.ID = accountToCheck.ID;
                        CurrentAccount.username = enteredUsername;
                        Console.WriteLine("Login Successful, welcome " + enteredUsername + "! c:");
                        System.Threading.Thread.Sleep(2000);
                        mainScreen.Show(CurrentAccount);
                        loggingIn = false;
                }
                else
                {
                    Console.WriteLine("Password or Username is incorrect...");
                    System.Threading.Thread.Sleep(1500);
                }
            }
        }
    }
}
