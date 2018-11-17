﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Сварочные материалы")]
    [Table("p_WeldMaterial")]
    public class WeldMaterial : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid WeldMaterial_ID { get; set; }
        [Required]
        public string WeldMaterial_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => WeldMaterial_Code; set => WeldMaterial_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
