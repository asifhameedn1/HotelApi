using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hotels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AH.Hotels.Entities
{
    public class HotelContext : DbContext
    {
        private readonly string _connectionString;
        public HotelContext(IConfiguration config)
        {
            _connectionString = config.GetSection("HotelConnectionString")?.Value.ToString();
        }
        public DbSet<HotelDetails> HotelDetail { get; set; }

        public DbSet<RoomDetails> RoomDetail { get; set; }

        public DbSet<BookingDetail> BookingDetail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            optionsBuilder.UseSqlServer(_connectionString, ConfigureSqlServerDatabaseOptions);
        }

        private void ConfigureSqlServerDatabaseOptions(SqlServerDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(HotelContext).Namespace);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<HotelDetails>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<RoomDetails>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<BookingDetail>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<BookingDetail>()
            .HasOne(e => e.Room)
            .WithMany(e => e.Bookings)
            .HasForeignKey(e => e.Id)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingDetail>()
             .HasOne(e => e.Hotel)
            .WithMany(e => e.Bookings)
            .HasForeignKey(e => e.Id)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
