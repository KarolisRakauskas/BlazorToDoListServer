using System.Linq.Expressions;

namespace BlazorToDoListAPI.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetAsync(int id);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task SaveAsync();
	}
}
