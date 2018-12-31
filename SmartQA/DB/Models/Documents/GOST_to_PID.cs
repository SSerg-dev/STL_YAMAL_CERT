using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_GOST_to_PID")]
    [M2M(typeof(GOST), typeof(PID))]
    public class GOST_to_PID : CommonEntity
    {
        public Guid GOST_ID { get; set; }
        public Guid PID_ID { get; set; }

        public virtual GOST GOST { get; set; }        
        public virtual PID PID { get; set; }
    }
}