using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.People;
using SmartQA.Models.Shared;
using SmartQA.Util;

namespace SmartQA.Models
{
    public class AppUserEdit: EntityForm<AppUser>
    {
        public Guid? AppUser_ID { get; set; }

        public class EmployeeID
        {
            public Guid? ID { get; set; }   
        }
        
        [Required]
        public string AppUser_Code { get; set; }
        public string User_Password { get; set; }
        public List<Guid> Role_IDs { get; set; }
        public Guid? Employee_ID { get; set; }
        public EmployeeID Employee { get; set; }
        
        public override void Serialize(AppUser entity, DataContext _context)
        {
            entity.AppUser_Code = AppUser_Code;
            entity.Role_IDs = Role_IDs;
            
            var newEmployee = Employee?.ID == null ? null : _context.Set<Employee>().Find(Employee.ID);
            if (entity.Employee != null && newEmployee?.ID != entity.Employee.ID)
            {
                entity.Employee.AppUser_ID = null;                
            }

            entity.Employee = newEmployee;
            
            if (!string.IsNullOrEmpty(User_Password))
            {
                entity.User_Password = new Encryptor3DES(ApplicationUser.passKey).encrypt(
                    Encoding.UTF8.GetBytes(User_Password)
                );
            }             
        }
    }
}