using System;
using Microsoft.EntityFrameworkCore;

namespace LOGINREG.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { set; get; }
    }
}