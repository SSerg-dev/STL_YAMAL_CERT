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
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Models.Login;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.Models.Dictionaries
{
    //CLASS
    public class MarkaListDictionary
    {
        public IEnumerable<MarkaDictionary> fill()
        {
            using(var context = new Entities())
            {
                var config = new MapperConfiguration(cfg => 
                    cfg.CreateMap<UI_Marka, MarkaDictionary>()
                    .ForMember(x=>x.newOrder, opt=>opt.Ignore())
                    );
                IMapper mapper = config.CreateMapper();

                return context.UI_Marka
                    .Where(x=>x.Row_Status< 100)
                    .OrderBy(x => x.ReportOrder)
                    .ToList()
                    .Select(x => mapper.Map<UI_Marka, MarkaDictionary>(x))
                    .ToList();
            }
        }
    }
    //CLASS
    public class MarkaDictionary
    {
        public Guid? Marka_ID { get; set; }
        public string Marka_Name { get; set; }
        public string Code_of_mark { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }
        public string Engineering_Drawing_Type_Eng { get; set; }
        public string Engineering_Drawing_Type_Rus { get; set; }
        public Nullable<bool> IsUsedInMatrix { get; set; }
        public Nullable<bool> IsPriority { get; set; }
        public string ReportColor { get; set; }
        public Nullable<int> ReportOrder { get; set; }
        public Nullable<int> Row_Status { get; set; }
        /*mirror field used to retrieve data from the FrontEnd - just to map Json, 
        the used to get the ReportOrder of the preceeding element */
        public Guid? newOrder { get; set; }

        private IMapper mapper = null;
        private IResult<MsgIdPair> result;
        private StoredProcedureAdapter spAdapter;
        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        public MarkaDictionary()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
                        cfg.CreateMap<UI_Marka, MarkaDictionary>()
                        .ForMember(x => x.newOrder, opt => opt.Ignore())
                    );
            mapper = config.CreateMapper();
            result = new MultipleSetsResultIdError<MsgIdPair>();
        }
        public IResult<MsgIdPair> Save()
        {
            //escape from empty marka
            if (Marka_ID == null) return null;

            using (var context = new Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spAdapter = new StoredProcedureAdapter(context);

                        //START ENUMERATION:
                        int index = 1;

                        //the value ReportOrder will be set in accordance with newOrder field coming from FE
                        ReportOrder = null;

                        //if the marka is wanted to become first it has empty guid in newOrder
                        if (newOrder == Guid.Empty)
                        {
                            ReportOrder = index;
                        }
                        var naMarka = getNaMarka(context);

                        //retrieving all Markas except the one being updated or created and except N/A marka

                        List<MarkaDictionary> markaList = (new MarkaListDictionary())
                            .fill()
                            .Where(x => x.Marka_ID != Marka_ID)
                            .Where(x => x.Marka_ID != naMarka.Marka_ID)
                            .ToList();

                        foreach (var m in markaList)
                        {
                            if (m.Marka_ID == newOrder) ReportOrder = index+1;
                            if (index == ReportOrder) index++; //save place for the marka that is being created or updated

                            if (m.ReportOrder != index) //no need to call procedure of updating if element already has the right value
                            {
                                m.ReportOrder = index;
                                m.update(spAdapter, result);
                                if (!result.isValid) return result;
                            }
                            index++;
                        }
                        //place marka with null ReportOrder last in order
                        if (ReportOrder == null) ReportOrder = index;
                        //FINISH ENUMERATION

                        //logical fork - if we need to create or update Marka
                        if (Marka_ID == null)
                        {
                            this.create(spAdapter, result); //this - for clarity when reading
                        }
                        else this.update(spAdapter, result);

                        result.AddParentId();

                        //place N/A marka last in order
                        //2=1+1: other 1 stands for marka that's being updated/created
                        naMarka.ReportOrder = markaList.Count + 2;
                        naMarka.update(spAdapter, result);

                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        return result;
                    }
                    finally //finally block is operated before any return statement
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
        public IResult<MsgIdPair> Delete()
        {
            //escape from null marka:
            if (Marka_ID == null) return null;

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
                            "Marka_Delete",
                            UserId.ToString(),
                            Marka_ID.ToString()
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
        private IResult<T> create<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "Marka_Insert",
                "0",
                UserId.ToString(),
                Marka_Name,
                Code_of_mark,
                Description_Eng,
                Description_Rus,
                Engineering_Drawing_Type_Eng,
                Engineering_Drawing_Type_Rus,
                IsUsedInMatrix.HasValue ? IsUsedInMatrix.ToString() : null,
                IsPriority.HasValue ? IsPriority.ToString() : null,
                ReportColor,
                ReportOrder.ToString()
            );
        }
        private IResult<T> update<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T:IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "Marka_Update",
                Marka_ID.ToString(),
                "0",
                UserId.ToString(),
                Marka_Name,
                Code_of_mark,
                Description_Eng,
                Description_Rus,
                Engineering_Drawing_Type_Eng,
                Engineering_Drawing_Type_Rus,
                IsUsedInMatrix.HasValue ? IsUsedInMatrix.ToString() : null,
                IsPriority.HasValue ? IsPriority.ToString() : null,
                ReportColor,
                ReportOrder.ToString()
            );
        }
        public MarkaDictionary getMarkaDictionaryById(Guid? Marka_ID, Entities context)
        {
            return context.UI_Marka
                .Where(x => x.Marka_ID == Marka_ID)
                .ToList()
                .Select(x => mapper.Map<UI_Marka, MarkaDictionary>(x))
                .FirstOrDefault();
        }
        public MarkaDictionary getNaMarka(Entities context)
        {
            var naMarka =  context.UI_Marka
                .Where(x => x.Marka_Name == "N/A")
                .ToList()
                .Select(x => mapper.Map<UI_Marka, MarkaDictionary>(x))
                .FirstOrDefault();

            if (naMarka == null)
            {
                var ex = new ArgumentNullException("NA object is not found in Marka dictionary.");
                new Logger(ex).Log();
            }

            return naMarka;
        }
    }
}