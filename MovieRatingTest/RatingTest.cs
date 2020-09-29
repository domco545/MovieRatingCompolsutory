using Infrastructure.Data;
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
            ratingRepositoryFile = new RatingsRepository();
            ratingService = new RatingServiceFile(ratingRepositoryFile);
            ratingList = ratingRepositoryFile.GetAll();
        }
        [Theory]
        [InlineData(822109)]
        [InlineData(1245640)]
        [InlineData(1711859)]
        public void GetAverageRateOfMovieTest(int movie)
        {
            var actuallResult = ratingList.Where(x => x.Movie == movie).Average(x => x.Grade);
            var result = ratingService.GetAverageRateOfMovie(movie);
            Assert.Equal(actuallResult, result);
            
        }
    }
}
