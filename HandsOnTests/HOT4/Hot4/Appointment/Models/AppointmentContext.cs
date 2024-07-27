using System;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }

        public DbSet<Appointments> Appointments { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>().HasData(
				new Customer
				{
					CustomerId = 1,
					UserName = "JohnSmith123",
					PhoneNumber = "314-655-4009"
				},

				new Customer
				{
					CustomerId = 2,
					UserName = "Rileysmiley222",
					PhoneNumber = "314-888-1234"
				},

				new Customer
				{
					CustomerId = 3,
					UserName = "Buddy554",
					PhoneNumber = "313-776-0984"
				},

				new Customer
				{
					CustomerId = 4,
					UserName = "Killerclutch33",
					PhoneNumber = "312-000-1234"
				});

			modelBuilder.Entity<Appointments>().HasData(
				new Appointments
				{
					AppointmentsId = 1,
					StartTime = new DateTime(2024, 7, 26),
					CustomerId = 1
					
				},

				new Appointments
				{
					AppointmentsId = 2,
					StartTime = new DateTime(2024, 7, 27),
					CustomerId = 2

				},

				new Appointments
				{
					AppointmentsId = 3,
					StartTime = new DateTime(2024, 7, 28),
					CustomerId = 3

				},

				new Appointments
				{
					AppointmentsId = 4,
					StartTime = new DateTime(2024, 7, 29),
					CustomerId = 4

				},

				new Appointments
				{
					AppointmentsId = 5,
					StartTime = new DateTime(2024, 7, 29),
					CustomerId = 1

				}

				);
		}
	}
}
