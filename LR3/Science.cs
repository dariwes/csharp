using System;

namespace LR3
{
    class Science : Literature
    {
        private string language;
        public string Language 
        { 
            get => Language; 
            set
            {
                if (value == "rus" || value == "eng")
                {
                    language = value;
                }
                else
                {
                    throw new ArgumentNullException(value,
                        "The language is entered incorrectly. You must enter \"rus\" or \"eng\".");
                }
            }
        }

        public Science(string title, string author, int pages, int year, string language) :
            base(title, author, pages, year)
        { 
            Language = language;
        }

        public Science() : base() { }

        public override string ToString() => $"{title,-55} {author,-35} {pages,-10} {year,-10} {language,-20}";

        public string Timing()
        {
            int minutes = pages / 2;
            int hours = minutes / 60;
            minutes -= hours * 60;

            return $"{hours} hours {minutes} minutes.";
        }

        public override decimal CalculateTheCost()
        {
            decimal percent = (decimal)(nowYear.Year - year) / 10 + (language == "rus" ? -0.1M : 0M);

            if (percent <= 0M)
            {
                return 4.00M;
            }

            if (percent >= 1M)
            {
                return 0.80M;
            }

            return 4.00M - 4.00M * percent / 10;
        }
    }
}
