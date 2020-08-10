﻿// <auto-generated />
using System;
using FELFEL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FELFEL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200810182807_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FELFEL.Data.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchStateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BatchStateId");

                    b.HasIndex("ExpirationDate")
                        .IsUnique();

                    b.ToTable("Batch");
                });

            modelBuilder.Entity("FELFEL.Data.BatchState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BatchState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fresh"
                        },
                        new
                        {
                            Id = 2,
                            Description = "ExpiringToday"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Expired"
                        });
                });

            modelBuilder.Entity("FELFEL.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Customer4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Customer5"
                        });
                });

            modelBuilder.Entity("FELFEL.Data.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("FELFEL.Data.InventoryHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("InventoryHistory");
                });

            modelBuilder.Entity("FELFEL.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStateId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderStateId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FELFEL.Data.OrderState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Description = "On Going"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Received"
                        });
                });

            modelBuilder.Entity("FELFEL.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bread"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chicken Meat"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Broccoli"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Apples"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Avocados"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Eggs"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Asparagus"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Onions"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Tomatoes"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Shrimp"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Sardines"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Tuna"
                        });
                });

            modelBuilder.Entity("FELFEL.Data.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Supplier1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Supplier2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Supplier3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Supplier4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Supplier5"
                        });
                });

            modelBuilder.Entity("FELFEL.Data.Batch", b =>
                {
                    b.HasOne("FELFEL.Data.BatchState", "BatchState")
                        .WithMany()
                        .HasForeignKey("BatchStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FELFEL.Data.Inventory", b =>
                {
                    b.HasOne("FELFEL.Data.Batch", "Batch")
                        .WithMany()
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FELFEL.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FELFEL.Data.InventoryHistory", b =>
                {
                    b.HasOne("FELFEL.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("FELFEL.Data.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FELFEL.Data.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("FELFEL.Data.Order", b =>
                {
                    b.HasOne("FELFEL.Data.OrderState", "OrderState")
                        .WithMany()
                        .HasForeignKey("OrderStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FELFEL.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FELFEL.Data.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}