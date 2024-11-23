﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VideoBench.Infrastructure.Data;

#nullable disable

namespace VideoBench.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategorySurvey", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<Guid>("SurveysId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "SurveysId");

                    b.HasIndex("SurveysId");

                    b.ToTable("CategorySurvey");
                });

            modelBuilder.Entity("CategoryVideoTest", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<Guid>("VideoTestsId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "VideoTestsId");

                    b.HasIndex("VideoTestsId");

                    b.ToTable("CategoryVideoTest");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Quality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("quality");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DeviceType")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VideoTestId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VideoTestId");

                    b.ToTable("survey");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Bitrate")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<string>("SourceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("video");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.VideoTest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QualityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QualityId");

                    b.ToTable("video_test");
                });

            modelBuilder.Entity("CategorySurvey", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoBench.Domain.Entities.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryVideoTest", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoBench.Domain.Entities.VideoTest", null)
                        .WithMany()
                        .HasForeignKey("VideoTestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Survey", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.VideoTest", "VideoTest")
                        .WithMany("Surveys")
                        .HasForeignKey("VideoTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VideoTest");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Video", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Survey", "Survey")
                        .WithMany("Videos")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.VideoTest", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Quality", "Quality")
                        .WithMany("VideoTests")
                        .HasForeignKey("QualityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quality");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Quality", b =>
                {
                    b.Navigation("VideoTests");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Survey", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.VideoTest", b =>
                {
                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
