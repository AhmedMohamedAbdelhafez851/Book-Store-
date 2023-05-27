using Book.BL;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            ClsItems oClsItems = new ClsItems();
            HomePageModel model = new HomePageModel();
            model.lstAllItems = oClsItems.GetAll();
            model.lstNewItems = model.lstAllItems.Take(5);
            model.lstBestSellers = model.lstNewItems.Take(3);
            model.lstCategories = model.lstAllItems.GroupBy(a => a.CategoryId).Select(a => a.First()).ToList();

            return View(model);
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Cart()
        {
           return View();
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