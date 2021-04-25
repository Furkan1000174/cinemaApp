using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
        public class Account
        {
            public string ID { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public override string ToString()
            {
                return string.Format("Account information:\n\tID: {0}, Username: {1}, Password: {2}", ID, username, password);
            }
        }

}
