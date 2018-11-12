using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using AutoMapper;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.DB.StoredProcedures;
using System.Web;
using SmartQA1._1._2.Models.Login;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.BusinessModels
{
    //CLASS
    public class RegisterList
    {
        public int resultsFound { get; set; }
        public IEnumerable<Register> registerList { get; set; }

        public void fill(List<Filter> inputFilters)
        {
            resultsFound = 0;
            registerList = null;
            
            using (var context = new Entities())
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UI_RegisterList, Register>());
                    IMapper mapper = config.CreateMapper();
                    Guid UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());

                    // 1 step
                    var regsID = context.UI_RegisterList
                        .Where(x => x.User_Id == UserId)
                        .Where(x => x.Register_Row_status < 200)
                        .OrderBy(x => x.Register_Number);

                    // 2 step
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // 3-4 step
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    // 5-6 step
                    //retrievning the whole list of Register_ID that will satisfy our criterea (wanted registers)
                    var _regsID = (queryFactory.concatenateFilters(regsID))
                    .Select(x => x.Register_ID)
                    .ToList()
                    .Distinct()
                    .ToList();

                    // 7 step
                    stopwatch.Stop();
                    Debug.WriteLine($"{stopwatch.ElapsedMilliseconds}To retrieve register list");
                    stopwatch.Start();

                    // 8 step
                    resultsFound = _regsID.Count();

                    // 9 step 
                    //skipping and taking:
                    List<Guid> _regsIDSkipped = queryFactory.ApplyRowNumFilter(_regsID);

                    // 10 step
                    // gathering all other information about the registers which ID's are in the list of wanted registers
                    var regs = 
                        (
                            from member 
                            in context.UI_RegisterList.Where(x => x.User_Id == UserId)
                            where _regsIDSkipped.Contains(member.Register_ID)
                            select member
                        )
                        .ToList();

                    // 11 step
                    regs = queryFactory.ApplyOrderByFilter(regs);

                    // 12 step
                    var _temp =
                        regs
                        .GroupBy(x => x.Register_ID)
                        .Select
                        (x =>
                            {
                                var EntityRegister = x.FirstOrDefault();

                                Register okModel = mapper.Map<UI_RegisterList, Register>(EntityRegister);

                                okModel.TitleObject_ID_Concatenated =

                                String.Join("/",
                                                x
                                                .Where(y => y.Register_to_TitleObject_Row_status!=200)
                                                .Select(y => y.TitleObject_ID)
                                                .Distinct()
                                           );

                                okModel.TitleObject_Name_Concatenated =
                                String.Join("/",
                                                x
                                                .Where(y => y.Register_to_TitleObject_Row_status != 200)
                                                .Select(y => y.TitleObject_Name)
                                                .Distinct()
                                           );

                                okModel.Marka_ID_Concatenated =
                                String.Join("/",
                                                x
                                                .Where(y => y.Register_to_Marka_Row_status != 200)
                                                .Select
                                                (y => y.Marka_ID)
                                                .Distinct()
                                           );

                                okModel.Marka_Name_Concatenated =
                                String.Join("/",
                                                x
                                                .Where(y => y.Register_to_Marka_Row_status != 200)
                                                .Select(y => y.Marka_Name)
                                                .Distinct()
                                           );
                                return
                                    okModel; 
                            }
                        );
                    //measuring how much time did it take to retrieve the other info
                    stopwatch.Stop();
                    Debug.WriteLine($"{stopwatch.ElapsedMilliseconds}- to retrieve other info");

                    registerList = _temp;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    resultsFound = 0;
                    registerList = null;
                }
            }
        }
    }
    //CLASS
    public class Register : IEqualityComparer<Register>
    {
        #region Model Variables
        public Guid? Register_ID
        { get; set; }
        public string LOG_ID
        { get; set; }
        public string Register_Number //UI
        { get; set; }
        public string Phase //UI
        { get; set; }
        public string ProcessPhase_Name //UI
        { get; set; }
        public string TitleObject_Name
        { get; set; }
        public string Target__Unit_ISO_
        { get; set; }
        public string Marka_Name //UI //EDIT
        { get; set; }
        public string Work_Desc //UI //EDIT
        { get; set; }

        public DateTime? CNT_Date
        {
            get
            {
                return cNT_Date;
            }
            set
            {
                CNT_Date_UINormalized = DateKit.convertToUIDate(value ?? default(DateTime));
                cNT_Date = value;
            }
        }
        public string CNT_Date_UINormalized //UI
        { get; set; }
        private DateTime? cNT_Date=null;

        public DateTime? ABDStatusDate //UI
        {
            get
            {
                return aBDStatusDate;
            }
            set
            {
                ABDStatusDate_UINormalized = DateKit.convertToUIDate(value ?? default(DateTime));
                aBDStatusDate = value;
            }
        }
        public string ABDStatusDate_UINormalized //EDIT
        { get; set; }
        private DateTime? aBDStatusDate;
        public string SCTR_RESP //UI (отв. от субподрядчика)
        { get; set; }
        public string CTR_RESP //UI (ответственный от подрядчика)
        { get; set; }
        public string Description_Rus //UI (Статус)
        { get; set; }
        public string Notesl //UI
        { get; set; }
        public string TitleColor
        { get; set; }
        public int? TitleOrder;
        public string MarkaColor;
        public int? MarkaOrder;
        public string StatusColor;
        public int? StatusOrder;
        public Guid? TitleObject_ID
        { get; set; }
        public Guid? Marka_ID
        { get; set; }
        public Guid? ABDStatus_ID
        { get; set; }
        public Guid? WorkPackage_ID
        { get; set; }
        public Guid? ProcessPhase_ID
        { get; set; }
        public string WorkPackage_Name //UI (Пакет)
        { get; set; }
        public string TitleObject_ID_Concatenated //UI //EDIT
        { get; set; }
        public string Marka_ID_Concatenated //UI
        { get; set; }
        public string Phase_ID_Concatenated
        { get; set; }
        public string TitleObject_Name_Concatenated;
        public string Marka_Name_Concatenated //UI
        { get; set; }
        public string FileLOG { get; set; }
        #endregion Model Variables

        public bool Equals(Register r1, Register r2)
        {
            return r1.Register_ID == r2.Register_ID;
        }
        public int GetHashCode(Register r1)
        {
            return r1.Register_ID.GetHashCode();
        }
        public static Register getRegisterByRegisterId(Guid? inputRegisterId)
        {
            using (var context = new Entities())
            {
                try
                {
                    var config = new MapperConfiguration
                        (cfg => cfg.CreateMap<UI_RegisterList, Register>());

                    IMapper mapper = config.CreateMapper();

                    Guid UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());

                    var _temp =
                        context.UI_RegisterList
                        .Where(x => x.User_Id == UserId)
                        .Where
                        (x => x.Register_ID == inputRegisterId)
                        .Where
                        (x => x.Register_Row_status != 200)
                        .ToList()
                        .GroupBy
                        (x => x.Register_ID)
                        .Select
                        (x =>
                                {
                                    var EntityRegister = x.FirstOrDefault();

                                    Register okModel =
                                    mapper.Map<UI_RegisterList, Register>(EntityRegister);

                                    okModel
                                    .TitleObject_ID_Concatenated =
                                    String.Join("/",
                                                    x
                                                    .Where(y => y.Register_to_TitleObject_Row_status != 200)
                                                    .Select(y => y.TitleObject_ID)
                                                    .Distinct()
                                               );

                                    okModel
                                    .TitleObject_Name_Concatenated =
                                    String.Join("/",
                                                    x
                                                    .Where(y => y.Register_to_TitleObject_Row_status != 200)
                                                    .Select(y => y.TitleObject_Name)
                                                    .Distinct()
                                               );

                                    okModel
                                    .Marka_ID_Concatenated =
                                    String.Join("/",
                                                    x
                                                    .Where(y => y.Register_to_Marka_Row_status != 200)
                                                    .Select(y => y.Marka_ID)
                                                    .Distinct()
                                               );

                                    okModel
                                    .Marka_Name_Concatenated =
                                    String.Join("/",
                                                    x
                                                    .Where(y => y.Register_to_Marka_Row_status != 200)
                                                    .Select(y => y.Marka_Name)
                                                    .Distinct()
                                               );
                                    return
                                        okModel;
                                }
                        )
                        .First();

                    return _temp;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    return
                        null;
                }
            }
        }
        public long? GetNewRegisterNumber()
        {
            using (var context = new Entities())
            {
                try
                {
                    //Вызов хранимой процедуры для генерации номера нового реестра
                    return 0;
                        //context.Register_SequenceNumber().First();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    return
                        null;
                }
            }
        }
        #region CRUD
        public IResult<MsgIdPair> SaveRegister(SmartQA1._1._2.BusinessModels.Register reg)
        {
            //Во фронтэнде метод SaveRegister вызывается дважды.
            //При этом, во время первого вызова приходит почему-то пустой объект reg.
            //Причина двойного вызова метода SaveRegister пока не выяснена.
            //Возможно, дважды срабатывает Ajax-компонент во фронтэнде.
            //Делаем выход из метода, если пришёл пустой объект reg.
            if (String.IsNullOrWhiteSpace(reg.Register_Number))
                return null;

            
            //Для БД создаём контекст, который будет уничтожен при выходе из блока using { }
            using (var context = new Entities())
            {
                //Создаём транзакцию в этом контексте, которая будет уничтожена при выходе из блока using { }
                using (var transaction = context.Database.BeginTransaction())
                {

                    IResult<MsgIdPair> proceduresResult = new MultipleSetsResultIdError<MsgIdPair>();
                    try
                    {
                        //DELETE THIS LINE AFTER PROCEDURE TRANSFER TO THE OLD DB:
                        StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);

                        //Получаем текущее время от SQL-сервера с помощью SysDateTime()
                        reg.ABDStatusDate = context.Phases.Select(x => DateTime.Now).First();

                        //Вызов хранимой процедуры для обновления уже существующего реестра
                        if (reg.Register_ID.HasValue)
                        {
                            reg.update(spAdapter, proceduresResult);

                            if (!proceduresResult.isValid) return proceduresResult;
                            else reg.Register_ID = proceduresResult.GetLastObject();

                            //UDPATING TITLES:
                            (new TitleObjectList()).updateByRegister(spAdapter, proceduresResult, reg);

                            //UPDATING MARKAS:
                            (new MarkaList()).updateByRegister(spAdapter, proceduresResult, reg);
                        }
                        //Вызов хранимой процедуры для создания нового реестра
                        else if (!String.IsNullOrWhiteSpace(reg.Register_Number))
                        {
                            reg.create(spAdapter, proceduresResult);

                            if (!proceduresResult.isValid) return proceduresResult;
                            else reg.Register_ID = proceduresResult.GetLastObject();

                            //INSERTING TITLES:
                            (new TitleObjectList()).createByRegister(spAdapter, proceduresResult, reg);

                            //INSERTING MARKAS:
                            (new MarkaList()).createByRegister(spAdapter, proceduresResult, reg);
                        }
                        return proceduresResult;
                    }
                    catch (Exception ex)
                    {
                        proceduresResult.AddException(ex);
                        return proceduresResult;
                    }
                    //finally is always called before any return statement
                    finally
                    {
                        if (proceduresResult.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
        public IResult<MsgIdPair> DeleteRegister(Register reg)
        {
            if (!reg.Register_ID.HasValue && String.IsNullOrWhiteSpace(reg.Register_Number))
                return null;

            using (var context = new Entities())
            {
                IResult<MsgIdPair> proceduresResult = new MultipleSetsResultIdError<MsgIdPair>();
                //Транзакцию НЕ УДАЛЯТЬ !!!
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);
                        return
                        spAdapter.ExecuteStoredProcedure
                        (
                            proceduresResult,
                            "dbo",
                            "Register_Delete",
                            "WebServerUser",
                            $"{Register_ID}"
                        );
                    }
                    catch (Exception ex)
                    {
                        proceduresResult.AddException(ex);
                        return proceduresResult;
                    }
                    //finally is always called before any return statement
                    finally
                    {
                        if (proceduresResult.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
        private IResult<T> create<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T : IDataSet<T>
        {
            return 
            spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_Insert",
                 "0",
                 "WebServerUser",
                 Register_Number,
                 SCTR_RESP,
                 CTR_RESP,
                 null, //i_Comment
                 null, //i_Incoming_Control
                 $"{WorkPackage_ID}",
                 FileLOG,
                 LOG_ID,
                 String.IsNullOrWhiteSpace(CNT_Date_UINormalized) ? null
                 : $"{DateKit.String2DateTime(CNT_Date_UINormalized):yyyy-MM-dd}",
                 Work_Desc,
                 Notesl,
                 null, //InArchiveDate
                 ABDStatusDate.HasValue ? $"{ABDStatusDate.Value:yyyy-MM-dd}" : $"{DateTime.Today:yyyy-MM-dd}",
                 $"{ABDStatus_ID}"
            );
        }
        private IResult<T> update<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T : IDataSet<T>
        {
            return
            spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_Update",
                 "0",
                 "WebServerUser",
                 Register_ID.HasValue ? $"{Register_ID.Value}" : null,
                 Register_Number,
                 SCTR_RESP,
                 CTR_RESP,
                 null, //i_Comment
                 null, //i_Incoming_Control
                 !WorkPackage_ID.HasValue ? WorkPackage_ID.ToString() : "",
                 FileLOG,
                 LOG_ID,
                 String.IsNullOrWhiteSpace(CNT_Date_UINormalized) ? null
                 : $"{DateKit.String2DateTime(CNT_Date_UINormalized):yyyy-MM-dd}",
                 Work_Desc,
                 Notesl,
                 null, //InArchiveDate
                 ABDStatusDate.HasValue ? $"{ABDStatusDate.Value:yyyy-MM-dd}" : $"{DateTime.Today:yyyy-MM-dd}",
                 $"{ABDStatus_ID}"
            );
        }
        #endregion CRUD
    }
}