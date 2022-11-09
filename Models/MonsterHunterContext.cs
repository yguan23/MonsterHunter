using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prjCore.Models
{
    public partial class MonsterHunterContext : DbContext
    {
        public MonsterHunterContext()
        {
        }

        public MonsterHunterContext(DbContextOptions<MonsterHunterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armor> Armor { get; set; }
        public virtual DbSet<Monster> Monster { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=YGUAN23;Initial Catalog=MonsterHunter;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.系列名稱)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.名稱)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.弱點屬性).HasMaxLength(50);

                entity.Property(e => e.弱點武器).HasMaxLength(50);

                entity.Property(e => e.弱點部位).HasMaxLength(50);

                entity.Property(e => e.種類).HasMaxLength(50);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.充能斧).HasMaxLength(50);

                entity.Property(e => e.單手劍).HasMaxLength(50);

                entity.Property(e => e.大劍).HasMaxLength(50);

                entity.Property(e => e.大錘).HasMaxLength(50);

                entity.Property(e => e.太刀).HasMaxLength(50);

                entity.Property(e => e.弓).HasMaxLength(50);

                entity.Property(e => e.操蟲棍).HasMaxLength(50);

                entity.Property(e => e.斬擊斧).HasMaxLength(50);

                entity.Property(e => e.狩獵笛).HasMaxLength(50);

                entity.Property(e => e.系列名稱)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.輕弩).HasMaxLength(50);

                entity.Property(e => e.重弩).HasMaxLength(50);

                entity.Property(e => e.銃槍).HasMaxLength(50);

                entity.Property(e => e.長槍).HasMaxLength(50);

                entity.Property(e => e.雙劍).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
