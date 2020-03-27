using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    abstract class Composition
    {
        protected string title;
        protected string author;

        public Composition(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public Composition() { }

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

        abstract public void DisplayInform(int i);
    }
}
