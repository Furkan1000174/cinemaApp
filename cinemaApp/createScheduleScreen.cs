using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class createScheduleScreen
    {
        public static void createSchedule()
        {

            List<String> jsonContents = new List<String> { };
            foreach (string line in File.ReadLines(@"movies.json"))
            {
                jsonContents.Add(line);
            }
            var movieList = new List<CateringJSN> { };
            foreach (String movie in jsonContents)
            {
                movieList.Add(JsonConvert.DeserializeObject<CateringJSN>(movie));
            }


        }

    }
}
