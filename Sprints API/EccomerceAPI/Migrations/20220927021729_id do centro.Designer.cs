﻿// <auto-generated />
using System;
using EccomerceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EccomerceAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220927021729_id do centro")]
    partial class iddocentro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("EccomerceAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EccomerceAPI.Models.DistributionCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddComplemente")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Neighbourhood")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DistributionCenters");
                });

            modelBuilder.Entity("EccomerceAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AmountOfProducts")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<double>("Height")
                        .HasColumnType("double");

                    b.Property<double>("Lengths")
                        .HasColumnType("double");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.Property<double>("Widths")
                        .HasColumnType("double");

                    b.Property<int>("distribuitonCenterId")
                        .HasColumnType("int");

                    b.Property<int>("subCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("distribuitonCenterId");

                    b.HasIndex("subCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EccomerceAPI.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EccomerceAPI.Models.Product", b =>
                {
                    b.HasOne("EccomerceAPI.Models.DistributionCenter", "DistributionCenters")
                        .WithMany("Products")
                        .HasForeignKey("distribuitonCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EccomerceAPI.Models.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("subCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DistributionCenters");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("EccomerceAPI.Models.SubCategory", b =>
                {
                    b.HasOne("EccomerceAPI.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EccomerceAPI.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("EccomerceAPI.Models.DistributionCenter", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EccomerceAPI.Models.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}