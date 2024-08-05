using Chapter3finalredone.Models.Configuration;
using Chapter3finalredone.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Chapter3finalredone.Models.DataLayer
{
	public class LoggingContext : DbContext
	{
		public LoggingContext(DbContextOptions<LoggingContext> options) 
			:base(options)
		{ }

		public DbSet<Date> Dates { get; set; } = null!;
		public DbSet<Note> Notes { get; set; } = null!;
		public DbSet<ExcersizeLog> ExcersizeLogs { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Seed Data
			modelBuilder.ApplyConfiguration(new DateConfig());
			modelBuilder.ApplyConfiguration(new NoteConfig());
			modelBuilder.ApplyConfiguration(new ExcersizeLogConfig());


		}
	}
}
