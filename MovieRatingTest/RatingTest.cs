using Infrastructure.Data;
using Moq;
using MovieRatingCompolsutory.Core.ApplicationService;
using MovieRatingCompolsutory.Core.ApplicationService.Impl;
using MovieRatingCompolsutory.Core.DomainService;
using MovieRatingCompolsutory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieRatingTest
{
    public class RatingTest
    {
        private List<Rating> ratingList { get; set; }
        private readonly IRatingService ratingService;
        private readonly IRatingRepositoryFile ratingRepositoryFile;
        public RatingTest()
        {
            /*
            ratingRepositoryFile = new RatingsRepository();
            ratingService = new RatingServiceFile(ratingRepositoryFile);
            ratingList = ratingRepositoryFile.GetAll();
            */
        }

        [Fact]
        public void GetAverageRateOfMovieTest()
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{
                new Rating {Reviewer = 123, Movie = 321, Grade = 4, Date = DateTime.Now },
                new Rating{Reviewer = 124, Movie = 321, Grade = 2, Date = DateTime.Now  }
            };

            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);

            var expepected = 3;
            var actual = service.GetAverageRateOfMovie(321);


            Assert.Equal(expepected, actual);
        }
        [Theory]
        [InlineData(321,1,4)]
        [InlineData(321,1,2)]
        [InlineData(321,0,3)]
        [InlineData(3,0,3)]

        public void GetNumberOfRatesTest(int movie,int expected,int rate)
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{
                new Rating {Reviewer = 123, Movie = 321, Grade = 4, Date = DateTime.Now },
                new Rating{Reviewer = 124, Movie = 321, Grade = 2, Date = DateTime.Now  }
            };

            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);

            
            var actual = service.GetNumberOfRates(movie,rate);


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAverageRateFromReviewerTest() 
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{ 
                new Rating {Reviewer = 123, Movie = 321, Grade = 2, Date = DateTime.Now },
                new Rating{Reviewer = 123, Movie = 456, Grade = 2, Date = DateTime.Now  } 
            };

            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);

            var expepected = 2;
            var actual = service.GetAverageRateFromReviewer(123);


            Assert.Equal(expepected, actual);
        }
    }
}
