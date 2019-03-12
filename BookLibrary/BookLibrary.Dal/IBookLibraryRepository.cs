using BookLibrary.Models;
using System.Threading.Tasks;

namespace BookLibrary.Dal
{
	public interface IBookLibraryRepository
	{
		Task<Book> AddAsync(string name, string content);
	}
}