﻿// <auto-generated />
using System;
using Consolidados.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Consolidados.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Consolidados.Common.Entities.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContainerName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("Payload")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContainerName")
                        .IsUnique()
                        .HasFilter("[ContainerName] IS NOT NULL");

                    b.HasIndex("ContractId");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("Consolidados.Common.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivedAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ArrivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StartingAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContractNumber")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Consolidados.Common.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContainerId")
                        .HasColumnType("int");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.HasIndex("ContractId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("Consolidados.Common.Entities.Container", b =>
                {
                    b.HasOne("Consolidados.Common.Entities.Contract", null)
                        .WithMany("Containers")
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("Consolidados.Common.Entities.State", b =>
                {
                    b.HasOne("Consolidados.Common.Entities.Container", null)
                        .WithMany("States")
                        .HasForeignKey("ContainerId");

                    b.HasOne("Consolidados.Common.Entities.Contract", null)
                        .WithMany("StateList")
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("Consolidados.Common.Entities.Container", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Consolidados.Common.Entities.Contract", b =>
                {
                    b.Navigation("Containers");

                    b.Navigation("StateList");
                });
#pragma warning restore 612, 618
        }
    }
}
