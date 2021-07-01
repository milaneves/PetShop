using Microsoft.EntityFrameworkCore;
using PetShop.Data.Map;
using PetShop.Models;

namespace PetShop.Data
{
    public class PetShopContext : DbContext
    {
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Alojamento> Alojamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SVR-BI01;Initial Catalog=PetShop;Integrated Security=False;User ID=sa;Password=123456;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AnimalMap());
            builder.ApplyConfiguration(new AlojamentoMap());

            builder.Entity<Alojamento>()
                .HasData( new Alojamento { Id = 1, Status = "Livre" },
                          new Alojamento { Id = 2, Status = "Livre" },
                          new Alojamento { Id = 3, Status = "Livre" },
                          new Alojamento { Id = 4, Status = "Livre" },
                          new Alojamento { Id = 5, Status = "Livre" },
                          new Alojamento { Id = 6, Status = "Livre" },
                          new Alojamento { Id = 7, Status = "Livre" },
                          new Alojamento { Id = 8, Status = "Livre" },
                          new Alojamento { Id = 9, Status = "Livre" },
                          new Alojamento { Id = 10, Status = "Livre" }
   
                );


        }
    }
}
