using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Dictionaries;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaks")]
    public class DocumentNaks : CommonEntity
    {
        [Key]
        public Guid DocumentNaks_ID { get; set; }
                
        public Guid Person_ID { get; set; }
        
        [ForeignKey("Person_ID")]
        public Person Person;

        [Required]
        public string Number;

        [Column(TypeName = "Date")]
        public DateTime IssueDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ValidUntil { get; set; }

        [Required]
        public string Schifr { get; set; }

        public Guid WeldType_ID { get; set; }
    
        [ForeignKey("WeldType_ID")]
        public WeldType WeldType { get; set; }

        [InverseProperty("DocumentNaks")]
        public ICollection<DocumentNaks_to_HIFGroup> DocumentNaks_to_HIFGroupSet { get; set; }
    }
    
}
