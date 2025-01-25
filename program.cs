using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    class Program
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }

            public Book(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
            }

            public override string ToString()
            {
                return $"{Title} by {Author} ({Year})";
            }
        }

        public class Library
        {
            private List<Book> books = new List<Book>();

            // Добавление книги
            public void AddBook(Book book)
            {
                books.Add(book);
                Console.WriteLine("Book added successfully.");
            }

            // Удаление книги
            public void RemoveBook(string title)
            {
                var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (book != null)
                {
                    books.Remove(book);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }

            // Поиск книг
            public List<Book> SearchBooks(string query)
            {
                return books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                         b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Book> SearchBooksByYear(int year)
            {
                return books.Where(b => b.Year == year).ToList();
            }

            // Вывод всех книг
            public void DisplayAllBooks()
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("No books in the library.");
                }
                else
                {
                    Console.WriteLine("Books in the library:");
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Library library = new Library();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Search Books by Year");
                Console.WriteLine("5. Display All Books");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter year: ");
                        if (int.TryParse(Console.ReadLine(), out int year))
                        {
                            library.AddBook(new Book(title, author, year));
                        }
                        else
                        {
                            Console.WriteLine("Invalid year. Please try again.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter the title of the book to remove: ");
                        string titleToRemove = Console.ReadLine();
                        library.RemoveBook(titleToRemove);
                        break;

                    case "3":
                        Console.Write("Enter search query (title or author): ");
                        string query = Console.ReadLine();
                        var results = library.SearchBooks(query);
                        if (results.Count > 0)
                        {
                            Console.WriteLine("Search results:");
                            foreach (var book in results)
                            {
                                Console.WriteLine(book);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter the year to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchYear))
                        {
                            var yearResults = library.SearchBooksByYear(searchYear);
                            if (yearResults.Count > 0)
                            {
                                Console.WriteLine("Search results:");
                                foreach (var book in yearResults)
                                {
                                    Console.WriteLine(book);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No books found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid year. Please try again.");
                        }
                        break;

                    case "5":
                        library.DisplayAllBooks();
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
