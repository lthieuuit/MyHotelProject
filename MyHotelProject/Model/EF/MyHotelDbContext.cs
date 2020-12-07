namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyHotelDbContext : DbContext
    {
        public MyHotelDbContext()
            : base("name=MyHotel")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<RoomTypeStatu> RoomTypeStatus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BillDetail>()
                .Property(e => e.TotalPayment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.TotalPayment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.RoomID)
                .IsFixedLength();

            modelBuilder.Entity<Room>()
                .Property(e => e.RoomTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<RoomType>()
                .Property(e => e.RoomType1)
                .IsUnicode(false);

            modelBuilder.Entity<RoomType>()
                .Property(e => e.Price)
                .IsFixedLength();

            modelBuilder.Entity<RoomTypeStatu>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
