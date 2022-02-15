using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

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
        private void ReadFromItemInfo()
        {
            string path =
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                    "\\..\\..\\..\\.\\Resources\\", "itemInfo.csv");
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    var location = values[0];
                    var item = values[1];
                    var description = values[2];
                    var manuf = values[3];
                    var price = (int)double.Parse(values[4]);

                    DestinyItem newResources = new DestinyItem(location, item, description, manuf, price);
                    DestinyItems.Add(newResources);
                }
            }
        }


        /// <summary>
        /// Reads the given file from import, and adds to ImportItem list.
        /// </summary>
        /// <param name="filePathToImport"></param>
        /// <param name="idAsMac"></param>
        public static List<ImportItem> ReadFromImport(string filePathToImport)
        {
            var ImportItems = new List<ImportItem>();

            bool idAsMac = Constants.IDAsMAC;
            bool hasBarcode = Constants.HasBarcode;
            using (StreamReader reader = new StreamReader(filePathToImport))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Length < 1)
                        continue;
                    var values = line.Split(',');
                    string serial = string.Empty;
                    string barcode = string.Empty;
                    string districtID = string.Empty;
                    if (hasBarcode)
                    {
                        try
                        {
                            barcode = values[0];
                            if (barcode.Equals("SN"))
                                continue;
                            serial = values[1];
                            districtID = values[2];
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        try
                        {
                            serial = values[0];
                            if (serial.Equals("SN"))
                                continue;
                            if (values.Length == 1)
                                districtID = serial;
                            else
                                districtID = values[1];
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    // "District ID as SN"
                    if (!idAsMac && !hasBarcode)
                        districtID = serial;
                    if (hasBarcode)
                        ImportItems.Add(new ImportItem(barcode, serial, districtID));
                    else
                        ImportItems.Add(new ImportItem(serial, districtID));
                }
            }

            return ImportItems;
        }
    }
}