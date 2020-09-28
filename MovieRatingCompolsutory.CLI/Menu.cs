using MovieRatingCompolsutory.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRatingCompolsutory.CLI
{
    class Menu
    {
        IRatingService service;
        public Menu(IRatingService serv)
        {
            service = serv;
            Run();
        }

        private void Run() 
        {
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose one option");
                Console.WriteLine("1. Get Number Of Reviews From Reviewer");

                var read = Console.ReadLine();
                switch (read)
                {
                    default: Console.WriteLine("Wrong input try again");
                        break;
                    case "1": 
                        GetNumberOfReviewsFromReviewer();
                        break;
                }
            }
        }

        private void GetNumberOfReviewsFromReviewer() 
        {
            var ready = false;
            var reviewer = 0;
            Console.WriteLine("enter reviewer id");
            while (!ready)
            {
                
                if (int.TryParse(Console.ReadLine(), out reviewer))
                {
                    ready = true;
                }
                else
                {
                    Console.WriteLine("try again");
                }
            }
            var reviews = service.GetNumberOfReviewsFromReviewer(reviewer);
            Console.WriteLine($"Reviewer {reviewer} has {reviews} reviews");
        }
    }
}
