using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MovieRatingCompolsutory.Core.DomainService;
using MovieRatingCompolsutory.Core.Entity;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    
    //Need Rename RatingsRepository to RatingRepositoryFile
    public class RatingsRepository : RatingRepositoryFile
    {
        private List<Rating> ratings = new List<Rating>();
        public RatingsRepository()
        {
            ReadFile();
        }
        public List<Rating> GetAll()
        {
            return ratings;
        }
        public void ReadFile()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\saraf\Documents\GitHub\MovieRatingCompolsutory\Infrastructure.Data\Content\ratings.json"))
            {
                string json = r.ReadToEnd();
                ratings = JsonConvert.DeserializeObject<List<Rating>>(json);
            }
        }
    }
}
