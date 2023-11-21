using ECommAPIAssessment.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommAPIAssessment.Database
{
    public class MyContext:DbContext
    {
        private readonly IConfiguration configuration;

        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnString"));
        }
    }
}
