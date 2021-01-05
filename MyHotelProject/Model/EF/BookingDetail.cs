namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingDetail")]
    public partial class BookingDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BookingID { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long? RoomTypeID { get; set; }

        public DateTime? ToDate { get; set; }

        public DateTime? FromDate { get; set; }

        public int? Adult { get; set; }

        public int? Children { get; set; }

        public int? Quantity { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string RoomTypeName { get; set; }

        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Link { get; set; }
    }
}
