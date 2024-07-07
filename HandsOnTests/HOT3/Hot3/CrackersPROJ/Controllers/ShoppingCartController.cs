using Microsoft.AspNetCore.Mvc;
using CrackersPROJ.Models;
using Microsoft.AspNetCore.Http;

namespace CrackersPROJ.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly CrackerContext _context;
		private List<ShoppingCartItem> _cartItems;



		public ShoppingCartController(CrackerContext context)
		{
			_context = context;
			_cartItems = new List<ShoppingCartItem>();
		}

		public IActionResult Index()
		{
			return View();
		}

		
		public IActionResult AddToCart(int id)
		{
			// Code to add the cracker to the shopping cart
			var crackerToAdd = _context.Crackers.Find(id);

			var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingCartItem = cartItems.FirstOrDefault(item => item.Crackers.CrackersId == id);

			if (existingCartItem != null)
			{
				existingCartItem.Quantity++;
			}
			else
			{
				cartItems.Add(new ShoppingCartItem				
				{ 
					Crackers = crackerToAdd,
					Quantity = 1
				});	
			}

			HttpContext.Session.Set("Cart", cartItems);

			TempData["CartMessage"] = $"{crackerToAdd.Name}  added to your cart.";

			return RedirectToAction("ViewCart");
		}

		
		public IActionResult ViewCart()
		{
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();


            var cartViewModel = new ShoppingCartViewModel
			{
				CartItems = cartItems,
				TotalPrice = cartItems.Sum(item => item.Crackers.Calories * item.Quantity)
			};

			ViewBag.CartMessage = TempData["CartMessage"];

			return View(cartViewModel);
		}

		public IActionResult RemoveItem(int id)
		{
			// Code to remove the cracker from the shopping cart
			var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
			var itemToRemove = cartItems.FirstOrDefault(item => item.Crackers.CrackersId == id);
			
			//writing temp data to display a message to the user after removing an item from the cart.
			TempData["CartMessage"] = $"{itemToRemove.Crackers.Name} Removed from cart.";


			if (itemToRemove != null)
			{
				if (itemToRemove.Quantity > 1)
				{
					itemToRemove.Quantity--;
				}
				else
				{
					cartItems.Remove(itemToRemove);
				}
			}
			HttpContext.Session.Set("Cart", cartItems);

			

			return RedirectToAction("ViewCart");
		}

		
		public IActionResult PurchaseItems()
		{
			// Code to process the purchased items and clear the cart.
			var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
			foreach (var item in cartItems)
			{
				//save each item as a purchase in the database.
				_context.Purchases.Add(new Purchase
				{
					CrackersId = item.Crackers.CrackersId,
					Quantity = item.Quantity,
					PurchaseDate = DateTime.Now,
					Total = item.Crackers.Calories * item.Quantity
				});
				

			}
			_context.SaveChanges();

			//clear the cart items
			HttpContext.Session.Set("Cart", new List<ShoppingCartItem>());

			return RedirectToAction("Index", "Home");
		}
	}
}