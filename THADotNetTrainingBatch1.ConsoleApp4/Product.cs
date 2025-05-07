using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace THADotNetTrainingBatch1.ConsoleApp4
{
    [Table("Tbl_Category")]
    public class ProductCategory
    {
        [Key]
        [Column("Id")]
        public int ProductCategoryId { get; set; }
        [Column("CategoryCode")]
        public string ProductCategoryCode { get; set; }
        [Column("Category")]
        public string CategoryName { get; set; }
    }

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = , ;
Database = DotNetTrainingBatch1;
User Id = sa ;
Password = sa@123 ;
TrustServerCertificate = ture ");
            }
        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
