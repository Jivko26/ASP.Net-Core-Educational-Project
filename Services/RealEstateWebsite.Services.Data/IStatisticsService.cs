namespace RealEstateWebsite.Services.Data
{
    using RealEstateWebsite.Web.ViewModels.Statistics;

    public interface IStatisticsService
    {
        StatisticsViewModel GetStatistics();
    }
}
