using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using DevExpress.XtraPrinting.Native;
using NodaTime;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Models.Permission.DocumentTypes;


namespace SmartQA1._1._2.DB.PermissionDb
{   
    public partial class Document_Naks
    {
        
        [DataType(DataType.Date)]
        [EAVDocumentAttr("Срок действия")]
        public LocalDate? EndDate { get; set; }
         
        [EAVDocumentAttr("Шифр клейма")]
        public string Schifr { get; set; }
        
        [EAVDocumentAttr("Вид сварки", relatedEntity: typeof(WeldType))]        
        public WeldType WeldType { get; set; }
        
        [EAVDocumentAttr("Группы технических устройств ОПО", multipleValues: true, relatedEntity: typeof(HIFGroup))]
        public ICollection<HIFGroup> HIFGroup { get; set; } = new List<HIFGroup>();
    }
}