﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShop.Data;

namespace PetShop.Migrations
{
    [DbContext(typeof(PetShopContext))]
    [Migration("20210701152918_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetShop.Models.Alojamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alojamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Livre"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Livre"
                        });
                });

            modelBuilder.Entity("PetShop.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlojamentoId")
                        .HasColumnType("int");

                    b.Property<string>("EnderecoTutor")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("EstadoSaude")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoInternacao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeAnimal")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NomeTutor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TelefoneTutor")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AlojamentoId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("PetShop.Models.Animal", b =>
                {
                    b.HasOne("PetShop.Models.Alojamento", "Alojamento")
                        .WithMany()
                        .HasForeignKey("AlojamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alojamento");
                });
#pragma warning restore 612, 618
        }
    }
}
