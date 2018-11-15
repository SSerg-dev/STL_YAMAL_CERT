using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.People
{  
    [Table("p_Employee")]
    public class Employee : CommonEntity
    {
        [Key]
        public System.Guid Employee_ID { get; set; }

        [Required]
        public string Employee_Code { get; set; }
        
        public System.Guid Person_ID { get; set; }
        [Column("Position_Id")]
        public Guid? Position_ID { get; set; }
        [Column("AppUser_Id")]
        public Guid? AppUser_ID { get; set; }
        public Guid? Contragent_ID { get; set; }

        [ForeignKey("Person_ID")]
        public Person Person { get; set; }
        [ForeignKey("AppUser_ID")]
        public AppUser AppUser { get; set; }
        [ForeignKey("Contragent_ID")]
        public Contragent Contragent { get; set; }
        [ForeignKey("Position_ID")]
        public Position Position { get; set; }
    }
}
