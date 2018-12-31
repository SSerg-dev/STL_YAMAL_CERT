using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaksAttest")]
    public class DocumentNaksAttest : CommonEntity
    {
        // ---- basic columns -------------

        public string DetailWidth { get; set; }        
        public string OuterDiameter { get; set; }
        public string WeldingWire { get; set; }
        public string ShieldingGasFlux { get; set; }
        public string SDR { get; set; }
        public string WeldPositionCustom { get; set; }

        // ---- foreign keys --------------

        public Guid DocumentNaks_ID { get; set; }
        public Guid WeldingEquipmentAutomationLevel_ID { get; set; }

        // ---- foreign key relations -----
        
        public virtual DocumentNaks DocumentNaks { get; set; }
        public virtual WeldingEquipmentAutomationLevel WeldingEquipmentAutomationLevel { get; set; }

        // ---- m2m relations -------------

        public virtual ICollection<DocumentNaksAttest_to_DetailsType> DocumentNaksAttest_to_DetailsTypeSet { get; set; }

        [NotMapped]
        public ICollection<DetailsType> DetailsTypeSet => this.GetM2MObjects<DetailsType>();
        [NotMapped]
        public ICollection<Guid> DetailsType_IDs
        {
            get => this.GetM2MKeys<DetailsType>();
            set => this.SetM2MKeys<DetailsType>( value);
        }

        public virtual ICollection<DocumentNaksAttest_to_SeamsType> DocumentNaksAttest_to_SeamsTypeSet { get; set; }
        [NotMapped]
        public ICollection<SeamsType> SeamsTypeSet => this.GetM2MObjects<SeamsType>();
        [NotMapped]
        public ICollection<Guid> SeamsType_IDs
        {
            get => this.GetM2MKeys<SeamsType>();
            set => this.SetM2MKeys<SeamsType>( value);
        }

        public virtual ICollection<DocumentNaksAttest_to_WeldMaterialGroup> DocumentNaksAttest_to_WeldMaterialGroupSet { get; set; }
        [NotMapped]
        public ICollection<WeldMaterialGroup> WeldMaterialGroupSet => this.GetM2MObjects<WeldMaterialGroup>();
        [NotMapped]
        public ICollection<Guid> WeldMaterialGroup_IDs
        {
            get => this.GetM2MKeys<WeldMaterialGroup>();
            set => this.SetM2MKeys<WeldMaterialGroup>( value);
        }

        public virtual ICollection<DocumentNaksAttest_to_WeldMaterial> DocumentNaksAttest_to_WeldMaterialSet { get; set; }
        [NotMapped]
        public ICollection<WeldMaterial> WeldMaterialSet => this.GetM2MObjects<WeldMaterial>();
        [NotMapped]
        public ICollection<Guid> WeldMaterial_IDs
        {
            get => this.GetM2MKeys<WeldMaterial>();
            set => this.SetM2MKeys<WeldMaterial>( value);
        }

        public virtual ICollection<DocumentNaksAttest_to_WeldPosition> DocumentNaksAttest_to_WeldPositionSet { get; set; }
        [NotMapped]
        public ICollection<WeldPosition> WeldPositionSet => this.GetM2MObjects<WeldPosition>();
        [NotMapped]
        public ICollection<Guid> WeldPosition_IDs
        {
            get => this.GetM2MKeys<WeldPosition>();
            set => this.SetM2MKeys<WeldPosition>( value);
        }

        public virtual ICollection<DocumentNaksAttest_to_JointKind> DocumentNaksAttest_to_JointKindSet { get; set; }
        [NotMapped]
        public ICollection<JointKind> JointKindSet => this.GetM2MObjects<JointKind>();
        [NotMapped]
        public ICollection<Guid> JointKind_IDs
        {
            get => this.GetM2MKeys<JointKind>();
            set => this.SetM2MKeys<JointKind>( value);
        }

        public virtual ICollection<DocumentNaksAttest_to_WeldGOST14098> DocumentNaksAttest_to_WeldGOST14098Set { get; set; }
        [NotMapped]
        public ICollection<WeldGOST14098> WeldGOST14098Set => this.GetM2MObjects<WeldGOST14098>();
        [NotMapped]
        public ICollection<Guid> WeldGOST14098_IDs
        {
            get => this.GetM2MKeys<WeldGOST14098>();
            set => this.SetM2MKeys<WeldGOST14098>( value);
        }
        
        public virtual ICollection<DocumentNaksAttest_to_JointType> DocumentNaksAttest_to_JointTypeSet { get; set; }
        [NotMapped]
        public ICollection<JointType> JointTypeSet => this.GetM2MObjects<JointType>();
        [NotMapped]
        public ICollection<Guid> JointType_IDs
        {
            get => this.GetM2MKeys<JointType>();
            set => this.SetM2MKeys<JointType>(value);
        }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DocumentNaksAttest>()
                .HasOne(x => x.DocumentNaks)
                .WithMany(x => x.DocumentNaksAttestSet)
                .HasForeignKey(x => x.DocumentNaks_ID)
                .OnDelete(DeleteBehavior.Restrict);
               
            modelBuilder.Entity<DocumentNaksAttest>()
                .HasOne(x => x.WeldingEquipmentAutomationLevel)
                .WithMany()
                .HasForeignKey(x => x.WeldingEquipmentAutomationLevel_ID)
                .OnDelete(DeleteBehavior.Restrict);
                 
        }

    }
}
