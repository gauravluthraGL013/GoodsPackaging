using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodsPackaging.Models
{
    /// <summary>
    /// creating a relation betwenn all the entities for compabnies packaging service
    /// 
    /// </summary>
    public class CompanyGoodsPackage
    {
        /// <summary>
        /// creating primary key for model
        /// </summary>
        [Key]
        public int companyGoodsPackageId { get; set; }
        /// <summary>
        /// creating a foreign key relation between entities
        /// </summary>

        public int CompanyId { get; set; } 
        public Company Company { get; set; } 
        public int PackageTypeid { get; set; }
        public PackageType PackageType { get; set; }
        public int GoodsTypeId { get; set; }
        public GoodsType GoodsType { get; set; }
        // on which date package was packed
        public DateTime PackagingDate { get; set; }
    }
}
