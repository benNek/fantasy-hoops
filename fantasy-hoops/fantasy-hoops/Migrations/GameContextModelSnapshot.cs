﻿// <auto-generated />
using fantasy_hoops.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace fantasy_hoops.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("fantasy_hoops.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NbaID");

                    b.Property<int>("Number");

                    b.Property<double>("PPG");

                    b.Property<string>("Position");

                    b.Property<int>("Price");

                    b.Property<int>("TeamID");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("fantasy_hoops.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.Property<int>("NbaID");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("fantasy_hoops.Models.Player", b =>
                {
                    b.HasOne("fantasy_hoops.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
