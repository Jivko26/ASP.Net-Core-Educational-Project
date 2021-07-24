namespace RealEstateWebsite.Web.Infrastructure
{
    using System.Security.Claims;

    using RealEstateWebsite.Common;

    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(GlobalConstants.AdministratorRoleName);

    }
}