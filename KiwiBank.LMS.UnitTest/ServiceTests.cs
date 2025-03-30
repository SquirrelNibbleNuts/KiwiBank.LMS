using KiwiBank.LMS.Models;
using KiwiBank.LMS.Repositories.Interfaces;
using KiwiBank.LMS.Services;
using Moq;

namespace KiwiBank.LMS.UnitTest
{
	public class ServiceTests
	{
		[Fact]
		public void AddBook_ShouldAddBook_WhenValidISBN()
		{
			var mockRepo = new Mock<IBookRepository>();
			var service = new BookService(mockRepo.Object);
			var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "978-3-16-148410-0" };

			service.AddBook(book);

			mockRepo.Verify(r => r.Add(It.IsAny<Book>()), Times.Once);
		}

		[Fact]
		public void AddBook_ShouldNotAddBook_WhenInvalidISBN()
		{
			var mockRepo = new Mock<IBookRepository>();
			var service = new BookService(mockRepo.Object);
			var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "InvalidISBN" };

			Assert.Throws<ArgumentException>(() => service.AddBook(book));
		}

		[Fact]
		public void UpdateBook_ShouldUpdateBook_WhenValidISBN()
		{
			var mockRepo = new Mock<IBookRepository>();
			var service = new BookService(mockRepo.Object);
			var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "978-3-16-148410-0" };

			service.UpdateBook(book);

			mockRepo.Verify(r => r.Update(It.IsAny<Book>()), Times.Once);
		}

		[Fact]
		public void UpdateBook_ShouldNotUpdateBook_WhenInvalidISBN()
		{
			var mockRepo = new Mock<IBookRepository>();
			var service = new BookService(mockRepo.Object);
			var book = new Book { Id = 1, Title = "Invalid Book", Author = "Author", ISBN = "InvalidISBN" };

			Assert.Throws<ArgumentException>(() => service.UpdateBook(book));
		}

		[Fact]
		public void GetBookById_ShouldReturnBook_WhenBookExists()
		{
			var mockRepo = new Mock<IBookRepository>();
			var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "978-3-16-148410-0" };
			mockRepo.Setup(r => r.GetById(1)).Returns(book);
			var service = new BookService(mockRepo.Object);

			var result = service.GetBookById(1);

			Assert.NotNull(result);
			Assert.Equal(1, result.Id);
		}

		[Fact]
		public void GetBookByIdSorted_ShouldReturnBook_WhenBookExists()
		{
			var mockRepo = new Mock<IBookRepository>();
			var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "978-3-16-148410-0" };
			mockRepo.Setup(r => r.GetByIdSorted(1)).Returns(book);
			var service = new BookService(mockRepo.Object);

			var result = service.GetByIdSorted(1);

			Assert.NotNull(result);
			Assert.Equal(1, result.Id);
		}

		[Fact]
		public void DeleteBook_ShouldCallDelete_WhenBookExists()
		{
			var mockRepo = new Mock<IBookRepository>();
			var service = new BookService(mockRepo.Object);

			service.DeleteBook(1);

			mockRepo.Verify(r => r.Delete(1), Times.Once);
		}
	}
}