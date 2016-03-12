using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GroceryApp.Models;

namespace GroceryApp.Migrations
{
    [DbContext(typeof(GroceryContext))]
    [Migration("20160312142755_RemoveDateFromStop")]
    partial class RemoveDateFromStop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroceryApp.Models.GroceryCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroceryApp.Models.GroceryStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroceryApp.Models.GroceryTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("TotalSpent");

                    b.Property<DateTime>("TripDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroceryApp.Models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroceryTripId");

                    b.Property<int?>("StoreId");

                    b.Property<decimal>("TotalSpent");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroceryApp.Models.StopCategoryTotal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountSpent");

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("StopId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroceryApp.Models.Stop", b =>
                {
                    b.HasOne("GroceryApp.Models.GroceryTrip")
                        .WithMany()
                        .HasForeignKey("GroceryTripId");

                    b.HasOne("GroceryApp.Models.GroceryStore")
                        .WithMany()
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("GroceryApp.Models.StopCategoryTotal", b =>
                {
                    b.HasOne("GroceryApp.Models.GroceryCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("GroceryApp.Models.Stop")
                        .WithMany()
                        .HasForeignKey("StopId");
                });
        }
    }
}
