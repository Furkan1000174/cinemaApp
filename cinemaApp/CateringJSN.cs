using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class CateringJSN
    {
        public int ID { get; set; }
        public string Food { get; set; }
        public string Drink { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        
        
        public CateringJSN(int id, string food, string drink, string size, string price)
        {
            ID = id;
            Food = food;
            Drink = drink;
            Size = size;
            Price = price;
        }
        
        
        public override string ToString()
        {
            return string.Format("\n[{0}]\nFood: {1}\nDrink: {2}\nSize: {3}\nPrice(euro): {4}\n\n", ID, Food, Drink, Size, Price);
        }
    }
}
