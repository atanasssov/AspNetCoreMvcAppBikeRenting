namespace BikeRenting.Common
{
    public static  class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 40;
        }

        public static class Bike
        {
            public const int TitleMinLength = 4;
            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 10;
            public const int AddressMaxLength = 120;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 500;

            public const int ImageUrlMaxLength = 2048;

            public const string PricePerMonthMinValue = "0";
            public const string PricePerMonthMaxValue = "5000";
        }

        public static class Agent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 18;
        }

        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 40;

        }
    }
}
