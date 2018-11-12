using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NodaTime;
using SmartQA1._1._2.DB.PermissionDb;

namespace SmartQA1._1._2.Models.Permission.ViewModels
{
    public class DocumentForm_NaksAttest : DocumentFormModel<Document_NaksAttest>
    {

        [Display(Name="Степень автоматизации сварочного оборудования")]
        [DocumentFormField(choicesEntity: typeof(WeldingEquipmentAutomationLevel))]
        public Guid WeldingEquipmentAutomationLevel { get; set; }

        [Display(Name="Вид деталей")]
        [DocumentFormField(choicesEntity: typeof(DetailsType))]
        public ICollection<Guid> DetailsType { get; set; }

        [Display(Name="Типы швов")]
        [DocumentFormField(choicesEntity: typeof(SeamsType))]
        public ICollection<Guid> SeamsType { get; set; }

        [Display(Name="Тип соединения")]
        [DocumentFormField(choicesEntity: typeof(JointType))]
        public Guid JointType { get; set; }

        [Display(Name="Группа свариваемого материала")]
        [DocumentFormField(choicesEntity: typeof(WeldMaterialGroup))]
        public ICollection<Guid> WeldMaterialGroup { get; set; }

        [Display(Name="Сварочные материалы")]
        [DocumentFormField(choicesEntity: typeof(WeldMaterial))]
        public ICollection<Guid> WeldMaterial { get; set; }

        [Display(Name="Толщина деталей")]
        [DocumentFormField]
        public string DetailWidth { get; set; }

        [Display(Name="Наружный диаметр")]
        [DocumentFormField]
        public string OuterDiameter { get; set; }
        
        [Display(Name="Положение при сварке")]
        [DocumentFormField(choicesEntity: typeof(WeldPosition))]
        public ICollection<Guid> WeldPosition { get; set; }
        
        [Display(Name="Вид соединения")]
        [DocumentFormField(choicesEntity: typeof(JointKind))]
        public ICollection<Guid> JointKind { get; set; }

        [Display(Name = "Обозначение по ГОСТ 14098")]
        [DocumentFormField(choicesEntity: typeof(WeldGOST14098))]
        public Guid WeldGOST14098 { get; set; }

    }

}