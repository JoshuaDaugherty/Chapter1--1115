﻿// <auto-generated />
using System;
using Appointment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Appointment.Migrations
{
    [DbContext(typeof(AppointmentContext))]
    [Migration("20240726161445_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointment.Models.Appointments", b =>
                {
                    b.Property<int>("AppointmentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentsId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentsId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentsId = 1,
                            CustomerId = 1,
                            StartTime = new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentsId = 2,
                            CustomerId = 2,
                            StartTime = new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentsId = 3,
                            CustomerId = 3,
                            StartTime = new DateTime(2024, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentsId = 4,
                            CustomerId = 4,
                            StartTime = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentsId = 5,
                            CustomerId = 1,
                            StartTime = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Appointment.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            PhoneNumber = "314-655-4009",
                            UserName = "JohnSmith123"
                        },
                        new
                        {
                            CustomerId = 2,
                            PhoneNumber = "314-888-1234",
                            UserName = "Rileysmiley222"
                        },
                        new
                        {
                            CustomerId = 3,
                            PhoneNumber = "313-776-0984",
                            UserName = "Buddy554"
                        },
                        new
                        {
                            CustomerId = 4,
                            PhoneNumber = "312-000-1234",
                            UserName = "Killerclutch33"
                        });
                });

            modelBuilder.Entity("Appointment.Models.Appointments", b =>
                {
                    b.HasOne("Appointment.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
