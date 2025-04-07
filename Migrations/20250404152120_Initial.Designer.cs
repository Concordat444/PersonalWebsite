﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWebsite.Models.StoreModels;

#nullable disable

namespace PersonalWebsite.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20250404152120_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Category", b =>
                {
                    b.Property<long>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Game", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameId"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<long?>("ProductOwnerOwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("GameId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductOwnerOwnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.ProductOwner", b =>
                {
                    b.Property<long>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OwnerId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("ProductOwners");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Game", b =>
                {
                    b.HasOne("PersonalWebsite.Models.StoreModels.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalWebsite.Models.StoreModels.ProductOwner", "ProductOwner")
                        .WithMany("Games")
                        .HasForeignKey("ProductOwnerOwnerId");

                    b.Navigation("Category");

                    b.Navigation("ProductOwner");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.ProductOwner", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
