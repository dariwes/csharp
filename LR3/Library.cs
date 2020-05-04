using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LR3
{
    class Library : IEnumerable<Literature>, IEnumerable
    {
        private List<Literature> books = new List<Literature>();

        public int Count => books.Count;

        public string Title { get; set; }

        public event Action<string> Added;
        public event Action<string> Deleted;

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
            if (book is null)
            {
                throw new FormatException("Adding a book isn't possible.");
            }

            books.Add(book);
            Added?.Invoke("Book added.");
        }

        public void RemoveBook(string title)
        {
            var book = books.FirstOrDefault(item => item.Title == title);

            if(book is null)
            {
                throw new FormatException("Book not found.");
            }

            books.Remove(book);
            Deleted?.Invoke("Book deleted.");
        }

        public void SortBook()
        {
            if (books.Count > 0)
            {
                books.Sort();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
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

        public IEnumerator<Literature> GetEnumerator()
        {
            return Implementation();

            IEnumerator<Literature> Implementation()
            {
                foreach (var book in books)
                {
                    yield return book;
                }
            }
        }
    }
}
