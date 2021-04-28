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


        private XmlDocument doc;
        private DateTime today;

        private List<ImportItem> ImportItems;

        /// <summary>
        /// Creates a new CsvReader.
        /// </summary>
        public CsvReader()
        {
            DestinyItems = new List<DestinyItem>();
            ImportItems = new List<ImportItem>();
            ReadFromItemInfo();
            today = DateTime.Today;
        }

        /// <summary>
        /// Reads item info from csv file to itemList.
        /// </summary>
        private void ReadFromItemInfo()
        {
            string path =
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                    "\\..\\..\\..\\..\\.\\Resources\\", "itemInfo.csv");
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

        public void CreateExportXML(string filePathToImport, bool idAsMac, bool macComment, string purchaseOrder,
            DestinyItem item)
        {
            ReadFromImport(filePathToImport, idAsMac);
            doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //"FSC-DestinyAssetImport"
            XmlElement destinyAssetImport = doc.CreateElement("FSC-Destiny-AssetImport");
            XmlAttribute assertImportVer = destinyAssetImport.Attributes.Append(doc.CreateAttribute("version"));
            assertImportVer.Value = "1";
            XmlAttribute assertImportDate = destinyAssetImport.Attributes.Append(doc.CreateAttribute("date"));
            assertImportDate.Value = today.Year.ToString() + today.Month.ToString() + today.Day.ToString();
            doc.AppendChild(destinyAssetImport);
            
            //Asset group
            XmlElement assetGroup = doc.CreateElement("AssetGroup");

            //AssetEntry
            XmlElement assetEntry = doc.CreateElement("AssetEntry");

            //OrganizationCode
            XmlElement organizationCode = doc.CreateElement("OrganizationCode");
            organizationCode.AppendChild(doc.CreateCDataSection("GSD"));
            assetEntry.AppendChild(organizationCode);
            //End - OrganizationCode

            //Template
            XmlElement template = doc.CreateElement("Template");
            template.AppendChild(doc.CreateCDataSection(item.Template));
            assetEntry.AppendChild(template);
            //End - Template

            CreateFieldElements(assetEntry, "Description", item.Model);
            CreateFieldElements(assetEntry, "Replacement Price", item.Price.ToString());
            CreateFieldElements(assetEntry, "Model", item.Description);
            CreateFieldElements(assetEntry, "Manufacturer", item.Manufacturer);

            foreach(ImportItem importItem in ImportItems)
                AddItem(importItem,item,assetEntry,purchaseOrder);
            
            //End - AssetEntry
            assetGroup.AppendChild(assetEntry);
            destinyAssetImport.AppendChild(assetGroup);
            

            doc.Save(@"..\..\..\..\Resources\test.xml");
        }

        private void AddItem(ImportItem theItem, DestinyItem destinyItem, XmlElement root,
            string order)
        {
            XmlElement item = doc.CreateElement("item");
            XmlElement barcode = doc.CreateElement("Barcode");
            XmlElement shortName = doc.CreateElement("SiteShortName");
            XmlElement status = doc.CreateElement("Status");
            XmlElement condition = doc.CreateElement("Condition");
            XmlElement districtID = doc.CreateElement("DistrictIdentifier");
            XmlElement price = doc.CreateElement("PurchasePrice");
            XmlElement acquired = doc.CreateElement("DateAcquired");
            XmlElement purchaseOrder = doc.CreateElement("PurchaseOrder");
            XmlElement lifespan = doc.CreateElement("ProjectedLife");
            XmlElement salvageValue = doc.CreateElement("SalvageValue");
            XmlElement serialNumber = doc.CreateElement("SerialNumber");
            XmlElement lastMaint = doc.CreateElement("LastPreventitiveMaintenanceDate");
            XmlElement home = doc.CreateElement("HomeLocation");
            XmlElement note = doc.CreateElement("ItemNote");

            // Create barcode
            appendCData(barcode, theItem.SerialNumber);
            appendCData(shortName, "wlkjr");
            appendCData(status, "Available");
            appendCData(condition, "New");
            appendCData(districtID, theItem.MacAddr);
            appendCData(price, destinyItem.Price.ToString());
            //TODO:
            // appendCData(acquired);
            appendCData(purchaseOrder, order);
            appendCData(lifespan, "5");
            appendCData(salvageValue, "0");
            appendCData(serialNumber, theItem.SerialNumber);
            //TODO:
            //appendCData maintenance

            XmlElement name = doc.CreateElement("Name");
            name.AppendChild(doc.CreateCDataSection("Student"));
            home.AppendChild(name);

            lastMaint.AppendChild(doc.CreateCDataSection(today.Year + "-" + today.Month + "-" + today.Day));
            //TODO : note.
            item.AppendChild(barcode);
            item.AppendChild(shortName);
            item.AppendChild(status);
            item.AppendChild(condition);
            item.AppendChild(districtID);
            item.AppendChild(price);
            item.AppendChild(purchaseOrder);
            item.AppendChild(lifespan);
            item.AppendChild(salvageValue);
            item.AppendChild(serialNumber);
            item.AppendChild(lastMaint);
            item.AppendChild(home);
            CreateFieldElements(item, "Item Description/Number", destinyItem.Description);
            root.AppendChild(item);
        }

        private void appendCData(XmlElement element, string data)
        {
            element.AppendChild(doc.CreateCDataSection(data));
        }

        /// <summary>
        /// Creates one of the field elements at the top of the document.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="root"></param>
        /// <param name="elemName"></param>
        /// <param name="data"></param>
        private void CreateFieldElements(XmlElement root, string elemName, string data)
        {
            // Begin "field"
            XmlElement field = doc.CreateElement("field");
            XmlElement name = doc.CreateElement("name");
            XmlElement xmldata = doc.CreateElement("data");
            name.AppendChild(doc.CreateCDataSection(elemName));
            xmldata.AppendChild(doc.CreateCDataSection(data));
            field.AppendChild(name);
            field.AppendChild(xmldata);
            root.AppendChild(field);
            // End "Field"
        }

        /// <summary>
        /// Reads the given file from import, and adds to ImportItem list.
        /// </summary>
        /// <param name="filePathToImport"></param>
        /// <param name="idAsMac"></param>
        private void ReadFromImport(string filePathToImport, bool idAsMac)
        {
            using (StreamReader reader = new StreamReader(filePathToImport))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    string serial, mac;
                    try
                    {
                        serial = values[0];
                        if (values.Length == 1)
                            mac = serial;
                        else
                            mac = values[1];
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    // "District ID as SN"
                    if (!idAsMac)
                        mac = serial;
                    ImportItems.Add(new ImportItem(serial, mac));
                }
            }
        }
    }
}