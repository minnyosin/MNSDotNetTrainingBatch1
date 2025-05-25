using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MNSDotNetTrainingBatch1.TestEFCore;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server = .; Database = DotNetTrainingBatch1; User Id = sa; Password = sa@123; TrustServerCertificate = True");
        }
    }
    public DbSet<ProductCategory> ProductCategory { get; set; }
}
[Table("Tbl_ProductCategory")]
public class ProductCategory
{
    [Key]
    public int Id { get; set; }

    [Column("Code")]
    public string Code { get; set; }

    [Column("Name")]
    public string Name { get; set; }
}

