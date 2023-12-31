﻿using SmartQA.DB;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartQA.Models
{
    public class DocumentNaksEdit : EntityForm<DocumentNaks>
    {
        [Required]
        public Guid? Person_ID { get; set; }
        
        public Guid? ParentDocumentNaks_ID { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime? IssueDate { get; set; }

        [Required]        
        public DateTime? ValidUntil { get; set; }
        
        public string Schifr { get; set; }

        [Required]
        public Guid? WeldType_ID { get; set; }
    
        [Required]
        public List<Guid> HIFGroup_IDs { get; set; }

        public override void Serialize(DocumentNaks dbModel, DataContext context)
        {
            dbModel.Person_ID = (Guid) Person_ID;
            dbModel.ParentDocumentNaks_ID = ParentDocumentNaks_ID;
            dbModel.Number = Number;
            dbModel.IssueDate = IssueDate;
            dbModel.ValidUntil = ValidUntil;
            dbModel.Schifr = Schifr;
            dbModel.WeldType_ID = (Guid) WeldType_ID;
            dbModel.HIFGroup_IDs = HIFGroup_IDs;
        }
    }
}
