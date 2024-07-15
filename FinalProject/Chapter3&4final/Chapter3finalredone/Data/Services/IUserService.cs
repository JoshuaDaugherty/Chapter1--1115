using System.Reflection;
using Chapter3finalredone.Models;

namespace Chapter3finalredone.Data.Services
{
	public interface IUserService
	{
		IQueryable<User> GetAll();
		Task Add(User Users);
		Task<User> GetById(int? id);
		Task SaveChanges();
	}
}
