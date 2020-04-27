using System;
using System.Collections.Generic;

namespace LR3
{
    enum State
    {
        Rating,
        Language,
        Illustration
    }

    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Literature>()
            {
                new Fiction("Pride and Prejudice", "Jane Austen", 416, 1797, 4.9),
                new Fiction("Harry Potter and the prisoner of Azkaban", "Joanne Rowling", 432, 1999, 5.0),
                new Fiction("All Sherlock Holmes", "Sir Arthur Conan Doyle", 1151, 1927, 5.0),
                new Fiction("Mint Tale", "Alexander Polyarny", 160, 2018, 3.0),
                new Fiction("Three comrades", "Erich Maria Remarque", 546, 1936, 5.0),
                new Science("Limitless mind", "Joe Bowler", 260, 2018, "eng"),
                new Science("C# in Depth", "Jon Skeet", 528, 2017, "eng"),
                new Science("Clean Code", "Robert Cecil Martin", 464, 2008, "rus"),
                new Science("Agile Principles, Patterns, and Practices in C#", "Robert & Micah Martin", 768, 2011, "rus"),
                new Science("C# Smorgasbord", "Filip Ekberg", 278, 2012, "rus"),
                new Science("The Art of Unit Testing", "Roy Osherove", 292, 2013, "rus"),
                new Science("New physical fireworks", "Girl Walker", 412, 1975, "eng"),
                new Children("70 megabytes. Smart notebook", "David Desteno", 80, 2019, true),
                new Children("Color. Snail books", "Olga Mozaleva", 12, 2017, true),
                new Children("Want to know everything.", "Daria Ermakovich", 320, 2016, false),
                new Children("Science at your leisure", "Jacob Perelman", 320, 2017, false)
        };

            var library = new Library();
            foreach (var book in books)
            {
                library.AddBook(0, book);
            }

            Action ShowedInfo = delegate
            {
                var count = 1;
                Console.WriteLine($"{"",-22} Title {"", -35} Author {"", -20} Pages {"", -6} Year {"", -3} Rat/Len/Ill");

                foreach (var book in library)
                {
                    Console.WriteLine($"{count++, 2}. " + book);
                }
            };

            while (true)
            {
                var choice = Menu(@$"
                                   Enter (P) Print all books.
                                   Enter (O) to Find out the cost of the book.
                                   Enter (A) sort books Alphabetically.
                                   Enter (F) to go to Fiction books.
                                   Enter (S) to go to Science books.
                                   Enter (C) to go to Children's books.
                                   Enter (E) to Exit", "pafscoe");

                var flag = true;

                while (flag)
                {
                    switch (choice)
                    {
                        case 'p':

                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            ShowedInfo();
                            flag = false;

                            Console.ResetColor();
                            break;

                        case 'a':

                            Console.ForegroundColor = ConsoleColor.Blue;

                            library.SortBook();
                            ShowedInfo();
                            flag = false;

                            Console.ResetColor();
                            break;

                        case 'f':

                            (flag, library) = SelectOperation<Fiction>(Menu(@$"
                                   Enter (L) to List books.
                                   Enter (N) to enter New book.
                                   Enter (D) to Delete book.
                                   Enter (R) to arrange books in descending order of Rating.
                                   Enter (E) to Exit", "lndre"), library, State.Rating, ShowedInfo);
                         
                            break;

                        case 's':

                            (flag, library) = SelectOperation<Science>(Menu(@$"
                                   Enter (L) to List books.
                                   Enter (N) to enter New book.
                                   Enter (D) to Delete book.
                                   Enter (T) to find out the Time it took to read the book.
                                   Enter (E) to Exit", "lndte"), library, State.Language, ShowedInfo);

                            break;

                        case 'c':

                            (flag, library) = SelectOperation<Children>(Menu(@$"
                                   Enter (L) to List books.
                                   Enter (N) to enter New book.
                                   Enter (D) to Delete book.
                                   Enter (E) to Exit", "lnde"), library, State.Illustration, ShowedInfo);

                            break;

                        case 'o':

                            Console.ForegroundColor = ConsoleColor.Magenta;

                            Console.Write("What book cost do you want to know? ");
                            string title = Console.ReadLine();

                            Console.Write("The cost of this book: ");

                            Console.Write($"{((IBook)library[title])?.CalculateTheCost()}");

                            Console.ResetColor();
                            break;

                        case 'e':

                            Console.ResetColor();
                            return;
                    }
                }
            }
        }

        static char Menu(string menu, string letters)
        {
            var flag = ' ';

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(menu);

                try
                {
                    flag = Convert.ToChar(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                if (letters.Contains(flag = Char.ToLower(flag)))
                {
                    break;
                }
                Console.ResetColor();
            }
            return flag;
        }

        static (bool, Library) SelectOperation<T>(char choice, Library library, 
                        State state, Action ShowedInfo) where T : Literature, new()
        {
            switch (choice)
            {
                case 'l':

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    ShowedInfo();

                    Console.ResetColor();
                    break;

                case 'n':

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;

                    library.Added += CreateNewBook<T>;
                    library.AddBook(state);

                    Console.ResetColor();
                    break;

                case 'd':

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    library.Deleted += delegate
                    {
                        Console.WriteLine("Which account book do you want to delete?");
                        string title = Console.ReadLine();
                        return title;
                    };

                    try
                    {
                        library.RemoveBook();
                    }
                    catch(ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.ResetColor();
                    break;

                case 't':

                    Console.ForegroundColor = ConsoleColor.Magenta;
   
                    Console.WriteLine("For which book do you want to calculate the reading time?");
                    string title = Console.ReadLine();

                    Console.Write("If you really try, you can read this book in ");

                    if (library[title] is Science)
                    {
                        ((Science)library[title])?.Timing();
                    }

                    Console.ResetColor();
                    break;

                case 'r':

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                
                    var fictionBook= new List<Fiction>();
                    var count = 1;

                    foreach (var book in library)
                    {
                        if (book is Fiction)
                        {
                            fictionBook.Add((Fiction)book);
                        }
                    }

                    fictionBook.Sort();

                    Console.WriteLine($"{"",-22} Title {"",-35} Author {"",-20} Pages {"",-6} Year  {state,10}");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    foreach(var book in fictionBook)
                    {
                        Console.WriteLine($"{count++, 2}. " + book);
                    }

                    Console.ResetColor();
                    break;

                case 'e':

                    return (false, library);
            }

            return (true, library);
        }

        static Literature CreateNewBook<T>(State state) where T : Literature, new()
        {
            Literature book = new T();

            Console.WriteLine("So, please..\nEnter a title for the book:");

            try
            {
                Console.WriteLine("Enter a title for the book:");
                book.Title = Console.ReadLine();

                Console.WriteLine("Enter the author of the book:");
                book.Author = Console.ReadLine();
            
                Console.WriteLine("Enter the number of pages in the book:");
                book.Pages = Convert.ToInt32(Console.ReadLine());
            
                Console.WriteLine("Enter the year the book was published:");
                book.Year = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            switch (state)
            {
                case State.Rating: book = IndividualInfo((Fiction)book); break;
                case State.Language: book = IndividualInfo((Science)book); break;
                case State.Illustration: book = IndividualInfo((Children)book); break;
            }

            return book;
        }

        static Literature IndividualInfo(Fiction fiction) 
        {
            Console.WriteLine("Enter book rating:");

            try
            {
                fiction.Rating = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return fiction;
        }

        static Literature IndividualInfo(Science science)
        {
            Console.WriteLine("Enter book language(\"rus\" or \"eng\"):");

            try
            {
                science.Language = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return science;
        }

        static Literature IndividualInfo(Children child)
        {
            Console.WriteLine("Book with illustrations?(true or false)");

            try
            {
                child.Illustration = Convert.ToBoolean(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return child;
        }
    }
}   