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

            var expected = 2;
            var actual = service.GetAverageRateFromReviewer(123);


            Assert.Equal(expected, actual);
        }

        

        [Theory]
        [InlineData(321, 2)]
        [InlineData(154, 4)]
        public void GetNumberOfReviewsTest(int movie, int expected) 
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{
                new Rating {Reviewer = 123, Movie = 321, Grade = 4, Date = DateTime.Now },
                new Rating{Reviewer = 456, Movie = 321, Grade = 2, Date = DateTime.Now  },
                new Rating{Reviewer = 865, Movie = 154, Grade = 4, Date = DateTime.Now  },
                new Rating{Reviewer = 876, Movie = 154, Grade = 5, Date = DateTime.Now  },
                new Rating{Reviewer = 244, Movie = 154, Grade = 5, Date = DateTime.Now  },
                new Rating{Reviewer = 875, Movie = 154, Grade = 5, Date = DateTime.Now  },
                new Rating{Reviewer = 957, Movie = 790, Grade = 5, Date = DateTime.Now  },
                new Rating{Reviewer = 896, Movie = 790, Grade = 5, Date = DateTime.Now  },
                new Rating{Reviewer = 967, Movie = 790, Grade = 5, Date = DateTime.Now  }
            };

            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);

            var actual = service.GetNumberOfReviews(movie);


            Assert.Equal(expected, actual);
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

            var expected = 3;
            var actual = service.GetAverageRateOfMovie(321);


            Assert.Equal(expected, actual);
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
        public void GetNumberOfReviewsFromReviewerTest()
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{
                new Rating {Reviewer = 123, Movie = 321, Grade = 2, Date = DateTime.Now },
                new Rating{Reviewer = 123, Movie = 456, Grade = 2, Date = DateTime.Now  },
                new Rating{Reviewer = 103, Movie = 456, Grade = 2, Date = DateTime.Now  }
            };

            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);

            var expepected = 2;
            var actual = service.GetNumberOfReviewsFromReviewer(123);


            Assert.Equal(expepected, actual);
        }

        [Theory]
        [InlineData(123, 2, 2)]
        [InlineData(103, 2, 1)]
        public void GetNumberOfRatesByReviewerTest(int reviewer, int rate,int expected)
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{
                new Rating {Reviewer = 123, Movie = 321, Grade = 2, Date = DateTime.Now },
                new Rating{Reviewer = 123, Movie = 456, Grade = 2, Date = DateTime.Now  },
                new Rating{Reviewer = 103, Movie = 456, Grade = 2, Date = DateTime.Now  }
            };

            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);

            
            var actual = service.GetNumberOfRatesByReviewer(reviewer,rate);


            Assert.Equal(expected, actual);
        }

        
        [Fact]

        public void GetMoviesWithHighestNumberOfTopRatesTest()
        {
            Mock<IRatingRepositoryFile> repo = new Mock<IRatingRepositoryFile>();
            List<Rating> ratings = new List<Rating>{
                new Rating {Reviewer = 123, Movie = 321, Grade = 5, Date = DateTime.Now },
                new Rating{Reviewer = 123, Movie = 476, Grade = 2, Date = DateTime.Now  },
                new Rating{Reviewer = 103, Movie = 426, Grade = 1, Date = DateTime.Now  },
                new Rating{Reviewer = 113, Movie = 496, Grade = 4, Date = DateTime.Now  }
            };
            repo.Setup(r => r.GetAll()).Returns(() => ratings);
            IRatingService service = new RatingServiceFile(repo.Object);
            repo.Verify(m => m.GetAll(), Times.Once);
            List<int> actual = service.GetMoviesWithHighestNumberOfTopRates();


            List<int> expected = service.GetMoviesWithHighestNumberOfTopRates();

            Assert.Equal(expected,actual);
        }
        

    }
}
