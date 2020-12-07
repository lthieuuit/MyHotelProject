namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public long ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long GuestID { get; set; }

        public DateTime? ToDate { get; set; }

        public DateTime? FromDate { get; set; }

        public long RoomNumber { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        public long? IdCardNumber { get; set; }

        [StringLength(50)]
        public string BookAddress { get; set; }

        [StringLength(50)]
        public string BookEmail { get; set; }

        [StringLength(50)]
        public string BookPhone { get; set; }

        public int? Status { get; set; }
    }
}
