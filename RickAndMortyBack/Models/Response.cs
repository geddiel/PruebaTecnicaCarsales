namespace RickAndMortyBack.Models
{
	public class ApiResponse
	{
		public List<Episode> Results { get; set; }
	}

	public class Episode
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Air_Date { get; set; }
		public List<string> Characters { get; set; }
	}

	public class Character
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public string Species { get; set; }
		public string Image { get; set; }
	}

}
