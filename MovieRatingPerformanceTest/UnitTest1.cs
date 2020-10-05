using Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieRatingCompolsutory.Core.ApplicationService;
using MovieRatingCompolsutory.Core.ApplicationService.Impl;
using MovieRatingCompolsutory.Core.DomainService;

namespace MovieRatingPerformanceTest
{
    [TestClass]
    public class UnitTest1
    {
        static IRatingService service;
        
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var JsonList = new RatingsRepository().GetAll();
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();

            repo.Setup(r => r.GetAll()).Returns(() => JsonList);
            service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);
        }

        /*
        [TestMethod]
        [Timeout(40000)]
        public void LoadJson() 
        {
           var JsonList = new RatingsRepository().GetAll();
        }
        */

        
        [TestMethod]
        [Timeout(4000)]
        public void GetNumberOfReviewsFromReviewerPerformance()
        {
            service.GetNumberOfReviewsFromReviewer(25);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetAverageRateFromReviewerPerformance()
        {
            service.GetAverageRateFromReviewer(25);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetNumberOfRatesByReviewerPerformance()
        {
            service.GetNumberOfRatesByReviewer(25, 5);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetNumberOfReviewsPerformance()
        {
            service.GetNumberOfReviews(30878);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetAverageRateOfMoviePerformance()
        {
            service.GetAverageRateOfMovie(2442);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetNumberOfRatesPerfomance()
        {
            service.GetNumberOfRates(1080361,3);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetMoviesWithHighestNumberOfTopRatesPerformance()
        {
            service.GetMoviesWithHighestNumberOfTopRates();
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetMostProductiveReviewersPerformance()
        {
            service.GetMostProductiveReviewers();
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetTopRatedMoviesPerformance()
        {
            service.GetTopRatedMovies(5);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetTopMoviesByReviewerPerformance()
        {
            service.GetTopMoviesByReviewer(666);
        }

        [TestMethod]
        [Timeout(4000)]
        public void GetReviewersByMoviePerformance()
        {
            service.GetReviewersByMovie(253436);
        }
    }
}
