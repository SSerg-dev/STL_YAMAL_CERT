using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models.Shared;

namespace SmartQA.Models
{
    public class DocumentNaksAttestEdit : EntityForm<DocumentNaksAttest>
    {
        [Required]
        public Guid? DocumentNaks_ID { get; set; }

        // ---- basic columns -------------

        [Required]
        public string DetailWidth { get; set; }
        [Required]
        public string OuterDiameter { get; set; }
        public string SDR { get; set; }

        // ---- foreign keys --------------
        [Required]
        public Guid? JointType_ID { get; set; }
        [Required]
        public Guid? WeldingEquipmentAutomationLevel_ID { get; set; }
        [Required]
        public Guid? WeldGOST14098_ID { get; set; }

        public ICollection<Guid> DetailsType_IDs { get; set; }
        public ICollection<Guid> SeamsType_IDs { get; set; }
        public ICollection<Guid> WeldMaterialGroup_IDs { get; set; }
        public ICollection<Guid> WeldMaterial_IDs { get; set; }        
        public ICollection<Guid> WeldPosition_IDs { get; set; }
        public ICollection<Guid> JointKind_IDs { get; set; }

        public DocumentNaksAttestEdit()
        {        
               
        }

        public override void Serialize(DocumentNaksAttest dbModel)
        {
            dbModel.DocumentNaks_ID                       = (Guid) DocumentNaks_ID                         ;
            dbModel.DetailWidth                           = DetailWidth                             ;
            dbModel.OuterDiameter                         = OuterDiameter                           ;
            dbModel.SDR                                   = SDR                                     ;
            dbModel.JointType_ID                          = (Guid) JointType_ID                            ;
            dbModel.WeldingEquipmentAutomationLevel_ID    = (Guid) WeldingEquipmentAutomationLevel_ID      ;
            dbModel.WeldGOST14098_ID                      = (Guid) WeldGOST14098_ID                        ;
            dbModel.DetailsType_IDs                       = DetailsType_IDs                         ;
            dbModel.SeamsType_IDs                         = SeamsType_IDs                           ;
            dbModel.WeldMaterialGroup_IDs                 = WeldMaterialGroup_IDs                   ;
            dbModel.WeldMaterial_IDs                      = WeldMaterial_IDs                        ;
            dbModel.WeldPosition_IDs                      = WeldPosition_IDs                        ;
            dbModel.JointKind_IDs = JointKind_IDs;


        }
    }
}
