using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Группа технических устройств ОПО")]
    [Table("p_HIFGroup")]
    public class HIFGroup : CommonEntity, IReftableEntity
    {
        [Key]
        public Guid HIFGroup_ID { get; set; }

        [Required]
        public string HIFGroup_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => HIFGroup_Code; set => HIFGroup_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }

    }
}
