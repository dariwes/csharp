using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    class Literature
    {
        protected string title;
        protected string author;
        protected int pages;

        public Literature(string title, string author, int pages)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
        }

        public Literature() { }



        public string Title
        {
            set
            {
                if (value.Length <= 0 || value.Length > 30)
                {

                    Console.WriteLine("Input incorrect...");
                }
                else
                {
                    title = value;
                }
            }
        }
        public string Author
        {
            set
            {
                if (value.Length <= 0 || value.Length > 30)
                {

                    Console.WriteLine("Input incorrect...");
                }
                else
                {
                    author = value;
                }

            }
        }

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

        public void DisplayInformWithPages(int i)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{i}. {title,-55} {author,-40} {pages,-10}");
        }
    }
}
