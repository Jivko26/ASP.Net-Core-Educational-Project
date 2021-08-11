namespace RealEstateWebsite.Services.Data.ServiceModels.Viewings
{
    using System;

    public class AllViewingsServiceModel
    {
        public int ViewingId { get; set; }

        public string ViewingsPropertyImageUrl { get; set; }

        public string ViewingsPropertyType { get; set; }

        public string ViewingsPropertyDistrict { get; set; }

        public string ViewingsPropertyAddress { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
