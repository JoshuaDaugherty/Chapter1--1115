using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
	public class FitController : Controller
	{
		private ExcersizeContext context { get; set; }

		public FitController(ExcersizeContext ctx)
		{
			context = ctx;
		}

		[HttpGet]
		// id sent from URL
		public IActionResult Delete(int id)
		{
			var ExerciseLog = context.ExerciseLog.Find(id);
			return View(ExerciseLog);
		}

		[HttpPost]
		public IActionResult Delete(ExerciseLog ExerciseLog)
		{
			context.ExerciseLog.Remove(ExerciseLog);
			context.SaveChanges();
			return RedirectToAction("Index", "History");
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new ExerciseLog());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit Workout";
			ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
			//PK Search
			var ExerciseLog = context.ExerciseLog.Find(id);
			return View(ExerciseLog);
		}

		[HttpPost]
		public IActionResult Edit(ExerciseLog ExerciseLog)
		{
			if (ModelState.IsValid)
			{
				//add or edit
				if(ExerciseLog.ExerciseId == 0)
				{
					context.ExerciseLog.Add(ExerciseLog);
				}
				else
				{
					context.ExerciseLog.Update(ExerciseLog);
				}
				context.SaveChanges();
				return RedirectToAction("Index", "History");
				
			}
			else
			{
				ViewBag.Action = (ExerciseLog.ExerciseId == 0) ? "Add" : "Edit";
				ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
				return View(ExerciseLog);
			}

		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
