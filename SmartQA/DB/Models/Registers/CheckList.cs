using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Registers
{
    public class CheckList 
    {
        [Column("CheckList_Code", TypeName = "varchar(255)")]
        public string Code { get; set; }
     
        // public DateTime? CheckList_Date {}
        
    }
}