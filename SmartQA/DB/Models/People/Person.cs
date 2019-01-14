using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Castle.Core.Internal;
using SmartQA.DB.Models.PermissionDocuments;
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

        [NotMapped]
        public string FullName 
            => string.Join(" ", new[] {LastName, FirstName, SecondName}.Where(x => !x.IsNullOrEmpty()));

        [Required]
        [Column(TypeName = "Date")]
        public virtual DateTime? BirthDate { get; set; }        

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<DocumentNaks> DocumentNaksSet { get; set; }
    }
}
