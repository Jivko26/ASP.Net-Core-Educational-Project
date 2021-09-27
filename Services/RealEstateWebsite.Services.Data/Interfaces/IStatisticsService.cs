namespace RealEstateWebsite.Services.Data.Interfaces
{
    using RealEstateWebsite.Web.ViewModels.Statistics;

    public interface IStatisticsService
    {
        StatisticsViewModel GetStatistics();
    }
}
