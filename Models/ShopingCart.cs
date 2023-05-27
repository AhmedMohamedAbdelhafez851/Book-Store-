using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            ListItems = new List<ShopingCartItem>();
        }
        public List<ShopingCartItem>? ListItems { get; set; }

        public decimal Total { get; set; }
    }
}
