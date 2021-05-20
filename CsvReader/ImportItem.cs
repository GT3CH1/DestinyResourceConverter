namespace DestinyConverter
{
    public class ImportItem
    {
        /// <summary>
        /// The serial number of this item.
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// The mac address of this item.
        /// </summary>
        public string DistrictId { get; private set; }

        /// <summary>
        /// The barcode of this item.
        /// </summary>
        public string Barcode { get; private set; }

        /// <summary>
        /// Creates a new import item.
        /// </summary>
        /// <param name="serial">The serial number of this item.</param>
        /// <param name="districtID">The mac address of this item.</param>
        public ImportItem(string serial, string districtID)
        {
            SerialNumber = serial;
            DistrictId = districtID;
        }

        /// <summary>
        /// Creates a new import item.
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="serial"></param>
        /// <param name="districtID"></param>
        public ImportItem(string barcode, string serial, string districtID)
        {
            Barcode = barcode;
            SerialNumber = serial;
            DistrictId = districtID;
        }
    }
}