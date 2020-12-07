namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        public long BillCode { get; set; }

        public long? GuestID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal? Total { get; set; }
    }
}
