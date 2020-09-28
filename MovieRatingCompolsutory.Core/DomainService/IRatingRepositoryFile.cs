using System;
using System.Collections.Generic;
using System.Text;
using MovieRatingCompolsutory.Core.Entity;

namespace MovieRatingCompolsutory.Core.DomainService
{
    public interface IRatingRepositoryFile
    {
        List<Rating> GetAll();
    }
}
