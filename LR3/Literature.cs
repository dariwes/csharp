using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    class Literature : Composition
    {
        protected int pages;
        protected int year;
        protected static DateTime nowYear = DateTime.Now;

        public Literature(string title, string author, int pages, int year) :

            base(title, author)
        {

            this.pages = pages;
            this.year = year;
        }

        public Literature() :
            base()
        { }

        public int Pages
        {
            set
            {
                if (value <= 0 || value > 10000)
                {

                    Console.WriteLine("Input incorrect...");
                }
                else
                {
                    pages = value;
                }
            }
        }

        public int Year
        {
            set
            {
                if (value <= 1500 || value > nowYear.Year)
                {

                    Console.WriteLine("Input incorrect...");
                }
                else
                {
                    year = value;
                }
            }
        }

        public override void DisplayInform(int i)
        {
            Console.Write($"{i}. {title,-55} {author,-40} {pages,-10} {year,-10}");
        }
    }
}

