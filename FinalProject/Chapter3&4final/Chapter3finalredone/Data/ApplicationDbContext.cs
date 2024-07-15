using Chapter3finalredone.Models;
using Microsoft.EntityFrameworkCore;
namespace Chapter3finalredone.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
					: base(options)
		{
		}

		public DbSet<WorkoutLog> WorkoutLogs { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
