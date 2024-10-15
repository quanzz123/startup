using Microsoft.EntityFrameworkCore;


namespace startup.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) 
        {
        }
        
        public DbSet<Menu> Menus { get; set; } 
        public DbSet<Post> Posts { get; set; }
        
    }

    
}
