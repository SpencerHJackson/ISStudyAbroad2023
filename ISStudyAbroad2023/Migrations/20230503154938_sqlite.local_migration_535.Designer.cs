﻿// <auto-generated />
using System;
using ISStudyAbroad2023.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISStudyAbroad2023.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20230503154938_sqlite.local_migration_535")]
    partial class sqlitelocal_migration_535
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("ISStudyAbroad2023.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastCheckin")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}