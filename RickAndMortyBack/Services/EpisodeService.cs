using RickAndMortyBack.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RickAndMortyBack.Services
{
	public class EpisodeService : IEpisodeService
	{
		private readonly HttpClient _httpClient;

		public EpisodeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ApiResponse> GetEpisodes()
		{
			var response = await _httpClient.GetFromJsonAsync<ApiResponse>("https://rickandmortyapi.com/api/episode");
			return response ?? new ApiResponse { Results = new List<Episode>() };
		}

		public async Task<object> GetEpisodeDetail(int id)
		{
			var episode = await _httpClient.GetFromJsonAsync<Episode>($"https://rickandmortyapi.com/api/episode/{id}");
			if (episode == null) return null;

			var characterTasks = episode.Characters.Select(url => _httpClient.GetFromJsonAsync<Character>(url));
			var characters = await Task.WhenAll(characterTasks);

			return new { episode, characters };
		}
	}
}
