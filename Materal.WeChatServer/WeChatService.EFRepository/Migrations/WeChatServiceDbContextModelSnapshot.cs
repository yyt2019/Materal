﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeChatService.EFRepository;

namespace WeChatService.EFRepository.Migrations
{
    [DbContext(typeof(WeChatServiceDbContext))]
    partial class WeChatServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeChatService.Domain.Application", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppID")
                        .IsRequired();

                    b.Property<string>("AppSecret")
                        .IsRequired();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("EncodingAESKey");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Remark");

                    b.Property<string>("WeChatToken")
                        .IsRequired();

                    b.Property<DateTime>("UpdateTime");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("WeChatService.Domain.WeChatDomain", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("Index")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("WeChatDomain");
                });
#pragma warning restore 612, 618
        }
    }
}
