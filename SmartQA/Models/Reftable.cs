using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SmartQA.DB.Models.Shared;

namespace SmartQA.Models.Forms
{
    public class Reftable
    {
        public string Title { get; set; }
        [Key]
        public string ModelName { get; set; }

        public static IEnumerable<Type> GetReftableTypes()
        {
            var currentAssembly = typeof(Reftable).Assembly;
            return currentAssembly.GetExportedTypes().Where(
                x => x.GetInterfaces().Contains(typeof(IReftableEntity))
            );
        }                      

        public static IEnumerable<Reftable> GetList()
        {
            return GetReftableTypes().Select(t => new Reftable()
                {
                    ModelName = t.Name,
                    Title =
                        (t.GetCustomAttributes(true).SingleOrDefault(a => a is DisplayAttribute) as
                            DisplayAttribute)?.Name ?? t.Name
                });

        }
    }
}
