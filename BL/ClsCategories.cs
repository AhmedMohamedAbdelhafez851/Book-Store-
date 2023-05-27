using Book.Models;
using System;

namespace Book.BL
{


    public class ClsCategories
    {

        public List<TbCategories> GetAll()
        {

            StoreContext ctx = new StoreContext();
            return ctx.TbCategories.ToList();


        }




    }

}