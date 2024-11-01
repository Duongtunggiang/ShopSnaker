namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Size")]
    public partial class Size
    {
        public int SizeID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(10)]
        public string SizeValue { get; set; }

        public virtual Product Product { get; set; }
    }
}
