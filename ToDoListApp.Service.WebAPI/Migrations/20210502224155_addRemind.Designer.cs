﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListApp.Service.WebAPI.Data.Context.EfCore;

namespace ToDoListApp.Service.WebAPI.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    [Migration("20210502224155_addRemind")]
    partial class addRemind
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoListApp.Service.WebAPI.Entities.MyTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemind")
                        .HasColumnType("bit");

                    b.Property<string>("TaskContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MyTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 5, 3, 1, 41, 54, 278, DateTimeKind.Local).AddTicks(9361),
                            IsDelete = false,
                            IsDone = true,
                            IsRemind = false,
                            TaskContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                            TaskDate = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(6717),
                            TaskTitle = "Lorem Ipsum",
                            UpdatedAt = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(3948)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7331),
                            IsDelete = false,
                            IsDone = false,
                            IsRemind = false,
                            TaskContent = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                            TaskDate = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7385),
                            TaskTitle = "Contrary to popular",
                            UpdatedAt = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7346)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDelete = false,
                            IsDone = true,
                            IsRemind = false,
                            TaskContent = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                            TaskDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTitle = "Contrary to popula",
                            UpdatedAt = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2020, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7602),
                            IsDelete = true,
                            IsDone = true,
                            IsRemind = false,
                            TaskContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
                            TaskDate = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7842),
                            TaskTitle = "There are many variations",
                            UpdatedAt = new DateTime(2020, 6, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7834)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2018, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7845),
                            IsDelete = false,
                            IsDone = false,
                            IsRemind = false,
                            TaskContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
                            TaskDate = new DateTime(2021, 5, 3, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7915),
                            TaskTitle = "There are many variations",
                            UpdatedAt = new DateTime(2019, 7, 18, 1, 41, 54, 280, DateTimeKind.Local).AddTicks(7848)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
