using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LR3
{
    class Science : Literature
    {
        public string Language { get; set; }

        public Science(string title, string author, int pages, int year, string language) :
            base(title, author, pages, year)
        { Language = language; }

        public Science() : base() { }

        public override void DisplayInform(int i)
        {
            Console.WriteLine($"{i}. {title,-55} {author,-35} {pages,-10} {year,-10} {Language,-20}");
        }

        public int BookAge()
        {
            return nowYear.Year - year;
        }

        public void Timing()
        {
            int minutes = pages / 2;
            int hours = minutes / 60;
            minutes -= hours * 60;

            Console.WriteLine($"{hours} hours {minutes} minutes.");
        }
    }
}
