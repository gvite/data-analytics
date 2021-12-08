﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuntosVerdes.Context;

namespace PuntosVerdes.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PuntosVerdes.Models.Barrio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Barrio");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Comuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comuna");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Cooperativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cooperativa");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Poblacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<long>("Cantidad")
                        .HasColumnType("bigint");

                    b.Property<int>("ComunaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComunaId");

                    b.ToTable("Poblacion");
                });

            modelBuilder.Entity("PuntosVerdes.Models.PuntoVerde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarrioId")
                        .HasColumnType("int");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calle2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComunaId")
                        .HasColumnType("int");

                    b.Property<int>("CooperativaId")
                        .HasColumnType("int");

                    b.Property<double>("Latitud")
                        .HasColumnType("float");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BarrioId");

                    b.HasIndex("ComunaId");

                    b.HasIndex("CooperativaId");

                    b.ToTable("PuntoVerde");
                });

            modelBuilder.Entity("PuntosVerdes.Models.PuntoverdeMateriales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("PuntoVerdeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PuntoVerdeId");

                    b.ToTable("PuntoverdeMateriales");
                });

            modelBuilder.Entity("PuntosVerdes.Models.RecoleccionMateriales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Mes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Pesaje")
                        .HasColumnType("real");

                    b.Property<int>("PuntoVerdeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PuntoVerdeId");

                    b.ToTable("RecoleccionMateriales");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Visitas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Mes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuntoVerdeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuntoVerdeId");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Poblacion", b =>
                {
                    b.HasOne("PuntosVerdes.Models.Comuna", "Comuna")
                        .WithMany()
                        .HasForeignKey("ComunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comuna");
                });

            modelBuilder.Entity("PuntosVerdes.Models.PuntoVerde", b =>
                {
                    b.HasOne("PuntosVerdes.Models.Barrio", "Barrio")
                        .WithMany()
                        .HasForeignKey("BarrioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuntosVerdes.Models.Comuna", "Comuna")
                        .WithMany()
                        .HasForeignKey("ComunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuntosVerdes.Models.Cooperativa", "Cooperativa")
                        .WithMany()
                        .HasForeignKey("CooperativaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barrio");

                    b.Navigation("Comuna");

                    b.Navigation("Cooperativa");
                });

            modelBuilder.Entity("PuntosVerdes.Models.PuntoverdeMateriales", b =>
                {
                    b.HasOne("PuntosVerdes.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuntosVerdes.Models.PuntoVerde", "PuntoVerde")
                        .WithMany()
                        .HasForeignKey("PuntoVerdeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("PuntoVerde");
                });

            modelBuilder.Entity("PuntosVerdes.Models.RecoleccionMateriales", b =>
                {
                    b.HasOne("PuntosVerdes.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuntosVerdes.Models.PuntoVerde", "PuntoVerde")
                        .WithMany()
                        .HasForeignKey("PuntoVerdeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("PuntoVerde");
                });

            modelBuilder.Entity("PuntosVerdes.Models.Visitas", b =>
                {
                    b.HasOne("PuntosVerdes.Models.PuntoVerde", "PuntoVerde")
                        .WithMany()
                        .HasForeignKey("PuntoVerdeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PuntoVerde");
                });
#pragma warning restore 612, 618
        }
    }
}
