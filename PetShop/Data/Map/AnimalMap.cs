using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Models;

namespace PetShop.Data.Map
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeAnimal).IsRequired().HasColumnType("varchar(150)"); ;
            builder.Property(x => x.MotivoInternacao).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.EstadoSaude).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.NomeTutor).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.EnderecoTutor).IsRequired().HasColumnType("varchar(150)");
            builder.Property(x => x.TelefoneTutor).IsRequired().HasColumnType("varchar(20)");
            builder.HasOne(x => x.Alojamento);

        }
    }
}
