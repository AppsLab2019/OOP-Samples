using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary
{
    class Library
    {
        private readonly List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public Book FindBookById(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book FindByName(string name)
        {
            foreach (var book in books)
            {
                if (book.Name == name)
                {
                    return book;
                }
            }
            return null;
        }

        public Book FindByAuthor(string author)
        {
            foreach (var book in books)
            {
                if (book.Author == author)
                {
                    return book;
                }
            }
            return null;
        }

        public void Borrow(Book book, string who)
        {
            if (book.IsAvailable)
            {
                book.BorrowedBy = who;
                book.BorrowedAt = DateTime.Now;
                book.IsAvailable = false;
                Console.WriteLine($"{book.Name} is borrowed by {who}");
            }
            else
            {
                Console.WriteLine($"{book.Name} is not available.");
            }
        }
    }
}
