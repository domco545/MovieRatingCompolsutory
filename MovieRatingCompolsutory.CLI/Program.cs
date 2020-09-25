using Infrastructure.SQLite;
using System;
using MovieRatingCompolsutory.Core.Entity;
using System.Linq;
using System.Reflection;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace MovieRatingCompolsutory.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new RatingDBContext();

            var found = ctx.Ratings.FirstOrDefault(o => o.Reviewer == 1);
            Console.WriteLine(found);
        }
    }
}
