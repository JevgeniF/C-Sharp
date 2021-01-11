﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Domain.Boat", b =>
                {
                    b.Property<int>("BoatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GameOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("GameOptionsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("BoatId");

                    b.HasIndex("GameOptionsId");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("Domain.GameOptions", b =>
                {
                    b.Property<int>("GameOptionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BoardSide")
                        .HasColumnType("int");

                    b.Property<int>("BoatsCount")
                        .HasColumnType("int");

                    b.Property<int>("EBoatsCanTouch")
                        .HasColumnType("int");

                    b.Property<int>("ENextMoveAfterHit")
                        .HasColumnType("int");

                    b.Property<int>("SavedGameId")
                        .HasColumnType("int");

                    b.HasKey("GameOptionsId");

                    b.ToTable("GameOptions");
                });

            modelBuilder.Entity("Domain.SavedGame", b =>
                {
                    b.Property<int>("SavedGameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("GameOptionsId")
                        .HasColumnType("int");

                    b.Property<string>("SavedGameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerializedSavedGameData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SavedGameId");

                    b.HasIndex("GameOptionsId");

                    b.ToTable("SavedGames");
                });

            modelBuilder.Entity("Domain.Boat", b =>
                {
                    b.HasOne("Domain.GameOptions", "GameOptions")
                        .WithMany("BoatsList")
                        .HasForeignKey("GameOptionsId");

                    b.Navigation("GameOptions");
                });

            modelBuilder.Entity("Domain.SavedGame", b =>
                {
                    b.HasOne("Domain.GameOptions", "GameOptions")
                        .WithMany("SavedGamesList")
                        .HasForeignKey("GameOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameOptions");
                });

            modelBuilder.Entity("Domain.GameOptions", b =>
                {
                    b.Navigation("BoatsList");

                    b.Navigation("SavedGamesList");
                });
#pragma warning restore 612, 618
        }
    }
}
