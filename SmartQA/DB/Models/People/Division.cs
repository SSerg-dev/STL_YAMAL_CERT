using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.People
{
    [Table("p_Division")]
    public class Division : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public System.Guid Division_ID { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Division_Code { get; set; }

        public System.Guid? Contragent_ID { get; set; }

        [StringLength(255)]
        public string Division_Name { get; set; }        
        
        [ForeignKey("Contragent_ID")]
        public virtual Contragent Contragent { get; set; }
    }
}
