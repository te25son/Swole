﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swole.Data;

namespace Swole.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210302093136_AddEmployees")]
    partial class AddEmployees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Swole.Data.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Swole.Data.Gym", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("Swole.Data.GymEmployee", b =>
                {
                    b.Property<Guid>("GymId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.HasKey("GymId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("GymEmployee");
                });

            modelBuilder.Entity("Swole.Data.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GymId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Swole.Data.GymEmployee", b =>
                {
                    b.HasOne("Swole.Data.Employee", "Employee")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swole.Data.Gym", "Gym")
                        .WithMany("Employees")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Swole.Data.Member", b =>
                {
                    b.HasOne("Swole.Data.Gym", null)
                        .WithMany("Members")
                        .HasForeignKey("GymId");
                });

            modelBuilder.Entity("Swole.Data.Employee", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Swole.Data.Gym", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
