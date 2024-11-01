namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingDetails
    {
        public int BookingDetailsID { get; set; }

        public int? BookingID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Product Product { get; set; }
    }
}
