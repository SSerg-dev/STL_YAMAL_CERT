using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DelegateDecompiler;
using DelegateDecompiler.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models;
using SmartQA.Models.API;
using SmartQA.Util;

namespace SmartQA.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class NaksReportController : Controller
    {
        protected readonly AppUserManager _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly AppSettings _appSettings;
        protected readonly DataContext _context;

        public NaksReportController(DataContext context,
            AppUserManager userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        private class BadFilterException : Exception
        {
            public BadFilterException(string message) : base(message)
            {
            }
        }

        public IQueryable<DocumentNaks> BaseQuery()
        {
            return _context.Set<DocumentNaks>()
                .Include(x => x.WeldType)
                .Include(x => x.DocumentNaks_to_HIFGroupSet)
                .ThenInclude(y => y.HIFGroup)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(x => x.WeldingEquipmentAutomationLevel)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_DetailsTypeSet)
                .ThenInclude(z => z.DetailsType)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_JointKindSet)
                .ThenInclude(z => z.JointKind)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_SeamsTypeSet)
                .ThenInclude(z => z.SeamsType)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_WeldMaterialGroupSet)
                .ThenInclude(z => z.WeldMaterialGroup)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_WeldMaterialSet)
                .ThenInclude(z => z.WeldMaterial)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_WeldPositionSet)
                .ThenInclude(z => z.WeldPosition)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_WeldGOST14098Set)
                .ThenInclude(z => z.WeldGOST14098)
                .Include(x => x.DocumentNaksAttestSet)
                .ThenInclude(y => y.DocumentNaksAttest_to_JointTypeSet)
                .ThenInclude(z => z.JointType)
                .Include(n => n.Person)
                .ThenInclude(p => p.Employees)
                .ThenInclude(e => e.Contragent)
                .Include(n => n.Person)
                .ThenInclude(p => p.Employees)
                .ThenInclude(e => e.Position)                
                .OrderBy(x => x.Person.LastName);
        }
                                      
        [Computed]        
        public static bool IsValid(DocumentNaks naks)
            => naks.ValidUntil < DateTime.Today;

        [Computed]        
        public static string Person_FullName(DocumentNaks naks)
            => naks.Person.FullName;
        
        [Computed]        
        public static long Person_BirthYear(DocumentNaks naks)
            => ((DateTime)naks.Person.BirthDate).Year;
        
        
        /// <summary>
        /// Given propertyName, e.g. "IsValid",
        /// try to find a lambda expression for that property 
        /// like "x => x.IsValid" or "x => x.IsValid()" or "x => IsValid(x)". 
        /// Replaces . in propertyName with _, so "Person.FullName" becomes "Person_FullName"
        /// </summary>
        /// <param name="propertyName">Name of property in request</param>
        /// <typeparam name="T">Type of entity that is an argument to expression (x)</typeparam>
        /// <returns>Lambda expression that computes the property value</returns>
        public LambdaExpression GetPropertyExpression<T>(string propertyName)
        {
            propertyName = propertyName.Replace(".", "_");
            
            // try to find property on T class
            var property = typeof(T).GetProperty(propertyName);
            if (property != null && PredicateBuilder.PropertyTypesSupported.Contains(
                    Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType
                    ))
            {
                // create lambda x => x.PropertyName
                var argParam = Expression.Parameter(typeof(T), "x");
                return Expression.Lambda(Expression.Property(argParam, propertyName), argParam);
            }

            // try to find method on DocumentNaks class            
            var method = typeof(DocumentNaks).GetMethod(propertyName, new Type[] { })
                         // ..or try to find method on this class
                         ?? GetType().GetMethod(propertyName, new[] {typeof(DocumentNaks)});
            
            if (method != null)
            {
                // create lambda x => x.PropertyName()
                var argParam = Expression.Parameter(typeof(T), "x");
                return Expression.Lambda(Expression.Call(method, argParam), argParam);
            }

            return null;
        }

        public Expression<Func<DocumentNaks, bool>> MakeFilterClause(IList<object> filter)
        {
            var field = (string) filter[0];
            var operator_ = (string) filter[1];
            var value = filter[2];

            // handle filter on a property or method
            var propertyExpr = GetPropertyExpression<DocumentNaks>(field);
            if (propertyExpr != null)
            {
                try
                {
                    return PredicateBuilder.MakePropertyFilterExprTyped(
                        typeof(DocumentNaks), propertyExpr.ReturnType,
                        propertyExpr, operator_, value);
                }
                catch (PredicateBuilder.OperationNotSupported e)
                {
                    throw new BadFilterException(e.Message);
                }
            }

            switch (field)
            {
                case "Person.Organization":
                    return n => n.Person.Employees.Any(e => e.Contragent_ID == Guid.Parse((string) value));
                case "WeldType":
                    return n => n.WeldType_ID == Guid.Parse((string) value);
                case "HIFGroup":
                    return n => n.DocumentNaks_to_HIFGroupSet.Any(
                        x => x.HIFGroup_ID == Guid.Parse((string) value)
                    );
                case "DetailsType":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_DetailsTypeSet
                            .Any(x => x.DetailsType_ID == Guid.Parse((string) value)));
                case "SeamsType":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_SeamsTypeSet
                            .Any(x => x.SeamsType_ID == Guid.Parse((string) value)));
                case "JointType":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_JointTypeSet
                            .Any(x => x.JointType_ID == Guid.Parse((string) value)));
                case "WeldMaterialGroup":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_WeldMaterialGroupSet
                            .Any(x => x.WeldMaterialGroup_ID == Guid.Parse((string) value)));
                case "WeldMaterial":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_WeldMaterialSet
                            .Any(x => x.WeldMaterial_ID == Guid.Parse((string) value)));
                case "WeldPosition":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_WeldPositionSet
                            .Any(x => x.WeldPosition_ID == Guid.Parse((string) value)));
                case "JointKind":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_JointKindSet
                            .Any(x => x.JointKind_ID == Guid.Parse((string) value)));
                case "WeldGOST14098":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.DocumentNaksAttest_to_WeldGOST14098Set
                            .Any(x => x.WeldGOST14098_ID == Guid.Parse((string) value)));
                case "WeldingEquipmentAutomationLevel":
                    return n => n.DocumentNaksAttestSet
                        .Any(na => na.WeldingEquipmentAutomationLevel_ID == Guid.Parse((string) value));
            }

            throw new BadFilterException($"Unsupported filter: {filter}");
        }

        public Expression<Func<DocumentNaks, bool>> MakeFilterPredicate(IList filter)
        {                       
            var parts = filter.Cast<object>()
                .Select(x => x is JArray array ? array.ToList() : x is JValue v ? v.Value : x).ToList();

            if (parts.Count == 0)
            {
                return PredicateBuilder.True<DocumentNaks>();
            }
            
            if (parts.All(x => !(x is IList)))
            {
                return MakeFilterClause(parts);
            }

            if (parts.Count == 2 && parts[0] is string s && s == "!")
            {
                var p = MakeFilterPredicate(parts[1] as IList);
                return Expression.Lambda<Func<DocumentNaks, bool>>(
                    Expression.Not(p.Body), p.Parameters);
            }             

            string operation = null;
            var predicate = default(Expression<Func<DocumentNaks, bool>>);

            foreach (var  f in parts)
            {
                switch (f)
                {
                    case string fString:
                        operation = fString;
                        break;
                    case IList fList:
                    {
                        var filterPredicate = MakeFilterPredicate(fList);
                        switch (operation)
                        {
                            case "and":
                                predicate = predicate.And(filterPredicate);
                                break;
                            case "or":
                                predicate = predicate.Or(filterPredicate);
                                break;
                            default:
                                predicate = filterPredicate;
                                break;
                        }

                        break;
                    }
                }
            }

            return predicate;
        }

        public IQueryable<DocumentNaks> ApplyFilter(IQueryable<DocumentNaks> query, IList filter)
        {
            var predicate = MakeFilterPredicate(filter);
            return query.Where(predicate);
        }

        
        public IQueryable<NaksUI> ApplySelect(IQueryable<DocumentNaks> query)
        {
           
            return query                    
                .SelectMany(x => x.DocumentNaksAttestSet.DefaultIfEmpty(),
                    (naks, attest) => new NaksUI
                    {
                        ID = attest == null ? naks.ID : attest.ID,
                        DocumentNaks_ID = naks.ID,
                        ParentDocumentNaks_ID = naks.ParentDocumentNaks_ID,
                        DocumentNaksAttest_ID = attest == null ? (Guid?) null : attest.ID,
                        Person = new NaksPersonUI
                        {
                            ID = naks.Person_ID,
                            LastName = naks.Person.LastName,
                            FirstName = naks.Person.FirstName,
                            SecondName = naks.Person.SecondName,
                            BirthDate = naks.Person.BirthDate,
                            BirthYear = Person_BirthYear(naks),
                            FullName = Person_FullName(naks),
                            Organization = naks.Person.Employees.OrderBy(e => e.ID).Select(x => x.Contragent.Title)
                                .FirstOrDefault(),
                            Organization_Description = naks.Person.Employees.OrderBy(e => e.ID)
                                .Select(x => x.Contragent.Title).FirstOrDefault(),
                            Position = naks.Person.Employees.OrderBy(e => e.ID).FirstOrDefault().Position.Title,
                        },

                        Number = naks.Number,
                        Schifr = naks.Schifr,
                        WeldType = naks.WeldType.Title,
                        HIFGroup = attest.DocumentNaks.DocumentNaks_to_HIFGroupSet.Select(x => x.HIFGroup.Title).OrderBy(x => x).ToList(),
                        IssueDate = naks.IssueDate,
                        ValidUntil = naks.ValidUntil,
                        IsValid = IsValid(naks),

                        DetailsType = attest == null
                            ? (IEnumerable<string>) new string[] { }
                            : attest.DocumentNaksAttest_to_DetailsTypeSet.Select(x => x.DetailsType.Title).OrderBy(x => x).ToList(),
                        DetailWidth = attest == null ? null : attest.DetailWidth,
                        JointKind = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_JointKindSet.Select(x => x.JointKind.Title).OrderBy(x => x).ToList(),
                        JointType = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_JointTypeSet.Select(x => x.JointType.Title).OrderBy(x => x).ToList(),
                        OuterDiameter = attest == null ? (IEnumerable) new string[] { } : attest.OuterDiameter,
                        SeamsType = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_SeamsTypeSet.Select(x => x.SeamsType.Title).OrderBy(x => x).ToList(),
                        SDR = attest == null ? null : attest.SDR,
                        ShieldingGasFlux = attest == null ? (IEnumerable) new string[] { } : attest.ShieldingGasFlux,
                        WeldingWire = attest == null ? null : attest.WeldingWire,
                        WeldMaterial = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_WeldMaterialSet.Select(x => x.WeldMaterial.Title).OrderBy(x => x).ToList(),
                        WeldPosition = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_WeldPositionSet.Select(x => x.WeldPosition.Title).OrderBy(x => x).ToList(),
                        WeldMaterialGroup = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_WeldMaterialGroupSet.Select(x => x.WeldMaterialGroup.Title)
                                .ToList(),
                        WeldPositionCustom = attest == null ? null : attest.WeldPositionCustom,
                        WeldingEquipmentAutomationLevel =
                            attest == null ? null : attest.WeldingEquipmentAutomationLevel.Title,
                        WeldGOST14098 = attest == null
                            ? (IEnumerable) new string[] { }
                            : attest.DocumentNaksAttest_to_WeldGOST14098Set.Select(x => x.WeldGOST14098.Title).OrderBy(x => x).ToList(),
                    }).DecompileAsync();
        }


        public IQueryable<NaksUI> GetQuery(QueryOptions q)
        {
            var queryNaks = BaseQuery();

            if (q.filter != null)
            {
                queryNaks = ApplyFilter(queryNaks, q.filter);
            }

            var queryResult = ApplySelect(queryNaks);

            return queryResult;
        }

        [HttpPost]
        public async Task<IActionResult> GetData([FromBody] QueryOptions q)
        {
            IQueryable<NaksUI> fullQuery;
            try
            {
                fullQuery = GetQuery(q);
            }
            catch (BadFilterException e)
            {
                return BadRequest(e.Message);
            }

            var query = fullQuery;

            if (q.skip != null) query = query.Skip((int) q.skip);
            if (q.take != null) query = query.Take((int) q.take);

            var result = new Dictionary<string, object>
            {
                ["data"] = await query.ToListAsync()
            };

            if (q.requireTotalCount ?? false)
            {
                result["totalCount"] = await fullQuery.CountAsync();
            }

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> TotalCount([FromBody] QueryOptions q)
        {
            var query = GetQuery(q);
            return new JsonResult(await query.CountAsync());
        }
       
    }
}