namespace RealEstateWebsite.Services.Data
{
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Web.ViewModels.Statistics;

    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext data;

        public StatisticsService(ApplicationDbContext data)
            => this.data = data;

        public StatisticsViewModel GetStatistics()
            => new StatisticsViewModel
            {
                TotalOffers = this.data.Posts.Count(),
            };
    }
}
