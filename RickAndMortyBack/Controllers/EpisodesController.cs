using Microsoft.AspNetCore.Mvc;
using RickAndMortyBack.Services;
using System.Threading.Tasks;

namespace RickAndMortyBack.Controllers
{
	[ApiController]
	[Route("api/episodes")]
	public class EpisodesController : ControllerBase
	{
		private readonly IEpisodeService _episodeService;

		public EpisodesController(IEpisodeService episodeService)
		{
			_episodeService = episodeService;
		}

		[HttpGet]
		public async Task<IActionResult> GetEpisodes()
		{
			var episodes = await _episodeService.GetEpisodes();
			if (episodes == null) return NotFound("No se encontraron episodios.");

			return Ok(episodes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetEpisodeDetail(int id)
		{
			var episodeDetail = await _episodeService.GetEpisodeDetail(id);
			return episodeDetail != null ? Ok(episodeDetail) : NotFound($"Episodio con ID {id} no encontrado.");
		}
	}
}
