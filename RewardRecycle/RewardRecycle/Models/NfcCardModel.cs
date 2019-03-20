using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RewardRecycle.Models
{
    public class NfcCardModel
    {
        [Key]
        public int CardId { get; set; }

        // Foreign key 
        [Display(Name = "ApplicationUserModel")]
        public string ApplicationUserModelId { get; set; }

        [ForeignKey("ApplicationUserModelId")]
        public virtual ApplicationUserModel ApplicationUserModel { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? LastScanDate { get; set; }
    }
}
