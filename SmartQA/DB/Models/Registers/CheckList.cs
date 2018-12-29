using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Registers
{
    public class CheckList : CommonEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CheckList_ID")]
        public Guid ID { get; set; }
        
        [Column("CheckList_Code", TypeName = "varchar(255)")]
        public string Code { get; set; }
     
        // public DateTime? CheckList_Date {}
        
    }
}