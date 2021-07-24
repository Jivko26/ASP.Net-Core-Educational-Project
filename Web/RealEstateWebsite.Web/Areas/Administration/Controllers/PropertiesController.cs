namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : AdministrationController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            return this.View();
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
