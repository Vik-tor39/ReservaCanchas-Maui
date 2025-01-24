using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;

var builder = WebApplication.CreateBuilder(args);

/*
 // Add services to the container.
builder.Services.AddDbContext<APIDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationConnection")));
*/

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection")));

builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection") 
    ?? throw new InvalidOperationException("Connection string 'ApplicationConnection' not found.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
