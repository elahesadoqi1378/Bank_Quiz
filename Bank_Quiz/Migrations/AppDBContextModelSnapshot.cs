﻿// <auto-generated />
using System;
using Bank_Quiz.InfraStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank_Quiz.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank_Quiz.Entities.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Bank_Quiz.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("DestinationCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SourceCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isSuccessful")
                        .HasColumnType("bit");

                    b.HasKey("TransactionId");

                    b.HasIndex("DestinationCardNumber");

                    b.HasIndex("SourceCardNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Bank_Quiz.Entities.Transaction", b =>
                {
                    b.HasOne("Bank_Quiz.Entities.Card", "DestinationCard")
                        .WithMany("DestinationTransactions")
                        .HasForeignKey("DestinationCardNumber")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Bank_Quiz.Entities.Card", "SourceCard")
                        .WithMany("SourceTransactions")
                        .HasForeignKey("SourceCardNumber")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("Bank_Quiz.Entities.Card", b =>
                {
                    b.Navigation("DestinationTransactions");

                    b.Navigation("SourceTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}