using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
        public class Account
        {
            public int ID { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }
            public string Role { get; set; }

        public Account(int id, string username, string password,string role)
        {
            ID = id;
            UserName = username;
            PassWord = password;
            Role = role;


        }

            public override string ToString() => string.Format("Account information:\n\tID: {0}, Username: {1}, Password: {2} Role:{3}", ID, UserName, PassWord,Role);
            
        }

}
