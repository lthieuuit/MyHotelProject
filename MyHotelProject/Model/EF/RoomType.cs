namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomType")]
    public partial class RoomType
    {
        public long ID { get; set; }

        [Column("RoomType")]
        [StringLength(50)]
        public string RoomType1 { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [StringLength(550)]
        public string Description { get; set; }

        [StringLength(550)]
        public string Image { get; set; }

        public int? Quantity { get; set; }
    }
}
