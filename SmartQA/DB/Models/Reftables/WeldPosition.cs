using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Положение при сварке")]
    [Table("p_WeldPosition")]
    public class WeldPosition : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid WeldPosition_ID { get; set; }
        [Required]
        public string WeldPosition_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => WeldPosition_Code; set => WeldPosition_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
