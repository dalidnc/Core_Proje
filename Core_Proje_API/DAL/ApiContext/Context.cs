using Core_Proje_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_API.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3VF2N1Q\\SQLSERVER2022;Database=CoreProjeDB2;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories { get; set; }

    }
}
