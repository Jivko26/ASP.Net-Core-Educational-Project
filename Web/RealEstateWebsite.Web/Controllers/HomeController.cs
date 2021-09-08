namespace RealEstateWebsite.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Web.ViewModels;
    using RealEstateWebsite.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IPropertiesService propertiesService;

        public HomeController(IPropertiesService propertiesService)
            => this.propertiesService = propertiesService;

        public IActionResult Index()
        {
            return this.View(new IndexSearchViewModel
            {
                Districts = this.propertiesService.GetPropertyDistricts(),
                Types = this.propertiesService.GetPropertiesTypes(),
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
