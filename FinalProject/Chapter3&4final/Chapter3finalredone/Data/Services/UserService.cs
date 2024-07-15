using System.Reflection;
using Chapter3finalredone.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter3finalredone.Data.Services
{
	public class UserService : IUserService
	{
		private readonly ApplicationDbContext _context;

		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Add(User User)
		{
			_context.Users.Add(User);
			await _context.SaveChangesAsync();
		}

		public IQueryable<User> GetAll()
		{
			var applicationDbContext = _context.Users.Include(l => l.UserId);
			return applicationDbContext;
		}

		public async Task<User> GetById(int? id)
		{
			var user = await _context.Users
				
				.FirstOrDefaultAsync(m => m.UserId == id);
			return user;
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}
