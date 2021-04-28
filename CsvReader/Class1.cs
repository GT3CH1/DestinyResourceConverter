using System;
using System.Collections.Generic;
using System.IO;

namespace DestinyConverter
{
    public class CsvReader
    {

        /// <summary>
        /// The list that contains all of our resource items.
        /// </summary>
        public List<DestinyItem> DestinyItems { get; private set; }
        
        /// <summary>
        /// Creates a new CsvReader.
        /// </summary>
        public CsvReader()
        {
            DestinyItems = new List<DestinyItem>();
            ReadFromItemInfo();
        }

        /// <summary>
        /// Reads item info from csv file to itemList.
        /// </summary>
        public void ReadFromItemInfo()
        {
            var path = @"..\..\..\Resources\itemInfo.csv";
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    var location = values[0];
                    var item = values[1];
                    var description = values[2];
                    var manuf = values[3];
                    var price = double.Parse(values[4]);

                    DestinyItem newResources = new DestinyItem(location, item, description, manuf, price);
                    DestinyItems.Add(newResources);
                }
            }
        }
    }
}