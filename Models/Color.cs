namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Color")]
    public partial class Color
    {
        public int ColorID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(50)]
        public string ColorValue { get; set; }

        public virtual Product Product { get; set; }
    }
}
