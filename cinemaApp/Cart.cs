using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Cart
    {
        public string Item { get; set; }
        public string Price { get; set; }
        
        
        public Cart(string item, string price)
        {
            Item = item;
            Price = price;
        }
        
        
        
        public override string ToString()
        {
            return string.Format("\nItem: {0}\nPrice: {1}\n",Item,Price);
        }
    }
   
}
