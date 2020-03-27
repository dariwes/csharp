using System;
using System.Collections.Generic;
using System.Text;

namespace LR3 
{
    class Children : Literature
    {
        public bool Illustration { get; set; } = true;

        public Children(string title, string author, int pages, int year, bool illustration) :
            base(title, author, pages, year)
        { Illustration = illustration; }

        public Children() : base() { }

        public override void DisplayInform(int i)
        {
            Console.WriteLine($"{i}. {title,-55} {author,-35} {pages,-10} {year,-10} {Illustration,-20}");
        }
    }
}
