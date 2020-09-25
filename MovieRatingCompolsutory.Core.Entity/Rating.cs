using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRatingCompolsutory.Core.Entity
{
    public class Rating
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Reviewer:{Reviewer} Movie:{Movie}, Grade:{Grade}, Date:{Date.ToShortDateString()}";
        }
    }
}
