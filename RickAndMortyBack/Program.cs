using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

var app = builder.Build();

app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 
app.Run();
