using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoodsPackaging.Models;

namespace GoodsPackaging.Data
{
    public class GoodsPackagingContext : DbContext
    {
        public GoodsPackagingContext (DbContextOptions<GoodsPackagingContext> options)
            : base(options)
        {
        }

        public DbSet<GoodsPackaging.Models.Company> Company { get; set; }

        public DbSet<GoodsPackaging.Models.GoodsType> GoodsType { get; set; }

        public DbSet<GoodsPackaging.Models.PackageType> PackageType { get; set; }

        public DbSet<GoodsPackaging.Models.CompanyGoodsPackage> CompanyGoodsPackage { get; set; }
    }
}
