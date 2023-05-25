using BlazorToDoListAPI.Data;
using BlazorToDoListAPI.Repository.IRepository;
using BlazorToDoListLibrary;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoListAPI.Repository
{
	public class ToDoActiveRepository : Repository<ToDoActive>, IToDoActiveRepository
	{
		public ToDoActiveRepository(AplicationDbContext context) : base(context)
		{
		}
	}
}
