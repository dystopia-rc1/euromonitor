using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euromonitor.Assessment.Common
{
    public static class BookService
    {
        private static IEnumerable<Book> _books = new List<Book>()
        {
            new Book() { Name = "Book1", PurchasePrice = 1, Text = "Text1" },
            new Book() { Name = "Book2", PurchasePrice = 2, Text = "Text2" },
            new Book() { Name = "Book3", PurchasePrice = 3, Text = "Text3" },
            new Book() { Name = "Book4", PurchasePrice = 4, Text = "Text4" },
            new Book() { Name = "Book5", PurchasePrice = 5, Text = "Text5" }
        };
        public static IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public static Book GetBook(string name)
        {
            return _books.First(b => b.Name.Equals(name));
        }
    }
}
