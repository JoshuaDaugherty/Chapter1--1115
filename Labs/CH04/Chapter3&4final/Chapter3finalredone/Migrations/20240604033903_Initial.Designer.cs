﻿// <auto-generated />
using Chapter3finalredone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chapter3finalredone.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20240604033903_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Chapter3finalredone.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "killerclutch@gmail.com",
                            Reason = "Lose weight.",
                            UserName = "Joshua555"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "Random616@gmail.com",
                            Reason = "Gain weight.",
                            UserName = "Random616"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "CoolBeans83@gmail.com",
                            Reason = "I want to jump higher.",
                            UserName = "CoolBeans83"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "Fitnessguy454@gmail.com",
                            Reason = "I want to fill out shirts.",
                            UserName = "Fitnessguy454"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
