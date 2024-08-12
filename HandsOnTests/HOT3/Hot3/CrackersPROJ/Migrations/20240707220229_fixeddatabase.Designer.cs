﻿// <auto-generated />
using System;
using CrackersPROJ.Models.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrackersPROJ.Migrations
{
    [DbContext(typeof(CrackerContext))]
    [Migration("20240707220229_fixeddatabase")]
    partial class fixeddatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrackersPROJ.Models.Crackers", b =>
                {
                    b.Property<int?>("CrackersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CrackersId"));

                    b.Property<int?>("Calories")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Invented")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrackersId");

                    b.ToTable("Crackers");

                    b.HasData(
                        new
                        {
                            CrackersId = 1,
                            Calories = 20,
                            ImageFileName = "grahamCrackers.jpg",
                            Invented = "1933",
                            Name = "Graham Crackers",
                            Price = "$2.00"
                        },
                        new
                        {
                            CrackersId = 2,
                            Calories = 25,
                            ImageFileName = "Ritz.jpg",
                            Invented = "1945",
                            Name = "Ritz",
                            Price = "$2.50"
                        },
                        new
                        {
                            CrackersId = 3,
                            Calories = 15,
                            ImageFileName = "GoldFish.jpg",
                            Invented = "1950",
                            Name = "GoldFish",
                            Price = "$3.50"
                        },
                        new
                        {
                            CrackersId = 4,
                            Calories = 8,
                            ImageFileName = "Saltine.jpg",
                            Invented = "1960",
                            Name = "Saltine",
                            Price = "$4.50"
                        },
                        new
                        {
                            CrackersId = 5,
                            Calories = 7,
                            ImageFileName = "animal Crackers.jpg",
                            Invented = "1970",
                            Name = "Animal Crackers",
                            Price = "$4.00"
                        });
                });

            modelBuilder.Entity("CrackersPROJ.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CrackersId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CrackersId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CrackersPROJ.Models.Purchase", b =>
                {
                    b.HasOne("CrackersPROJ.Models.Crackers", "Crackers")
                        .WithMany()
                        .HasForeignKey("CrackersId");

                    b.Navigation("Crackers");
                });
#pragma warning restore 612, 618
        }
    }
}
