namespace RealEstateWebsite.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Data;

    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext data;

        public DistrictsController(ApplicationDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
