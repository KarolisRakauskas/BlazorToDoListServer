using BlazorToDoListAPI.Data;
using BlazorToDoListAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoListAPI.Repository
{
	public class Repository <T> : IRepository <T> where T : class
	{
		private readonly AplicationDbContext _context;
		internal DbSet<T> dbSet;

		public Repository(AplicationDbContext context, DbSet<T> dbSet)
		{
			_context = context;
			this.dbSet = dbSet;
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
			IQueryable<T> querey = dbSet;
			return await querey.ToListAsync();
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
