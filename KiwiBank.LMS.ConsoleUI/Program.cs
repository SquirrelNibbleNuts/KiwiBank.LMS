using KiwiBank.LMS.ConsoleUI;
using KiwiBank.LMS.Models;
using KiwiBank.LMS.Repositories.InMemory;
using KiwiBank.LMS.Repositories.Interfaces;
using KiwiBank.LMS.Services;

IBookRepository repository = new ListBookRepository();
BookService service = new(repository);
PreloadTestData.LoadTestBooks(service);

while (true)
{
	Console.WriteLine("\n1. Add Book\n2. List Books\n3. Get Book by ID\n4. Get Book by ID as a sorted list (faster)\n5. Update Book\n6. Delete Book\n6. Exit\n");
	string choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
			Console.Write("Enter Title: ");
			string title = Console.ReadLine();
			Console.Write("Enter Author: ");
			string author = Console.ReadLine();
			Console.Write("Enter ISBN: ");
			string isbn = Console.ReadLine();
			service.AddBook(new Book { Id = new Random().Next(1, 1000), Title = title, Author = author, ISBN = isbn });
			break;
		case "2":
			foreach (var book in service.GetAllBooks())
				Console.WriteLine($"BookId: {book.Id}, Book Title: {book.Title}, Book Author: {book.Author} (ISBN: {book.ISBN})");
			break;
		case "3":
			Console.Write("Enter Book ID: ");
			int id = int.Parse(Console.ReadLine());
			var bookById = service.GetBookById(id);
			Console.WriteLine(bookById != null ? $"BookId: {bookById.Id}, Book Title: {bookById.Title}, Book Author: {bookById.Author} (ISBN: {bookById.ISBN})" : "Book not found.");
			break;
		case "4":
			Console.Write("Enter Book ID: ");
			int bookId = int.Parse(Console.ReadLine());
			var bookByIdSorted = service.GetByIdSorted(bookId);
			Console.WriteLine(bookByIdSorted != null ? $"BookId: {bookByIdSorted.Id}, Book Title: {bookByIdSorted.Title}, Book Author: {bookByIdSorted.Author} (ISBN: {bookByIdSorted.ISBN})" : "Book not found.");
			break;
		case "5":
			Console.Write("Enter Book ID: ");
			int updateId = int.Parse(Console.ReadLine());
			Console.Write("Enter New Title: ");
			string newTitle = Console.ReadLine();
			Console.Write("Enter New Author: ");
			string newAuthor = Console.ReadLine();
			Console.Write("Enter New ISBN: ");
			string newIsbn = Console.ReadLine();
			service.UpdateBook(new Book { Id = updateId, Title = newTitle, Author = newAuthor, ISBN = newIsbn });
			break;
		case "6":
			Console.Write("Enter Book ID: ");
			int deleteId = int.Parse(Console.ReadLine());
			service.DeleteBook(deleteId);
			break;
		case "7":
			return;
		default:
			Console.WriteLine("Invalid choice. Try again.");
			break;
	}
}