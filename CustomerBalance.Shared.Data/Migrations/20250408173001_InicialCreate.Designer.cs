﻿// <auto-generated />
using CustomerBalance.Shared.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerBalance.Shared.Data.Migrations
{
    [DbContext(typeof(CustomerLedgerContext))]
    [Migration("20250408173001_InicialCreate")]
    partial class InicialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerBalance.Shared.Model.CustomerLedger", b =>
                {
                    b.Property<int>("AN8")
                        .HasColumnType("int");

                    b.Property<string>("DCT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DOC")
                        .HasColumnType("int");

                    b.Property<decimal>("AAP")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("AAR")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("AG")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("AID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DTR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DVJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AN8", "DCT", "DOC");

                    b.ToTable("CustomerLedgers");
                });
#pragma warning restore 612, 618
        }
    }
}
