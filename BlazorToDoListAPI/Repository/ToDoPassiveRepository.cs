using BlazorToDoListAPI.Data;
using BlazorToDoListAPI.Repository.IRepository;
using BlazorToDoListLibrary;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoListAPI.Repository
{
	public class ToDoPassiveRepository : Repository<ToDoPassive>, IToDoPassiveRepository
	{
		public ToDoPassiveRepository(AplicationDbContext context) : base(context)
		{
		}
	}
}
