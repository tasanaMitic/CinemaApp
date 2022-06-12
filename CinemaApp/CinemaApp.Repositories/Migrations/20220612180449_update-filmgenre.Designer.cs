﻿// <auto-generated />
using System;
using CinemaApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApp.Repositories.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20220612180449_update-filmgenre")]
    partial class updatefilmgenre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaApp.Models.Models.Cinemahall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NmbrOfSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CinemaHalls");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.FilmGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FilmGenres");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Romantic"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("CinemaApp.Models.Models.Projection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CinemahallId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("SoldOut")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CinemahallId");

                    b.HasIndex("FilmId");

                    b.ToTable("Projections");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Sold")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectionId");

                    b.HasIndex("Username");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.Projection", b =>
                {
                    b.HasOne("CinemaApp.Models.Models.Cinemahall", "Cinemahall")
                        .WithMany()
                        .HasForeignKey("CinemahallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.Models.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinemahall");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("CinemaApp.Models.Models.Ticket", b =>
                {
                    b.HasOne("CinemaApp.Models.Models.Projection", "Projection")
                        .WithMany()
                        .HasForeignKey("ProjectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.Models.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projection");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
