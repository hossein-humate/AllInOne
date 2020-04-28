using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Blog
{
    [Table(name: "Documents", Schema = "Blog")]
    public class Document : BaseEntity
    {
        ~Document() { Dispose(true); }
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        public virtual Guid? ParentId { get; set; }

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

        [DefaultValue(0)]
        public short SortOrder { get; set; }

        public virtual Document Parent { get; set; }

        public virtual IList<Document> Childrens { get; set; }

        public virtual IList<DocumentImage> DocumentImages { get; set; }
    }
}
