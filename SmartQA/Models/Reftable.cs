using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using SmartQA.DB;
using SmartQA.DB.Models.Shared;

namespace SmartQA.Models.Forms
{
    public class Reftable
    {
        public string Title { get; set; }
        [Key]
        public string ModelName { get; set; }

        public static IEnumerable<Type> GetReftableTypes(DbContext context)
            => context.Model.GetEntityTypes()
                .Select(t => t.ClrType)
                .Where(t => t.GetInterfaces().Contains(typeof(IReftableEntity)));                           

        public static IEnumerable<Reftable> GetList(DbContext context)
        {
            return GetReftableTypes(context).Select(t => new Reftable()
                {
                    ModelName = t.Name,
                    Title =
                        (t.GetCustomAttributes(true).SingleOrDefault(a => a is DisplayAttribute) as
                            DisplayAttribute)?.Name ?? t.Name
                });

        }
    }
}
