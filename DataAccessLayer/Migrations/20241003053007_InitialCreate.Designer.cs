﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(EAMDbcontext))]
    [Migration("20241003053007_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataAccessLayer.Attendance", b =>
                {
                    b.Property<long>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<TimeSpan>("CheckInTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("CheckOutTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("EmployeeID")
                        .HasColumnType("bigint");

                    b.HasKey("AttendanceID");

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("DataAccessLayer.Employee", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataAccessLayer.Attendance", b =>
                {
                    b.HasOne("DataAccessLayer.Employee", "Employee")
                        .WithOne("Attendance")
                        .HasForeignKey("DataAccessLayer.Attendance", "EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DataAccessLayer.Employee", b =>
                {
                    b.Navigation("Attendance");
                });
#pragma warning restore 612, 618
        }
    }
}
