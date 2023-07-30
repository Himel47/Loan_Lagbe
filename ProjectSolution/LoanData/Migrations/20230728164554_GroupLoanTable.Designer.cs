﻿// <auto-generated />
using System;
using LoanData.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanData.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230728164554_GroupLoanTable")]
    partial class GroupLoanTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoanData.Models.Group.CollectionGroup", b =>
                {
                    b.Property<int>("CollectionGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionGroupId"));

                    b.Property<int>("CollectedMoney")
                        .HasColumnType("int");

                    b.Property<string>("CollectionGroupName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<long?>("MemberNID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CollectionGroupId");

                    b.HasIndex("MemberNID");

                    b.ToTable("CollectionGroups");
                });

            modelBuilder.Entity("LoanData.Models.Group.GroupType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("GroupTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("GroupTypes");
                });

            modelBuilder.Entity("LoanData.Models.Group.LoanGroup", b =>
                {
                    b.Property<int>("LoanGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanGroupId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLoanPlanned")
                        .HasColumnType("bit");

                    b.Property<string>("LoanGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<long?>("MemberNID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalLoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanGroupId");

                    b.HasIndex("MemberNID");

                    b.ToTable("LoanGroups");
                });

            modelBuilder.Entity("LoanData.Models.Loan.GroupLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<long>("GroupLoanId")
                        .HasColumnType("bigint");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLoanRunning")
                        .HasColumnType("bit");

                    b.Property<long>("MemberNID")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GroupLoans");
                });

            modelBuilder.Entity("LoanData.Models.Loan.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstallmentCount")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentDays")
                        .HasColumnType("int");

                    b.Property<long>("MemberNID")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("InstallmentDetails");
                });

            modelBuilder.Entity("LoanData.Models.Loan.InstallmentPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstallmentId")
                        .HasColumnType("int");

                    b.Property<int>("InstalmentAmount")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<long>("LoanId")
                        .HasColumnType("bigint");

                    b.Property<long>("MemberNID")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaidAmount")
                        .HasColumnType("int");

                    b.Property<int>("RemainingAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LoanPersonalInstallments");
                });

            modelBuilder.Entity("LoanData.Models.Loan.LoanBasic", b =>
                {
                    b.Property<long>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LoanId"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExtraCharge")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IncludedInterest")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentCount")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentDays")
                        .HasColumnType("int");

                    b.Property<int>("InterestRate")
                        .HasColumnType("int");

                    b.Property<bool>("IsLoanPaymentComplete")
                        .HasColumnType("bit");

                    b.Property<int>("LoanAmount")
                        .HasColumnType("int");

                    b.Property<long>("MemberNID")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerInstallmentAmount")
                        .HasColumnType("int");

                    b.Property<int>("ProcessingFee")
                        .HasColumnType("int");

                    b.Property<int>("RefundAmount")
                        .HasColumnType("int");

                    b.Property<long>("SerialId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubmissionTimeInMonth")
                        .HasColumnType("int");

                    b.Property<int>("TotalCharge")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("LoanData.Models.Loan.LoanPaidDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IsPaidDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanPaymentDetails");
                });

            modelBuilder.Entity("LoanData.Models.Loan.SubmissionPeriod", b =>
                {
                    b.Property<int>("SubmissionPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubmissionPeriodId"));

                    b.Property<string>("SubmissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubmissionPeriodDays")
                        .HasColumnType("int");

                    b.HasKey("SubmissionPeriodId");

                    b.ToTable("SubmissionPeriods");
                });

            modelBuilder.Entity("LoanData.Models.Member.MaritalStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("MaritalStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("MaritalStatuses");
                });

            modelBuilder.Entity("LoanData.Models.Member.MemberBase", b =>
                {
                    b.Property<long>("NID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NID"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonthlyIncome")
                        .HasColumnType("int");

                    b.Property<string>("MotherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfEarningMember")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalFamilyMember")
                        .HasColumnType("int");

                    b.HasKey("NID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LoanData.Models.MemberWithGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("GroupTypeId")
                        .HasColumnType("int");

                    b.Property<long>("MemberNID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MembersWithGroups");
                });

            modelBuilder.Entity("LoanData.Models.Group.CollectionGroup", b =>
                {
                    b.HasOne("LoanData.Models.Member.MemberBase", "Member")
                        .WithMany()
                        .HasForeignKey("MemberNID");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LoanData.Models.Group.LoanGroup", b =>
                {
                    b.HasOne("LoanData.Models.Member.MemberBase", "Member")
                        .WithMany()
                        .HasForeignKey("MemberNID");

                    b.Navigation("Member");
                });
#pragma warning restore 612, 618
        }
    }
}
