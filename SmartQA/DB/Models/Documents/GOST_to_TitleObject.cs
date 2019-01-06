using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_GOST_to_TitleObject")]
    [M2M(typeof(GOST), typeof(TitleObject))]
    public class GOST_to_TitleObject : CommonEntity
    {
        public Guid GOST_ID { get; set; }
        public Guid TitleObject_ID { get; set; }

        public virtual GOST GOST { get; set; }
        public virtual TitleObject TitleObject { get; set; }
    }
}