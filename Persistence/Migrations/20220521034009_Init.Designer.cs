﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220521034009_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("Domain.Entities.HabitEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitRoutineId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HabitRoutineId");

                    b.ToTable("HabitEvents");
                });

            modelBuilder.Entity("Domain.Entities.HabitEventReward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Currency")
                        .HasColumnType("money");

                    b.Property<int>("HabitRoutineId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("RewardType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitRoutineId")
                        .IsUnique();

                    b.ToTable("HabitEventRewards");
                });

            modelBuilder.Entity("Domain.Entities.HabitRoutine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HabitId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.ToTable("HabitRoutines");
                });

            modelBuilder.Entity("Domain.Entities.HabitEvent", b =>
                {
                    b.HasOne("Domain.Entities.HabitRoutine", "HabitRoutine")
                        .WithMany("HabitEvents")
                        .HasForeignKey("HabitRoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HabitRoutine");
                });

            modelBuilder.Entity("Domain.Entities.HabitEventReward", b =>
                {
                    b.HasOne("Domain.Entities.HabitRoutine", "HabitRoutine")
                        .WithOne("Reward")
                        .HasForeignKey("Domain.Entities.HabitEventReward", "HabitRoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HabitRoutine");
                });

            modelBuilder.Entity("Domain.Entities.HabitRoutine", b =>
                {
                    b.HasOne("Domain.Entities.Habit", "Habit")
                        .WithMany("HabitRoutines")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("Domain.Entities.Habit", b =>
                {
                    b.Navigation("HabitRoutines");
                });

            modelBuilder.Entity("Domain.Entities.HabitRoutine", b =>
                {
                    b.Navigation("HabitEvents");

                    b.Navigation("Reward")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
