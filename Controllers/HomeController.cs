using dateandtime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dateandtime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DateAndTimeDbContext _context;

        public HomeController(ILogger<HomeController> logger, DateAndTimeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult doit(DateTable obj)
        {
            obj.FirstDate = DateTime.Now.ToString();
            obj.SecondDate = DateTime.Now.ToString();
            _context.DateTables.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("calculate");
        }
        public IActionResult calculate()
        {
            var data = _context.DateTables.FirstOrDefault(x => x.Id == 2);
            var first = data.FirstDate;
            var second = data.SecondDate;
            DateTime f = Convert.ToDateTime(first);
            DateTime s = Convert.ToDateTime(second);
            TimeSpan objTimeSpan = f - s;
            var total = objTimeSpan.TotalHours;
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}