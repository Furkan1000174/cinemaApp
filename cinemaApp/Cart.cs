using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Cart
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string Price { get; set; }
        
        
        public Cart(int id,string item, string price)
        {
            ID = id;
            Item = item;
            Price = price;
        }
        
        
        
        public override string ToString()
        {
            return string.Format("\n{0}Item: {1}\nPrice: {2}\n",Item,Price);
        }
    }
   
}
