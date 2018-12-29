using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_PID")]
    public class PID : CommonEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PID_ID")]
        public Guid ID { get; set; }
        
        [Required]
        [StringLength(255)]
        public string PID_Code { get; set; }
        
        [StringLength(255)]
        public string Description_Eng { get; set; }
 
    }
}