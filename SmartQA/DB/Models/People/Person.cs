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
    [Table("p_Person")]
    public class Person : CommonEntity
    {
        [Key]
        public Guid Person_ID { get; set; }

        [Required]
        public string Person_Code { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
