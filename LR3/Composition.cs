using System;
using System.Collections.Generic;

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
            get
            {
                return title;
            }
            set
            {
                if (value.Length >= 0 || value.Length < 30)
                {
                    title = value;
                }
            }
        }
        public string Author
        {
            set
            {
                if (value.Length >= 0 || value.Length < 30)
                {

                    author = value;
                }
            }
        }

        abstract public override string ToString();
    }
}
