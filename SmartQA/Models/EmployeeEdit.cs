using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.People;

namespace SmartQA.Models
{
    public class EmployeeEdit
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTimeOffset? BirthDate { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public Guid? Position_ID { get; set; }

        [Required]
        [Display(Name = "Организация")]
        public Guid? Contragent_ID { get; set; }

        public EmployeeEdit()
        {

        }

        public EmployeeEdit(Employee dbModel)
        {
            if (dbModel == null || dbModel.Person_ID == Guid.Empty) return;

            FirstName = dbModel.Person.FirstName;
            SecondName = dbModel.Person.SecondName;
            LastName = dbModel.Person.LastName;
            BirthDate = DateTime.SpecifyKind((DateTime) dbModel.Person.BirthDate, DateTimeKind.Utc);
            Position_ID = dbModel.Position_ID;
            Contragent_ID = dbModel.Contragent_ID;
        }

        public void Serialize(Employee dbModel)
        {

            dbModel.Person.FirstName = FirstName;
            dbModel.Person.SecondName = SecondName;
            dbModel.Person.LastName = LastName;
            dbModel.Person.BirthDate = BirthDate?.DateTime;
            dbModel.Position_ID = (Guid)Position_ID;
            dbModel.Contragent_ID = Contragent_ID;
        }


    }
}
