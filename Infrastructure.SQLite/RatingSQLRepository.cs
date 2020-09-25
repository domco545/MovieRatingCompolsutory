using Microsoft.EntityFrameworkCore;
using MovieRatingCompolsutory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.SQLite
{
    public class RatingSQLRepository : IRatingRepository
    {
        readonly RatingDBContext ctx = new RatingDBContext();

        public double GetAverageRateFromReviewer(int reviewer)
        {
            var res = ctx.Ratings
                .Where(o => o.Reviewer == reviewer)
                .Average(o => o.Grade);
            return Math.Round(res, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAverageRateOfMovie(int movie)
        {
            var res = ctx.Ratings
                .Where(o => o.Movie == movie)
                .Average(o => o.Grade);
            return Math.Round(res, 2, MidpointRounding.AwayFromZero);
        }

        public List<int> GetMostProductiveReviewers()
        {
            var res = ctx.Ratings
                .GroupBy(o => o.Reviewer)
                .OrderByDescending(gp => gp.Count())
                .Take(5)
                .Select(g => g.Key).ToList();
            return res;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var res = ctx.Ratings
                .FromSqlRaw("SELECT Movie,COUNT(Movie) AS c, Grade FROM Ratings WHERE Grade = 5 GROUP BY Movie ORDER BY c DESC LIMIT 5")
                .Select(o => o.Movie)
                .ToList();
            //SELECT Movie,COUNT(Movie) AS c, Grade FROM Ratings WHERE Grade = 5 GROUP BY Movie ORDER BY c DESC LIMIT 10
            return res;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            //SELECT COUNT(Grade) FROM Ratings WHERE Movie = 794999 AND Grade = 5
            var res = ctx.Ratings
                .Where(o => o.Movie == movie)
                .Where(o => o.Grade == rate)
                .Count();
            return res;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
