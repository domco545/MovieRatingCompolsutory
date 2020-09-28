using Infrastructure.Data;
using Infrastructure.SQLite;
using MovieRatingCompolsutory.Core.ApplicationService;
using MovieRatingCompolsutory.Core.ApplicationService.Impl;
using System;
using System.Linq;

namespace MovieRatingCompolsutory.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var choose = false;
            IRatingService service = null;

            Console.WriteLine("Select dataset by enetring number");
            Console.WriteLine("1. SQL");
            Console.WriteLine("2. Json");
            while (!choose)
            {
                var read = Console.ReadLine();
                switch (read)
                {
                    default:
                        Console.WriteLine("not recognized try again");
                        break;
                    case "1": 
                        Console.WriteLine("SQL was selected");
                        service = new RatingService(new RatingSQLRepository());
                        choose = true;
                        break;
                    case "2":
                        Console.WriteLine("Json was selected");
                        service = new RatingServiceFile(new RatingsRepository());
                        choose = true;
                        break;
                }

                new Menu(service);
            }

        }
    }
}
