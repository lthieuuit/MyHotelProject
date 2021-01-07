using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class MyHotelDbContext : DbContext
    {
        public MyHotelDbContext()
            : base("name=MyHotelDbContext")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<RoomTypeBook> RoomTypeBooks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BillDetail>()
                .Property(e => e.TotalPayment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RoomTypeBook>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
