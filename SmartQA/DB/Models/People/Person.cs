using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.People
{
    [Table("p_Person")]
    public class Person : CommonEntity
    {
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
        public virtual DateTime? BirthDate { get; set; }        

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
