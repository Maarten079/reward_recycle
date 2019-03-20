using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RewardRecycle.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
        [Display(Name = "House number")]
        public int HouseNumber { get; set; }

        public int Points { get; set; }

        public string Role { get; set; }

        public ApplicationUserModel()
        {
            Points = 60;
        }

       
    }
}

