using SmartQA.DB;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartQA.Models
{
    public class DocumentNDTEdit : EntityForm<DocumentNDT>
    {
        [Required]
        public Guid? Person_ID { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime? IssueDate { get; set; }

        [Required]
        public string OrganizationPublishedNDT { get; set; }

        public override void Serialize(DocumentNDT dbModel, DataContext context)
        {
            dbModel.Person_ID = (Guid)Person_ID;            
            dbModel.Number = Number;
            dbModel.IssueDate = IssueDate;            
            dbModel.OrganizationPublishedNDT = OrganizationPublishedNDT;            
        }

    }
}
