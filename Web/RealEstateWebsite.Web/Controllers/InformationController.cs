namespace RealEstateWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class InformationController : Controller
    {
        public IActionResult Guide()
        {
            return this.View();
        }

        public IActionResult SentViewing()
        {
            return this.View();
        }
    }
}
