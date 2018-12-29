using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_TitleObject")]
    public class TitleObject : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TitleObject_ID")]
        public Guid ID { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("TitleObject_Code")]
        public string Title { get; set; }
        
        public Guid? Parent_ID { get; set; }

        [Required]
        public int Structure { get; set; }
        
        [StringLength(300)]
        public string Description_Eng { get; set; }
        
        [StringLength(400)]
        [Column("Description_Rus")]
        public string Description { get; set; }
        
        [StringLength(100)]
        public string Phase_Name { get; set; }        
        
        [StringLength(50)]
        public string ReportColor { get; set; }
        
        public int? ReportOrder { get; set; }
        public float? Book1_Pct { get; set; }
        public float? Book1_Weight { get; set; }
        public float? Book2_Pct { get; set; }
        public float? Book2_Weight { get; set; }
        public float? Book3_Pct { get; set; }
        public float? Book3_Weight { get; set; }
        public float? Book4_Weight { get; set; }
        
        [StringLength(100)]
        public string TitleObject_for_ABDFinalSet { get; set; }
        
        [StringLength(10)]
        public string StageOfConstr  { get; set; }
        public float? Book1_Documents_Total { get; set; }
        public float? Book1_Documents_received { get; set; }
        public float? Book1_Progress { get; set; }
        public float? Book1_Documents_transmitted_to_CPY { get; set; }
        

    }
}