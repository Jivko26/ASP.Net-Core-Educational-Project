using System;

namespace RealEstateWebsite.Data.Common
{
    public class DataConstants
    {
        public class Property
        {
            public const int InteriorMaxLenght = 15;
            public const int InteriorMinLenght = 5;

            public const int AddressMaxLenght = 30;
            public const int AddressMinLenght = 10;

            public const int MinLivingArea = 0;
            public const int MaxLivingArea = 5000;

            public const int MaxRooms = 10;
            public const int MinRooms = 0;

            public const int MaxFloors = 10;
            public const int MinFloors = 0;

            public const int MinYear = 1970;
            public const int MaxYear = 2021;

            public const double MaxPrice = double.MaxValue;
            public const double MinPrice = 0;

        }

        public class EstateAgent
        {
            public const int NameMaxLenght = 50;

            public const int EmailMaxLenght = 50;

            public const int TelephoneMaxLenght = 30;

            public const int OfficeLocationMaxLenght = 50;
        }

        public class District
        {
            public const int NameMaxLenght = 20;
        }
    }
}
