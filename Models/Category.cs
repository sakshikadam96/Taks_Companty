using Microsoft.EntityFrameworkCore;

namespace Product.Models
{
    public class Category: DbContext
    {
              public Category(DbContextOptions<Category> options):base(options)
                  { 


                  }

        public DbSet<db_table1> db_table1 { get;set; }

        public DbSet<Table2> Table2 { get;set; }
        
    }
}
