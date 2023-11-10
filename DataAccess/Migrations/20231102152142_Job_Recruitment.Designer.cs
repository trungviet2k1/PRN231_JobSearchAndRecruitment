﻿// <auto-generated />
using System;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(PRN231_ProjectDbContext))]
    [Migration("20231102152142_Job_Recruitment")]
    partial class Job_Recruitment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Models.Employer", b =>
                {
                    b.Property<int>("EmployerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployerId"));

                    b.Property<string>("CompanyDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CompanyWebsite")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("EmployerId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("BusinessObject.Models.FollowedEmployers", b =>
                {
                    b.Property<int>("FollowedEmployerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FollowedEmployerId"));

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.HasKey("FollowedEmployerId");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("FollowedEmployers");
                });

            modelBuilder.Entity("BusinessObject.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<DateTime>("ApplicationDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RequiredEducation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RequiredSkills")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TimeType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("JobId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("BusinessObject.Models.JobApplicant", b =>
                {
                    b.Property<int>("JobApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobApplicationId"));

                    b.Property<int>("ApplicationStatus")
                        .HasColumnType("int");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.HasKey("JobApplicationId");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobApplicants");
                });

            modelBuilder.Entity("BusinessObject.Models.JobSeeker", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobSeekerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ProfileDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("WorkExperience")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("JobSeekerId");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("BusinessObject.Models.Notifications", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NotificationId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("BusinessObject.Models.RatingsAndReviews", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("RatingsAndReviews");
                });

            modelBuilder.Entity("BusinessObject.Models.Resume", b =>
                {
                    b.Property<int>("ResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResumeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("BusinessObject.Models.SavedJobs", b =>
                {
                    b.Property<int>("SavedJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SavedJobId"));

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.HasKey("SavedJobId");

                    b.HasIndex("JobId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("SavedJobs");
                });

            modelBuilder.Entity("BusinessObject.Models.FollowedEmployers", b =>
                {
                    b.HasOne("BusinessObject.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.JobSeeker", "JobSeeker")
                        .WithMany("FollowedEmployers")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("BusinessObject.Models.Job", b =>
                {
                    b.HasOne("BusinessObject.Models.Employer", "Employer")
                        .WithMany("Jobs")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("BusinessObject.Models.JobApplicant", b =>
                {
                    b.HasOne("BusinessObject.Models.Employer", null)
                        .WithMany("JobApplications")
                        .HasForeignKey("EmployerId");

                    b.HasOne("BusinessObject.Models.Job", "Job")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.JobSeeker", "JobSeeker")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("BusinessObject.Models.Notifications", b =>
                {
                    b.HasOne("BusinessObject.Models.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("BusinessObject.Models.RatingsAndReviews", b =>
                {
                    b.HasOne("BusinessObject.Models.Employer", "Employer")
                        .WithMany("RatingsAndReviews")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("BusinessObject.Models.Resume", b =>
                {
                    b.HasOne("BusinessObject.Models.JobSeeker", "JobSeeker")
                        .WithMany("Resumes")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("BusinessObject.Models.SavedJobs", b =>
                {
                    b.HasOne("BusinessObject.Models.Job", "Job")
                        .WithMany("SavedJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.JobSeeker", "JobSeeker")
                        .WithMany("SavedJobs")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("BusinessObject.Models.Employer", b =>
                {
                    b.Navigation("JobApplications");

                    b.Navigation("Jobs");

                    b.Navigation("RatingsAndReviews");
                });

            modelBuilder.Entity("BusinessObject.Models.Job", b =>
                {
                    b.Navigation("JobApplications");

                    b.Navigation("SavedJobs");
                });

            modelBuilder.Entity("BusinessObject.Models.JobSeeker", b =>
                {
                    b.Navigation("FollowedEmployers");

                    b.Navigation("JobApplications");

                    b.Navigation("Resumes");

                    b.Navigation("SavedJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
