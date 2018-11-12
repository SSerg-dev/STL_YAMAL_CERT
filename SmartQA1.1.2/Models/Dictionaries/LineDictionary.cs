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
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Models.Login;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.Models.Dictionaries
{
    //CLASS
    public class LineListDictionary
    {
        public int resultsFound { get; set; }
        public IEnumerable<LineDictionary> lineList { get; set; }

        private IMapper mapper;
        public LineListDictionary()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UI_Line, LineDictionary>());
            mapper = config.CreateMapper();
        }
        public void fill(List<Filter> inputFilters)
        {
            resultsFound = 0;
            lineList = null;
            if (inputFilters != null && inputFilters.Count() > 0)
            {
                using (var context = new Entities())
                {
                    // 1 step
                    var lineIDQuery = context.UI_Line.Where(x => x.Row_Status < 100).OrderBy(x => x.Line_Number);

                    // 3-4 step
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    // 5-6-7 step
                    //retrieving the whole list of Line_ID that will satisfy our criterea (wanted Lines)
                    var _linesID = queryFactory.concatenateFilters(lineIDQuery)
                        .Select(x => x.Line_ID)
                        .ToList()
                        .Distinct()
                        .ToList();

                    // 8 step
                    resultsFound = _linesID.Count();

                    // 9 step
                    //skipping and taking:
                    List<Guid> _linesIDSkipped = queryFactory.ApplyRowNumFilter(_linesID);


                    // 10 step
                    //retrieving all other information about the Lnines which ID's are in the list of wanted Lines
                    var lines = (
                        from member
                        in context.UI_Line
                        where _linesIDSkipped.Contains(member.Line_ID)
                        select member
                    ).OrderBy(x=>x.Line_Number)
                    .ToList();

                    // 11 step
                    lines = queryFactory.ApplyOrderByFilter(lines);

                    // 12 step
                    lineList = lines.Select(x => mapper.Map<UI_Line, LineDictionary>(x));
                }
            }
        }
        public void getLineByIso(Guid? isoGuid)
        {
            using (var context = new Entities())
            {
                context.Database.Log = ToolKit.writeOutput;
                var _result = context.UI_Line
                    .Where(
                    x =>
                        x.Line_ID == context.UI_ISO
                            .Where(y => y.ISO_ID == isoGuid)
                            .Select(y => y.Line_ID)
                            .FirstOrDefault()
                    )
                    .ToList()
                    .Select(x => mapper.Map<UI_Line, LineDictionary>(x))
                    .ToList();

                //assuming that we'll get only single line for one Iso, 
                //checking this assumption before retrieving FirstOrDefault():
                if (_result.Count > 1)
                {
                    var ex = new DatabaseStateException(
                        "Found not single line for single Iso. ISO_ID: "+isoGuid);
                    new Logger(ex).Log();
                }

                resultsFound = _result.Count;
                lineList = _result;
            }
        }
        public LineDictionary getLineById(Guid? lineId)
        {
            using (var context = new Entities())
            {
                return mapper.Map<UI_Line, LineDictionary>(
                    context.UI_Line
                    .Where(x => x.Line_ID == lineId)
                    .FirstOrDefault());
            }
        }
        public LineDictionary getLineByNumber(string number)
        {
            using (var context = new Entities())
            {
                return mapper.Map<UI_Line, LineDictionary>(
                    context.UI_Line
                    .Where(x => x.Line_Number == number)
                    .FirstOrDefault());
            }
        }
    }
    public class LineDictionary
    {
        public Guid? Line_ID { get; set; }
        public string Line_Number { get; set; }
        public Nullable<int> Row_Status { get; set; }
        public string Location_From { get; set; }
        public string Location_To { get; set; }
        public string Fluid_Name_Eng { get; set; }
        public string Fluid_Name_Rus { get; set; }
        public string Fluid_Danger_Code_By_Gost { get; set; }
        public string Fluid_Fire_Aand_Explosive_Hazard { get; set; }
        public string Fluid_Group_By_TP_TC_032_2013 { get; set; }
        public string Fluid_Group_By_GOST { get; set; }
        public string Pipeline_Category_By_GOST { get; set; }
        public string Piprline_Category_By_TP_TC_032_2013 { get; set; }

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        private IMapper mapper;
        private IResult<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();

        public LineDictionary()
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
            using (var context = new Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);

                        //here comes the embrachment - where to CREATE or UPDATE the model:
                        //CREATE
                        if (Line_ID == null)
                        {
                            spAdapter.ExecuteStoredProcedure
                            (
                                result,
                                "dbo",
                                "Line_Insert",
                                "0",
                                UserId != null ? UserId.ToString() : null,
                                Line_Number,
                                Location_From,
                                Location_To,
                                Fluid_Name_Eng,
                                Fluid_Name_Rus,
                                Fluid_Danger_Code_By_Gost,
                                Fluid_Fire_Aand_Explosive_Hazard,
                                Fluid_Group_By_TP_TC_032_2013,
                                Fluid_Group_By_GOST,
                                Pipeline_Category_By_GOST,
                                Piprline_Category_By_TP_TC_032_2013
                            );
                            result.AddParentId(); //this value will be returned to FE to update the whole edit window
                            return result;
                        }
                        else
                        {
                            spAdapter.ExecuteStoredProcedure
                            (
                                result,
                                "dbo",
                                "Line_Update",
                                Line_ID,
                                "0",
                                UserId != null ? UserId.ToString() : null,
                                Line_Number,
                                Location_From,
                                Location_To,
                                Fluid_Name_Eng,
                                Fluid_Name_Rus,
                                Fluid_Danger_Code_By_Gost,
                                Fluid_Fire_Aand_Explosive_Hazard,
                                Fluid_Group_By_TP_TC_032_2013,
                                Fluid_Group_By_GOST,
                                Pipeline_Category_By_GOST,
                                Piprline_Category_By_TP_TC_032_2013
                            );
                            result.AddParentId(); //this value will be returned to FE to update the whole edit window
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
                            "Line_Delete",
                            UserId.ToString(),
                            Line_ID.ToString()
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