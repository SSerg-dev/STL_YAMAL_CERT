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
using System.Diagnostics;
using SmartQA1._1._2.Models.Login;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.Models.Dictionaries
{
    public class IsoListDictionary
    {
        public int resultsFound { get; set; }
        public IEnumerable<IsoDictionary> isoList { get; set; }

        private IMapper mapper;
        public IsoListDictionary()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UI_ISO, IsoDictionary>());
            mapper = config.CreateMapper();
        }
        public void fill(List<Filter> inputFilters)
        {
            resultsFound = 0;
            isoList = null;

            if (inputFilters != null && inputFilters.Count() > 0)
            {
                using (var context = new Entities())
                {
                    // 1 step
                    var isoIDQuery = context.UI_ISO.Where(x => x.Row_status < 100 && (x.Line_Row_status < 100 || x.Line_Row_status==null)).OrderBy(x => x.ISO_Number);

                    // 3-4 step
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    // 5-6-7 step
                    //retrieving the whole list of Line_ID that will satisfy our criterea (wanted Lines)
                    var _isoID = queryFactory.concatenateFilters(isoIDQuery)
                        .Select(x => x.ISO_ID)
                        .ToList()
                        .Distinct()
                        .ToList();

                    // 8 step
                    resultsFound = _isoID.Count();

                    // 9 step
                    //skipping and taking:
                    List<Guid> _linesIDSkipped = queryFactory.ApplyRowNumFilter(_isoID);

                    // 10 step
                    //retrieving all other information about the Isos which ID's are in the list of wanted ones
                    var isos = (
                        from member
                        in context.UI_ISO
                        where _linesIDSkipped.Contains(member.ISO_ID)
                        select member
                    ).OrderBy(x => x.ISO_Number)
                    .ToList();

                    // 11 step
                    isos = queryFactory.ApplyOrderByFilter(isos);

                    // 12 step
                    isoList = isos.Select(x => mapper.Map<UI_ISO, IsoDictionary>(x));
                }
            }
        }
        public IsoDictionary getIsoById(Guid? isoId)
        {
            using (var context = new Entities())
            {
                return mapper.Map<UI_ISO, IsoDictionary>(
                    context.UI_ISO
                    .Where(x => x.ISO_ID == isoId)
                    .FirstOrDefault());
            }
        }
        public void getIsosByLine(Guid? lineGuid)
        {
            using (var context = new Entities())
            {
                isoList = context.UI_ISO
                    .Where(x => x.Row_status < 100)
                    .Where(x=>x.Line_ID == lineGuid)
                    .OrderBy(x => x.ISO_Number)
                    .ToList()
                    .Select(x => mapper.Map<UI_ISO, IsoDictionary>(x))
                    .ToList();
                resultsFound = isoList.Count();
            }
        }
    }
    public class IsoDictionary
    {
        public Guid? ISO_ID { get; set; }
        public string ISO_Number { get; set; }
        public Nullable<System.Guid> Marka_ID { get; set; }
        public string Marka_Name { get; set; }
        public Nullable<System.Guid> TitleObject_ID { get; set; }
        public string TitleObject_Name { get; set; }
        public Nullable<System.Guid> DesignAreaType_ID { get; set; }
        public string DesignAreaType_Name { get; set; }
        public Nullable<System.Guid> ProcessPhase_ID { get; set; }
        public string ProcessPhase_Name { get; set; }
        public Nullable<System.Guid> Line_ID { get; set; }
        public string Line_Number { get; set; }
        public Nullable<int> Row_status { get; set; }
        public Nullable<System.Guid> Phase_ID { get; set; }
        public string Phase_Name { get; set; }
        public Nullable<int> Line_Row_status { get; set; }

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        private IMapper mapper;
        private IResult<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();

        public IsoDictionary()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UI_ISO, IsoDictionary>());
            mapper = config.CreateMapper();
        }
        public IResult<MsgIdPair> Save()
        {
            if (UserId == null)
            {
                result.AddException(new ArgumentNullException("UserIdentity instance hasn't been initialized"));
                return result;
            }
            if (Line_Number != null)
            {
                using (var context = new Entities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            //retrieve Line ID by name:
                            if (Line_ID == null)
                            {
                                var line = (new LineListDictionary()).getLineByNumber(Line_Number);
                                if (line == null) {
                                    result.AddError("No line exists with that number");
                                    return result;
                                }
                                Line_ID = line.Line_ID;
                            }

                            StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);

                            //here comes the embrachment - where to CREATE or UPDATE the model:
                            //CREATE
                            if (ISO_ID == null)
                            {
                                spAdapter.ExecuteStoredProcedure
                                (
                                    result,
                                    "dbo",
                                    "ISO_Insert",
                                    "0",
                                    UserId.ToString(),
                                    ISO_Number.ToString(),
                                    Line_ID .ToString(),
                                    Phase_ID != null ? Phase_ID.ToString() : null,
                                    Marka_ID != null ? Marka_ID.ToString() : null,
                                    TitleObject_ID != null ? TitleObject_ID.ToString() : null,
                                    DesignAreaType_ID != null ? DesignAreaType_ID.ToString() : null,
                                    ProcessPhase_ID != null ? ProcessPhase_ID.ToString() : null
                                );
                                result.AddParentId(); //this value will be returned to FE to update the whole edit window
                                return result;
                            }
                            //UDATE
                            else
                            {
                                spAdapter.ExecuteStoredProcedure
                                (
                                    result,
                                    "dbo",
                                    "ISO_Update",
                                    ISO_ID,
                                    "0",
                                    UserId.ToString(),
                                    ISO_Number.ToString(),
                                    Line_ID.ToString(),
                                    Phase_ID != null ? Phase_ID.ToString() : null,
                                    Marka_ID != null ? Marka_ID.ToString() : null,
                                    TitleObject_ID !=null ? TitleObject_ID.ToString() : null,
                                    DesignAreaType_ID != null ? DesignAreaType_ID.ToString() : null,
                                    ProcessPhase_ID != null? ProcessPhase_ID.ToString() : null
                                );
                                result.AddParentId();
                                return result;
                            }
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
            else return null;
        }
        public IResult<MsgIdPair> Delete()
        {
            if (UserId == null)
            {
                result.AddException(new ArgumentNullException("UserIdentity instance hasn't been initialized"));
                return result;
            }
            using (var context = new Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);
                        spAdapter.ExecuteStoredProcedure
                        (
                            result,
                            "dbo",
                            "ISO_Delete",
                            ISO_ID.ToString(),
                            UserId.ToString()
                        );
                        return result;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.InnerException ?? ex);
                        return null;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
    }
}