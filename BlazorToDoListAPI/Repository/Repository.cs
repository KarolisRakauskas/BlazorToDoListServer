using BlazorToDoListAPI.Data;
using BlazorToDoListAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoListAPI.Repository
{
	public class Repository <T> : IRepository <T> where T : class
	{
		private readonly AplicationDbContext _context;
		internal DbSet<T> dbSet;

		public Repository(AplicationDbContext context)
		{
			_context = context;
			this.dbSet = _context.Set<T>();
		}

		public async Task CreateAsync(T entity)
		{
			await dbSet.AddAsync(entity);
			await SaveAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			dbSet.Remove(entity);
			await SaveAsync();
		}

		public async Task<List<T>> GetAllAsync()
		{
			IQueryable<T> query = dbSet;
			return await query.ToListAsync();
		}

		public async Task<T> GetAsync(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			dbSet.Update(entity);
			await SaveAsync();
		}
	}
}
