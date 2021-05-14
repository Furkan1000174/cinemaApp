using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Security;
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



                //Ik heb de onzichtbare password nonsense eruitgehaald, hij weergeeft nu asterisks inplaats ervan
                //(ﾉ◕ヮ◕)ﾉ *:･ﾟ✧ ✧ﾟ･: *ヽ(◕ヮ◕ヽ)

                SecureString pass = maskInputString();
                string enteredPassword = new System.Net.NetworkCredential(string.Empty, pass).Password;
                Console.WriteLine("\n");

                static SecureString maskInputString()
                {
                    SecureString pass = new SecureString();
                    ConsoleKeyInfo keyInfo;
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                        if (!char.IsControl(keyInfo.KeyChar))
                        {
                            pass.AppendChar(keyInfo.KeyChar);
                            Console.Write("*");
                        }
                        else if(keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass.RemoveAt(pass.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    while (keyInfo.Key != ConsoleKey.Enter);
                    {
                        return pass;
                    }

                }
                try
                {
                    Account tempAccount = new Account(1, "firstUser", "firstPass", "User");
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
                        if (account.UserName.ToLower() == enteredUsername.ToLower())
                        {
                            accountToCheck = account;//...and stores it in accountToCheck when found
                        }
                    }
                    //Console.WriteLine(accountToCheck); //can be used to check what account is found

                    if (accountChecker.check(enteredUsername, enteredPassword, accountToCheck) == true)
                    { //gives accountToCheck to the accountchecker
                        CurrentAccount.ID = accountToCheck.ID;
                        CurrentAccount.UserName = enteredUsername;
                        CurrentAccount.Role = accountToCheck.Role;
                        Console.WriteLine("Login Successful, welcome! c:");
                        System.Threading.Thread.Sleep(2000);
                        mainScreen.Show(CurrentAccount);
                        loggingIn = false;
                    }
                    else
                    {
                        Console.WriteLine("Password or Username is incorrect...");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No accounts found please!\nPlease create a account first!");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    Program.Main();
                }
            }
        }
    }
}
