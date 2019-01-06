using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaksAttest_to_DetailsType")]
    [M2M(typeof(DocumentNaksAttest), typeof(DetailsType))]
    public class DocumentNaksAttest_to_DetailsType : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid DetailsType_ID { get; set; }

        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }

        public virtual DetailsType DetailsType { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_SeamsType")]
    [M2M(typeof(DocumentNaksAttest), typeof(SeamsType))]
    public class DocumentNaksAttest_to_SeamsType : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid SeamsType_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual SeamsType SeamsType { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldMaterialGroup")]
    [M2M(typeof(DocumentNaksAttest), typeof(WeldMaterialGroup))]
    public class DocumentNaksAttest_to_WeldMaterialGroup : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldMaterialGroup_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual WeldMaterialGroup WeldMaterialGroup { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldMaterial")]
    [M2M(typeof(DocumentNaksAttest), typeof(WeldMaterial))]
    public class DocumentNaksAttest_to_WeldMaterial : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldMaterial_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual WeldMaterial WeldMaterial { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldPosition")]
    [M2M(typeof(DocumentNaksAttest), typeof(WeldPosition))]
    public class DocumentNaksAttest_to_WeldPosition : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldPosition_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual WeldPosition WeldPosition { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_JointKind")]
    [M2M(typeof(DocumentNaksAttest), typeof(JointKind))]
    public class DocumentNaksAttest_to_JointKind : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid JointKind_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual JointKind JointKind { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldGOST14098")]
    [M2M(typeof(DocumentNaksAttest), typeof(WeldGOST14098))]
    public class DocumentNaksAttest_to_WeldGOST14098 : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldGOST14098_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual WeldGOST14098 WeldGOST14098 { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_JointType")]
    [M2M(typeof(DocumentNaksAttest), typeof(JointType))]
    public class DocumentNaksAttest_to_JointType : CommonEntity
    {
        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid JointType_ID { get; set; }


        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }


        public virtual JointType JointType { get; set; }
    }
}