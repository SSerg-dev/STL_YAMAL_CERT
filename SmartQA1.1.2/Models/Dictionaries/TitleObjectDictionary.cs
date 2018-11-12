using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SmartQA1._1._2.DB;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Service;
using System.Data.Entity;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Models.Login;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.Models.Dictionaries
{
    //CLASS
    public class TitleObjectListDictionary
    {
        public IEnumerable<TitleObjectDictionary> fill()
        {
            using (var context = new Entities())
            {
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<UI_TitleObject, TitleObjectDictionary>()
                    .ForMember(x => x.newOrder, opt => opt.Ignore())
                    );
                IMapper mapper = config.CreateMapper();

                var titlesAll = context.UI_TitleObject
                    .Where(x => x.Row_Status < 100)
                    .OrderBy(x => x.ReportOrder)
                    .ToList()
                    .Select(x => mapper.Map<UI_TitleObject, TitleObjectDictionary>(x))
                    .ToList();

                //getting the level of hierarchy of every TitleObject and placing them into the List
                var titlesFlattened = new List<TitleObjectDictionary>();

                //retrieve highest in hierarchy titles:
                var parentTitles = titlesAll.Where(x => x.TitleObject_PARENTID == null).ToList();
                foreach (var parent in parentTitles) selectChildTitles(parent); //calling the recursion tree for every parent TitleObject

                //recursion tree walk-around with a side effect on list 'titlesFlattened'
                void selectChildTitles(TitleObjectDictionary title)
                {
                    titlesFlattened.Add(title);

                    var childNodes = titlesAll.Where(x => x.TitleObject_PARENTID == title.TitleObject_ID);

                    //also children inherit ReportColor of their parents:
                    foreach (var child in childNodes) child.ReportColor = title.ReportColor;

                    foreach (var child in childNodes) selectChildTitles(child);
                }
                return titlesFlattened;
            }
        }
    }
    //CLASS
    public class TitleObjectDictionary
    {
        public System.Guid? TitleObject_ID { get; set; }
        public Nullable<System.Guid> TitleObject_PARENTID { get; set; }
        public string Structure { get; set; }
        public string TitleObject_Name { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }
        public string Phase_Name { get; set; }
        public string ReportColor { get; set; }
        public Nullable<int> ReportOrder { get; set; }
        public Nullable<double> GLB_Weight { get; set; }
        public Nullable<double> Book1_Pct { get; set; }
        public Nullable<double> Book1_Weight { get; set; }
        public Nullable<double> Book2_Pct { get; set; }
        public Nullable<double> Book2_Weight { get; set; }
        public Nullable<double> Book3_Pct { get; set; }
        public Nullable<double> Book3_Weight { get; set; }
        public Nullable<double> Book4_Weight { get; set; }
        public string TitleObject_for_ABDFinalSet { get; set; }
        public string StageOfConstr { get; set; }
        public Nullable<int> Row_Status { get; set; }

        private IMapper mapper = null;
        private IResult<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();
        private StoredProcedureAdapter spAdapter;
        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        //to prevent all unecessary updates
        private bool shouldBeUpdated = false;

        /*mirror field used to retrieve data from the FrontEnd - just to map Json, 
        the used to get the ReportOrder of the preceeding element */
        public Guid? newOrder { get; set; }

        public IResult<MsgIdPair> Save()
        {
            //escape from null title
            if (TitleObject_ID==null) return null;

            using (var context = new Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spAdapter = new StoredProcedureAdapter(context);

                        //INHERITANCE:
                        //retrieving parent object to fill up overwrite fields that are inherited from the parent object:
                        if (TitleObject_PARENTID != null)
                        {
                            var parent = getTitleObjectDictionaryById(TitleObject_PARENTID, context);
                            int _temp = 0;
                            if (int.TryParse(parent.Structure, out _temp))
                            {
                                Structure = (_temp + 1).ToString();
                            }
                            //that will be a critical error in db interaction - unable to convert this field into the integer type
                            else
                            {
                                var ex = new DatabaseStateException(
                                    $"Invalid Structure for: TitleObject_ID: {parent.TitleObject_ID.Value.ToString()}");
                                new Logger(ex).Log();
                            }
                            ReportColor = parent.ReportColor;
                        }
                        else
                        {
                            Structure = "1";
                        }
                        //START ENUMERATION - recursive walk round all nodes
                        //retrieve all titles except the required one:
                        var allTitles = (new TitleObjectListDictionary()).fill()
                            .Where(x => x.TitleObject_ID != TitleObject_ID)
                            .ToList();

                        //ALSO the TitleObject N/A must me the last in report order
                        var naTitle = getNaTitleObject(context);
                        if (naTitle != null)
                        {
                            naTitle.ReportOrder = allTitles.Count + 2;
                            naTitle.update(spAdapter, result);
                            allTitles = allTitles.Where(x => x.TitleObject_ID != naTitle.TitleObject_ID).ToList();
                        }
                        //create root node to this list so highest in hierarchy nodes will also have parent:
                        var root = new TitleObjectDictionary();

                        int index = 0;
                        enumerateNodeAndItsChildren(root);

                        void enumerateNodeAndItsChildren(TitleObjectDictionary _title)
                        {
                            //first, I, as a node, enumerate myself and decide where I should be updated:
                            if (_title.ReportOrder != index)
                            {
                                _title.ReportOrder = index;
                                _title.shouldBeUpdated = true;
                            }
                            index++;

                            //than I ask to enumerate my children
                            var children = allTitles.Where(x => x.TitleObject_PARENTID == _title.TitleObject_ID);

                            //Parent node: If I have the required node in my children, I'll be more attentive:
                            //...place it first if needed:
                            if (TitleObject_PARENTID == _title.TitleObject_ID && newOrder == Guid.Empty)
                            {
                                enumerateNodeAndItsChildren(this);
                                index++;
                            }
                            foreach (var child in children) enumerateNodeAndItsChildren(child);
                            //...place it last in the group if no ReportOrder is selected
                            if (TitleObject_PARENTID == _title.TitleObject_ID && newOrder == null)
                            {
                                newOrder = children.Last().TitleObject_ID;
                                enumerateNodeAndItsChildren(this);
                                index++;
                            }
                            //if I'm the node that the required node is wanted to be placed after - I invite it for enumeration
                            if (_title.TitleObject_ID == newOrder) enumerateNodeAndItsChildren(this);
                        }

                        //after enumeration save the result to the DB:
                        var titleExcluded = allTitles.Where(x => x.TitleObject_ID != TitleObject_ID).Where(x => x.shouldBeUpdated).ToList();
                        foreach (var _title in titleExcluded)
                        {
                            _title.update(spAdapter, result);
                        }

                        //FINISH ENUMERATION
                        if (TitleObject_ID == null)
                        {
                            create(spAdapter, result);
                        }
                        else update(spAdapter, result);

                        result.AddParentId();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
        public IResult<MsgIdPair> Delete()
        {
            using (var context = new Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spAdapter = new StoredProcedureAdapter(context);
                        spAdapter.ExecuteStoredProcedure
                        (
                            result,
                            "dbo",
                            "TitleObject_Delete",
                            UserId.ToString(),
                            TitleObject_ID.ToString()
                        );
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
        public IResult<T> update<T>(StoredProcedureAdapter spa, IResult<T> result) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "TitleObject_Update",
                TitleObject_ID.ToString(),
                "0",
                UserId.ToString(),
                TitleObject_Name,
                TitleObject_PARENTID.HasValue ? TitleObject_PARENTID.ToString() : null,
                Structure,
                Description_Eng,
                Description_Rus,
                Phase_Name,
                ReportColor,
                ReportOrder.HasValue ? ReportOrder.ToString() : null,
                GLB_Weight.HasValue ? GLB_Weight.ToString() : null,
                Book1_Pct.HasValue ? Book1_Pct.ToString() : null,
                Book1_Weight.HasValue ? Book1_Weight.ToString() : null,
                Book2_Pct.HasValue ? Book2_Pct.ToString() : null,
                Book2_Weight.HasValue ? Book2_Weight.ToString() : null,
                Book3_Pct.HasValue ? Book3_Pct.ToString() : null,
                Book3_Weight.HasValue ? Book3_Weight.ToString() : null,
                Book4_Weight.HasValue ? Book4_Weight.ToString() : null,
                TitleObject_for_ABDFinalSet,
                null, //Book1_Documents_Total
                null, //Book1_Documents_Received
                null, //Book1_Progress
                null, //Book1_Documents_transmitted_to_CPYParameter
                StageOfConstr
            );
        }
        public IResult<T> create<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "TitleObject_Insert",
                UserId.ToString(),
                "0",
                TitleObject_Name,
                TitleObject_PARENTID.HasValue ? TitleObject_PARENTID.ToString() : null,
                Structure,
                Description_Eng,
                Description_Rus,
                Phase_Name,
                ReportColor,
                ReportOrder.HasValue?ReportOrder.ToString():null,
                GLB_Weight.HasValue? GLB_Weight.ToString():null,
                Book1_Pct.HasValue ? Book1_Pct.ToString() : null,
                Book1_Weight.HasValue ? Book1_Weight.ToString() : null,
                Book2_Pct.HasValue ? Book2_Pct.ToString():null,
                Book2_Weight.HasValue? Book2_Weight.ToString():null,
                Book3_Pct.HasValue? Book3_Pct.ToString():null,
                Book3_Weight.HasValue? Book3_Weight.ToString(): null,
                Book4_Weight.HasValue? Book4_Weight.ToString(): null,
                TitleObject_for_ABDFinalSet,
                null, //Book1_Documents_Total
                null, //Book1_Documents_Received
                null, //Book1_Progress
                null, //Book1_Documents_transmitted_to_CPYParameter
                StageOfConstr
            );
        }
        
        public TitleObjectDictionary getTitleObjectDictionaryById(Guid? TitleObject_ID, Entities context)
        {
            return context.UI_TitleObject
                        .Where(x => x.TitleObject_ID == TitleObject_ID)
                        .ToList()
                        .Select(x => mapper.Map<UI_TitleObject, TitleObjectDictionary>(x))
                        .FirstOrDefault();
        }
        public TitleObjectDictionary getNaTitleObject(Entities context)
        {
            var naTitle =  context.UI_TitleObject
                        .Where(x => x.TitleObject_Name == "N/A")
                        .ToList()
                        .Select(x => mapper.Map<UI_TitleObject, TitleObjectDictionary>(x))
                        .FirstOrDefault();
            if (naTitle == null)
            {
                var ex = new ArgumentNullException("No NA entity found in TitleObject dictionary");
                new Logger(ex).Log();
            }
            return naTitle;
        }
    }
}