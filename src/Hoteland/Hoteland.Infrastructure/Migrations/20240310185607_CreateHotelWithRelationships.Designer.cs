﻿// <auto-generated />
using System;
using Hoteland.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace Hoteland.Infrastructure.Migrations
{
    [DbContext(typeof(HotelandContext))]
    [Migration("20240310185607_CreateHotelWithRelationships")]
    partial class CreateHotelWithRelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hoteland.Domain.Models.City", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("CountryID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("Hoteland.Domain.Models.Country", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("Hoteland.Domain.Models.Feature", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Feature", (string)null);
                });

            modelBuilder.Entity("Hoteland.Domain.Models.Hotel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<long?>("CityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CountryID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelStar")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureAlt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tell")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.HasIndex("CountryID");

                    b.ToTable("Hotel", (string)null);
                });

            modelBuilder.Entity("Hoteland.Domain.Models.HotelFeature", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("FeatureID")
                        .HasColumnType("bigint");

                    b.Property<long>("HotelID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelFeatures");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.HotelPicture", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("HotelID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PictureAlt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelPictures");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.City", b =>
                {
                    b.HasOne("Hoteland.Domain.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.Hotel", b =>
                {
                    b.HasOne("Hoteland.Domain.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Hotel_City");

                    b.HasOne("Hoteland.Domain.Models.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Hotel_Country");

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.HotelFeature", b =>
                {
                    b.HasOne("Hoteland.Domain.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hoteland.Domain.Models.Hotel", "Hotel")
                        .WithMany("Features")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.HotelPicture", b =>
                {
                    b.HasOne("Hoteland.Domain.Models.Hotel", "Hotel")
                        .WithMany("Pictures")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Hoteland.Domain.Models.Hotel", b =>
                {
                    b.Navigation("Features");

                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
