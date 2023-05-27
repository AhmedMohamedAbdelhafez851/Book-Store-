using System.ComponentModel.DataAnnotations;
using System;

namespace Book.Models
{
    public class TbSlider
    {
        [Key]
        public int SliderId { get; set; }
        [MaxLength(200)]
        public string? Title { get; set; }
        [MaxLength(500)]

        public string? Description { get; set; }
        [Required]
        [MaxLength(200)]

        public string? ImageName { get; set; }
    }
}
