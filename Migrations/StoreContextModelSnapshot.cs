﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWebsite.Models.StoreModels;

#nullable disable

namespace PersonalWebsite.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamePublisher", b =>
                {
                    b.Property<long>("GamesGameId")
                        .HasColumnType("bigint");

                    b.Property<long>("PublishersPublisherId")
                        .HasColumnType("bigint");

                    b.HasKey("GamesGameId", "PublishersPublisherId");

                    b.HasIndex("PublishersPublisherId");

                    b.ToTable("GamePublisher");
                });

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

                    b.Property<string>("GameDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProductId"));

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<long?>("ProductOwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("SellerDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("GameId");

                    b.HasIndex("ProductOwnerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.ProductOwner", b =>
                {
                    b.Property<long>("ProductOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProductOwnerId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductOwnerId");

                    b.ToTable("ProductOwners");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Publisher", b =>
                {
                    b.Property<long>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("GamePublisher", b =>
                {
                    b.HasOne("PersonalWebsite.Models.StoreModels.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalWebsite.Models.StoreModels.Publisher", null)
                        .WithMany()
                        .HasForeignKey("PublishersPublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Game", b =>
                {
                    b.HasOne("PersonalWebsite.Models.StoreModels.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Product", b =>
                {
                    b.HasOne("PersonalWebsite.Models.StoreModels.Game", "Game")
                        .WithMany("Products")
                        .HasForeignKey("GameId");

                    b.HasOne("PersonalWebsite.Models.StoreModels.ProductOwner", "ProductOwner")
                        .WithMany("Products")
                        .HasForeignKey("ProductOwnerId");

                    b.Navigation("Game");

                    b.Navigation("ProductOwner");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.Game", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PersonalWebsite.Models.StoreModels.ProductOwner", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
