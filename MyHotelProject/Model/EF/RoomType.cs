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
        [StringLength(50)]
        public string RoomTypeName { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [StringLength(550)]
        public string Description { get; set; }

        [StringLength(550)]
        public string Image1 { get; set; }

        [StringLength(550)]
        public string Image2 { get; set; }

        [StringLength(550)]
        public string Image3 { get; set; }
    }
}
