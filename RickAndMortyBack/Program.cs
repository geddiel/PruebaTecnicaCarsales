using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RickAndMortyBack.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAngular", policy =>
		policy.WithOrigins("http://localhost:4200")
			  .AllowAnyMethod()
			  .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Rick and Morty API",
		Version = "v1",
		Description = "API de Rick and Morty con ASP.NET 9",
		Contact = new OpenApiContact
		{
			Name = "Kevin Rujano",
			Email = "rujanok@gmail.com",
			Url = new Uri("https://github.com/geddiel")
		}
	});
});

var app = builder.Build();

app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rick and Morty API v1");
	c.RoutePrefix = "swagger"; 
});

var url = "http://localhost:5069/swagger";
app.Lifetime.ApplicationStarted.Register(() =>
{
	var psi = new System.Diagnostics.ProcessStartInfo
	{
		FileName = url,
		UseShellExecute = true
	};
	System.Diagnostics.Process.Start(psi);
});

app.Run();
