using System.ComponentModel.DataAnnotations;
using System;

namespace Book.Models
{
    public class TbItemDiscount
    {
        [Key]
        public int ItemDiscountId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]


        public decimal DiscountPercent { get; set; }
        [Required]


        public DateTime EndDate { get; set; }


    }
}
