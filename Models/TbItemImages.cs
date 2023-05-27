using System.ComponentModel.DataAnnotations;
using System;
using Book.Models;
using Newtonsoft.Json.Serialization;

namespace Book.Models
{
    public partial class TbItemImages
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string? ImageName { get; set; }
        [Required(ErrorMessage ="please enter id")]
        public int ItemId { get; set; }

        public virtual TbItems? Item { get; set; }
    }
}
