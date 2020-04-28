using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;

namespace Model.Entity.Blog
{
    [Table(name: "ArticleGroups", Schema = "Blog")]
    public class ArticleGroup: BaseEntity
    {
        ~ArticleGroup(){Dispose(true);}

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string MetaDescription { get; set; }

        [StringLength(200)]
        public string MetaRobots { get; set; }

        [StringLength(200)]
        public string MetaKeywords { get; set; }

        public virtual Guid? ParentId { get; set; }

        public virtual ArticleGroup Parent { get; set; }

        public virtual IList<ArticleGroup> Childrens { get; set; }
      
        public virtual IList<Article> Articles { get; set; }

        [NotMapped]
        public string ImageUrl =>
          string.IsNullOrEmpty(Image) ? String.Empty :
              string.Concat(GlobalParameter.CdnDomainUrl, GlobalParameter.ArticleImagePath, Image);
    }
}