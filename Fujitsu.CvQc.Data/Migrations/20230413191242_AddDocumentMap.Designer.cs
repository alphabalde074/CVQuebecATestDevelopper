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
    [Migration("20230413191242_AddDocumentMap")]
    partial class AddDocumentMap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DocumentMapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentMapId");

                    b.ToTable("Projects");
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

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.DocumentMapSection", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.DocumentMap", null)
                        .WithMany("Sections")
                        .HasForeignKey("DocumentMapId");
                });

            modelBuilder.Entity("Fujitsu.CvQc.Data.Entities.Project", b =>
                {
                    b.HasOne("Fujitsu.CvQc.Data.Entities.DocumentMap", "DocumentMap")
                        .WithMany()
                        .HasForeignKey("DocumentMapId");

                    b.Navigation("DocumentMap");
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
#pragma warning restore 612, 618
        }
    }
}
