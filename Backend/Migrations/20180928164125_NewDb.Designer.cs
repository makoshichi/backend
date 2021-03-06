﻿// <auto-generated />
using System;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20180928164125_NewDb")]
    partial class NewDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Backend.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("GenreId");

                    b.Property<string>("Name");

                    b.Property<int?>("RentalId");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("RentalId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Backend.Model.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("RegistrationNumber");

                    b.HasKey("Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Backend.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Model.Movie", b =>
                {
                    b.HasOne("Backend.Model.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("Backend.Model.Rental")
                        .WithMany("MovieList")
                        .HasForeignKey("RentalId");
                });
#pragma warning restore 612, 618
        }
    }
}
