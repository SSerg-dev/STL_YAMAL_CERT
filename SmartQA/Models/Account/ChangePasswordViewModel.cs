using System.ComponentModel.DataAnnotations;

namespace SmartQA.Models.Account
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}