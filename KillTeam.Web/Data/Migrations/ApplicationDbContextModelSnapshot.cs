﻿// <auto-generated />
using System;
using KillTeam.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KillTeam.Web.Data.Migrations
{
    [DbContext(typeof(KillTeamWebContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KillTeam.Web.Models.Faction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Faction");
                });

            modelBuilder.Entity("KillTeam.Web.Models.FactionGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("FactionGroup");
                });

            modelBuilder.Entity("KillTeam.Web.Models.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("KillTeam.Web.Models.Faction", b =>
                {
                    b.HasOne("KillTeam.Web.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("KillTeam.Web.Models.FactionGroup", b =>
                {
                    b.HasOne("KillTeam.Web.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");

                    b.Navigation("Race");
                });
#pragma warning restore 612, 618
        }
    }
}
