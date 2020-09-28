using System;
using System.Collections.Generic;
using System.Text;
using MovieRatingCompolsutory.Core.Entity;

namespace MovieRatingCompolsutory.Core.DomainService
{
    //Need rename RatingRepositoryFile to IRatingRepositoryFile
    public interface RatingRepositoryFile
    {
        List<Rating> GetAll();
    }
}
