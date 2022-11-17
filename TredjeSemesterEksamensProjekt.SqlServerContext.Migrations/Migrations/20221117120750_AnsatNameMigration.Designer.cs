﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TredjeSemesterEksamensProjekt.SqlDbContextProjekt;

#nullable disable

namespace TredjeSemesterEksamensProjekt.SqlServerContext.Migrations.Migrations
{
    [DbContext(typeof(TredjeSemesterEksamensProjektContext))]
    [Migration("20221117120750_AnsatNameMigration")]
    partial class AnsatNameMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnsatEntityKompetanceEntity", b =>
                {
                    b.Property<int>("AnsatteId")
                        .HasColumnType("int");

                    b.Property<int>("KompetancerId")
                        .HasColumnType("int");

                    b.HasKey("AnsatteId", "KompetancerId");

                    b.HasIndex("KompetancerId");

                    b.ToTable("AnsatEntityKompetanceEntity");
                });

            modelBuilder.Entity("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.AnsatEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ansat", "ansat");
                });

            modelBuilder.Entity("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.KompetanceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kompetance", "kompetance");
                });

            modelBuilder.Entity("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.OpgaveEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("KompetanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KompetanceId");

                    b.ToTable("Opgave", "opgave");
                });

            modelBuilder.Entity("AnsatEntityKompetanceEntity", b =>
                {
                    b.HasOne("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.AnsatEntity", null)
                        .WithMany()
                        .HasForeignKey("AnsatteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.KompetanceEntity", null)
                        .WithMany()
                        .HasForeignKey("KompetancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.OpgaveEntity", b =>
                {
                    b.HasOne("TredjeSemesterEksamensProjekt.Opgave.Domain.Model.KompetanceEntity", "Kompetance")
                        .WithMany()
                        .HasForeignKey("KompetanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kompetance");
                });
#pragma warning restore 612, 618
        }
    }
}
