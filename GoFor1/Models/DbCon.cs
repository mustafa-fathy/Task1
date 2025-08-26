using Microsoft.EntityFrameworkCore;

namespace GoFor1.Models
{
    public class DbCon :DbContext
    {

        public DbCon()
        {
            
        }
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {

        }
       public virtual DbSet<Courses> Courses { get; set; }

    }
}
