using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using DevExpress.XtraPrinting.Native;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Models.Permission.DocumentTypes;


namespace SmartQA1._1._2.DB.PermissionDb
{
    public partial class Document_NaksAttest
    {
        [EAVDocumentAttr("Степень автоматизации сварочного оборудования", relatedEntity: typeof(WeldingEquipmentAutomationLevel))]
        public WeldingEquipmentAutomationLevel WeldingEquipmentAutomationLevel { get; set; }

        [EAVDocumentAttr("Вид деталей", multipleValues: true, relatedEntity: typeof(DetailsType))]
        public ICollection<DetailsType> DetailsType { get; set; }

        [EAVDocumentAttr("Типы швов", multipleValues: true, relatedEntity: typeof(SeamsType))]
        public ICollection<SeamsType> SeamsType { get; set; }

        [EAVDocumentAttr("Тип соединения", relatedEntity: typeof(JointType))]
        public JointType JointType { get; set; }

        [EAVDocumentAttr("Группа свариваемого материала", multipleValues: true, relatedEntity: typeof(WeldMaterialGroup))]
        public ICollection<WeldMaterialGroup> WeldMaterialGroup { get; set; }

        [EAVDocumentAttr("Сварочные материалы", multipleValues: true, relatedEntity: typeof(WeldMaterial))]
        public ICollection<WeldMaterial> WeldMaterial { get; set; }

        [EAVDocumentAttr("Толщина деталей")]
        public int DetailWidth { get; set; }

        [EAVDocumentAttr("Наружный диаметр")]
        public int OuterDiameter { get; set; }

        [EAVDocumentAttr("SDR")]
        public string SDR { get; set; }

        [EAVDocumentAttr("Положение при сварке", multipleValues: true, relatedEntity: typeof(WeldPosition))]
        public ICollection<WeldPosition> WeldPosition { get; set; }

        [EAVDocumentAttr("Вид соединения", multipleValues: true, relatedEntity: typeof(JointKind))]
        public ICollection<JointKind> JointKind { get; set; }

        [EAVDocumentAttr("Обозначение по ГОСТ 14098", relatedEntity: typeof(WeldGOST14098))]
        public WeldGOST14098 WeldGOST14098 { get; set; }

    }
}