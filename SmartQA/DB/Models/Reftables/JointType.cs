using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Тип соединения")]
    [Table("p_JointType")]
    public class JointType : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid JointType_ID { get; set; }
        [Required]
        public string JointType_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => JointType_Code; set => JointType_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
