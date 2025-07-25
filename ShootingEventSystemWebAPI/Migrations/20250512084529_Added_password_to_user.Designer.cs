﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShootingEventSystemWebAPI.Entities;

#nullable disable

namespace ShootingEventSystemWebAPI.Migrations
{
    [DbContext(typeof(TournamentDbContext))]
    [Migration("20250512084529_Added_password_to_user")]
    partial class Added_password_to_user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArbiterTournament", b =>
                {
                    b.Property<int>("ArbitersId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("ArbitersId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("ArbiterTournament");
                });

            modelBuilder.Entity("CompetitorTournament", b =>
                {
                    b.Property<int>("CompetitorsId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("CompetitorsId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("CompetitorTournament");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Arbiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LicenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Arbiter");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxScore")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Competitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LicenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("UserId");

                    b.ToTable("Competitor");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArbiterId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisqualified")
                        .HasColumnType("bit");

                    b.Property<decimal>("PenaltyPoints")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("Score")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArbiterId");

                    b.HasIndex("CompetitorId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSignUpOpen")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCompetitorsCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArbiterTournament", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Arbiter", null)
                        .WithMany()
                        .HasForeignKey("ArbitersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShootingEventSystemWebAPI.Entities.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompetitorTournament", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Competitor", null)
                        .WithMany()
                        .HasForeignKey("CompetitorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShootingEventSystemWebAPI.Entities.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Club", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Address", "Address")
                        .WithOne("Club")
                        .HasForeignKey("ShootingEventSystemWebAPI.Entities.Club", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Competitor", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShootingEventSystemWebAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Result", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Arbiter", "Arbiter")
                        .WithMany()
                        .HasForeignKey("ArbiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShootingEventSystemWebAPI.Entities.Competitor", "Competitor")
                        .WithMany()
                        .HasForeignKey("CompetitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShootingEventSystemWebAPI.Entities.Tournament", "Tournament")
                        .WithMany("Results")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arbiter");

                    b.Navigation("Competitor");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Tournament", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.User", b =>
                {
                    b.HasOne("ShootingEventSystemWebAPI.Entities.Club", null)
                        .WithMany("Users")
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Address", b =>
                {
                    b.Navigation("Club")
                        .IsRequired();
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Club", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ShootingEventSystemWebAPI.Entities.Tournament", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
