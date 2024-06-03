using Microsoft.AspNetCore.Mvc;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
namespace FitnessApp.Controllers
{
    public class HistoryController : Controller
    {
        private ExcersizeContext context {  get; set; }

        public HistoryController(ExcersizeContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var ExcersizeLog = context.ExerciseLog.Include(e => e.Genre).OrderBy(e => e.Workout).ToList();
            return View(ExcersizeLog);
        }
    }
}
