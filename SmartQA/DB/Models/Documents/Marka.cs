using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Marka")]
    
    public class Marka : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Marka_ID")]
        public Guid ID { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("Marka_Code")]
        public string Title { get; set; }
        
        [StringLength(255)]
        public string Marka_Code_Eng { get; set; }

        [StringLength(255)]
        public string Description_Eng { get; set; }
        
        [StringLength(255)]
        [Column("Description_Rus")]
        public string Description { get; set; }
        
        [StringLength(255)]
        public string Engineering_Drawing_Type_Eng { get; set; }
        
        [StringLength(255)]
        public string Engineering_Drawing_Type_Rus { get; set; }
        
        public bool? IsUsedInMatrix { get; set; }
        
        public bool? IsPriority { get; set; }
        
        [StringLength(255)]
        public string ReportColor { get; set; }

        public int? ReportOrder { get; set; }

    }
}