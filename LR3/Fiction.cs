using System;

namespace LR3
{
    class Fiction : Literature, IComparable<Fiction>
    {
        double rating;

        public Fiction(string title, string author, int pages, int year, double rating) :
            base(title, author, pages, year)
        { 
            this.Rating = rating; 
        }

        public Fiction() : base() { }

        public double Rating
        {
            get => rating;
            set
            {
                if (value < 0.0 || value > 5.0)
                {
                    throw new ArgumentNullException(Convert.ToString(value), 
                        "Rating should be in the range from 0 to 5."); 
                }

                rating = value;
            }
        }

        int IComparable<Fiction>.CompareTo(Fiction item) => this.Rating.CompareTo(item.Rating);

        public override string ToString() => $"{title,-55} {author,-35} {pages,-10} {year,-10} {rating,-20}";

        public override decimal CalculateTheCost()
        {
            decimal percent = (decimal)rating / 10M;

            if (percent >= 0.5M)
            {
                return 4.00M;
            }

            if (percent <= 0.1M)
            {
                return 0.60M;
            }

            return 2.50M + 2.00M * percent / 10;
        }
    }
}
