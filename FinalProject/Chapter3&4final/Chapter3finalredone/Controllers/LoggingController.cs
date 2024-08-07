using Chapter3finalredone.Models.DataLayer;
using Chapter3finalredone.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Controllers
{
	public class LoggingController : Controller
	{
		private Repository<WorkoutLog> WorkoutLogs { get; set; }
		private Repository<Exercise> exercises { get; set; }

		public LoggingController(LoggingContext context)
		{
			WorkoutLogs = new Repository<WorkoutLog>(context);
			exercises = new Repository<Exercise>(context);
		}

		public IActionResult Index(int id)
		{
			var dateOptions = new QueryOptions<Exercise>
			{
				OrderBy = d => d.ExerciseId
			};
			var WorkoutLogOptions = new QueryOptions<WorkoutLog>
			{
				Includes = "Date,Note"
			};

			if (id == 0)
			{
				WorkoutLogOptions.OrderBy = c => c.WorkoutLogId;
				WorkoutLogOptions.ThenOrderBy = c => c.Date;

			}
			else
			{
				WorkoutLogOptions.Where = c => c.WorkoutLogId == id;
				WorkoutLogOptions.OrderBy = c => c.Date;
			}

			var DateList = exercises.List(dateOptions);
			var WorkoutLogList = WorkoutLogs.List(WorkoutLogOptions);

			ViewBag.Id = id;
			ViewBag.Date = DateList;

			return View(WorkoutLogList);
		}

		[HttpGet]
		public ViewResult Add() => View();

		[HttpPost]
		public IActionResult Add(WorkoutLog e)
		{
			bool isAdd = e.WorkoutLogId == 0;

			if (ModelState.IsValid)
			{
				if (isAdd)
					WorkoutLogs.Insert(e);
				else
					WorkoutLogs.Update(e);
				WorkoutLogs.Save();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				string operation = (isAdd) ? "Add" : "Edit";
				this.LoadViewBag(operation);
				return View("AddEdit", e);
			}
		}

		[HttpGet]
		public ViewResult Delete(int id) => View(WorkoutLogs.Get(id));

		[HttpPost]
		public RedirectToActionResult Delete(WorkoutLog WorkoutLog)
		{
			WorkoutLogs.Delete(WorkoutLog);
			WorkoutLogs.Save();
			return RedirectToAction("AddWorkout");
		}

		[HttpGet]
		public ViewResult Edit(int id)
		{
			this.LoadViewBag("Edit");
			var c = this.GetExcersizeLog(id);
			return View("AddEdit");
		}

		private WorkoutLog GetExcersizeLog(int id)
		{
			var WorkoutLogOptions = new QueryOptions<WorkoutLog>
			{
				Includes = "Note, Date",
				Where  = c => c.WorkoutLogId ==id
			};
			return WorkoutLogs.Get(WorkoutLogOptions) ?? new WorkoutLog();
		}

		private void LoadViewBag(string operation)
		{
			//ViewBag.Dates = exercises.List(new QueryOptions<WorkoutLog>
			//{
			//	OrderBy = d => d.Date
			//});
			//ViewBag.Note = notes.List(new QueryOptions<Note>
			//{
			//	OrderBy = d => d.NotesAfterWorkout
			//});
			ViewBag.Operation = operation;

		}

	}
}

