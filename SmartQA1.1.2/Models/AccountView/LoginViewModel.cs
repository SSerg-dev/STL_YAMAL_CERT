using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SmartQA1._1._2.Models.AccountView
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
    
}