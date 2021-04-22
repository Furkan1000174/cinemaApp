using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
        public class Account
        {
            public string ID { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }

        public Account(string id, string username, string password)
        {
            ID = id;
            UserName = username;
            PassWord = password;
        }

            public override string ToString()
            {
                return string.Format("Account information:\n\tID: {0}, Username: {1}, Password: {2}", ID, UserName, PassWord);
            }
        }

}
