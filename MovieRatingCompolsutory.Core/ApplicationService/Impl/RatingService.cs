﻿using MovieRatingCompolsutory.Core.DomainService;
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
            throw new NotImplementedException();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            return repository.GetNumberOfReviews(movie);
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
