using CrackersPROJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrackersPROJ.Areas.Admin.Controllers
{
	[Area("Admin")]
	
	public class CrackerController : Controller
	{
		CrackerContext _ctx;
		public CrackerController(CrackerContext ctx)
		{
			_ctx = ctx;
		}

		[Route("[area]/crackers/{Name?}")]
		public IActionResult List(string brand = "all")
		{
			List<Crackers> cracker;

			if (brand.Equals("all"))
			{
				cracker = _ctx.Crackers.ToList();
			}
			else
			{
				cracker = _ctx.Crackers.Where(c => c.Name == (brand)).ToList();
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
            return RedirectToAction("List");
        }


		[HttpGet]
		public IActionResult Add(int? id)
		{
			if (id.HasValue)
			{
				var cracker = _ctx.Crackers.Find(id.Value);
				if (cracker != null)
				{
					return View("AddEdit", cracker);
				}
			}
			return View("AddEdit", new Crackers());
		}


		[HttpPost]
		public IActionResult Add(Crackers cracker)
		{
			//Add operation if id is 0

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
				return RedirectToAction("List");
			}
			return View("AddEdit", cracker);
		}


	}
}
