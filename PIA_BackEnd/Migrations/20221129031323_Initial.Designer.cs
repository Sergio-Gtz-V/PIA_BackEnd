﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIA_BackEnd;

#nullable disable

namespace PIA_BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221129031323_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PIA_BackEnd.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RaffleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaffleId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("PIA_BackEnd.Entities.Prizes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("RaffleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaffleId");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("PIA_BackEnd.Entities.Raffle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasEnded")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("NumberOfWinners")
                        .HasColumnType("int");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rifas");
                });

            modelBuilder.Entity("PIA_BackEnd.Entities.Participant", b =>
                {
                    b.HasOne("PIA_BackEnd.Entities.Raffle", null)
                        .WithMany("Participants")
                        .HasForeignKey("RaffleId");
                });

            modelBuilder.Entity("PIA_BackEnd.Entities.Prizes", b =>
                {
                    b.HasOne("PIA_BackEnd.Entities.Raffle", null)
                        .WithMany("Prizes")
                        .HasForeignKey("RaffleId");
                });

            modelBuilder.Entity("PIA_BackEnd.Entities.Raffle", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("Prizes");
                });
#pragma warning restore 612, 618
        }
    }
}
