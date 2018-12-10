using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartQA.Models
{
    public class DocumentNaksAttestEdit : EntityForm<DocumentNaksAttest>
    {
        [Required]
        public Guid? DocumentNaks_ID { get; set; }

        // ---- basic columns -------------
        public string WeldingWire { get; set; }
        public string ShieldingGasFlux { get; set; }
        public string WeldPositionCustom { get; set; }
        [Required]
        public string DetailWidth { get; set; }
        [Required]
        public string OuterDiameter { get; set; }
        public string SDR { get; set; }

        // ---- foreign keys --------------
        //[Required]
        //public Guid? JointType_ID { get; set; }
        [Required]
        public Guid? WeldingEquipmentAutomationLevel_ID { get; set; }
        //[Required]
        //public Guid? WeldGOST14098_ID { get; set; }

        public ICollection<Guid> DetailsType_IDs { get; set; }
        public ICollection<Guid> SeamsType_IDs { get; set; }
        public ICollection<Guid> WeldMaterialGroup_IDs { get; set; }
        public ICollection<Guid> WeldMaterial_IDs { get; set; }        
        public ICollection<Guid> WeldPosition_IDs { get; set; }
        public ICollection<Guid> JointKind_IDs { get; set; }
        public ICollection<Guid> WeldGOST14098_IDs { get; set; }
        public ICollection<Guid> JointType_IDs { get; set; }

        public DocumentNaksAttestEdit()
        {        
               
        }

        public override void Serialize(DocumentNaksAttest dbModel)
        {
            dbModel.DocumentNaks_ID                       = (Guid) DocumentNaks_ID                          ;
            dbModel.WeldingWire                           = WeldingWire                                     ;  
            dbModel.ShieldingGasFlux                      = ShieldingGasFlux                                ;
            dbModel.DetailWidth                           = DetailWidth                                     ;
            dbModel.OuterDiameter                         = OuterDiameter                                   ;
            dbModel.SDR                                   = SDR                                             ;
            dbModel.JointType_IDs                         = JointType_IDs                                   ;
            dbModel.WeldingEquipmentAutomationLevel_ID    = (Guid) WeldingEquipmentAutomationLevel_ID       ;
            dbModel.WeldGOST14098_IDs                     = WeldGOST14098_IDs                               ;
            dbModel.DetailsType_IDs                       = DetailsType_IDs                                 ;
            dbModel.SeamsType_IDs                         = SeamsType_IDs                                   ;
            dbModel.WeldMaterialGroup_IDs                 = WeldMaterialGroup_IDs                           ;
            dbModel.WeldMaterial_IDs                      = WeldMaterial_IDs                                ;
            dbModel.WeldPosition_IDs                      = WeldPosition_IDs                                ;
            dbModel.WeldPositionCustom = WeldPositionCustom;
            dbModel.JointKind_IDs = JointKind_IDs;


        }
    }
}
