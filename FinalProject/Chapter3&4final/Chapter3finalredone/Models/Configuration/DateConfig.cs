using Chapter3finalredone.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chapter3finalredone.Models.Configuration
{
	public class DateConfig : IEntityTypeConfiguration<Date>
	{
		public void Configure(EntityTypeBuilder<Date> entity)
		{
			new Date { DateId = 1, DateofWorkout = new DateTime(8 / 3 / 2024) };
			new Date { DateId = 2, DateofWorkout = new DateTime(8 / 4 / 2024) };
			new Date { DateId = 3, DateofWorkout = new DateTime(8 / 5 / 2024) };
			new Date { DateId = 4, DateofWorkout = new DateTime(8 / 6 / 2024) };
			new Date { DateId = 5, DateofWorkout = new DateTime(8 / 7 / 2024) };
			new Date { DateId = 6, DateofWorkout = new DateTime(8 / 8 / 2024) };
			
		}
	}
}
