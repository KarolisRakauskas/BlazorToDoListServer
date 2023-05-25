using BlazorToDoListAPI.Data;
using BlazorToDoListAPI.Repository;
using BlazorToDoListAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationDbContext>(option => {
	option.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")
		);
});
builder.Services.AddScoped<IToDoActiveRepository, ToDoActiveRepository>();
builder.Services.AddScoped<IToDoPassiveRepository, ToDoPassiveRepository>();
builder.Services.AddControllers().AddNewtonsoftJson();
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
