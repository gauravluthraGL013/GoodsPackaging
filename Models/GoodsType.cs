using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodsPackaging.Models
{
    /// <summary>
    /// creating a class for GoodsType
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// creating primary key for model
        /// </summary>
        [Key]
        public int GoodsTypeId { get; set; }
        // other memerproperties for type of goods and description about it
        public string GoodType { get; set; }
        public string Description { get; set; }
    }
}
