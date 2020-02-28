using System;

namespace LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 10;
            CSharp[] Book = new CSharp[12];

            Book[0] = new CSharp(" Pro C# 7: With .NET and .NET Core", " Andrew Troelsen & Philip Japikse", 1372, 4.5, 2017);
            Book[1] = new CSharp(" C# in Depth", " Jon Skeet", 528, 4.9, 2017);
            Book[2] = new CSharp(" Clean Code", " Robert Cecil Martin", 464, 4.4, 2008);
            Book[3] = new CSharp(" Agile Principles, Patterns, and Practices in C#", " Robert & Micah Martin", 768, 4.3, 2011);
            Book[4] = new CSharp(" C# Smorgasbord", " Filip Ekberg", 278, 4.0, 2012);
            Book[5] = new CSharp(" The Art of Unit Testing", " Roy Osherove", 292, 4.3, 2013);
            Book[6] = new CSharp(" Effective C#: 50 Specific Ways to Improve Your C#", " Bill Wagner", 316, 4.1, 2008);
            Book[7] = new CSharp(" C# Programming Yellow Book", " Rob Miles", 222, 4.1, 2018);
            Book[8] = new CSharp(" Fundamentals of Computer Programming with C#", " Svetlin Nakov and Team", 1122, 3.9, 2013);
            Book[9] = new CSharp("C# 7.0 Pocket Reference", "Joseph & Ben Albahari", 240, 4.5, 2017);
            
            while(true)
            {
                char choice = Menu();

                switch (choice)
                {
                    case 'l':
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{"", -22} Title {"", -35} Author {"", -20} Pages");

                        for(int i = 0; i < index; i++)
                        {
                            Book[i].PagesInformation(i + 1);
                        }

                        break;

                    case 'n':
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;

                        Book[index] = NewBook();
                        index++;

                        break;

                    case 'd':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        DeleteBook(ref Book);
                        index--;
                        break;

                    case 'r':
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        ArrangeBooks(ref Book, index);
                        Console.WriteLine($"{"",-22} Title {"",-35} Author {"",-20} Rating");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                        for (int i = 0; i < index; i++)
                        {
                            Book[i].PopularityInformation(i + 1);
                        }

                        break;

                    case 't':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        ReadingTime(ref Book);

                        break;

                    case 'a':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("What age book do you want to know?");
                        int n = Input(index);
                        Console.WriteLine($"Age of the book: {Book[n].BookAge()}");

                        break;

                    case 'e':
                        Console.ResetColor();

                        return;
                }
            }
        }

        static char Menu()
        {
            char flag = ' ';

            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press any key to bring up the menu...");
                Console.ReadKey();

                Console.WriteLine($"\t\t\t\tEnter (L) to List books." +
                                   "\n\t\t\t\tEnter (N) to enter New book." +
                                   "\n\t\t\t\tEnter (D) to Delete book." +
                                   "\n\t\t\t\tEnter (R) to arrange books in descending order of Rating." +
                                   "\n\t\t\t\tEnter (T) to find out the Time it took to read the book." +
                                   "\n\t\t\t\tEnter (A) to find out the Age of the book." +
                                   "\n\t\t\t\tenter (E) to Exit");

                
                try
                {
                    flag = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                if ("lndarte".Contains(Char.ToLower(flag)))
                {
                    break;
                }
            }
            return flag;
        }

        static CSharp NewBook()
        {
            CSharp Book = new CSharp();

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

            Console.WriteLine("Enter book rating:");

            try
            {
                Book.Popularity = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return Book;
        }

        static void DeleteBook(ref CSharp[] Book)
        {
            int index = 0;
            CSharp[] newBook = new CSharp[Book.Length - 1];

            Console.WriteLine("Which account book do you want to delete?");

            index = Input(Book.Length);
            index--;

            for (int i = 0; i < newBook.Length; i++)
            {
                if(i >= index)
                {
                    newBook[i] = Book[i + 1];
                }
                else
                {
                    newBook[i] = Book[i];
                }
            }
            Book = newBook;
        }

        static void ArrangeBooks(ref CSharp[] Book, int length)
        {
            for (int i = 0; i < length; i++)
            {

                CSharp temp = Book[0];

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
        }

        static void ReadingTime(ref CSharp[] Book)
        {
            int index = 0;

            Console.WriteLine("For which book do you want to calculate the reading time?");
            index = Input(Book.Length);

            Console.Write("If you really try, you can read this book in ");
            Book[index - 1].Timing();
        }

        static int Input(int length)
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

        public void PagesInformation(int i)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{i}. {title, -55} {author, -40} {pages, -10}");
        }
    }

    class CSharp : Literature 
    {
        double popularity;
        int year;
        static int thisYear = 2020;

        public CSharp(string title, string author, int pages, double popularity, int year) :
            base(title, author, pages)
        {
            this.popularity = popularity;
            this.year = year;
        }

        public CSharp() :
            base() { }

        public double Popularity 
        { 
            get { return popularity; }
            set
            {
                if(value < 0 || value > 5)
                {
                    Console.WriteLine("Input incorrect..");
                }
                else
                {
                    popularity = value;
                }
            }
        }

        public int Year
        {
            set
            {
                if (value > thisYear || value < 1983)
                {
                    Console.WriteLine("Input incorrect...");
                }
                else
                {
                    year = value;
                }
            }
        }

        public static int ThisYear
        {
            get { return thisYear; }
        }

        public void PopularityInformation(int i)
        {
            Console.WriteLine($"{i}. {title,-55} {author,-35} {popularity, -10}");
        }

        public void Timing()
        {
            int minutes = pages / 2;
            int hours = minutes / 60;
            minutes -= hours * 60;

            Console.WriteLine($"{hours} hours {minutes} minutes.");
        }

        public int BookAge()
        {
            return thisYear - year;
        }

        public static bool operator <(CSharp B1, CSharp B2)
        {
            if (B1.Popularity < B2.Popularity)
                return true;
            else
                return false;
        }
        public static bool operator >(CSharp B1, CSharp B2)
        {
            if (B1.Popularity < B2.Popularity)
                return true;
            else
                return false;
        }
    }
}
