﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vietjet_BackEnd.Models;

#nullable disable

namespace Vietjet_BackEnd.Migrations
{
    [DbContext(typeof(VietjetDbContext))]
    partial class VietjetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vietjet_BackEnd.Models.Account", b =>
                {
                    b.Property<string>("Id")
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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Terminated_until")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Aircraft", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Compartment", b =>
                {
                    b.Property<string>("AircraftId")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FlightId")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("CompartmentId")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Arrival")
                        .HasColumnType("int");

                    b.Property<int>("LoadingInstruction")
                        .HasColumnType("int");

                    b.Property<int>("LoadingReport")
                        .HasColumnType("int");

                    b.HasKey("AircraftId", "FlightId", "CompartmentId");

                    b.HasIndex("FlightId");

                    b.ToTable("Compartments");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Document", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Account_createdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crew_roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightId")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pilot_roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Account_createdId");

                    b.HasIndex("FlightId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Document_Version", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IssuerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("IssuerId");

                    b.ToTable("DocumentVersions");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Flight", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("AircraftId")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DepartmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoadingPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnloadingPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.SystemConfig", b =>
                {
                    b.Property<bool>("Captcha")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Compartment", b =>
                {
                    b.HasOne("Vietjet_BackEnd.Models.Aircraft", "Aircraft")
                        .WithMany("Compartments")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Vietjet_BackEnd.Models.Flight", "Flight")
                        .WithMany("Compartments")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Document", b =>
                {
                    b.HasOne("Vietjet_BackEnd.Models.Account", "Account_created")
                        .WithMany()
                        .HasForeignKey("Account_createdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vietjet_BackEnd.Models.Flight", "Flight")
                        .WithMany("Documents")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account_created");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Document_Version", b =>
                {
                    b.HasOne("Vietjet_BackEnd.Models.Document", "Document")
                        .WithMany("DocumentVersions")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Vietjet_BackEnd.Models.Account", "Issuer")
                        .WithMany()
                        .HasForeignKey("IssuerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Issuer");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Flight", b =>
                {
                    b.HasOne("Vietjet_BackEnd.Models.Aircraft", "Aircraft")
                        .WithMany("Flights")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Aircraft", b =>
                {
                    b.Navigation("Compartments");

                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Document", b =>
                {
                    b.Navigation("DocumentVersions");
                });

            modelBuilder.Entity("Vietjet_BackEnd.Models.Flight", b =>
                {
                    b.Navigation("Compartments");

                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
