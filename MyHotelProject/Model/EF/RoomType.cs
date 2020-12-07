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
        public int ID { get; set; }

        public int RoomNumber { get; set; }

        [Column("RoomType")]
        [StringLength(50)]
        public string RoomType1 { get; set; }

        public int? RoomCapacity { get; set; }

        [StringLength(10)]
        public string Price { get; set; }

        [StringLength(550)]
        public string Description { get; set; }

        [Required]
        [StringLength(550)]
        public string Image { get; set; }

        public int? StatusID { get; set; }

        public int? Quantity { get; set; }
    }
}
