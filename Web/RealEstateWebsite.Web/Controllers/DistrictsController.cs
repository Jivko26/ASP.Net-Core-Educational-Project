namespace RealEstateWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data;

    public class DistrictsController : Controller
    {
        private readonly IDistrictsService districtsService;

        public DistrictsController(IDistrictsService districtsService)
            => this.districtsService = districtsService;


        public IActionResult All()
        {
            var districts = this.districtsService.GetAllDistricts();

            return this.View(districts);
        }
    }
}
