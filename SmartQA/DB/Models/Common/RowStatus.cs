using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Common
{
    [Table("p_RowStatus")]
    public class RowStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Column("RowStatus_ID")]
        public int ID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Status_Name_Eng { get; set; }        
        
        [Required]
        [StringLength(100)]
        public string Status_Name_Rus { get; set; } 
        
        [StringLength(255)]
        public string Description_Eng { get; set; }

        [StringLength(255)]
        public string Description_Rus { get; set; }
    }
}