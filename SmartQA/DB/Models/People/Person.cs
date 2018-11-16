using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.Edm;

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
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Display(Name="Фамилия")]
        [Required]
        public string LastName { get; set; }
        public string ShortName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }        

        public List<Employee> Employees { get; set; }

    }
}
