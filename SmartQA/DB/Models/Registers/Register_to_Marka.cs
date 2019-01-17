using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;
using SmartQA.DB.Models.Documents;

namespace SmartQA.DB.Models.Registers
{
    [Table("p_Register_to_Marka")]
    [M2M(typeof(Register), typeof(Marka))]
    public class Register_to_Marka : CommonEntity
    {
        public Guid Register_ID { get; set; }
        public Guid Marka_ID { get; set; }

        public virtual Register Register { get; set; }
        public virtual Marka Marka { get; set; }
    }
}