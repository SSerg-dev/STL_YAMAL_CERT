using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.Extensions.DependencyInjection;
using SmartQA.DB;
using SmartQA.DB.Models.Shared;

namespace SmartQA.Controllers.Reftables
{
    // https://www.strathweb.com/2018/04/generic-and-dynamically-generated-controllers-in-asp-net-core-mvc/

    public class ReftableControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(ReftableControllerFeatureProvider).Assembly;
            var candidates = currentAssembly.GetExportedTypes().Where(
                x => x.GetInterfaces().Contains(typeof(IReftableEntity))
            );
            AssemblyName assemblyName = new AssemblyName("MyDynamicAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder
                = assemblyBuilder.DefineDynamicModule("MyDynamicModule");

            foreach (var candidate in candidates)
            {
                TypeBuilder typeBuilder
                    = moduleBuilder.DefineType(
                        $"{candidate.Name}Controller",
                        TypeAttributes.Public
                        | TypeAttributes.Class
                        | TypeAttributes.AutoClass
                        | TypeAttributes.AnsiClass
                        | TypeAttributes.ExplicitLayout,
                        typeof(ReftableBaseController<>).MakeGenericType(candidate));

                ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
                    CallingConventions.Standard,
                    new Type[]
                    {
                        typeof(DataContext)

                    });
//                    );
//                constructorBuilder.
//
//                //   var controllerType = typeof(ReftableBaseController<>).MakeGenericType(candidate);
//
//                var ti = typeBuilder.CreateTypeInfo();
//                //controllerType.
//                //controllerType.Name = ;
//                feature.Controllers.Add(
//                    ti
//                    //controllerType.GetTypeInfo()
//                );
            }
        }    
    }

}
