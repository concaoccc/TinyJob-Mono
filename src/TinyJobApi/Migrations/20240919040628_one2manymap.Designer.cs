﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TinyJobApi.Database;

#nullable disable

namespace TinyJobApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240919040628_one2manymap")]
    partial class one2manymap
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TinyJobApi.Database.Entity.ExecutorDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreateTime");

                    b.Property<DateTimeOffset>("LastHeartbeat")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastHeartbeat");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset>("UpdateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Executor", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastHeartbeat = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "MockedExecutor",
                            Status = "Online",
                            UpdateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.JobDo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset?>("ActualExecutionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreateTime");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("FinishTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("FinishTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Name");

                    b.Property<DateTimeOffset?>("ScheduledExecutionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SchedulerId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset>("UpdateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("SchedulerId");

                    b.ToTable("Job", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "TestJob",
                            ScheduledExecutionTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            SchedulerId = 1,
                            Status = "WaitForExecution",
                            UpdateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.PackageDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreateTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("OwnerId");

                    b.Property<string>("RelativePath")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("RelativePath");

                    b.Property<string>("StorageAccount")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("StorageAccount");

                    b.Property<DateTimeOffset>("UpdateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdateTime");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Name", "OwnerId", "Version")
                        .IsUnique();

                    b.ToTable("Package", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Echo helloworld",
                            Name = "HelloWorld",
                            OwnerId = 1,
                            RelativePath = "MockedRelativePath",
                            StorageAccount = "MockedStorageAccount",
                            UpdateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Version = "1.0.0"
                        });
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.SchedulerDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AssemblyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("AssemblyName");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ClassName");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreateTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Description");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndTime");

                    b.Property<string>("ExecutionParams")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ExecutionParams");

                    b.Property<string>("ExecutionPlan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ExecutionPlan");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Name");

                    b.Property<string>("Namespace")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Namespace");

                    b.Property<DateTimeOffset?>("NextExecutionTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("NextExecutionTime");

                    b.Property<int>("PackageId")
                        .HasColumnType("integer")
                        .HasColumnName("PackageId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Type");

                    b.Property<DateTimeOffset>("UpdateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("Scheduler", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssemblyName = "JobExample",
                            ClassName = "HelloWorldJob",
                            CreateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "TestScheduler",
                            EndTime = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 8, 0, 0, 0)),
                            ExecutionPlan = "0 0 12 0 0",
                            Name = "TestScheduler",
                            Namespace = "JobExample",
                            NextExecutionTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PackageId = 1,
                            Type = "Cron",
                            UpdateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.UserDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreateTime");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Password");

                    b.Property<DateTimeOffset?>("UpdateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdateTime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "fake@localhost",
                            Password = "DefaultPassword",
                            UpdateTime = new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "DefaultAccount"
                        });
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.JobDo", b =>
                {
                    b.HasOne("TinyJobApi.Database.Entity.ExecutorDo", "Executor")
                        .WithMany("Jobs")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TinyJobApi.Database.Entity.SchedulerDo", "Scheduler")
                        .WithMany("Jobs")
                        .HasForeignKey("SchedulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("Scheduler");
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.PackageDo", b =>
                {
                    b.HasOne("TinyJobApi.Database.Entity.UserDo", "Owner")
                        .WithMany("Packages")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.SchedulerDo", b =>
                {
                    b.HasOne("TinyJobApi.Database.Entity.PackageDo", "Package")
                        .WithMany("Schedulers")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.ExecutorDo", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.PackageDo", b =>
                {
                    b.Navigation("Schedulers");
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.SchedulerDo", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("TinyJobApi.Database.Entity.UserDo", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}