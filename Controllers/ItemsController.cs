using Microsoft.AspNetCore.Mvc;
using Book.BL;
using Book.Models;
using System;





namespace Book.Controllers
{

    public class ItemsController : Controller
    {




        public IActionResult Details(int id)
        {
            ClsItems oClsItems = new ClsItems();
            ItemDetailModel model = new ItemDetailModel();
            model.Item = oClsItems.GetByIdWithImages(id);
            model.listRelatedItems = oClsItems.GetRelatedItems(model.Item.SalesPrice);
            model.listUpSellItems = oClsItems.GetUpSellItem();


            return View(model);
        }
        public IActionResult AddToCart(int id)
        {
            ClsItems oClsItems = new ClsItems(); 
            ShopingCart? oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            if (oShopingCart == null)
                oShopingCart = new ShopingCart();
            TbItems? item = oClsItems.GetById(id);
            ShopingCartItem? shopingItem = oShopingCart.ListItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                oShopingCart.ListItems.Add(new ShopingCartItem()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName = item.ImageName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice
                });
            }

            oShopingCart.Total = (decimal)oShopingCart.ListItems.Sum(a => a.Total);  
            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);
            return Redirect("/Home/Index");
        }






    }
}



