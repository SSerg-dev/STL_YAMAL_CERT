using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartQA.DB;

namespace SmartQA.Models
{
    public class DocumentNDTITEdit : EntityForm<DocumentNDTIT>
    {
        [Required]
        public Guid? DocumentNDT_ID { get; set; }

        // ---- basic columns -------------        

        [Required]
        public DateTime? ValidUntil { get; set; }

        // ---- foreign keys --------------

        public Guid InspectionTechnique_ID { get; set; }
        public Guid Level_ID { get; set; }

        public ICollection<Guid> InspectionSubject_IDs { get; set; }

        public DocumentNDTITEdit()
        {

        }

        public override void Serialize(DocumentNDTIT dbModel, DataContext context)
        {
            dbModel.DocumentNDT_ID = (Guid)DocumentNDT_ID;
            dbModel.ValidUntil = ValidUntil;
            dbModel.InspectionTechnique_ID = InspectionTechnique_ID;
            dbModel.Level_ID = Level_ID;
            dbModel.InspectionSubject_IDs = InspectionSubject_IDs;

        }

    }
}
