using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaksAttest_to_DetailsType")]
    public class DocumentNaksAttest_to_DetailsType : M2MEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid DetailsType_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("DetailsType_ID")]
        public virtual DetailsType DetailsType { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_SeamsType")]
    public class DocumentNaksAttest_to_SeamsType : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid SeamsType_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("SeamsType_ID")]
        public virtual SeamsType SeamsType { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldMaterialGroup")]
    public class DocumentNaksAttest_to_WeldMaterialGroup : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldMaterialGroup_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldMaterialGroup_ID")]
        public virtual WeldMaterialGroup WeldMaterialGroup { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldMaterial")]
    public class DocumentNaksAttest_to_WeldMaterial : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldMaterial_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldMaterial_ID")]
        public virtual WeldMaterial WeldMaterial { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldPosition")]
    public class DocumentNaksAttest_to_WeldPosition : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldPosition_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldPosition_ID")]
        public virtual WeldPosition WeldPosition { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_JointKind")]
    public class DocumentNaksAttest_to_JointKind : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid JointKind_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("JointKind_ID")]
        public virtual JointKind JointKind { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldGOST14098")]
    public class DocumentNaksAttest_to_WeldGOST14098 : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldGOST14098_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldGOST14098_ID")]
        public virtual WeldGOST14098 WeldGOST14098 { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_JointType")]
    public class DocumentNaksAttest_to_JointType : M2MEntity
    {

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid JointType_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("JointType_ID")]
        public virtual JointType JointType { get; set; }
    }

}
