namespace DestinyConverter
{
    public class DestinyItem
    {
        public string Template { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string Manufacturer { get; private set; }
        public double Price { get; private set; }

        public DestinyItem(string template, string model, string description, string manufacturer, double price)
        {
            Template = template;
            Model = model;
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
            return Template + "," + Model + "," + Description + "," + Manufacturer + "," + Price.ToString();
        }
    }
}