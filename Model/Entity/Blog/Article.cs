using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Utility;

namespace Model.Entity.Blog
{
    [Table(name: "Articles", Schema = "Blog")]
    public class Article : BaseEntity
    {
        ~Article() { Dispose(true); }
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [Required]
        public string Summary { get; set; }

        public virtual Guid? ArticleGroupId { get; set; }

        [DefaultValue(0)]
        public int VisitNumber { get; set; }

        [StringLength(200)]
        public string MetaDescription { get; set; }

        [StringLength(200)]
        public string MetaRobots { get; set; }

        [StringLength(200)]
        public string MetaKeywords { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public virtual ArticleGroup ArticleGroup { get; set; }

        public virtual IList<ArticleImage> ArticleImages { get; set; }

        [NotMapped]
        public string ImageUrl =>
            string.IsNullOrEmpty(Image) ? String.Empty :
                string.Concat(GlobalParameter.CdnDomainUrl, GlobalParameter.ArticleImagePath, Image);
    }
}
