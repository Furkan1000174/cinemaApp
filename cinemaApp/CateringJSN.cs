using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class CateringJSN
    {
        public string food { get; set; }
        public string drink { get; set; }
        public string size { get; set; }
        public string price { get; set; }
        public override string ToString()
        {
            return string.Format("\nFood: {0}\nDrink: {1}\nSize: {2}\nPrice(euro): {3}\n\n", food, drink, size, price);
        }
    }
}
