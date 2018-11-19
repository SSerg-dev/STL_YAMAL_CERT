﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaksAttest_to_DetailsType")]
    public class DocumentNaksAttest_to_DetailsType : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_to_DetailsType_ID")]
        public Guid ID { get; set; }

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid DetailsType_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("DetailsType_ID")]
        public virtual DetailsType DetailsType { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_SeamsType")]
    public class DocumentNaksAttest_to_SeamsType : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_to_SeamsType_ID")]
        public Guid ID { get; set; }

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid SeamsType_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("SeamsType_ID")]
        public virtual SeamsType SeamsType { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldMaterialGroup")]
    public class DocumentNaksAttest_to_WeldMaterialGroup : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_to_WeldMaterialGroup_ID")]
        public Guid ID { get; set; }

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldMaterialGroup_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldMaterialGroup_ID")]
        public virtual WeldMaterialGroup WeldMaterialGroup { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldMaterial")]
    public class DocumentNaksAttest_to_WeldMaterial : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_to_WeldMaterial_ID")]
        public Guid ID { get; set; }

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldMaterial_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldMaterial_ID")]
        public virtual WeldMaterial WeldMaterial { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_WeldPosition")]
    public class DocumentNaksAttest_to_WeldPosition : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_to_WeldPosition_ID")]
        public Guid ID { get; set; }

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid WeldPosition_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("WeldPosition_ID")]
        public virtual WeldPosition WeldPosition { get; set; }
    }

    [Table("p_DocumentNaksAttest_to_JointKind")]
    public class DocumentNaksAttest_to_JointKind : CommonEntity
    {
        [Key]
        [Column("DocumentNaksAttest_to_JointKind_ID")]
        public Guid ID { get; set; }

        public Guid DocumentNaksAttest_ID { get; set; }
        public Guid JointKind_ID { get; set; }

        [ForeignKey("DocumentNaksAttest_ID")]
        public virtual DocumentNaksAttest DocumentNaksAttest { get; set; }
        [ForeignKey("JointKind_ID")]
        public virtual JointKind JointKind { get; set; }
    }



}