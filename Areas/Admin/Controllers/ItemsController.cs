
using Microsoft.AspNetCore.Mvc;
using Book.Models;
using Book.BL;

namespace Book1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemsController : Controller
    {
        public IActionResult List()
        {
            ClsItems oClsItems = new ClsItems();


            return View(oClsItems.GetAll());
        }

        [HttpPost]

        public async  Task<IActionResult> Save(TbItems item , List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filPaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    using (var stream = System.IO.File.Create(filPaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    item.ImageName = ImageName;
                }
            }



            //ClsItems oClsItems = new ClsItems();
            //   if (item.ItemId == 0)
            //    oClsItems.Add(item);
            //   else
            //     oClsItems.Edit(item);
                return RedirectToAction("List");
           
            }

            
    

        
      //  function To Edit
        public IActionResult Edit(int? id)
        {
            ClsCategories oClsCategories = new ClsCategories();
            ViewBag.Categories = oClsCategories.GetAll();

            if(id != null)
            {
                ClsItems oClsItems = new ClsItems();
                return View(oClsItems.GetById(Convert.ToInt32(id)));


            }
            else
            {
                return View();


            }

        }


        public IActionResult Delete(TbItems item)
        {
            ClsItems oClsItems = new ClsItems();
            oClsItems.Delete1(item); 
            return RedirectToAction("List");
        }



    }
}

