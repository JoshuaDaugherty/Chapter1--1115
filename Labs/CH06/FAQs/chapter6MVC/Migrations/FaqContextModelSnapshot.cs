﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chapter6MVC.Models;

#nullable disable

namespace chapter6MVC.Migrations
{
    [DbContext(typeof(FaqContext))]
    partial class FaqContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("chapter6MVC.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "gen",
                            Name = "General"
                        },
                        new
                        {
                            CategoryId = "hist",
                            Name = "History"
                        });
                });

            modelBuilder.Entity("chapter6MVC.Models.FAQ", b =>
                {
                    b.Property<int>("FAQId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FAQId"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FAQId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TopicId");

                    b.ToTable("FAQs");

                    b.HasData(
                        new
                        {
                            FAQId = 1,
                            Answer = "ASP.NET Core is a free and open-source web framework",
                            CategoryId = "gen",
                            Question = "What is ASP.Net Core?",
                            TopicId = "asp"
                        },
                        new
                        {
                            FAQId = 2,
                            Answer = "ASP.NET Core 1.0 was released on June 27,2016.",
                            CategoryId = "hist",
                            Question = "When was ASP.NET Core released?",
                            TopicId = "asp"
                        },
                        new
                        {
                            FAQId = 3,
                            Answer = "Blazer is a Free and open-source web framework",
                            CategoryId = "gen",
                            Question = "What is Blazer?",
                            TopicId = "blz"
                        },
                        new
                        {
                            FAQId = 4,
                            Answer = "Blazor was released on May 14 2020",
                            CategoryId = "hist",
                            Question = "When was Blazor released?",
                            TopicId = "blz"
                        },
                        new
                        {
                            FAQId = 5,
                            Answer = "Open source ORM framework",
                            CategoryId = "gen",
                            Question = "What is Entity Framework?",
                            TopicId = "ef"
                        },
                        new
                        {
                            FAQId = 6,
                            Answer = "Entity Framework 1.0 was released in 2008",
                            CategoryId = "hist",
                            Question = "When was Entity Framework released?",
                            TopicId = "ef"
                        });
                });

            modelBuilder.Entity("chapter6MVC.Models.Topic", b =>
                {
                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            TopicId = "asp",
                            Name = "ASP.NET Core"
                        },
                        new
                        {
                            TopicId = "blz",
                            Name = "Blazor"
                        },
                        new
                        {
                            TopicId = "ef",
                            Name = "Entity Framework"
                        });
                });

            modelBuilder.Entity("chapter6MVC.Models.FAQ", b =>
                {
                    b.HasOne("chapter6MVC.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("chapter6MVC.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Topic");
                });
#pragma warning restore 612, 618
        }
    }
}
