﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBudget.Models;

namespace PersonalBudget.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220225183404_AddLinksBetweenBudgetsCategoriesAndSubcategories")]
    partial class AddLinksBetweenBudgetsCategoriesAndSubcategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalBudget.Models.Budget", b =>
                {
                    b.Property<Guid>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BudgetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RunningTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BudgetId");

                    b.ToTable("Budgets");

                    b.HasData(
                        new
                        {
                            BudgetId = new Guid("a52c4865-fd8d-4ab2-89d8-850354d6ef22"),
                            BudgetName = "2021 Budget",
                            RunningTotal = 0m
                        });
                });

            modelBuilder.Entity("PersonalBudget.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.HasIndex("BudgetId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PersonalBudget.Models.LineItem", b =>
                {
                    b.Property<Guid>("LineItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubcategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("LineItemId");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("PersonalBudget.Models.Subcategory", b =>
                {
                    b.Property<Guid>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubcategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubcategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("PersonalBudget.Models.Category", b =>
                {
                    b.HasOne("PersonalBudget.Models.Budget", null)
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("PersonalBudget.Models.LineItem", b =>
                {
                    b.HasOne("PersonalBudget.Models.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBudget.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBudget.Models.Subcategory", "Subcategory")
                        .WithMany()
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Category");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("PersonalBudget.Models.Subcategory", b =>
                {
                    b.HasOne("PersonalBudget.Models.Category", null)
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("PersonalBudget.Models.Budget", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("PersonalBudget.Models.Category", b =>
                {
                    b.Navigation("Subcategories");
                });
#pragma warning restore 612, 618
        }
    }
}
