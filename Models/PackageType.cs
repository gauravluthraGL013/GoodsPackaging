using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodsPackaging.Models
{
    /// <summary>
    /// creating a model class for packaging type
    /// </summary>
    public class PackageType
    {
        /// <summary>
        /// creating primary key for model
        /// and other member properties liuke packaging type and description
        /// </summary>
        [Key]
        public int PackageTypeId { get; set; }
        public string PackagingType { get; set; }
        public string Description { get; set; }

    }
}
