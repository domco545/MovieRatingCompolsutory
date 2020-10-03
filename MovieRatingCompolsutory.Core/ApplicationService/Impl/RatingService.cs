using MovieRatingCompolsutory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRatingCompolsutory.Core.ApplicationService.Impl
{
    public class RatingService : IRatingService
    {
        IRatingRepository repository;
        public RatingService(IRatingRepository r)
        {
            repository = r;
        }
        public double GetAverageRateFromReviewer(int reviewer)
        {
            return repository.GetAverageRateFromReviewer(reviewer);
        }

        public double GetAverageRateOfMovie(int movie)
        {
            return repository.GetAverageRateOfMovie(movie);
        }

        public List<int> GetMostProductiveReviewers()
        {
            return repository.GetMostProductiveReviewers();
        }

        
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return repository.GetMoviesWithHighestNumberOfTopRates();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return repository.GetNumberOfRates(movie, rate);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return repository.GetNumberOfRatesByReviewer(reviewer, rate);
        }

        public int GetNumberOfReviews(int movie)
        {
            return repository.GetNumberOfReviews(movie);
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return repository.GetNumberOfReviewsFromReviewer(reviewer);
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return repository.GetReviewersByMovie(movie);
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return repository.GetTopMoviesByReviewer(reviewer);
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return repository.GetTopRatedMovies(amount);
        }
    }
}
