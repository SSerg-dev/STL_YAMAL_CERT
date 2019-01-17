using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Registers
{
    [Table("p_WorkPackage")]
    public class WorkPackage : CommonEntity, IReftableEntity
    {
        [Required]
        [StringLength(255)]
        [Column("WorkPackage_Code")]
        public string Title { get; set; }

        [StringLength(255)]
        [Column("Description_Rus")]
        public string Description { get; set; }

        [StringLength(100)]
        public string SiteRussiaYard { get; set; }
        
        [StringLength(100)]
        public string LocationOfWork { get; set; }
        
        [StringLength(1000)]
        public string ScopeOfWork { get; set; }
        
        [StringLength(1000)]
        public string AreaOfWork { get; set; }

    }
}