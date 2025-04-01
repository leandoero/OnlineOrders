using Microsoft.EntityFrameworkCore;
using OnlineOrders.Data;
using OnlineOrders.Mappings;
using OnlineOrders.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineOrdersDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineOrdersConnectionString")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddScoped<IProductRepository, SQLProductRepository>();
builder.Services.AddScoped<IClientRepository, SQLClientRepository>();

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
