using BlazorToDoListLibrary;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoListAPI.Data
{
	public class AplicationDbContext : DbContext
	{
		public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<ToDoActive> ToDoActives {  get; set; }
		public DbSet<ToDoPassive> ToDoPassives { get; set;}
	}
}
