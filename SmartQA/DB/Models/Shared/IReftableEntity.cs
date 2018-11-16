using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQA.DB.Models.Shared
{
    public interface IReftableEntity
    {
                
        [NotMapped]
        string Title { get; set; }

        [NotMapped]
        string Description { get; set; }

    }
}
