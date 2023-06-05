﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegisterApplications.Repositories;

#nullable disable

namespace RegisterApplications.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230605112254_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegisterApplications.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourierId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourierId");

                    b.ToTable("Bids");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cargo = "Коробка",
                            Name = "Заявка 1",
                            Recipient = "Петров Петр Петрович",
                            Sender = "Иванов Иван Иванович",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            Cargo = "Печь для бани",
                            Comment = "Отмена из-за погодных условий",
                            CourierId = 1,
                            Name = "Заявка 2",
                            Recipient = "Мягков Виталий Олегович",
                            Sender = "Иванов Владислав Дмитриевич",
                            Status = 3
                        },
                        new
                        {
                            Id = 3,
                            Cargo = "Телефон",
                            CourierId = 2,
                            Name = "Заявка 3",
                            Recipient = "Пупкин Сергей Викторович",
                            Sender = "Сидоров Олег Дмитриевич",
                            Status = 2
                        },
                        new
                        {
                            Id = 4,
                            Cargo = "Трубы",
                            CourierId = 3,
                            Name = "Заявка 4",
                            Recipient = "Васильев Роман Валерьевич",
                            Sender = "Смирнов Юрий Николаевич",
                            Status = 1
                        });
                });

            modelBuilder.Entity("RegisterApplications.Models.Courier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Couriers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Валерий"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Антон"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Олег"
                        });
                });

            modelBuilder.Entity("RegisterApplications.Models.Bid", b =>
                {
                    b.HasOne("RegisterApplications.Models.Courier", "Courier")
                        .WithMany("Bids")
                        .HasForeignKey("CourierId");

                    b.Navigation("Courier");
                });

            modelBuilder.Entity("RegisterApplications.Models.Courier", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
