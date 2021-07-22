﻿namespace RealEstateWebsite.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Data;
    using RealEstateWebsite.Web.ViewModels.Agencies;

    public class AgenciesController : Controller
    {
        private readonly ApplicationDbContext data;

        public AgenciesController(ApplicationDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IActionResult All()
        {
            var agencies = this.data.RealEstateAgents
                .Select(a => new AllAgenciesViewModel
                {
                    Name = a.Name,
                    Description = a.Description,
                    Address = a.OfficeLocation,
                    Email = a.ContactEmail,
                    PhoneNumber = a.Telephone,
                    TotalPropertiesCount = a.Properties.Count(),
                })
                .OrderByDescending(ea => ea.TotalPropertiesCount)
                .ToList();

            return this.View(agencies);

        }
    }
}
