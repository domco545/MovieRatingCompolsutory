using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MovieRatingCompolsutory.Core.DomainService;
using MovieRatingCompolsutory.Core.Entity;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    
    //Need Rename RatingsRepository to IRatingRepositoryFile
    public class RatingsRepository : IRatingRepositoryFile
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
            Console.WriteLine("Reading file");
            var path = System.IO.Directory.GetParent(@"../../../../").FullName;
            using (StreamReader r = new StreamReader(path+@"\ratings.json"))
            {
                string json = r.ReadToEnd();
                ratings = JsonConvert.DeserializeObject<List<Rating>>(json);
            }
        }
    }
}
