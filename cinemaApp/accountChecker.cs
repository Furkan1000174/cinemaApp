using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
        public class accountChecker
        {
            public static bool check(string enteredUsername, string enteredPassword, Account accountToCheck)
            { //checks the login info
                if (accountToCheck.username == enteredUsername && accountToCheck.password == enteredPassword)
                {
                    return true;
                }
                return false;
            }
        }
}
