using System;
using System.ComponentModel.DataAnnotations;
using SmartQA.DB.Models.Documents;

namespace SmartQA.Models
{
    public class DocumentUI
    {
        [Key]
        public Guid ID { get; set; }       
        public string Document_Code { get; set; }
        public DateTimeOffset? Issue_Date { get; set; }
        
        public string Document_Number { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Document_Date { get; set; }
        
        public string Document_Name { get; set; }
        
        public bool IsActual { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Status Status { get; set; }

    }


}