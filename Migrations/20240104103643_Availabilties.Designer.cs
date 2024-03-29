﻿// <auto-generated />
using System;
using LaCroute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaCroute.Migrations
{
    [DbContext(typeof(LaCrouteContext))]
    [Migration("20240104103643_Availabilties")]
    partial class Availabilties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("LaCroute.Models.AvailabiltyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<bool>("is_available")
                        .HasColumnType("INTEGER");

                    b.Property<int>("serviceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("serviceId");

                    b.HasIndex("tableId");

                    b.ToTable("Availabilties");
                });

            modelBuilder.Entity("LaCroute.Models.EventModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("thumbnail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("LaCroute.Models.LabelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Svg")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("LaCroute.Models.ProductLabelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LabelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductLabel");
                });

            modelBuilder.Entity("LaCroute.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("LaCroute.Models.ReviewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("LaCroute.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("LaCroute.Models.TableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<int>("number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("seat")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("LaCroute.Models.TypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("LaCroute.Models.AvailabiltyModel", b =>
                {
                    b.HasOne("LaCroute.Models.ServiceModel", "service")
                        .WithMany("availabilties")
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaCroute.Models.TableModel", "table")
                        .WithMany("availabilties")
                        .HasForeignKey("tableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("service");

                    b.Navigation("table");
                });

            modelBuilder.Entity("LaCroute.Models.ProductLabelModel", b =>
                {
                    b.HasOne("LaCroute.Models.LabelModel", "Label")
                        .WithMany("ProductLabel")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaCroute.Models.ProductModel", "Product")
                        .WithMany("ProductLabel")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LaCroute.Models.ProductModel", b =>
                {
                    b.HasOne("LaCroute.Models.TypeModel", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("LaCroute.Models.LabelModel", b =>
                {
                    b.Navigation("ProductLabel");
                });

            modelBuilder.Entity("LaCroute.Models.ProductModel", b =>
                {
                    b.Navigation("ProductLabel");
                });

            modelBuilder.Entity("LaCroute.Models.ServiceModel", b =>
                {
                    b.Navigation("availabilties");
                });

            modelBuilder.Entity("LaCroute.Models.TableModel", b =>
                {
                    b.Navigation("availabilties");
                });

            modelBuilder.Entity("LaCroute.Models.TypeModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
