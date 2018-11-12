using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Models.Login;
using AutoMapper;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Service;
using static SmartQA1._1._2.Service.ModelStateSerializer;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.Models.Permission
{
    public class EmployeeEdit
    {
        public Guid? Employee_ID { get; set; }

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
        public DateTime? BirthDate { get; set; }

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
            if (dbModel == null || dbModel.Person_Id == Guid.Empty) return;

            Employee_ID = dbModel.Employee_ID;
            FirstName = dbModel.Person.FirstName;
            SecondName = dbModel.Person.SecondName;
            LastName = dbModel.Person.LastName;
            BirthDate = dbModel.Person.BirthDate;
            Position_ID = dbModel.Position_Id;
            Contragent_ID = dbModel.Contragent_ID;
        }

        public void Serialize(Employee dbModel)
        {
            if (dbModel.Person_Id == Guid.Empty)
            {
                dbModel.Person = new Person();
            }
            dbModel.Person.FirstName = FirstName;
            dbModel.Person.SecondName = SecondName;
            dbModel.Person.LastName = LastName;
            dbModel.Person.BirthDate = BirthDate;
            dbModel.Position_Id = (Guid) Position_ID;
            dbModel.Contragent_ID = Contragent_ID;
        }
    }

}