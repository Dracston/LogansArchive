﻿// <auto-generated />
using System;
using LogansArchive.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogansArchive.Migrations
{
    [DbContext(typeof(SecondArchiveContext))]
    partial class MainArchiveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogansArchive.Models.Connection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("gameId")
                        .HasColumnType("int");

                    b.Property<int>("studioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("gameId");

                    b.HasIndex("studioId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("LogansArchive.Models.Director", b =>
                {
                    b.Property<int>("directorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("directorId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("directorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("LogansArchive.Models.Game", b =>
                {
                    b.Property<int>("gameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("gameId"));

                    b.Property<string>("Console")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("gameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("LogansArchive.Models.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movieId"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("LogansArchive.Models.Show", b =>
                {
                    b.Property<int>("showId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("showId"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("episodeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("firstDateAired")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("lastDateAired")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("showId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("LogansArchive.Models.Studio", b =>
                {
                    b.Property<int>("studioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studioId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("yearEstablished")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("studioId");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("LogansArchive.Models.Connection", b =>
                {
                    b.HasOne("LogansArchive.Models.Game", "Game")
                        .WithMany("Connections")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogansArchive.Models.Studio", "Studio")
                        .WithMany("Connections")
                        .HasForeignKey("studioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("LogansArchive.Models.Game", b =>
                {
                    b.Navigation("Connections");
                });

            modelBuilder.Entity("LogansArchive.Models.Studio", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
