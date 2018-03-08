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

            modelBuilder.Entity("fantasy_hoops.Models.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title");

                    b.HasKey("NewsID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("fantasy_hoops.Models.Paragraph", b =>
                {
                    b.Property<int>("ParagraphID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("NewsID");

                    b.HasKey("ParagraphID");

                    b.HasIndex("NewsID");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("fantasy_hoops.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AST");

                    b.Property<double>("BLK");

                    b.Property<double>("FPPG");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NbaID");

                    b.Property<int>("Number");

                    b.Property<double>("PTS");

                    b.Property<string>("Position");

                    b.Property<int>("Price");

                    b.Property<double>("REB");

                    b.Property<double>("STL");

                    b.Property<int>("TeamID");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("fantasy_hoops.Models.Stats", b =>
                {
                    b.Property<int>("StatsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AST");

                    b.Property<int>("BLK");

                    b.Property<int>("DREB");

                    b.Property<DateTime>("Date");

                    b.Property<int>("FGA");

                    b.Property<int>("FGM");

                    b.Property<int>("FLS");

                    b.Property<int>("FTA");

                    b.Property<int>("FTM");

                    b.Property<int>("OREB");

                    b.Property<int>("PTS");

                    b.Property<int>("PlayerID");

                    b.Property<int>("STL");

                    b.Property<int>("TOV");

                    b.HasKey("StatsID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Stats");
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

            modelBuilder.Entity("fantasy_hoops.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FavoriteTeam");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
                    
            modelBuilder.Entity("fantasy_hoops.Models.Paragraph", b =>
                {
                    b.HasOne("fantasy_hoops.Models.News", "News")
                        .WithMany("Paragraphs")
                        .HasForeignKey("NewsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("fantasy_hoops.Models.Player", b =>
                {
                    b.HasOne("fantasy_hoops.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("fantasy_hoops.Models.Stats", b =>
                {
                    b.HasOne("fantasy_hoops.Models.Player", "Player")
                        .WithMany("Stats")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
