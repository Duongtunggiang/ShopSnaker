namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerWallet")]
    public partial class CustomerWallet
    {
        [Key]
        public int WalletID { get; set; }

        public int CustomerID { get; set; }

        public decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
