﻿// <auto-generated />
using System;
using LogansArchive.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogansArchive.Migrations
{
    [DbContext(typeof(MainArchiveContext))]
    [Migration("20240517024731_AddDirectorToShow")]
    partial class AddDirectorToShow
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int?>("directorId1")
                        .HasColumnType("int");

                    b.HasKey("directorId");

                    b.HasIndex("directorId1");

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

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("gameId1")
                        .HasColumnType("int");

                    b.HasKey("gameId");

                    b.HasIndex("gameId1");

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

                    b.Property<int?>("movieId1")
                        .HasColumnType("int");

                    b.HasKey("movieId");

                    b.HasIndex("movieId1");

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

                    b.Property<int?>("showId1")
                        .HasColumnType("int");

                    b.HasKey("showId");

                    b.HasIndex("showId1");

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

                    b.Property<int?>("studioId1")
                        .HasColumnType("int");

                    b.Property<DateOnly>("yearEstablished")
                        .HasColumnType("date");

                    b.HasKey("studioId");

                    b.HasIndex("studioId1");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("LogansArchive.Models.Director", b =>
                {
                    b.HasOne("LogansArchive.Models.Director", null)
                        .WithMany("Directors")
                        .HasForeignKey("directorId1");
                });

            modelBuilder.Entity("LogansArchive.Models.Game", b =>
                {
                    b.HasOne("LogansArchive.Models.Game", null)
                        .WithMany("Games")
                        .HasForeignKey("gameId1");
                });

            modelBuilder.Entity("LogansArchive.Models.Movie", b =>
                {
                    b.HasOne("LogansArchive.Models.Movie", null)
                        .WithMany("Movies")
                        .HasForeignKey("movieId1");
                });

            modelBuilder.Entity("LogansArchive.Models.Show", b =>
                {
                    b.HasOne("LogansArchive.Models.Show", null)
                        .WithMany("Shows")
                        .HasForeignKey("showId1");
                });

            modelBuilder.Entity("LogansArchive.Models.Studio", b =>
                {
                    b.HasOne("LogansArchive.Models.Studio", null)
                        .WithMany("Studios")
                        .HasForeignKey("studioId1");
                });

            modelBuilder.Entity("LogansArchive.Models.Director", b =>
                {
                    b.Navigation("Directors");
                });

            modelBuilder.Entity("LogansArchive.Models.Game", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("LogansArchive.Models.Movie", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("LogansArchive.Models.Show", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("LogansArchive.Models.Studio", b =>
                {
                    b.Navigation("Studios");
                });
#pragma warning restore 612, 618
        }
    }
}
