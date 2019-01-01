using System;
using SmartQA.DB.Models.Documents;
using SmartQA.Models.Shared;

namespace SmartQA.Models
{
    public class DocumentNew : EntityForm<Document>
    {
        public Guid? Root_ID { get; set; }
        
        public override void Serialize(Document entity)
        {            
            entity.Root_ID = Root_ID ?? Guid.Empty;                             
        }
    }
    
    public class DocumentEdit : EntityForm<Document>
    {
        
    }
}