using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class ShopingCartItem
    {
        [Key]
        public int? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ImageName { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public decimal? Total { get; set; }
    }
}
