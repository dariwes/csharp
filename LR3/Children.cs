using System;

namespace LR3 
{
    class Children : Literature
    {
        public bool Illustration { get; set; } = true;

        public Children(string title, string author, int pages, int year, bool illustration) :
            base(title, author, pages, year)
        { 
            Illustration = illustration; 
        }

        public Children() : base() { }

        public override string ToString() => $"{title,-55} {author,-35} {pages,-10} {year,-10} {Illustration,-20}";

        public override decimal CalculateTheCost()
        {
            decimal percent = (decimal)(nowYear.Year - year) / 10 + (Illustration == true ? -0.2M : 0);
            
            if(percent <= 0M)
            {
                return 3.00M;
            }
            
            if(percent >= 1M)
            {
                return 0.30M;
            }

            return 3.00M - 3.00M * percent / 10;
        }
    }
}
