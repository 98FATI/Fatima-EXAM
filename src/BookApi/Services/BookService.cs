using BookApi.Models;

namespace BookApi.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "Moonlight", Author = "Claire" },
        new Book { Id = 2, Title = "Darkness Rising", Author = "Sombre" }
    };

    public List<Book> GetAll() => _books;

    public Book? Get(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        book.Id = _books.Max(b => b.Id) + 1;
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index != -1)
        {
            _books[index] = book;
        }
    }

    public void Delete(int id)
    {
        var book = Get(id);
        if (book != null)
        {
            _books.Remove(book);
        }
    }
}
