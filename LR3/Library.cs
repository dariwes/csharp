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

        public event Func<State, Literature> Added;
        public event Func<string> Deleted;

        public Literature this[string title]
        {
            get
            {
                var book = books.FirstOrDefault(item => item.Title == title);
                return book;
            }
        }

        public void AddBook(State state, Literature book = null)
        {
            if (book is null)
            {
                book = Added?.Invoke(state);
            }
            
            books.Add(book);
            Added = null;
        }

        public void RemoveBook()
        {
            string title = Deleted?.Invoke();
            Deleted = null;

            var book = books.FirstOrDefault(item => item.Title == title);

            if(book is null)
            {
                throw new FormatException("Book not found.");
            }

            books.Remove(book);
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
