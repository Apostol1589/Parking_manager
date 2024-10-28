﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingManager.DataAccess.Data;

#nullable disable

namespace ParkingManager.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241025124012_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingManager.DataAccess.Entities.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("ParkingManager.DataAccess.Entities.ParkingSpace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ParkingLotId")
                        .HasColumnType("int");

                    b.Property<string>("SpaceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("ParkingSpaces");
                });

            modelBuilder.Entity("ParkingManager.DataAccess.Entities.ParkingTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ExitedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssueAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParkingSpaceId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpaceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ParkingTickets");
                });

            modelBuilder.Entity("ParkingManager.DataAccess.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParkingManager.DataAccess.Entities.ParkingSpace", b =>
                {
                    b.HasOne("ParkingManager.DataAccess.Entities.ParkingLot", "ParkingLot")
                        .WithMany()
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingLot");
                });

            modelBuilder.Entity("ParkingManager.DataAccess.Entities.ParkingTicket", b =>
                {
                    b.HasOne("ParkingManager.DataAccess.Entities.ParkingSpace", "ParkingSpace")
                        .WithMany()
                        .HasForeignKey("ParkingSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingManager.DataAccess.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpace");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
