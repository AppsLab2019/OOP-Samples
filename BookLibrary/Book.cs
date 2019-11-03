using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{
    class Book
    {
        public Book(int id, string name, string author)
        {
            Name = name;
            Author = author;
        }

        public int Id { get; }
        public string Name { get; }
        public string Author { get; }
        public bool IsAvailable { get; set; }
        public DateTime BorrowedAt { get; set; }
        public string BorrowedBy { get; set; }
    }
}
