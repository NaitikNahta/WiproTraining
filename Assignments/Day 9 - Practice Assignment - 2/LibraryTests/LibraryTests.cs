using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement;
using NUnit.Framework;
namespace LibraryTests
{
        [TestFixture]
        public class LibraryTests
        {
            private Library _library;
            private Book _book1;
            private Book _book2;
            private Borrower _borrower1;

            // Runs before each test — sets up fresh objects
            [SetUp]
            public void SetUp()
            {
                _library = new Library();
                _book1 = new Book("C# Programming", "John Smith", "ISBN001");
                _book2 = new Book("ASP.NET Core", "Jane Doe", "ISBN002");
                _borrower1 = new Borrower("Alice", "CARD001");
            }

            // ─── ADD BOOK ───────────────────────────────────────────

            [Test]
            public void AddBook_BookAddedToLibrary_CountIncreases()
            {
                _library.AddBook(_book1);
                Assert.AreEqual(1, _library.Books.Count);
            }

            [Test]
            public void AddBook_BookDetailsStoredCorrectly()
            {
                _library.AddBook(_book1);
                Assert.AreEqual("C# Programming", _library.Books[0].Title);
                Assert.AreEqual("John Smith", _library.Books[0].Author);
                Assert.AreEqual("ISBN001", _library.Books[0].ISBN);
            }

            [Test]
            public void AddBook_NewBookIsAvailableByDefault()
            {
                _library.AddBook(_book1);
                Assert.IsFalse(_library.Books[0].IsBorrowed);
            }

            // ─── REGISTER BORROWER ──────────────────────────────────

            [Test]
            public void RegisterBorrower_BorrowerAddedToLibrary_CountIncreases()
            {
                _library.RegisterBorrower(_borrower1);
                Assert.AreEqual(1, _library.Borrowers.Count);
            }

            [Test]
            public void RegisterBorrower_BorrowerDetailsStoredCorrectly()
            {
                _library.RegisterBorrower(_borrower1);
                Assert.AreEqual("Alice", _library.Borrowers[0].Name);
                Assert.AreEqual("CARD001", _library.Borrowers[0].LibraryCardNumber);
            }

            [Test]
            public void RegisterBorrower_NewBorrowerHasNoBorrowedBooks()
            {
                _library.RegisterBorrower(_borrower1);
                Assert.AreEqual(0, _library.Borrowers[0].BorrowedBooks.Count);
            }

            // ─── BORROW BOOK ────────────────────────────────────────

            [Test]
            public void BorrowBook_BookIsMarkedAsBorrowed()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");
                Assert.IsTrue(_book1.IsBorrowed);
            }

            [Test]
            public void BorrowBook_BookAssociatedWithBorrower()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");
                Assert.AreEqual(1, _borrower1.BorrowedBooks.Count);
                Assert.AreEqual("ISBN001", _borrower1.BorrowedBooks[0].ISBN);
            }

            [Test]
            public void BorrowBook_AlreadyBorrowed_ThrowsException()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");

                // Try to borrow again — should throw
                var borrower2 = new Borrower("Bob", "CARD002");
                _library.RegisterBorrower(borrower2);
                Assert.Throws<InvalidOperationException>(() => _library.BorrowBook("ISBN001", "CARD002"));
            }

            [Test]
            public void BorrowBook_InvalidISBN_ThrowsException()
            {
                _library.RegisterBorrower(_borrower1);
                Assert.Throws<Exception>(() => _library.BorrowBook("INVALID", "CARD001"));
            }

            // ─── RETURN BOOK ────────────────────────────────────────

            [Test]
            public void ReturnBook_BookIsMarkedAsAvailable()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");
                _library.ReturnBook("ISBN001", "CARD001");
                Assert.IsFalse(_book1.IsBorrowed);
            }

            [Test]
            public void ReturnBook_BookRemovedFromBorrowerList()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");
                _library.ReturnBook("ISBN001", "CARD001");
                Assert.AreEqual(0, _borrower1.BorrowedBooks.Count);
            }

            // ─── VIEW BOOKS & BORROWERS ─────────────────────────────

            [Test]
            public void ViewBooks_ReturnsCorrectNumberOfBooks()
            {
                _library.AddBook(_book1);
                _library.AddBook(_book2);
                var result = _library.ViewBooks();
                Assert.AreEqual(2, result.Count);
            }

            [Test]
            public void ViewBooks_ShowsCorrectStatus()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");
                var result = _library.ViewBooks();
                Assert.IsTrue(result[0].Contains("Borrowed"));
            }

            [Test]
            public void ViewBorrowers_ReturnsCorrectNumberOfBorrowers()
            {
                _library.RegisterBorrower(_borrower1);
                var result = _library.ViewBorrowers();
                Assert.AreEqual(1, result.Count);
            }

            [Test]
            public void ViewBorrowers_ShowsBorrowedBooks()
            {
                _library.AddBook(_book1);
                _library.RegisterBorrower(_borrower1);
                _library.BorrowBook("ISBN001", "CARD001");
                var result = _library.ViewBorrowers();
                Assert.IsTrue(result[0].Contains("C# Programming"));
            }
        }
}