﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkDataLayer;

#nullable disable

namespace ParkDataLayer.Migrations
{
    [DbContext(typeof(ParkbeheerContext))]
    partial class ParkbeheerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkDataLayer.Model.HuisEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Actief")
                        .HasColumnType("bit");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.Property<string>("ParkId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Straat")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ParkId");

                    b.ToTable("Huizen");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuisHuurderEF", b =>
                {
                    b.Property<int>("HuisEFId")
                        .HasColumnType("int");

                    b.Property<int>("HuurderEFId")
                        .HasColumnType("int");

                    b.HasKey("HuisEFId", "HuurderEFId");

                    b.HasIndex("HuurderEFId");

                    b.ToTable("HuisHuurders");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuurcontractEF", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("AantalDagen")
                        .HasColumnType("int");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HuisId")
                        .HasColumnType("int");

                    b.Property<int?>("HuurderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HuisId");

                    b.HasIndex("HuurderId");

                    b.ToTable("Huurcontracten");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuurderEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefoon")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Huurders");
                });

            modelBuilder.Entity("ParkDataLayer.Model.ParkEF", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Locatie")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Parken");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuisEF", b =>
                {
                    b.HasOne("ParkDataLayer.Model.ParkEF", "Park")
                        .WithMany("Huizen")
                        .HasForeignKey("ParkId");

                    b.Navigation("Park");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuisHuurderEF", b =>
                {
                    b.HasOne("ParkDataLayer.Model.HuisEF", "Huis")
                        .WithMany("HuisHuurders")
                        .HasForeignKey("HuisEFId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkDataLayer.Model.HuurderEF", "Huurder")
                        .WithMany("GehuurdeHuizen")
                        .HasForeignKey("HuurderEFId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Huis");

                    b.Navigation("Huurder");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuurcontractEF", b =>
                {
                    b.HasOne("ParkDataLayer.Model.HuisEF", "Huis")
                        .WithMany()
                        .HasForeignKey("HuisId");

                    b.HasOne("ParkDataLayer.Model.HuurderEF", "Huurder")
                        .WithMany()
                        .HasForeignKey("HuurderId");

                    b.Navigation("Huis");

                    b.Navigation("Huurder");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuisEF", b =>
                {
                    b.Navigation("HuisHuurders");
                });

            modelBuilder.Entity("ParkDataLayer.Model.HuurderEF", b =>
                {
                    b.Navigation("GehuurdeHuizen");
                });

            modelBuilder.Entity("ParkDataLayer.Model.ParkEF", b =>
                {
                    b.Navigation("Huizen");
                });
#pragma warning restore 612, 618
        }
    }
}
