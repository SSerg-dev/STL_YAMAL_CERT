using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Shared;

namespace SmartQA.Models
{
    public class ReftableItem
    {        
        public string Title { get; set; }
        public string Description { get; set; }     
                
        public void Serialize(IReftableEntity dbModel)
        {
            dbModel.Title = Title ?? dbModel.Title;
            dbModel.Description = Description ?? dbModel.Description;
        }
    }

    
}
