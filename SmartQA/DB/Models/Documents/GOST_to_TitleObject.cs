using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_GOST_to_TitleObject")]
    public class GOST_to_TitleObject : M2MEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GOST_to_TitleObject_ID { get; set; }

        public Guid GOST_ID { get; set; }
        public Guid TitleObject_ID { get; set; }

        [ForeignKey("GOST_ID")]
        public virtual GOST GOST { get; set; }
        [ForeignKey("TitleObject_ID")]
        public virtual TitleObject TitleObject { get; set; }
    }
}