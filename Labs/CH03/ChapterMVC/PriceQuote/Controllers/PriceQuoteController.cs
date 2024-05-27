using Microsoft.AspNetCore.Mvc;
using PriceQuote.Models;
namespace PriceQuote.Controllers
{
    public class PriceQuoteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.Message = "Price Quote";
            PriceQuoteModel quote = new PriceQuoteModel();
            quote.Total = 0;

            

			return View( quote);
        }

        [HttpPost]
        public IActionResult Index(PriceQuoteModel a1)
        {
            a1.CalcQuote();
            return View(a1);
        }
    }
}
