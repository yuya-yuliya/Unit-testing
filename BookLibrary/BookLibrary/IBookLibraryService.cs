using System.Threading.Tasks;

namespace BookLibrary.Services
{
	public interface IBookLibraryService
	{
		Task<int> AddAsync(string name, string content);
	}
}