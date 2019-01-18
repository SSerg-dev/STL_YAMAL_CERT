using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNDTIT_to_InspectionSubject")]
    [M2M(typeof(DocumentNDTIT), typeof(InspectionSubject))]
    public class DocumentNDTIT_to_InspectionSubject : CommonEntity
    {
        public Guid DocumentNDTIT_ID { get; set; }
        public Guid InspectionSubject_ID { get; set; }

        public virtual DocumentNDTIT DocumentNDTIT { get; set; }

        public virtual InspectionSubject InspectionSubject { get; set; }
    }
}
