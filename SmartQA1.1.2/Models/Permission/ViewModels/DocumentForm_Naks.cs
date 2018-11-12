using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NodaTime;
using SmartQA1._1._2.DB.PermissionDb;

namespace SmartQA1._1._2.Models.Permission.ViewModels
{
    public class DocumentForm_NAKS : DocumentFormModel<Document_Naks>
    {        
        [Required]
        [Display(Name = "Номер")]
        [DocumentFormField]
        public string Document_Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        [DocumentFormField]
        public DateTime? Document_Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия")]
        [DateDocumentFormField]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Шифр клейма")]
        [DocumentFormField]
        public string Schifr { get; set; }

        [Required]
        [Display(Name = "Вид (способ) сварки (наплавки)")]
        [DocumentFormField(choicesEntity: typeof(WeldType))]
        public Guid WeldType { get; set; }

        [Required]
        [Display(Name = "Группы технических устройств ОПО")]
        [DocumentFormField(choicesEntity: typeof(HIFGroup))]
        public ICollection<Guid> HIFGroup { get; set; } = new List<Guid>();

    }
}