using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RewardRecycle.Models
{
    public class RewardModel
    {
        public int Id { get; set; }
        [Display(Name = "Product name")]
        public string Title { get; set; }
        [Display(Name = "Price in points")]
        public int Price { get; set; }
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Display(Name = "Product Example")]
        public string ImagePath { get; set; }
    }
}
