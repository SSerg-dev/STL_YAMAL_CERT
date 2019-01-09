using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.Models.Shared;

namespace SmartQA.Models.Forms
{
    public class DocumentAttachmentEdit : EntityForm<DocumentAttachment>
    {
        public string Description { get; set; }

        public override void Serialize(DocumentAttachment entity, DataContext context)
        {
            entity.Description = Description;
        }
    }
}