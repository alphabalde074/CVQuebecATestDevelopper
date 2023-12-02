﻿// <auto-generated />
using System;
using Fujitsu.CvQc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fujitsu.CvQc.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230519193416_RemoveImportationTable")]
    partial class RemoveImportationTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentMapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Importation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DocumentMapId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.DocumentMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("DocumentMaps");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.DocumentMapSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DocumentMapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExportationMode")
                        .HasColumnType("int");

                    b.Property<string>("Match")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentMapId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.ProjectConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ImportMode")
                        .HasColumnType("int");

                    b.Property<string>("InputPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutputPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutputSuffix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplatePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("ProjectConfig");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.SectionParagraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DocumentMapSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentMapSectionId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Document", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.DocumentMap", "DocumentMap")
                        .WithMany()
                        .HasForeignKey("DocumentMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fujitsu.CvQc.Data.Entities.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentMap");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.DocumentMapSection", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.DocumentMap", null)
                        .WithMany("Sections")
                        .HasForeignKey("DocumentMapId");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Job", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Log", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.Job", "Job")
                        .WithMany("Logs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.ProjectConfig", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.Project", "Project")
                        .WithOne("Config")
                        .HasForeignKey("Fujitsu.CvQc.Data.Entities.ProjectConfig", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.SectionParagraph", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.DocumentMapSection", null)
                        .WithMany("Paragraphs")
                        .HasForeignKey("DocumentMapSectionId");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.DocumentMap", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.DocumentMapSection", b =>
                {
                    b.Navigation("Paragraphs");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Job", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Project", b =>
                {
                    b.Navigation("Config");

                    b.Navigation("Documents");

                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
