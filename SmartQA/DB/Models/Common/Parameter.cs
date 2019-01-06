using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Common
{
    [Table("p_Parameter")]
    public class Parameter : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string Parameter_Code { get; set; }

        [Required]
        [StringLength(1000)]
        public string Parameter_Value { get; set; }
        
        [StringLength(255)]
        public string Description_Rus { get; set; }
    }
}