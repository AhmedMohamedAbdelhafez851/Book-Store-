using Book.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Book.BL
{


    public class ClsItems
    {
        
        public bool Add(TbItems item)
        {
            try
            {
                StoreContext context = new StoreContext();
                context.Add<TbItems>(item); 
                //context.TbItems.Add(item);
                context.SaveChanges();
                return true;
            }



            catch (Exception)
            {
                return false;
            }

        }
        public bool Edit(TbItems item)
        {
            try
            {
                StoreContext context = new StoreContext();
                //TbItems oldItem = context.TbItems.Where(a=>a.ItemId == 1).FirstOrDefault();
                //oldItem.CategoryId =item.CategoryId;
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();


                return true;
            }



            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete1(TbItems item)
        {
            try
            {
                StoreContext context = new StoreContext();
                // TbItems oldItem = context.TbItems.Where(a=>a.ItemId == itemId).FirstOrDefault();
                // context.TbItems.Remove(oldItem);
                //oldItem.CategoryId =item.CategoryId;
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();


                return true;
            }




            catch (Exception)
            {
                return false;
            }


        }
        public List<TbItems> GetAll()
        {
            StoreContext context = new StoreContext();
            List<TbItems> list = context.TbItems.Include(a => a.Category)
                .OrderByDescending(a => a.ItemId).ToList();
            return list;


        }
        public TbItems? GetById(int id)

        {

            StoreContext context = new StoreContext();
            TbItems? item = context.TbItems.FirstOrDefault(a => a.ItemId == id);
            return item;           //select to Id ; 
        }





        public TbItems? GetByIdWithImages(int id)
        {
            StoreContext ctx = new StoreContext();
            TbItems? item = ctx.TbItems.Include(a => a.TbItemImages).FirstOrDefault();
            return item;  

        }
        public List<TbItems> GetRelatedItems(decimal price)
        {
            decimal start = price - 3000;
            decimal end = price + 3000;
            StoreContext ctx = new StoreContext();
            List<TbItems> lstItems = ctx.TbItems.Where(a => a.SalesPrice >= start && a.SalesPrice <= end).
                OrderByDescending(a => a.CreationDate).ToList();
            return lstItems; 
            

        }



        
        public List<TbItems> GetUpSellItem()
        {
            StoreContext ctx = new StoreContext();
            var query = from items in ctx.TbItems
                        join discount in ctx.TbItemDiscount
                    on items.ItemId equals discount.ItemId
                        where discount.EndDate <= DateTime.Now
                        select items; 
            return query.ToList();

        }









    }
}

    



   


