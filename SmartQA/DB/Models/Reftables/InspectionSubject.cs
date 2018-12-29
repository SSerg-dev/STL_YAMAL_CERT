using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Объект контроля")]
    [Table("p_InspectionSubject")]
    public class InspectionSubject : CommonEntity, IReftableEntity
    {
        [Column("Parent_ID")]
        public System.Guid? Parent_ID { get; set; }
        
        [Required]
        [Column("Structure_Level")]
        public int Structure_Level { get; set; }
        
        [Required]
        [Column("InspectionSubject_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
