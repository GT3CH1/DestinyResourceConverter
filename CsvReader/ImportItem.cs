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
        public string MacAddr { get; private set; }

        /// <summary>
        /// Creates a new import item.
        /// </summary>
        /// <param name="serial">The serial number of this item.</param>
        /// <param name="macAddr">The mac address of this item.</param>
        public ImportItem(string serial, string macAddr)
        {
            SerialNumber = serial;
            MacAddr = macAddr;
        }
    }
}