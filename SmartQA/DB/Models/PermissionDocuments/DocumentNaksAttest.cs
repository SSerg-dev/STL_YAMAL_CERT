using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaksAttest")]
    public class DocumentNaksAttest : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_ID")]
        public Guid ID { get; set; }

        // ---- basic columns -------------

        public string DetailWidth { get; set; }        
        public string OuterDiameter { get; set; }
        public string SDR { get; set; }

        // ---- foreign keys --------------

        public Guid DocumentNaks_ID { get; set; }
        public Guid JointType_ID { get; set; }
        public Guid WeldingEquipmentAutomationLevel_ID { get; set; }
        public Guid WeldGOST14098_ID { get; set; }

        // ---- foreign key relations -----

        [ForeignKey("DocumentNaks_ID")]
        public virtual DocumentNaks DocumentNaks { get; set; }

        [ForeignKey("JointType_ID")]
        public virtual JointType JointType { get; set; }

        [ForeignKey("WeldingEquipmentAutomationLevel_ID")]
        public virtual WeldingEquipmentAutomationLevel WeldingEquipmentAutomationLevel { get; set; }

        [ForeignKey("WeldGOST14098_ID")]
        public virtual WeldGOST14098 WeldGOST14098 { get; set; }

        // ---- m2m relations -------------

        [InverseProperty("DocumentNaksAttest")]
        public virtual ICollection<DocumentNaksAttest_to_DetailsType> DocumentNaksAttest_to_DetailsTypeSet { get; set; }

        [NotMapped]
        public ICollection<Guid> DetailsType_IDs
        {
            get => this.GetM2MKeys(typeof(DetailsType));
            set => this.SetM2MKeys(typeof(DetailsType), value);
        }

        [InverseProperty("DocumentNaksAttest")]
        public virtual ICollection<DocumentNaksAttest_to_SeamsType> DocumentNaksAttest_to_SeamsTypeSet { get; set; }

        [NotMapped]
        public ICollection<Guid> SeamsType_IDs
        {
            get => this.GetM2MKeys(typeof(SeamsType));
            set => this.SetM2MKeys(typeof(SeamsType), value);
        }

        [InverseProperty("DocumentNaksAttest")]
        public virtual ICollection<DocumentNaksAttest_to_WeldMaterialGroup> DocumentNaksAttest_to_WeldMaterialGroupSet { get; set; }

        [NotMapped]
        public ICollection<Guid> WeldMaterialGroup_IDs
        {
            get => this.GetM2MKeys(typeof(WeldMaterialGroup));
            set => this.SetM2MKeys(typeof(WeldMaterialGroup), value);
        }

        [InverseProperty("DocumentNaksAttest")]
        public virtual ICollection<DocumentNaksAttest_to_WeldMaterial> DocumentNaksAttest_to_WeldMaterialSet { get; set; }

        [NotMapped]
        public ICollection<Guid> WeldMaterial_IDs
        {
            get => this.GetM2MKeys(typeof(WeldMaterial));
            set => this.SetM2MKeys(typeof(WeldMaterial), value);
        }

        [InverseProperty("DocumentNaksAttest")]
        public virtual ICollection<DocumentNaksAttest_to_WeldPosition> DocumentNaksAttest_to_WeldPositionSet { get; set; }

        [NotMapped]
        public ICollection<Guid> WeldPosition_IDs
        {
            get => this.GetM2MKeys(typeof(WeldPosition));
            set => this.SetM2MKeys(typeof(WeldPosition), value);
        }

        [InverseProperty("DocumentNaksAttest")]
        public virtual ICollection<DocumentNaksAttest_to_JointKind> DocumentNaksAttest_to_JointKindSet { get; set; }

        [NotMapped]
        public ICollection<Guid> JointKind_IDs
        {
            get => this.GetM2MKeys(typeof(JointKind));
            set => this.SetM2MKeys(typeof(JointKind), value);
        }



    }
}
