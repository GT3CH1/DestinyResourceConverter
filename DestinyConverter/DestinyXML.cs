using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DestinyConverter
{
    public class DestinyXML
    {
        private XmlDocument doc;
        private DateTime today;
        private List<ImportItem> ImportItems;

        public DestinyXML()
        {
            today = DateTime.Today;
            ImportItems = new List<ImportItem>();
        }

        public bool CreateExportXML(string filePathToImport, DestinyItem item)
        {
            ImportItems = CsvReader.ReadFromImport(filePathToImport);
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

            foreach (ImportItem importItem in ImportItems)
                AddItem(importItem, item, assetEntry);

            //End - AssetEntry
            assetGroup.AppendChild(assetEntry);
            destinyAssetImport.AppendChild(assetGroup);
            try
            {
                string path = Directory.GetParent(filePathToImport) + @"\DestinyConversion.xml";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    doc.Save(path);
                }
                else
                    doc.Save(path);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void AddItem(ImportItem theItem, DestinyItem destinyItem, XmlElement root)
        {
            bool additionalComment = Constants.HasAdditionalNote;
            bool hasMacComment = Constants.HasMacComment;
            var month = (today.Month < 10 ? "0" + today.Month : today.Month.ToString());
            var day = (today.Day < 10 ? "0" + today.Day : today.Day.ToString());
            string date = today.Year + "-" + month + "-" + day;
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
            XmlElement lastMaint = doc.CreateElement("LastPreventiveMaintenanceDate");
            XmlElement home = doc.CreateElement("HomeLocation");
            XmlElement note = doc.CreateElement("ItemNote");
            if (Constants.HasBarcode)
                appendCData(barcode, theItem.Barcode);
            else
                appendCData(barcode, theItem.SerialNumber);
            appendCData(shortName, "wlkjr");
            appendCData(status, Constants.CurrentStatus);
            appendCData(condition, Constants.Condition);
            appendCData(districtID, theItem.DistrictId);
            appendCData(price, destinyItem.Price.ToString());
            appendCData(purchaseOrder, Constants.PurchaseOrder);
            appendCData(lifespan, "5");
            appendCData(salvageValue, "0");
            appendCData(serialNumber, theItem.SerialNumber);
            XmlElement name = doc.CreateElement("Name");
            name.AppendChild(doc.CreateCDataSection("Student"));
            home.AppendChild(name);
            string comment = "";
            if (hasMacComment)
                comment += "MAC: " + theItem.DistrictId;
            if (additionalComment)
                comment += Constants.AdditionalNote;
            lastMaint.AppendChild(doc.CreateCDataSection(date));
            acquired.AppendChild(doc.CreateCDataSection(date));
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
            item.AppendChild(acquired);
            

            if (hasMacComment || additionalComment)
            {
                appendCData(note, comment);
                item.AppendChild(note);
            }

            CreateFieldElements(item, "Item Description/Number", destinyItem.Description);
            root.AppendChild(item);
        }

        /// <summary>
        /// Adds a CDATA section to the given element, with the provided data string.
        /// </summary>
        /// <param name="element">The element to add CDATA to.</param>
        /// <param name="data">The data to add.</param>
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
    }
}