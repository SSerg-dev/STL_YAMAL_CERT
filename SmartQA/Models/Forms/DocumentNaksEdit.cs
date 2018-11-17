using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;

namespace SmartQA.Models
{
    public class DocumentNaksEdit
    {
        [Required]
        public Guid? Person_ID { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime? IssueDate { get; set; }

        [Required]        
        public DateTime? ValidUntil { get; set; }

        [Required]
        public string Schifr { get; set; }

        [Required]
        public Guid? WeldType_ID { get; set; }
    
        [Required]
        public List<Guid> HIFGroup_IDs { get; set; }

        public DocumentNaksEdit()
        {

        }

        public void Serialize(DataContext context, DocumentNaks dbModel)
        {            
            dbModel.Number = Number;
            dbModel.IssueDate = IssueDate;
            dbModel.ValidUntil = ValidUntil;
            dbModel.Schifr = Schifr;
            dbModel.WeldType_ID = (Guid) WeldType_ID;
            dbModel.HIFGroup_IDs = HIFGroup_IDs;
        }


    }
}
