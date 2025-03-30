using KiwiBank.LMS.Models;

namespace KiwiBank.LMS.Repositories.Interfaces
{
	public interface IBookRepository
	{
		/// <summary>
		/// Get a list of all available books.
		/// </summary>
		/// <returns></returns>
		IEnumerable<Book> GetAll();

		/// <summary>
		/// Get a nullable book by id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Book? GetById(int id);

		/// <summary>
		/// Get a nullable book by id as a sortable list which should be faster for larger datasets.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Book? GetByIdSorted(int id);

		/// <summary>
		/// Adds a book to the repository.
		/// </summary>
		/// <exception cref="System.ArgumentException">when ISBN is not valid.</exception>
		/// <param name="book"></param>
		void Add(Book book);

		/// <summary>
		/// Update book object
		/// </summary>
		/// /// <exception cref="System.ArgumentException">when ISBN is not valid.</exception>
		/// <param name="book"></param>
		void Update(Book book);

		/// <summary>
		/// Delete book by id. Assumes success in the case the id has no matches.
		/// </summary>
		/// <param name="id"></param>
		void Delete(int id);
	}
}
