using System;
using System.Collections.Generic;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.Models.Shared;

namespace SmartQA.Models
{
    public class DocumentNew : EntityForm<Document>
    {
        public Guid? Root_ID { get; set; }
        public Guid? Status_ID { get; set; }
        
        public override void Serialize(Document entity, DataContext context)
        {            
            entity.Root_ID = Root_ID ?? Guid.Empty;
                                                    
        }
    }
    
    public class DocumentEdit : EntityForm<Document>
    {
        public Guid? Status_ID { get; set; }
        public string Document_Number { get; set; }
        public DateTime? Document_Date { get; set; }
        public Guid? DocumentType_ID { get; set; }
        public string Document_Name { get; set; }
        public int? TotalSheets { get; set; }
        public Guid? Resp_Employee_ID { get; set; }
        
        public ICollection<Guid> GOST_IDs { get; set; }
        public ICollection<Guid> PID_IDs { get; set; }
        
        public override void Serialize(Document entity, DataContext context)
        {
            if (Status_ID != null && Status_ID != entity.Status_ID)
            {
                entity.Status_ID = Status_ID ?? Guid.Empty;
            }

            entity.Document_Number = Document_Number;
            entity.Document_Date = Document_Date;
            
            if (DocumentType_ID != null) entity.DocumentType_ID = (Guid) DocumentType_ID;

            entity.Resp_Employee_ID = Resp_Employee_ID;
            entity.TotalSheets = TotalSheets;
            entity.Document_Name = Document_Name;
            entity.GOST_IDs = GOST_IDs;
            entity.PID_IDs = PID_IDs;

        }
    }
}