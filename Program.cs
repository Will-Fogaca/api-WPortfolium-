using Microsoft.EntityFrameworkCore;
using WillPortfolio_Api.Data;
using WillPortfolio_Api.Repositories;
using WillPortfolio_Api.Repositories.Interfaces;
using WillPortfolio_Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    c.RoutePrefix = string.Empty; // Faz com que o Swagger fique em "/"
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();