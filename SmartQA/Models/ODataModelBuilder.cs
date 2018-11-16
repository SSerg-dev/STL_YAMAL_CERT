﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using SmartQA.DB.Models;

using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;
using SmartQA.Models.Forms;

namespace SmartQA.DB
{
    public class ODataModelBuilder
    {
        private StructuralTypeConfiguration<TEntityType> BuildCommon<TEntityType>(ODataConventionModelBuilder builder, string name=null) where TEntityType : CommonEntity
        {
            if (name == null) name = typeof(TEntityType).Name;

            var entitySet = (EntitySetConfiguration<TEntityType>)builder.GetType().GetMethod("EntitySet")
                .MakeGenericMethod(typeof(TEntityType))
                .Invoke(builder, new object[]{ name });            

            var conf = entitySet
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();  
        
            return conf;
        }

        private StructuralTypeConfiguration<TEntityType>
            BuildReftableEntity<TEntityType>(ODataConventionModelBuilder builder)
            where TEntityType : CommonEntity, IReftableEntity
        {
            var conf = BuildCommon<TEntityType>(builder);
            conf.Property(x => x.Description);
            conf.Property(x => x.Title);
            return conf;
        }


        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            BuildCommon<Employee>(builder);
            BuildCommon<Person>(builder);
            BuildCommon<Contragent>(builder);
            BuildCommon<Position>(builder);
            BuildCommon<DocumentNaks>(builder);

            BuildReftableEntity<HIFGroup>(builder);
            BuildReftableEntity<WeldType>(builder);

            builder.EntitySet<Reftable>(nameof(Reftable)).EntityType.Count().OrderBy().Page().Select();

            return builder.GetEdmModel();
        }
    }
}
