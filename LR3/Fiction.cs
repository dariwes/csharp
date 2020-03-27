using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    class Fiction : Literature
    {
        double rating;

        public Fiction(string title, string author, int pages, int year, double rating) :
            base(title, author, pages, year)
        { this.rating = rating; }

        public Fiction() : base() { }

        public double Rating
        {
            get { return rating; }
            set
            {
                if (value < 0.0 || value > 5.0)
                {
                    Console.WriteLine("Input incorrect..");
                }
                else
                {
                    rating = value;
                }
            }
        }

        public override void DisplayInform(int i) 
        {
            Console.WriteLine($"{i}. {title,-55} {author,-35} {pages,-10} {year,-10} {rating,-20}");
        }

        public static bool operator <(Fiction B1, Fiction B2)
        {
            return B1.Rating > B2.Rating;
        }
        public static bool operator >(Fiction B1, Fiction B2)
        {
            return B1.Rating < B2.Rating;
        }
    }
}
