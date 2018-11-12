using AutoMapper;
using SmartQA1._1._2.DB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity.Core.Objects;
using Newtonsoft.Json;
using SmartQA1._1._2.Service;

namespace SmartQA1._1._2.Models.BusinessModels
{
    public class FileList
    {
        public int ResultsFound { get; set; } = 0;
        public IEnumerable<File> fileList { get; set; } = null;
        public String Error { get; set; } = null;
        private IMapper mapper;

        public FileList()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FileShareTable, File>());
            mapper = config.CreateMapper();
        }
        public void Fill(List<Filter> inputFilters)
        {
            ResultsFound = 0;
            fileList = null;
            Error = null;

            using (var context = new FileStorageEntities())
            {
                try
                {
                    context.Database.Log = ToolKit.writeOutput;

                    // 1 step
                    var FileIDs = context.FileShareTables.OrderBy(x => x.FileName);

                    // 3-4 step
                    QueryFactory queryFactory = new QueryFactory(inputFilters, context);

                    // 5-6-7 step
                    //retrievning the whole list of Stream_Id that will satisfy our criterea (wanted files)
                    var _FileIDs = queryFactory.concatenateFilters(FileIDs)
                    .Select(x => x.Stream_Id)
                    .ToList()
                    .Distinct()
                    .ToList();

                    //retrieving guid list from the QueryFactory method
                    _FileIDs = queryFactory.ApplyFileContentFilter(_FileIDs);
                    
                    // 8 step
                    ResultsFound = _FileIDs.Count();

                    // 9 step
                    //skipping and taking:
                    List<Guid> _FileIDsSkipped = queryFactory.ApplyRowNumFilter(_FileIDs);

                    // 10 step
                    //getting all other information about the files which ID's are in the list of wanted files
                    var Files =
                        (
                            from member
                            in context.FileShareTables
                            where _FileIDsSkipped.Contains(member.Stream_Id)
                            select member
                        )
                        .ToList();

                    // 11 step
                    Files = queryFactory.ApplyOrderByFilter(Files);

                    // 12 step
                    fileList = Files.Select(x => { return mapper.Map<FileShareTable, File>(x); });
                }
                catch (Exception ex)
                {
                    Error = (ex.InnerException ?? ex).Message;
                    ResultsFound = 0;
                    fileList = null;
                }
            }
        }
        public File GetFileById(Guid streamId)
        {
            using (var context = new FileStorageEntities())
            {
                return context.FileShareTables.Where(x => x.Stream_Id == streamId)
                    .ToList()
                    .Select(x => mapper.Map<FileShareTable, File>(x))
                    .FirstOrDefault();
            }
        }
    }
    public class File
    {
        #region Model Variables
        public Guid? Stream_Id
        { get; set; }
        //public string PathDefault
        //{ get; set; }
        public string PathNonDefault
        { get; set; }
        public string FileName //UI
        { get; set; }
        public string FileType { get; set; }
        public DateTime? LastWriteTime
        {
            get
            {
                return _LastWriteTime;
            }
            set
            {
                var etm = value ?? default(DateTime);
                LastWriteTime_UINormalized = DateKit.convertToUIDate(etm);
                _LastWriteTime = value;
            }
        }
        public string LastWriteTime_UINormalized //UI
        { get; set; }

        private DateTime? _LastWriteTime = null;
        #endregion Model Variables

    }
}