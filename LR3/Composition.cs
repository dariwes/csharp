using System;
using System.Text.RegularExpressions;

namespace LR3
{
    abstract class Composition
    {
        protected string title;
        protected string author;

        public Composition(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public Composition() { }

        public string Title
        {
            get => title;
            set => title = value;
        }
        public string Author
        {
            set
            {
                if (!Regex.Match(value, "^[A-Z, a-z]").Success)
                {
                    throw new ArgumentNullException(value, "The name must not contain numbers.");
                }

                author = value;
            }
        }

        abstract public override string ToString();
    }
}
