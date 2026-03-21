using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
        /// <summary>Represents a book in the library.</summary>
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public bool IsBorrowed { get; set; }

            public Book(string title, string author, string isbn)
            {
                Title = title;
                Author = author;
                ISBN = isbn;
                IsBorrowed = false; // default: available
            }

            /// <summary>Marks the book as borrowed.</summary>
            public void Borrow()
            {
                if (IsBorrowed)
                    throw new InvalidOperationException($"Book '{Title}' is already borrowed.");
                IsBorrowed = true;
            }

            /// <summary>Marks the book as returned/available.</summary>
            public void Return()
            {
                if (!IsBorrowed)
                    throw new InvalidOperationException($"Book '{Title}' is not currently borrowed.");
                IsBorrowed = false;
            }
        }
}

