using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Вид соединения")]
    [Table("p_JointKind")]
    public class JointKind : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid JointKind_ID { get; set; }
        [Required]
        public string JointKind_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => JointKind_Code; set => JointKind_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
