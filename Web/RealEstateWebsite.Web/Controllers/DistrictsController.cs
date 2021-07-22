namespace RealEstateWebsite.Web.Controllers
{

    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Data;
    using RealEstateWebsite.Web.ViewModels.Districts;

    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext data;

        public DistrictsController(ApplicationDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IActionResult All()
        {
            var districts = this.data.Districts
                .Select(d => new AllDistrcitsViewModel
                {
                    Name = d.Name,
                    TotalProperties = d.Properties.Count(),
                })
                .OrderBy(t => t.Name)
                .ToList();

            return this.View(districts);
        }
    }
}
