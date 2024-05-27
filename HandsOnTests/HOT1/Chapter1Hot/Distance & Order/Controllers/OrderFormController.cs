using Distance___Order.Models;
using Microsoft.AspNetCore.Mvc;

namespace Distance___Order.Controllers
{
	public class OrderFormController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			OrderForm order = new OrderForm();
			//order.Subtotal = 0;
			return View(order);
		}

		[HttpPost]
		public IActionResult Index(OrderForm a1)
		{
			a1.CalcOrder();
			return View(a1);
		}
	}

}
