using System;

namespace LR3
{
    abstract class Literature : Composition, IComparable<Literature>, IBook
    {
        protected int pages;
        protected int year;
        protected static DateTime nowYear = DateTime.Now;

        public Literature(string title, string author, int pages, int year) :

            base(title, author)
        {

            this.Pages = pages;
            this.Year = year;
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
                    throw new ArgumentNullException(Convert.ToString(value), "Invalid page count.");
                }

                pages = value;
            }
        }

        public int Year
        {
            set
            {
                if (value < 868 || value >= nowYear.Year)
                {
                    throw new ArgumentNullException(Convert.ToString(value), "Invalid book creation year.");
                }

                year = value;
            }
        }

        int IComparable<Literature>.CompareTo(Literature item) => this.Title.CompareTo(item.Title);

        public override string ToString() => $"{title,-55} {author,-40} {pages,-10} {year,-10}";

        public abstract decimal CalculateTheCost();
    }
}

