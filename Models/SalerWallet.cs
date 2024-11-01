namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalerWallet")]
    public partial class SalerWallet
    {
        [Key]
        public int WalletID { get; set; }

        public int SalerID { get; set; }

        public decimal Balance { get; set; }

        public virtual Saler Saler { get; set; }
    }
}
