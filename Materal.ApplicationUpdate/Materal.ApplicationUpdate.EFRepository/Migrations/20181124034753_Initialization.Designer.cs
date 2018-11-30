﻿// <auto-generated />
using System;
using Materal.ApplicationUpdate.EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Materal.ApplicationUpdate.EFRepository.Migrations
{
    [DbContext(typeof(AppUpdateContext))]
    [Migration("20181124034753_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Materal.ApplicationUpdate.Domain.ApplicationLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Application");

                    b.Property<string>("Callsite");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<string>("Logger");

                    b.Property<string>("Message");

                    b.HasKey("ID");

                    b.ToTable("ApplicationLog");
                });

            modelBuilder.Entity("Materal.ApplicationUpdate.Domain.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .IsRequired();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<DateTime>("TokenExpireDate");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}