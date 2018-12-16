using Microsoft.EntityFrameworkCore;
using WebApiWithTesting.Domain.Entities;

namespace WebApiWithTesting.Data
{
    public class AppContext : DbContext
    {
        public virtual DbSet<House> House { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("server=127.0.0.1;database=buymyhouse;user=user;password=password");
        }
    }
}