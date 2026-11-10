using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

/*
builder.Services.AddDbContext<RaceDayDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

// Register Swagger generator services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable Swagger middleware globally 
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RaceDay API v1");
    c.RoutePrefix = string.Empty; // Loads Swagger directly at the root URL (e.g., http://localhost:5005)
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();