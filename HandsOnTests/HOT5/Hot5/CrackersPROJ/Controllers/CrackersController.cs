using CrackersPROJ.Models.DataLayer;
using CrackersPROJ.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrackersPROJ.Controllers
{
    
    public class CrackersController : Controller
	{
		CrackerContext _ctx;
		public CrackersController(CrackerContext ctx)
		{
			_ctx = ctx;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("AddEdit", new Crackers());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var cracker = _ctx.Crackers.Find(id);
			ViewBag.Action = "Edit";
			return View("AddEdit", cracker);
		}






		[HttpPost]
		public IActionResult AddEdit(Crackers cracker)
		{
			if (ModelState.IsValid)
			{

				if (cracker.CrackersId == 0)
				{

					_ctx.Crackers.Add(cracker);
				}
				else
				{
					_ctx.Crackers.Update(cracker);
				}
				_ctx.SaveChanges();
				return RedirectToAction("Index", "Home");

			}

			return View(cracker);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var cracker = _ctx.Crackers.Find(id);

			return View(cracker);
		}

		[HttpPost]
		public IActionResult Delete(Crackers cracker)
		{
			_ctx.Crackers.Remove(cracker);
			_ctx.SaveChanges();
			return RedirectToAction("Index", "Home");
		}

        public IActionResult Details(int id)
        {
            var cracker = _ctx.Crackers.Find(id);
            if (cracker != null && cracker.ImageFileName != null)
            {
                cracker.ImageFileName = "/images/" + cracker.ImageFileName;
            }
            return View(cracker);
        }

    }
}
