using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    class CSharp : Literature
    {
        double popularity;
        int year;
        static int thisYear = 2020;

        public CSharp(string title, string author, int pages, double popularity, int year) :

            base(title, author, pages)
        {
            this.popularity = popularity;
            this.year = year;
        }

        public CSharp() :
            base()
        { }

        public double Popularity
        {
            get { return popularity; }
            set
            {
                if (value < 0 || value > 5)
                {
                    Console.WriteLine("Input incorrect..");
                }
                else
                {
                    popularity = value;
                }
            }
        }

        public int Year
        {
            set
            {
                if (value > thisYear || value < 1983)
                {
                    Console.WriteLine("Input incorrect...");
                }
                else
                {
                    year = value;
                }
            }
        }

        public static int ThisYear
        {
            get { return thisYear; }
        }

        public void DisplayRatingInformation(int i)
        {
            Console.WriteLine($"{i}. {title,-55} {author,-35} {popularity,-10}");
        }

        public void Timing()
        {
            int minutes = pages / 2;
            int hours = minutes / 60;
            minutes -= hours * 60;

            Console.WriteLine($"{hours} hours {minutes} minutes.");
        }

        public int BookAge()
        {
            return thisYear - year;
        }

        public static bool operator <(CSharp B1, CSharp B2)
        {
            return B1.Popularity < B2.Popularity;
        }
        public static bool operator >(CSharp B1, CSharp B2)
        {
            return B1.Popularity > B2.Popularity;
        }
    }
}

