using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_WorkPackage")]
    public class WorkPackage
    {

        [StringLength(255)]
        public string WorkPackage_Code { get; set; }
        
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