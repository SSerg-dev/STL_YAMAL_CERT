using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
 {
     [Table("p_GOST_to_PID")]
     public class GOST_to_PID : M2MEntity
     {
         public Guid GOST_ID { get; set; }
         public Guid PID_ID { get; set; }
 
         [ForeignKey("GOST_ID")]
         public virtual GOST GOST { get; set; }
         [ForeignKey("PID_ID")]
         public virtual PID PID { get; set; }
     }
 }