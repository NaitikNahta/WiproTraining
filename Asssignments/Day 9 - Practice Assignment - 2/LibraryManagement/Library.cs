using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{/// <summary>Manages the library — books and borrowers.</summary>
        public class Library
        {
            public List<Book> Books { get; set; }
            public List<Borrower> Borrowers { get; set; }

            public Library()
            {
                Books = new List<Book>();
                Borrowers = new List<Borrower>();
            }

            /// <summary>Adds a new book to the library.</summary>
            public void AddBook(Book book)
            {
                Books.Add(book);
                Console.WriteLine($"Book '{book.Title}' added successfully.");
            }

            /// <summary>Registers a new borrower in the library.</summary>
            public void RegisterBorrower(Borrower borrower)
            {
                Borrowers.Add(borrower);
                Console.WriteLine($"Borrower '{borrower.Name}' registered successfully.");
            }

            /// <summary>Allows a borrower to borrow a book using ISBN and library card number.</summary>
            public void BorrowBook(string isbn, string libraryCardNumber)
            {
                // Find the book by ISBN
                Book? book = Books.FirstOrDefault(b => b.ISBN == isbn);
                if (book == null)
                    throw new Exception($"Book with ISBN '{isbn}' not found.");

                // Find the borrower by library card number
                Borrower?   borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
                if (borrower == null)
                    throw new Exception($"Borrower with card number '{libraryCardNumber}' not found.");

                // Borrow the book
                borrower.BorrowBook(book);
                Console.WriteLine($"'{book.Title}' borrowed by {borrower.Name}.");
            }

            /// <summary>Allows a borrower to return a book using ISBN and library card number.</summary>
            public void ReturnBook(string isbn, string libraryCardNumber)
            {
                // Find the borrower
                Borrower? borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
                if (borrower == null)
                    throw new Exception($"Borrower with card number '{libraryCardNumber}' not found.");

                // Find the book in borrower's list
                Book? book = borrower.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);
                if (book == null)
                    throw new Exception($"This borrower has not borrowed book with ISBN '{isbn}'.");

                // Return the book
                borrower.ReturnBook(book);
                Console.WriteLine($"'{book.Title}' returned by {borrower.Name}.");
            }

            /// <summary>Displays all books and their current status.</summary>
            public List<string> ViewBooks()
            {
                var result = new List<string>();
                foreach (var book in Books)
                {
                    string status = book.IsBorrowed ? "Borrowed" : "Available";
                    string info = $"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Status: {status}";
                    result.Add(info);
                    Console.WriteLine(info);
                }
                return result;
            }

            /// <summary>Displays all borrowers and their borrowed books.</summary>
            public List<string> ViewBorrowers()
            {
                var result = new List<string>();
                foreach (var borrower in Borrowers)
                {
                    string borrowedBooks = borrower.BorrowedBooks.Count > 0
                        ? string.Join(", ", borrower.BorrowedBooks.Select(b => b.Title))
                        : "None";
                    string info = $"Name: {borrower.Name}, Card: {borrower.LibraryCardNumber}, Borrowed Books: {borrowedBooks}";
                    result.Add(info);
                    Console.WriteLine(info);
                }
                return result;
            }
        }
}
