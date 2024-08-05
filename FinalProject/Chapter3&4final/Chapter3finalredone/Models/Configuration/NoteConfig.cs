using Chapter3finalredone.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chapter3finalredone.Models.Configuration
{
	public class NoteConfig : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> entity)
		{
			entity.HasData(
				new Note { NoteId = 1, NotesAfterWorkout = "I enjoyed leg day." },
				new Note { NoteId = 2, NotesAfterWorkout = "I need to work on my form for squats." },
				new Note { NoteId = 3, NotesAfterWorkout = "Im starting to make progress in my lifts." },
				new Note { NoteId = 4, NotesAfterWorkout = "I didnt really feel like going to the gym, but I went anyway." },
				new Note { NoteId = 5, NotesAfterWorkout = "Today I worked on my balance." },
				new Note { NoteId = 6, NotesAfterWorkout = "Today I ran a mile on the treadmill." }

				) ;
		}
	}
}
