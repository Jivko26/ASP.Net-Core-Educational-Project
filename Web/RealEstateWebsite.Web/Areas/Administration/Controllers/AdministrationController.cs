namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using RealEstateWebsite.Common;
    using RealEstateWebsite.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
