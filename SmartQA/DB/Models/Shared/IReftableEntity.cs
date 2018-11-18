using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQA.DB.Models.Shared
{
    public interface IReftableEntity
    {
                        
        string Title { get; set; }
        
        string Description { get; set; }

    }
}
