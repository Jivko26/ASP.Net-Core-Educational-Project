namespace RealEstateWebsite.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data;

    public class AgenciesController : Controller
    {
        private readonly IAgenciesService agenciesService;

        public AgenciesController(IAgenciesService agenciesService)
            => this.agenciesService = agenciesService;

        public IActionResult All()
        {
            var agencies = this.agenciesService.GetAllAgencies();

            return this.View(agencies);

        }
    }
}
