using Chapter3finalredone.Models.DataLayer;
using Chapter3finalredone.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Controllers
{
	public class LoggingController : Controller
	{
		private Repository<ExcersizeLog> ExcersizeLog { get; set; }
		private Repository<Date> dates { get; set; }

		public LoggingController(LoggingContext context)
		{
			ExcersizeLog = new Repository<ExcersizeLog>(context);
			dates = new Repository<Date>(context);
		}

		public IActionResult Index(int id)
		{
			var dateOptions = new QueryOptions<Date>
			{
				OrderBy = d => d.DateId
			};
			var ExcersizeLogOptions = new QueryOptions<ExcersizeLog>
			{
				Includes = "Date,Note"
			};

			if (id == 0)
			{
				ExcersizeLogOptions.OrderBy = c => c.DateId;
				ExcersizeLogOptions.ThenOrderBy = c => c.MilitaryTime;

			}
			else
			{
				ExcersizeLogOptions.Where = c => c.DateId == id;
				ExcersizeLogOptions.OrderBy = c => c.MilitaryTime;
			}

			var DateList = dates.List(dateOptions);
			var ExcersizeLogList = ExcersizeLog.List(ExcersizeLogOptions);

			ViewBag.Id = id;
			ViewBag.Date = DateList;

			return View(ExcersizeLogList);
		}

		[HttpGet]
		public ViewResult Add() => View();

		[HttpPost]
		public IActionResult Add(ExcersizeLog e)
		{
			bool isAdd = e.ExcersizeLogId == 0;

			if (ModelState.IsValid)
			{
				if (isAdd)
					ExcersizeLog.Insert(e);
				else
					ExcersizeLog.Update(e);
				ExcersizeLog.Save();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				string operation = (isAdd) ? "Add" : "Edit";
				this.LoadViewBag(operation);
				return View("AddeEdit", e);
			}
		}

		[HttpGet]
		public ViewResult Delete(int id) => View(ExcersizeLog.Get(id));

		[HttpPost]
		public RedirectToActionResult Delete(ExcersizeLog excersizeLog)
		{
			ExcersizeLog.Delete(excersizeLog);
			ExcersizeLog.Save();
			return RedirectToAction("AddWorkout");
		}

		[HttpGet]
		public ViewResult Edit(int id)
		{
			this.LoadViewBag("Edit");
			var c = this.GetExcersizeLog(id);
			return View("AddEdit");
		}

		private ExcersizeLog GetExcersizeLog(int id)
		{
			var ExcersizeLogOptions = new QueryOptions<ExcersizeLog>
			{
				Includes = "Note, ExcersizeLogName",
				Where  = c => c.ExcersizeLogId ==id
			};
			return ExcersizeLog.Get(ExcersizeLogOptions) ?? new ExcersizeLog();
		}

		private void LoadViewBag(string operation)
		{
			ViewBag.Dates = dates.List(new QueryOptions<Date>
			{
				OrderBy = d => d.DateId
			});
			//ViewBag.Note = notes.List(new QueryOptions<Note>
			//{
			//	OrderBy = d => d.NotesAfterWorkout
			//});
			ViewBag.Operation = operation;

		}

	}
}

