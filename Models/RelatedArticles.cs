namespace NewShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RelatedArticles
    {
        [Key]
        public int ArticleID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
