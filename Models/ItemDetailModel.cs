using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class ItemDetailModel
    {
   
        public TbItems? Item { get; set; }
        public List<TbItems>? listRelatedItems { get; set; }
        public List<TbItems>? listUpSellItems { get; set; }

    }
}
