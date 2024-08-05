using Chapter3finalredone.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chapter3finalredone.Models.Configuration
{
	public class ExcersizeLogConfig : IEntityTypeConfiguration<ExcersizeLog>
	{
		public void Configure(EntityTypeBuilder<ExcersizeLog> entity)
		{
			entity.HasOne(l => l.Date)
				.WithMany(d => d.excersizeLogs)
				.OnDelete(DeleteBehavior.Restrict);

			entity.HasData(
				new ExcersizeLog { ExcersizeLogId = 1, ExcersizeLogName = "Leg Day", NoteId =1, DateId = 1, MilitaryTime = "0900" },
				new ExcersizeLog { ExcersizeLogId = 2, ExcersizeLogName = "Leg Day", NoteId =2, DateId = 2, MilitaryTime = "0300" },
				new ExcersizeLog { ExcersizeLogId = 3, ExcersizeLogName = "Leg Day", NoteId =3, DateId = 3, MilitaryTime = "0400" },
				new ExcersizeLog { ExcersizeLogId = 4, ExcersizeLogName = "Leg Day", NoteId =4, DateId = 4, MilitaryTime = "0500" },
				new ExcersizeLog { ExcersizeLogId = 5, ExcersizeLogName = "Leg Day", NoteId =5, DateId = 5, MilitaryTime = "0650" },
				new ExcersizeLog { ExcersizeLogId = 6, ExcersizeLogName = "Leg Day", NoteId =6, DateId = 6, MilitaryTime = "0700" }
				);

		}
	}
}
