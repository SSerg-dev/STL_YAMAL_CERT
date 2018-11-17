using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Вид деталей")]
    [Table("p_DetailsType")]
    public class DetailsType : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid DetailsType_ID { get; set; }
        [Required]
        public string DetailsType_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => DetailsType_Code; set => DetailsType_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
