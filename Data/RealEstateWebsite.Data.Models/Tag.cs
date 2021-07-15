﻿namespace RealEstateWebsite.Data.Models
{

    using System.Collections.Generic;

    using RealEstateWebsite.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.Properties = new List<Property>();
        }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
