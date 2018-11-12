using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using SmartQA1._1._2.DB.EntityFramework;
using AutoMapper;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using Newtonsoft.Json;
using SmartQA1._1._2.Service;

namespace SmartQA1._1._2
{
    //CLASS
    public class FinalFolderList
    {
        public int resultsFound { get; set; }
        public IEnumerable<FinalFolder> finalFolderList  { get; set; }

        public void fill(List<Filter> inputFilters)
        {
            using (var context = new Entities())
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<FinalABDCompilation, FinalFolder>());
                    IMapper mapper = config.CreateMapper();

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    var folderID = context.FinalABDCompilations
                        .OrderBy(x => x.ReportOrder);

                    // 3-4 step
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    // 5-6 step
                    //retrieving the whole list of ABDFinalFolders that will satisfy to our criterea (wanted folders):
                    var _folderID = queryFactory.concatenateFilters(folderID)
                    .Select(x => x.ABDFinalFolder_ID)
                    .ToList()
                    .Distinct()
                    .ToList();

                    // 7 step
                    stopwatch.Stop();
                    Debug.WriteLine(stopwatch.ElapsedMilliseconds + "To retrieve final folder list");
                    stopwatch.Start();

                    // 8 step
                    resultsFound = _folderID.Count();

                    // 9 step 
                    //skipping and taking:
                    List<Guid> _foldersIDSkipped = queryFactory.ApplyRowNumFilter(_folderID);

                    // 10 step
                    //getting all other information by the ABDFinalfolderID that we retrieved:
                    var folders =
                        (
                            from member
                            in context.FinalABDCompilations
                            where _foldersIDSkipped.Contains(member.ABDFinalFolder_ID)
                            select member
                        )
                        .ToList();

                    // 11 step
                    folders = queryFactory.ApplyOrderByFilter(folders);

                    // 12 step
                    var _temp =
                        folders
                        .GroupBy(x => x.ABDFinalFolder_ID)
                        .Select
                        (x =>
                            {
                                var EntityFolder = x.FirstOrDefault();

                                FinalFolder okModel = mapper.Map<FinalABDCompilation, FinalFolder>(EntityFolder);

                                okModel.SubContractor_Id_Concatenated =
                                String.Join("/", x.Select(y => y.SubContractor_Id).Distinct());

                                okModel.SubContractor_Name_Concatenated =
                                String.Join("/", x.Select(y => y.SubContractor_Name).Distinct());

                                return okModel;
                            }
                        );
                    //measuring how much time did it take to retrieve the other info
                    stopwatch.Stop();
                    Debug.WriteLine(stopwatch.ElapsedMilliseconds + "- to retrieve other info");

                    finalFolderList = _temp;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    resultsFound = 0;
                    finalFolderList = null;
                }
            }
        }
    }
    //CLASS
    public class FinalFolder {
        public System.Guid ABDFinalFolder_ID { get; set; }
        public string ABDFinalFolder_Name { get; set; }
        public string CTR_RESP { get; set; }
        public Nullable<System.DateTime> Final_Compilation_Start_Date {
            get
            {
                return cSD;
            }
            set
            {
                var etm = value ?? default(DateTime);
                Norm_Final_Compilation_Start_Date = DateKit.convertToUIDate(etm);
                cSD = value;
            }
        }
        public string Norm_Final_Compilation_Start_Date { get; set; }
        public Nullable<System.DateTime> Final_Compilation_Target_Date {

            get
            {
                return cTD;
            }
            set
            {
                var etm = value ?? default(DateTime);
                Norm_Final_Compilation_Target_Date = DateKit.convertToUIDate(etm);
                cSD = value;
            }
        }
        public string Norm_Final_Compilation_Target_Date { get;  set; }
        public Nullable<int> ListCount { get; set; }
        public System.Guid ABDFinalSet_ID { get; set; }
        public string ABDFinalSet_Number { get; set; }
        public System.Guid ABDStatus_ID { get; set; }
        public string Status_ENG { get; set; }
        public string Status_Rus { get; set; }
        public System.Guid TitleObject_ID { get; set; }
        public string TitleObject_Name { get; set; }
        public System.Guid SubContractor_Id { get; set; }
        public string SubContractor_Id_Concatenated { get; set; }
        public string SubContractor_Name { get; set; }
        public string SubContractor_Name_Concatenated { get; set; }
        public System.Guid Marka_ID { get; set; }
        public string Marka_Name { get; set; }
        public Nullable<System.Guid> Transmittal_ID { get; set; }
        public string Transmittal_Code { get; set; }
        public string ReportColor { get; set; }
        public Nullable<int> ReportOrder { get; set; }
        public string FoldedStatus { get; set; }
        public System.Guid NewGUID { get; set; }

        private Nullable<System.DateTime> cSD = null;
        private Nullable<System.DateTime> cTD = null;
    }
}