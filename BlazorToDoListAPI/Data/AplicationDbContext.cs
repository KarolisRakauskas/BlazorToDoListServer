using BlazorToDoListLibrary;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoListAPI.Data
{
	public class AplicationDbContext : DbContext
	{
		public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
		{
			
		}

		DbSet<ToDoActive> ToDoActives {  get; set; }
		DbSet<ToDoPassive> ToDoPassives { get; set;}
	}
}
