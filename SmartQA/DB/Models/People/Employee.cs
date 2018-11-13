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
        public Guid? Position_Id { get; set; }
        public Guid? AppUser_Id { get; set; }
        public Guid? Contragent_ID { get; set; }

        [ForeignKey("Person_ID")]
        public Person Person { get; set; }
        [ForeignKey("AppUser_Id")]
        public AppUser AppUser { get; set; }
    }
}
