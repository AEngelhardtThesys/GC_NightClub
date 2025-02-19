﻿// <auto-generated />
using System;
using GC_NightClub.WebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GC_NightClub.WebAPI.Migrations
{
    [DbContext(typeof(NightClubDbContext))]
    partial class NightClubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GC_NightClub.WebAPI.Domain.IdentityCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CardNumber");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpirationDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("NationalRegistryNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NationalRegistryNumber");

                    b.Property<DateTime>("ValidDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidDate");

                    b.HasKey("Id");

                    b.ToTable("IdentityCards");
                });

            modelBuilder.Entity("GC_NightClub.WebAPI.Domain.MemberCard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("BlacklistedUntilDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BlacklistedUntilDate");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<Guid>("IdentityCardId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdentityCardId");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("IdentityCardId");

                    b.ToTable("MemberCards");
                });

            modelBuilder.Entity("GC_NightClub.WebAPI.Domain.MemberCard", b =>
                {
                    b.HasOne("GC_NightClub.WebAPI.Domain.IdentityCard", "IdentityCard")
                        .WithMany("MemberCards")
                        .HasForeignKey("IdentityCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityCard");
                });

            modelBuilder.Entity("GC_NightClub.WebAPI.Domain.IdentityCard", b =>
                {
                    b.Navigation("MemberCards");
                });
#pragma warning restore 612, 618
        }
    }
}
