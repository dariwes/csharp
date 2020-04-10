using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LR3
{
    class Library : IEnumerable  
    {
        private List<Literature> books = new List<Literature>();

        public int Count => books.Count;

        public string Title { get; set; }

        public Literature this[string title]
        {
            get
            {
                var book = books.FirstOrDefault(item => item.Title == title);
                return book;
            }
        }

        public void AddBook(Literature book)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book not found.");
            }
            
            books.Add(book);
        }

        public void RemoveBook(string title)
        {
            var book = books.FirstOrDefault(item => item.Title == title);

            if(book != null)
            {
                books.Remove(book);
            }
        }

        public void SortBook()
        {
            if (books.Count > 0)
            {
                books.Sort();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Implementation();

            IEnumerator Implementation()
            {
                foreach(var book in books)
                {
                    yield return book;
                }
            }
        }
    }
}
