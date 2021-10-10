using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodsPackaging.Models
{
    /// <summary>
    /// Creating a class for comapny entity in the model
    /// </summary>
    public class Company
    {
        /// <summary>
        /// creating all the member properties of the company like
        /// name, email, is compoany avtive right now, city and country
        /// </summary>
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool Active { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
