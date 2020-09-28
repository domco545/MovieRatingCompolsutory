using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MovieRatingCompolsutory.Core.DomainService;
using MovieRatingCompolsutory.Core.Entity;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
  public  class RatingsRepository : IRatingRepositoryFile
    {
        private List<Rating> ratings = new List<Rating>();

        public List<Rating> GetAll()
        {
            return ratings;
        }
        public void ReadFile()
        {
            using (StreamReader r = new StreamReader("C:\\3rdSemester\\MovieRatingCompolsutory\\Infrastructure.Data\\bin\\Debug\\ratings.json"))
            {
                string json = r.ReadToEnd();
                ratings = JsonConvert.DeserializeObject<List<Rating>>(json);
            }
        }
    }
}
