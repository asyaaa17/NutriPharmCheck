﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitaminBad.Data;

#nullable disable

namespace VitaminBad.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240121122652_editInteraction")]
    partial class editInteraction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodIngredients", b =>
                {
                    b.Property<long>("FoodsId")
                        .HasColumnType("bigint");

                    b.Property<long>("IngredientsId")
                        .HasColumnType("bigint");

                    b.HasKey("FoodsId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("FoodIngredients");
                });

            modelBuilder.Entity("HeabsIngredients", b =>
                {
                    b.Property<long>("HeabsId")
                        .HasColumnType("bigint");

                    b.Property<long>("IngredientsId")
                        .HasColumnType("bigint");

                    b.HasKey("HeabsId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("HeabsIngredients");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Drugs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Dose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Effect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDrug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NutrientDataBankNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Heabs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contratindication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdHear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InteractionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recomendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repeat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Times")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId");

                    b.ToTable("Heabs");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Ingredients", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("IdIng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rec_dose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Upper_Level")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Interaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("DrugsId")
                        .HasColumnType("bigint");

                    b.Property<string>("IdInteraction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("IngredientsId")
                        .HasColumnType("bigint");

                    b.Property<string>("InteractionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InteractionTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DrugsId")
                        .IsUnique()
                        .HasFilter("[DrugsId] IS NOT NULL");

                    b.HasIndex("IngredientsId");

                    b.HasIndex("InteractionTypeId")
                        .IsUnique()
                        .HasFilter("[InteractionTypeId] IS NOT NULL");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.InteractionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InteractionType");
                });

            modelBuilder.Entity("FoodIngredients", b =>
                {
                    b.HasOne("VitaminBad.Domain.Entity.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitaminBad.Domain.Entity.Ingredients", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HeabsIngredients", b =>
                {
                    b.HasOne("VitaminBad.Domain.Entity.Heabs", null)
                        .WithMany()
                        .HasForeignKey("HeabsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitaminBad.Domain.Entity.Ingredients", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Heabs", b =>
                {
                    b.HasOne("VitaminBad.Domain.Entity.Interaction", "Interaction")
                        .WithMany()
                        .HasForeignKey("InteractionId");

                    b.Navigation("Interaction");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Interaction", b =>
                {
                    b.HasOne("VitaminBad.Domain.Entity.Drugs", "Drugs")
                        .WithOne("Interaction")
                        .HasForeignKey("VitaminBad.Domain.Entity.Interaction", "DrugsId");

                    b.HasOne("VitaminBad.Domain.Entity.Ingredients", "Ingredients")
                        .WithMany()
                        .HasForeignKey("IngredientsId");

                    b.HasOne("VitaminBad.Domain.Entity.InteractionType", "InteractionType")
                        .WithOne("Interaction")
                        .HasForeignKey("VitaminBad.Domain.Entity.Interaction", "InteractionTypeId");

                    b.Navigation("Drugs");

                    b.Navigation("Ingredients");

                    b.Navigation("InteractionType");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.Drugs", b =>
                {
                    b.Navigation("Interaction");
                });

            modelBuilder.Entity("VitaminBad.Domain.Entity.InteractionType", b =>
                {
                    b.Navigation("Interaction");
                });
#pragma warning restore 612, 618
        }
    }
}
