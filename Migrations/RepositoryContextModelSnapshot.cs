// <auto-generated />
using System;
using BvnValidationAPInew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BvnValidationAPInew.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BvnValidationAPInew.Models.tblRequestAndResponseLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RequestBaseUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647)
                        .IsUnicode(true);

                    b.Property<string>("RequestEndpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647)
                        .IsUnicode(true);

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("RequestPayload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000)
                        .IsUnicode(true);

                    b.Property<DateTime>("RequestTimestamp")
                        .HasColumnType("datetime");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647)
                        .IsUnicode(true);

                    b.Property<DateTime>("ResponseTimestamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("tblRequestAndResponseLog");
                });
#pragma warning restore 612, 618
        }
    }
}
