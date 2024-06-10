using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Models;

namespace SalesOrder.Controllers
{
    public class ProductController : Controller
    {
        private SalesOrdersDB context { get; set; }

        public ProductController(SalesOrdersDB ctx)
        {
            this.context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var products = context.Products.Find(id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(Product products)
        {
            context.Products.Remove(products);
            context.SaveChanges();
            return RedirectToAction("Products", "Product");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Category = context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Product";
			ViewBag.Category = context.Categories.OrderBy(c => c.CategoryName).ToList();

			var products = context.Products.Find(id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Product products)
        {
            if (ModelState.IsValid)
            {
                if (products.ProductID == 0)
                {
                    context.Products.Add(products);
                }
                else
                {
                    context.Products.Update(products);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (products.ProductID == 0) ? "Add" : "Edit";
                ViewBag.Category = context.Categories.OrderBy(c => c.CategoryName).ToList();
                return View(products);
            }
        }
       

        public IActionResult Products()
        {
            var products = context.Products.Include(p => p.Category).OrderBy(p => p.ProductName).ToList();
            return View(products);
        }
    }
}
