namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImages
    {
        [Key]
        public int ImageID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        public virtual Product Product { get; set; }
    }
}
