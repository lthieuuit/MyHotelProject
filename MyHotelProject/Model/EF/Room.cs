namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNumber { get; set; }

        [StringLength(50)]
        public string RoomTypeID { get; set; }

        public int? RoomCapacity { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Price { get; set; }
    }
}
