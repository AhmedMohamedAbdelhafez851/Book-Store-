using System.ComponentModel.DataAnnotations;
using System;
using Book.Models;
using System.Collections.Generic;  


namespace Book.Models
{
    public class TbCategories
    {
        public TbCategories()
        {
            TbItems = new HashSet<TbItems>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Enter name")]
        public string? CategoryName { get; set; }




        public virtual ICollection<TbItems> TbItems { get; set; }

    }
}
