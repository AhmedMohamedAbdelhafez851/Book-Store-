using Microsoft.AspNetCore.Mvc;

using Book.Models;  
namespace Book.Controllers
{
    public class orderController : Controller
    {
        public IActionResult Cart()
        {
            return View(); 
        }
        public IActionResult Index()
        {
            ShopingCart? oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart"); 
            
            return View(oShopingCart);
        }
    }
}
