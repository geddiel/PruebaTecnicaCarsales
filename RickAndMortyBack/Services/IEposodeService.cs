using RickAndMortyBack.Models;
using System.Threading.Tasks;

namespace RickAndMortyBack.Services
{
	public interface IEpisodeService
	{
		Task<ApiResponse> GetEpisodes(); 
		Task<object> GetEpisodeDetail(int id);
	}
}
