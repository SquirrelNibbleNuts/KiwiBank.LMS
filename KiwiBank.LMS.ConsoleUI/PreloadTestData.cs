using KiwiBank.LMS.Models;
using KiwiBank.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiBank.LMS.ConsoleUI
{
	internal class PreloadTestData
	{
		public static void LoadTestBooks(BookService service)
		{
			for (int i = 1; i <= 5; i++)
			{
				service.AddBook(new Book
				{
					Id = i,
					Title = $"Test Book {i}",
					Author = $"Test Author {i}",
					ISBN = $"978-3-16-14841{i}-0"
				});
			}
		}
	}
}
