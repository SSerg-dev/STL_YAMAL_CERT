using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Status")]
    public class Status : CommonEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Status_ID")]
        public Guid ID { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Status_Code { get; set; }
        
        [Required]
        [StringLength(255)]
        public string StatusEntity { get; set; }
 
        [Required]
        public bool EntityLocked { get; set; }
        
        [StringLength(255)]
        public string Description_Eng { get; set; }

        [StringLength(255)]
        public string Description_Rus { get; set; }
        
        [StringLength(255)]
        public bool ReportColor { get; set; }

        public int ReportOrder { get; set; }

    }
}