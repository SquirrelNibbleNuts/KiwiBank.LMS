using KiwiBank.LMS.Models;
using KiwiBank.LMS.Repositories.Interfaces;
using System.Linq;

namespace KiwiBank.LMS.Repositories.InMemory
{
	public class ListBookRepository : IBookRepository
	{
		private readonly List<Book> books = [];

		public IEnumerable<Book> GetAll() => books;
		public Book? GetById(int id) => books.FirstOrDefault(b => b.Id == id);
		public Book? GetByIdSorted(int id)
		{
			var sortedBooks = books.OrderBy(b => b.Id).ToDictionary(b => b.Id, b => b);
			return sortedBooks.TryGetValue(id, out Book? value) ? value : null;
		}
		public void Add(Book book) => books.Add(book);
		public void Update(Book book)
		{
			var existing = GetById(book.Id);
			if (existing != null)
			{
				existing.Title = book.Title;
				existing.Author = book.Author;
				existing.ISBN = book.ISBN;
			}
		}

		//If no value is found for id, we will assume success.
		public void Delete(int id) => books.RemoveAll(b => b.Id == id);
	}
}
