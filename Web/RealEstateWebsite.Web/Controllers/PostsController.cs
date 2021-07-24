namespace RealEstateWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Common;

    public class PostsController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult All(string districtName)
        {
            return this.View();
        }

        public IActionResult All(int agentId)
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Create(string smth)
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Delete(int postId)
        {
            return this.View();
        }
    }
}
