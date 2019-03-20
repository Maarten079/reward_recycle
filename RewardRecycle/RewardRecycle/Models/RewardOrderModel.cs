using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RewardRecycle.Models
{
    public class RewardOrderModel
    {
        public int Id { get; set; }
        [Display(Name = "Your Name")]
        public string Name { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        [Display(Name = "House Number")]
        public int HouseNumber { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        // Foreign key 
        [Display(Name = "RewardModel")]
        public int RewardModelId { get; set; }

        [ForeignKey("RewardModelId")]
        public virtual RewardModel RewardModel { get; set; }
    }
}
