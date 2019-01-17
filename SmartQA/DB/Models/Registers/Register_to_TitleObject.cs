using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;
using SmartQA.DB.Models.Documents;

namespace SmartQA.DB.Models.Registers
{
    [Table("p_Register_to_TitleObject")]
    [M2M(typeof(Register), typeof(TitleObject))]
    public class Register_to_TitleObject : CommonEntity
    {
        public Guid Register_ID { get; set; }
        public Guid TitleObject_ID { get; set; }

        public virtual Register Register { get; set; }
        public virtual TitleObject TitleObject { get; set; }
    }
}