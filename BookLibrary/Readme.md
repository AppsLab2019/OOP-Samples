# Book Library OOP Sample

This simplified OOP (Object-Oriented-Programming) sample shows how objects could interact with each other.

Let's create a simple book library system.
There could be two classes that represents book and library:

```csharp
class Book
{
    public Book(string name, string author)
    {
        Name = name;
        Author = author;
    }

    public string Name { get; }
    public string Author { get; }
}
```
Every book needs an identificator, a name and an author. This is the reason why we add parameters `name` and `author` in `Book`'s constructor. This cannot be changed later once the book instance (object) is created. That's why the `Name` and `Author` properties do not have `set` method.

---

```csharp
class Library
{
    private readonly List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }
}
```

Library class represents a list of books that are in the library. This is list private so we can work with books only from this `Library` class. We will add some methods for that later.

Let's add a new feature to our library system.

## Feature: Borrow a book

In order to borrow a book we need to do the following:
1. Find a book by id, by name, or by author.
2. Check if book is available (it can be already borrowed).
3. If book is available, we need to:
   * set date when book was borrowed 
   * set information on who borrowed it
   * and make it not available for next borrows.

Let's add method to `Library` class to find book by `id`:

```csharp
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
```

---

Let's add method to `Library` class to find book by `name`:

```csharp
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
```

---

Let's add method to `Library` class to find book by `author`:

```csharp
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
```

See that all these methods could return found `book` object or `null` when book is not found.
`null` is a special keyword in C# that basically says that there is **no object**.

Let's continue.

---
If we have a `Book` object found we need to check if this book is available and it can be borrowed.
Let's add new `bool` property to `Book` class that will informs about available state. Like this:

```csharp
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
}
```
New property `IsAvailable` has `get` and `set` keywords. That means that we can read and write to this property once this object is created.

---

Let's add also additional property `BorrowedAt` of type `DateTime` this will inform about date & time when this book was borrowed, so that it can be tracked how long book is borrowed.

```csharp
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
}
```
New property `BorrowedAt` has also `get` and `set` keywords. That means that we can read and write to this property once this object is created.

---

Let's add also additional property `BorrowedAt` of type `DateTime` this will inform about date & time when this book was borrowed, so that it can be tracked how long book is borrowed.

```csharp
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
}
```
New property `BorrowedAt` has also `get` and `set` keywords. That means that we can read and write to this property once this object is created.

---

Let's add also additional property `BorrowedBy` of type `string` this will inform about who borrowed this book. 

*Note, that this is very simplified, in real system we would also have additional class for library's customers.*

```csharp
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
```
New property `BorrowedBy` has also `get` and `set` keywords. That means that we can read and write to this property once this object is created. When this property is not set yet, it has `null` value since `string` type is reference type.

---

Let's add new method `Borrow` to `Library` class, like this:

```csharp
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
```

---

*Note, that this library system sample is only for showing the relation between classes. Currently this `Library` class is empty and has no books.  
Let's add some books to library as a homework.*
