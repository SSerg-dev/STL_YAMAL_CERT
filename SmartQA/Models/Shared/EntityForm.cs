using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB;

namespace SmartQA.Models.Shared
{
    public class EntityForm<TEntity>
    {

        public virtual void Serialize(TEntity entity, DataContext context)
        {

        }
    }
}
