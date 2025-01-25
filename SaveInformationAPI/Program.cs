using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

/*
 // Add services to the container.
builder.Services.AddDbContext<APIDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationConnection")));
*/

// Add services to the container.
//builder.Services.AddDbContext<ApplicationDBContext>(
   // options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection") 
    ?? throw new InvalidOperationException("Connection string 'ApplicationConnection' not found.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyection of dependencies for the API Controllers
builder.Services.AddScoped<CanchaRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ReservaRepository>();
builder.Services.AddScoped<ComplejoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
