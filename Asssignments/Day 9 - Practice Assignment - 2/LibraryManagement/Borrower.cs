using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
        /// <summary>Represents a borrower registered in the library.</summary>
        public class Borrower
        {
            public string Name { get; set; }
            public string LibraryCardNumber { get; set; }
            public List<Book> BorrowedBooks { get; set; }

            public Borrower(string name, string libraryCardNumber)
            {
                Name = name;
                LibraryCardNumber = libraryCardNumber;
                BorrowedBooks = new List<Book>(); // empty list initially
            }

            /// <summary>Borrower borrows a book — marks it borrowed and adds to their list.</summary>
            public void BorrowBook(Book book)
            {
                book.Borrow(); // marks book as borrowed
                BorrowedBooks.Add(book); // adds to borrower's list
            }

            /// <summary>Borrower returns a book — marks it available and removes from their list.</summary>
            public void ReturnBook(Book book)
            {
                book.Return(); // marks book as available
                BorrowedBooks.Remove(book); // removes from borrower's list
            }
        }
}
