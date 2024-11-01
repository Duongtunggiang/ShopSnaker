namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CartItem")]
    public partial class CartItem
    {
        public int CartItemID { get; set; }

        public int? CartID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
