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

            modelBuilder.Entity("BitrateVideoTest", b =>
                {
                    b.Property<Guid>("BitrateValuesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestsId")
                        .HasColumnType("uuid");

                    b.HasKey("BitrateValuesId", "TestsId");

                    b.HasIndex("TestsId");

                    b.ToTable("BitrateVideoTest");
                });

            modelBuilder.Entity("CategorySurvey", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SurveysId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "SurveysId");

                    b.HasIndex("SurveysId");

                    b.ToTable("CategorySurvey");
                });

            modelBuilder.Entity("CategoryVideoTest", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestsId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "TestsId");

                    b.HasIndex("TestsId");

                    b.ToTable("CategoryVideoTest");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Bitrate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BitrateValues");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Bitrate")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Quality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Qualities");
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

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.VideoTest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QualityId")
                        .HasColumnType("integer");

                    b.Property<int>("SamplesNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("QualityId");

                    b.ToTable("VideoTests");
                });

            modelBuilder.Entity("BitrateVideoTest", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Bitrate", null)
                        .WithMany()
                        .HasForeignKey("BitrateValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoBench.Domain.Entities.VideoTest", null)
                        .WithMany()
                        .HasForeignKey("TestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("TestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Feedback", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Survey", "Survey")
                        .WithMany("Feedbacks")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Survey", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.VideoTest", "Test")
                        .WithMany("Surveys")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.VideoTest", b =>
                {
                    b.HasOne("VideoBench.Domain.Entities.Quality", "Quality")
                        .WithMany("Tests")
                        .HasForeignKey("QualityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quality");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Quality", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.Survey", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("VideoBench.Domain.Entities.VideoTest", b =>
                {
                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
