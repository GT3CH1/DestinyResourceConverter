namespace DestinyConverter
{
    public class DestinyItem
    {
        public string Location { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Manufacturer { get; private set; }
        public double Price { get; private set; }

        public DestinyItem(string location, string name, string description, string manufacturer, double price)
        {
            Location = location;
            Name = name;
            Description = description;
            Manufacturer = manufacturer;
            Price = price;
        }

        /// <summary>
        /// Returns the CSV format of this Destiny Item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Location + "," + Name + "," + Description + "," + Manufacturer + "," + Price.ToString();
        }
    }
}