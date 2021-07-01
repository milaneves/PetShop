using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Models;

namespace PetShop.Data.Map
{
    public class AlojamentoMap : IEntityTypeConfiguration<Alojamento>
    {
        public void Configure(EntityTypeBuilder<Alojamento> builder)
        {
            builder.ToTable("Alojamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status);

        }
    }
}
