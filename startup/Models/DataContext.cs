﻿using Microsoft.EntityFrameworkCore;
using startup.Areas.Admin.Models;


namespace startup.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) 
        {
        }
        
        public DbSet<Menu> Menus { get; set; } 
        public DbSet<Post> Posts { get; set; }
        public DbSet<view_Post_Menu> PostMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

    }


}
