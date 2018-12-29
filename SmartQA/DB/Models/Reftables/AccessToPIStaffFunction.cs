﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Допуск к работе в электроустановках в качестве")]
    [Table("p_AccessToPIStaffFunction")]
    public class AccessToPIStaffFunction : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AccessToPIStaffFunction_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("AccessToPIStaffFunction_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }

}
