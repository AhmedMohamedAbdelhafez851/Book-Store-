using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class HomePageModel
    {
        public IEnumerable<TbSlider>? lstSliderImages { get; set; }

        public IEnumerable<TbItems>? lstNewItems { get; set; }

        public IEnumerable<TbItems>? lstAllItems { get; set; }

        public IEnumerable<TbItems>? lstCategories { get; set; }

        public IEnumerable<TbItems>? lstBestSellers { get; set; }





    }
}
