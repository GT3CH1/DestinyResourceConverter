namespace DestinyConverter
{
    public class Constants
    {
        public static string PurchaseOrder;
        public static string AdditionalNote;
        public static string CurrentStatus = StatusConstants.AVAILABLE;
        public static string Condition = ConditionConstants.NEW;
        public static bool HasAdditionalNote;
        public static bool IDAsMAC;
        public static bool HasMacComment;
    }

    public class StatusConstants
    {
        public const string AVAILABLE = "Available";
        public const string IN_USE = "In Use";

        public static string[] CONSTANTS
        {
            get { return new[] {AVAILABLE, IN_USE}; }
            private set => value = value;
        }
    }

    public class ConditionConstants
    {
        public const string NEW = "New";
        public const string GOOD = "Good";
        public const string FAIR = "Fair";
        public const string POOR = "Poor";
        public const string USABLE = "Usable";
        public const string DAMAGED = "Damaged";
        public const string UNUSABLE = "Unusable";

        public static string[] CONSTANTS
        {
            get { return new[] {NEW, GOOD, FAIR, POOR, USABLE, DAMAGED, UNUSABLE}; }
            private set => value = value;
        }
    }
}