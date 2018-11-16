using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using SmartQA.DB.Models.Shared;

namespace SmartQA.Models.Forms
{
    public class Reftable
    {
        public string Title { get; set; }
        [Key]
        public string ModelName { get; set; }

        public static IEnumerable<Reftable> GetList(DbContext context)
        {
            return context.Model.GetEntityTypes()
                .Where(t => t.ClrType.GetInterfaces().Contains(typeof(IReftableEntity)))
                .Select(t => new Reftable()
                {
                    ModelName = t.ClrType.Name,
                    Title =
                        (t.ClrType.GetCustomAttributes(true).SingleOrDefault(a => a is DisplayAttribute) as
                            DisplayAttribute)?.Name ?? t.ClrType.Name
                });

        }
    }
}
