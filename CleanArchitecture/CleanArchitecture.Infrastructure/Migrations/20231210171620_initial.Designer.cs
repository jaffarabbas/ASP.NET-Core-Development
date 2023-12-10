﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20231210171620_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("CleanArchitecture.Domain.Entity.Blog", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("auther")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}