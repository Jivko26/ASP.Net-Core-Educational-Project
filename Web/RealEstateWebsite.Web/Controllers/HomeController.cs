namespace RealEstateWebsite.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data.Interfaces;
    using RealEstateWebsite.Web.ViewModels;
    using RealEstateWebsite.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IPropertiesService propertiesService;
        private readonly IStatisticsService statisticsService;

        public HomeController(IPropertiesService propertiesService, IStatisticsService statisticsService)
        {
            this.propertiesService = propertiesService;
            this.statisticsService = statisticsService;
        }

        public IActionResult Index()
        {
            return this.View(new IndexSearchViewModel
            {
                Districts = this.propertiesService.GetPropertyDistricts(),
                Types = this.propertiesService.GetPropertiesTypes(),
                Statistics = this.statisticsService.GetStatistics(),
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
