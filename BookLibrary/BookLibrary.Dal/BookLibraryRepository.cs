using System.Threading.Tasks;
using BookLibrary.Models;

namespace BookLibrary.Dal
{
	public class BookLibraryRepository : IBookLibraryRepository
	{
		public Task<Book> AddAsync(string name, string content)
		{
			return Task.FromResult(new Book
			{
				Id = 42,
				Name = name,
				Content = content
			});
		}
	}
}