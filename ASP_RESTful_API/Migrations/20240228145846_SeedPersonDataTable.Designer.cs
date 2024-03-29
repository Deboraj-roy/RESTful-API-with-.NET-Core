﻿// <auto-generated />
using System;
using ASP_BasicAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP_BasicAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240228145846_SeedPersonDataTable")]
    partial class SeedPersonDataTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP_BasicAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            CreatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9106),
                            Details = "Software Engineer",
                            Gender = "M",
                            ImageUrl = "https://example.com/john-doe.jpg",
                            Name = "John Doe",
                            Occupation = "Engineer",
                            Salary = 75000.0,
                            UpdatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9114)
                        },
                        new
                        {
                            Id = 2,
                            Age = 28,
                            CreatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9117),
                            Details = "Data Scientist",
                            Gender = "F",
                            ImageUrl = "https://example.com/jane-smith.jpg",
                            Name = "Jane Smith",
                            Occupation = "Data Scientist",
                            Salary = 80000.0,
                            UpdatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9117)
                        },
                        new
                        {
                            Id = 3,
                            Age = 35,
                            CreatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9119),
                            Details = "Doctor",
                            Gender = "M",
                            ImageUrl = "https://example.com/michael-johnson.jpg",
                            Name = "Michael Johnson",
                            Occupation = "Doctor",
                            Salary = 120000.0,
                            UpdatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9119)
                        },
                        new
                        {
                            Id = 4,
                            Age = 25,
                            CreatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9121),
                            Details = "Teacher",
                            Gender = "F",
                            ImageUrl = "https://example.com/emily-brown.jpg",
                            Name = "Emily Brown",
                            Occupation = "Teacher",
                            Salary = 50000.0,
                            UpdatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9121)
                        },
                        new
                        {
                            Id = 5,
                            Age = 40,
                            CreatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9122),
                            Details = "Lawyer",
                            Gender = "M",
                            ImageUrl = "https://example.com/david-wilson.jpg",
                            Name = "David Wilson",
                            Occupation = "Lawyer",
                            Salary = 100000.0,
                            UpdatedDate = new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9123)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
