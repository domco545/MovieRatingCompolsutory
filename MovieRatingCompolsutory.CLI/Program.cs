using Infrastructure.SQLite;
using System;
using MovieRatingCompolsutory.Core.Entity;
using System.Linq;
using System.Reflection;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using MovieRatingCompolsutory.Core.ApplicationService.Impl;

namespace MovieRatingCompolsutory.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            var repository = new RatingSQLRepository();
            var service = new RatingService(repository);

            p.GetNumberOfRates(service);

        }

        public void TestDbConnection()
        {
            var ctx = new RatingDBContext();

            var found = ctx.Ratings.FirstOrDefault(o => o.Reviewer == 1);
            Console.WriteLine(found);
        }

        public void GetAverageRateFromReviewer(RatingService service) 
        {
            var res = service.GetAverageRateFromReviewer(1);
            Console.WriteLine(res);
        }

        public void MostProductiveReviewer(RatingService service)
        {
            Console.WriteLine("most productive");
            foreach (var item in service.GetMostProductiveReviewers())
            {
                Console.WriteLine(item);
            }
        }

        public void MoviesWithHighestNumberOfTopRates(RatingService service) 
        {
            var res = service.GetMoviesWithHighestNumberOfTopRates();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        public void GetNumberOfRates(RatingService service) 
        {
            var res = service.GetNumberOfRates(794999, 5);
            Console.WriteLine(res);
        }
    }
}
