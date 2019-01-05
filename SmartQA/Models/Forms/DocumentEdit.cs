using System;
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

        public override void Serialize(Document entity, DataContext context)
        {
            if (Status_ID != null && Status_ID != entity.Status_ID)
            {
                entity.Status_ID = Status_ID ?? Guid.Empty;
            }
        }
    }
}