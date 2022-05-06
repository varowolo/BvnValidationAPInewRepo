using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BvnValidationAPInew.Models
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options)
          : base(options)
        {


        }

        public virtual DbSet<tblRequestAndResponseLog> tblRequestAndResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<tblRequestAndResponseLog>(entity =>
            {

                entity.ToTable("tblRequestAndResponseLog");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestType).IsRequired(true).IsUnicode(false).HasMaxLength(100);
                entity.Property(e => e.RequestPayload).IsRequired(true).IsUnicode(true).HasMaxLength(5000);
                entity.Property(e => e.RequestId).IsRequired(true).IsUnicode(false).HasMaxLength(50);
                entity.Property(e => e.Response).IsRequired(false).IsUnicode(true).HasMaxLength(int.MaxValue);
                entity.Property(e => e.RequestTimestamp).IsRequired(true).HasColumnType("datetime");
                entity.Property(e => e.ResponseTimestamp).IsRequired(true).HasColumnType("datetime");
                entity.Property(e => e.RequestBaseUrl).IsRequired(true).IsUnicode(true).HasMaxLength(int.MaxValue);
                entity.Property(e => e.RequestEndpoint).IsRequired(true).IsUnicode(true).HasMaxLength(int.MaxValue);

            });

        }
    }
}
