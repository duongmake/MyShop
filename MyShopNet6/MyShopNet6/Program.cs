using Microsoft.EntityFrameworkCore;
using MyShopNet6.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyShopContext>(option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("MyShop")));
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    //build.WithOrigins("https://duongpt.info", "https://localhost:3000");
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
