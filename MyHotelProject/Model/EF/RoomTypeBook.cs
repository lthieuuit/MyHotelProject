namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomTypeBook")]
    public partial class RoomTypeBook
    {
        public long ID { get; set; }

        public long RoomTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomTypeNameBook { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
