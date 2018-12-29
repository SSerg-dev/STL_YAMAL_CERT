using System.ComponentModel.DataAnnotations;
using SmartQA.DB.Models.Shared;

namespace SmartQA.Models
{
    public class ReftableItem
    {        
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }     
                
        public void Serialize(IReftableEntity dbModel)
        {
            dbModel.Title = Title ?? dbModel.Title;
            dbModel.Description = Description ?? dbModel.Description;
        }
    }

    
}
