﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MixMeal.Persistence.PostgreSQL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MixMeal.Persistence.PostgreSQL.Migrations
{
    [DbContext(typeof(MixMealDbContext))]
    [Migration("20220827143031_MoreUserProperties")]
    partial class MoreUserProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MixMeal.Core.Models.Allergy", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("IngredientName")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("IngredientName");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("MixMeal.Core.Models.Dish", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("DishSize")
                        .HasColumnType("integer");

                    b.Property<int>("DishType")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("MixMeal.Core.Models.Ingredient", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Calories")
                        .HasColumnType("double precision");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("double precision");

                    b.Property<string>("DishName")
                        .HasColumnType("text");

                    b.Property<double>("Fat")
                        .HasColumnType("double precision");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Premium")
                        .HasColumnType("boolean");

                    b.Property<double>("Proteins")
                        .HasColumnType("double precision");

                    b.Property<string>("ValidDishTypes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("DishName");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("MixMeal.Core.Models.IngredientTag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("IngredientName")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("IngredientName");

                    b.ToTable("IngredientTags");
                });

            modelBuilder.Entity("MixMeal.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActivityFactor")
                        .HasColumnType("integer");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Roles")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MixMeal.Core.Models.Allergy", b =>
                {
                    b.HasOne("MixMeal.Core.Models.Ingredient", null)
                        .WithMany("Allergies")
                        .HasForeignKey("IngredientName");
                });

            modelBuilder.Entity("MixMeal.Core.Models.Ingredient", b =>
                {
                    b.HasOne("MixMeal.Core.Models.Dish", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("DishName");
                });

            modelBuilder.Entity("MixMeal.Core.Models.IngredientTag", b =>
                {
                    b.HasOne("MixMeal.Core.Models.Ingredient", null)
                        .WithMany("Tags")
                        .HasForeignKey("IngredientName");
                });

            modelBuilder.Entity("MixMeal.Core.Models.Dish", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MixMeal.Core.Models.Ingredient", b =>
                {
                    b.Navigation("Allergies");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}