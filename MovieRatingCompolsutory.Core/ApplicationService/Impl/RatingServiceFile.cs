using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieRatingCompolsutory.Core.DomainService;
using MovieRatingCompolsutory.Core.Entity;

namespace MovieRatingCompolsutory.Core.ApplicationService.Impl
{
    public class RatingServiceFile : IRatingService
    {
        private readonly IRatingRepositoryFile _ratingRepoFile;
        private List<Rating> ratings = new List<Rating>();
        public RatingServiceFile(IRatingRepositoryFile ratingRepositoryFile)
        {
            _ratingRepoFile = ratingRepositoryFile;
            ratings = _ratingRepoFile.GetAll();
        }
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            var number = ratings.Where(rate => rate.Reviewer == reviewer).Select(rate => rate.Reviewer).Count();
            return number;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            var avgrade = ratings.Where(r => r.Reviewer == reviewer).Select(r => r.Grade).Average();
            return Math.Round(avgrade, 2, MidpointRounding.AwayFromZero);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            var rategiven = ratings.Where(r => r.Reviewer == reviewer && r.Grade == rate).Select(r => r.Grade).Count();
            return rategiven;
        }

        public int GetNumberOfReviews(int movie)
        {
            var movieReviewed = ratings.Where(r => r.Movie == movie).Select(r => r.Reviewer).Count();
            return movieReviewed;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            var result = ratings.Where(x => x.Movie == movie).Average(x => x.Grade);
            return result;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            var result = ratings.Where(x => x.Movie == movie && x.Grade==rate).Count();
            return result;
        }


        public List<int> GetMostProductiveReviewers()
        {
            var result = ratings.GroupBy(r => r.Reviewer)
                .OrderByDescending(r => r.Count()).Select(r => r.Key).Take(3).ToList();
            return result;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            // Something is maybe wrong, couldn't get grade.Average()
            var results = ratings
                .OrderByDescending(r => r.Grade)
                .Select(r => r.Movie)
                .Take(amount)
                .ToList();
            return results;
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            var results = ratings.Where(r => r.Reviewer == reviewer)
                .OrderByDescending(r => r.Grade)
                .Select(r => r.Movie).Take(4).ToList();
            return results;
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            var results = ratings
                .Where(r => r.Movie == movie)
                .Select(r => r.Reviewer)
                .ToList();
            return results;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var result = ratings.GroupBy(r => r.Movie)
                .OrderByDescending(r => r.Count()).Select(r => r.Key).Take(4).ToList();
            return result;
        }
    }
}
