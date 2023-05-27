using System.ComponentModel.DataAnnotations;
using System;

namespace Book.Models
{
    public class TbItems
    {
        public TbItems()
        {
                TbItemDiscount = new HashSet<TbItemDiscount>();
            TbItemImages = new HashSet<TbItemImages>();
 

        }
        [Key]
        public int? ItemId { get; set; }
        [Required(ErrorMessage = "Please Enter ItemName")]
        public string? ItemName { get; set; }


        [Required(ErrorMessage = "Please Enter SalesPrice")]
        public decimal SalesPrice { get; set; }


        [Required(ErrorMessage = "Please Enter PurchasePrice")]


        public decimal PurchasePrice { get; set; }
      [Required(ErrorMessage = "Please Select Category")]

        public int CategoryId { get; set; }
        [MaxLength(200)]
        public string? ImageName { get; set; }

        public DateTime CreationDate { get; set; }
         public virtual TbCategories Category { get; set; }

       public virtual ICollection<TbItemDiscount>? TbItemDiscount { get; set; }
        public virtual ICollection<TbItemImages>? TbItemImages { get; set; }


    }
}

