using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Cart
    {
        public string item { get; set; }
        public string price { get; set; }
        public override string ToString()
        {
            return string.Format("\nItem: {0}\nPrice: {1}\n",item,price);
        }
    }
   
}
