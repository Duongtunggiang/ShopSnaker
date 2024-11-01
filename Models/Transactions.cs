namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transactions
    {
        public int TransactionsID { get; set; }

        public int? BookingID { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? TransactionsDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
