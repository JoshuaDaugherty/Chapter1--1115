using System.Diagnostics;
using SalesOrderPROJ.Models;
using Microsoft.AspNetCore.Mvc;

namespace SalesOrderPROJ.Controllers
{
	public class ProductController : Controller
	{
		private SalesOrderContext context { get; set; }

		public ProductController(SalesOrderContext ctx)
		{
			context = ctx;
        }

        public IActionResult Products()
        {
            return View();
        }

        [HttpGet]
		public IActionResult Delete (int id)
		{
			var product = context.Product.Find(id);
			return View(product);
		}

		[HttpPost]
		public IActionResult Delete(Product product)
		{
			context.Product.Remove(product);
			context.SaveChanges();
			return RedirectToAction("Index", "product");
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Product());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit Product";
			var product = context.Product.Find(id);
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if(ModelState.IsValid)
			{
				if(product.ProductID == 0)
				{
					context.Product.Add(product);
				}
				context.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.Action = (product.ProductID == 0) ? "Add" : "Edit";
				return View(product);
			}
		}
		public IActionResult Index()
		{
			var product = context.Product.OrderBy(p => p.ProductName).ToList();
			return View(product);
		}
	}
}
