using System;

namespace LR3
{
    class Program
    {
        enum State
        {
            Rating,
            Language,
            Illustration
        }
        static void Main(string[] args)
        {
            int F_index = 5, S_index = 8, C_index = 4;

            Literature[] fiction = new Fiction[10];
            Literature[] science = new Science[10];
            Literature[] child = new Children[10];

            fiction[0] = new Fiction("Pride and Prejudice", "Jane Austen", 416, 1797, 4.9);
            fiction[1] = new Fiction("Harry Potter and the prisoner of Azkaban", "Joanne Rowling", 432, 1999, 5.0);
            fiction[2] = new Fiction("All Sherlock Holmes", "Sir Arthur Conan Doyle", 1151, 1927, 5.0);
            fiction[3] = new Fiction("Mint Tale", "Alexander Polyarny", 160, 2018, 3.0);
            fiction[4] = new Fiction("Three comrades", "Erich Maria Remarque", 546, 1936, 5.0);

            science[0] = new Science("70 megabytes.Smart notebook", "David Desteno", 272, 2009, "eng");
            science[1] = new Science("C# in Depth", "Jon Skeet", 528, 2017, "eng");
            science[2] = new Science("Clean Code", "Robert Cecil Martin", 464, 2008, "rus");
            science[3] = new Science("Agile Principles, Patterns, and Practices in C#", "Robert & Micah Martin", 768, 2011, "rus");
            science[4] = new Science("C# Smorgasbord", "Filip Ekberg", 278, 2012, "rus");
            science[5] = new Science("The Art of Unit Testing", "Roy Osherove", 292, 2013, "rus"); 
            science[6] = new Science("New physical fireworks", "Girl Walker", 412, 1975, "eng");
            science[7] = new Science("Limitless mind", "Joe Bowler", 260, 2018, "eng");

            child[0] = new Children("70 megabytes. Smart notebook", "David Desteno", 80, 2019, true);
            child[1] = new Children("Color. Snail books", "Olga Mozaleva", 12, 2017, true);
            child[2] = new Children("Want to know everything.", "Daria Ermakovich", 320, 2016, false);
            child[3] = new Children("Science at your leisure", "Jacob Perelman", 320, 2017, false);


            while (true)
            {
                char choice = Menu(@$"
                                   Enter (A) Print All Books.
                                   Enter (F) to go to Fiction books.
                                   Enter (S) to go to Science books.
                                   Enter (C) to go to Children's books.
                                   Enter (E) to Exit", "afsce");

                bool flag = true;

                while (flag)
                {
                    switch (choice)
                    {
                        case 'a':

                            int count = 0;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"{"",-22} Title {"",-35} Author {"",-20} Pages {"",-6} Year {"", -3} Rat/Len/Ill");
                            for (int i = 0; i < F_index; i++)
                            {
                                count++;

                                if (i < F_index) { fiction[i].DisplayInform(count++); };
                                if (i < S_index) { science[i].DisplayInform(count++); };
                                if (i < C_index) { child[i].DisplayInform(count++); };
                            }
                            flag = false;

                            Console.ResetColor();
                            break;

                        case 'f':

                            (flag, fiction, F_index) = SelectOperation<Fiction>(Menu(@$"
                                   Enter (L) to List books.
                                   Enter (N) to enter New book.
                                   Enter (D) to Delete book.
                                   Enter (R) to arrange books in descending order of Rating.
                                   Enter (E) to Exit", "lndre"), fiction, F_index, State.Rating);
                         
                            break;

                        case 's':

                            (flag, science, S_index) = SelectOperation<Science>(Menu(@$"
                                   Enter (L) to List books.
                                   Enter (N) to enter New book.
                                   Enter (D) to Delete book.
                                   Enter (T) to find out the Time it took to read the book.
                                   Enter (E) to Exit", "lndte"), science, S_index, State.Language);

                            break;

                        case 'c':

                            (flag, child, C_index) = SelectOperation<Children>(Menu(@$"
                                        Enter (L) to List books.
                                        Enter (N) to enter New book.
                                        Enter (D) to Delete book.
                                        Enter (E) to Exit", "lnde"), child, C_index, State.Illustration);

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
            char flag = ' ';

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(menu);

                try
                {
                    flag = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                if (letters.Contains(Char.ToLower(flag)))
                {
                    break;
                }
                Console.ResetColor();
            }
            return flag;
        }

        static (bool, Literature[], int) SelectOperation<T>(char choice, Literature[] book, int index, State state) 
            where T : Literature, new()
        {
        switch (choice)
            {
                case 'l':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{"",-22} Title {"",-35} Author {"",-20} Pages {"",-6} Year  {state, 10}");

                    for (int i = 0; i < index; i++)
                    {
                        ((T)book[i]).DisplayInform(i + 1);
                    }
                    Console.ResetColor();

                    break;

                case 'n':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;

                    book[index] = CreateNewBook<T>(state);
                    index++;
                    Console.ResetColor();

                    break;

                case 'd':
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    book = DeleteBook<T>(book);
                    index--;
                    Console.ResetColor();

                    break;

                case 't':
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    CalculateReadingTime(book);
                    Console.ResetColor();

                    break;

                case 'r':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    book = ArrangeBooks(book, index);
                    Console.WriteLine($"{"",-22} Title {"",-35} Author {"",-20} Pages {"",-6} Year  {state,10}");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    for (int i = 0; i < index; i++)
                    {
                        ((Fiction)book[i]).DisplayInform(i + 1);
                    }
                    Console.ResetColor();

                    break;

                case 'e':
                    return (false, book, index);
            }
            return (true, book, index);
        }

        static Literature CreateNewBook<T>(State state) where T : Literature, new()
        {
            Literature Book = new T();

            Console.WriteLine("So, please..\nEnter a title for the book:");

            try
            {
                Book.Title = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Enter the author of the book:");

            try
            {
                Book.Author = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Enter the number of pages in the book:");

            try
            {
                Book.Pages = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Enter the year the book was published:");

            try
            {
                Book.Year = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            switch (state)
            {
                case State.Rating: Book = IndividualInfo((Fiction)Book); break;
                case State.Language: Book = IndividualInfo((Science)Book); break;
                case State.Illustration: Book = IndividualInfo((Children)Book); break;
            }

            

            return Book;
        }

        static Literature IndividualInfo(Fiction fiction) 
        {
            Console.WriteLine("Enter book rating:");

            try
            {
                fiction.Rating = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return fiction;
        }

        static Literature IndividualInfo(Science science)
        {
            Console.WriteLine("Enter book language(0 - rus, other numbers  - eng):");

            try
            {
                int temp = Convert.ToInt32(Console.ReadLine());
                science.Language = temp == 0 ? "rus" : "eng";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return science;
        }

        static Literature IndividualInfo(Children child)
        {
            Console.WriteLine("Book with illustrations?(1 - yes, other numbers - no)");

            try
            {
                int temp = Convert.ToInt32(Console.ReadLine());
                child.Illustration = temp == 1 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return child;
        }

        static Literature[] DeleteBook<T>(Literature[] Book) where T : Literature
        {
            int index;
            Literature[] newBook = new T[Book.Length - 1];

            Console.WriteLine("Which account book do you want to delete?");

            index = Enter(Book.Length);
            index--;

            for (int i = 0; i < newBook.Length; i++)
            {
                if (i >= index)
                {
                    newBook[i] = Book[i + 1];
                }
                else
                {
                    newBook[i] = Book[i];
                }
            }
            return newBook;
        }

        static Literature[] ArrangeBooks(Literature[] fiction, int length)
        {
            Fiction[] Book = fiction as Fiction[];

            for (int i = 0; i < length; i++)
            {
                Fiction temp;

                for (int j = i + 1; j < length; j++)
                {

                    if (Book[i] > Book[j])
                    {

                        temp = Book[i];
                        Book[i] = Book[j];
                        Book[j] = temp;
                    }
                }
            }
            return Book;
        }

        static Literature[] CalculateReadingTime(Literature[] Book)
        {
            int index;

            Console.WriteLine("For which book do you want to calculate the reading time?");
            index = Enter(Book.Length);

            Console.Write("If you really try, you can read this book in ");
            ((Science)Book[index - 1]).Timing();

            return Book;
        }

        static int Enter(int length)
        {
            bool flag = true;
            int index = 0;

            while (flag)
            {
                try
                {
                    index = Convert.ToInt32(Console.ReadLine());

                    if (index > length)
                    {
                        Console.WriteLine("Try again..");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Input incorrect... Try again.");
                }
            }
            return index;
        }
    }
}   