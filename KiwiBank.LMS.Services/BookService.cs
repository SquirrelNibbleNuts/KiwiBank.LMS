using KiwiBank.LMS.Models;
using KiwiBank.LMS.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace KiwiBank.LMS.Services
{
	public class BookService
	{
		private readonly IBookRepository iRepository;

		public BookService(IBookRepository repository)
		{
			iRepository = repository;
		}

		/// <summary>
		/// Get a list of all available books.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Book> GetAllBooks() => iRepository.GetAll();

		/// <summary>
		/// Get a nullable book by id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Book? GetBookById(int id) => iRepository.GetById(id);

		/// <summary>
		/// Get a nullable book by id as a sortable list which should be faster for larger datasets.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Book? GetByIdSorted(int id) => iRepository.GetByIdSorted(id);

		/// <summary>
		/// Adds a book to the repository.
		/// </summary>
		/// <exception cref="System.ArgumentException">when ISBN is not valid.</exception>
		/// <param name="book"></param>
		public void AddBook(Book book)
		{
			if (!IsValidISBN(book.ISBN))
				throw new ArgumentException("Invalid ISBN format.");
			iRepository.Add(book);
		}

		/// <summary>
		/// Update book object
		/// </summary>
		/// <exception cref="System.ArgumentException">when ISBN is not valid.</exception>
		/// <param name="book"></param>
		public void UpdateBook(Book book)
		{
			if (!IsValidISBN(book.ISBN))
				throw new ArgumentException("Invalid ISBN format.");
			iRepository.Update(book);
		}

		/// <summary>
		/// Delete book by id. Assumes success in the case the id has no matches.
		/// </summary>
		/// <param name="id"></param>
		public void DeleteBook(int id) => iRepository.Delete(id);

		private bool IsValidISBN(string isbn)
		{
			return !string.IsNullOrEmpty(isbn) && Regex.IsMatch(isbn, @"^\d{3}-\d-\d{2}-\d{6}-\d$");
		}
	}
}
