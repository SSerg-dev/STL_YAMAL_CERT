using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Auth;

namespace SmartQA.DB.Models.PermissionDocuments
{
}
//    [Table("p_DocumentNaks")]
//    public class DocumentNaks
//    {
//        [Key]
//        public System.Guid Position_ID { get; set; }
//        [Required]
//        public string Position_Code { get; set; }
//
//        public int RowStatus { get; set; }
//        public DateTime Insert_DTS { get; set; }
//        public DateTime Update_DTS { get; set; }
//        public System.Guid Created_User_ID { get; set; }
//        public System.Guid Modified_User_ID { get; set; }
//
//        public System.Guid Person_ID { get; set; }
//
//        public string Description_Eng;
//        public string Description_Rus;
//
//        [ForeignKey("Created_User_ID")]
//        public AppUser Created_User;
//        [ForeignKey("Modified_User_ID")]
//        public AppUser Modified_User;
//
//        [ForeignKey("Person_ID")]
//        public Person Person;
//
//    }
//}
