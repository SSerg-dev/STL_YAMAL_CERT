using SmartQA1._1._2.DB;
using SmartQA1._1._2.DB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Diagnostics;

namespace SmartQA1._1._2.Models
{
    public class RegisterStatus
    {
        public System.Guid Register_ID { get; set; }
        public System.Guid Register_To_Status_ID { get; set; }
        public string Created_By { get; set; } //UI
        public string Modified_By { get; set; } //UI
        public string ABDStatusDate_UINormalized { get; set; } //UI
        public Nullable<System.DateTime> ABDStatusDate { get; set; }
        //private Nullable<System.DateTime> aBDStatusDate;
        public Status status { get; set; }

        public object getRegisterStatusByRegisterId(Guid Register_ID)
        {
            using (var context = new Entities())
            {
                try
                {
                    var er = context.p_Register_to_Status
                    //Если используем таблицы, а НЕ вьюхи,
                    //то нужно ограничение на Row_status,
                    //которое означает "только действительные записи".
                    //Либо нужно использовать вьюхи, а НЕ таблицы,
                    //тогда ограничение на Row_status уже НЕ нужно.
                    .Where(x => x.Row_status < 100)
                    .Where(x => x.Register_ID == Register_ID)
                    .GroupBy(x => x.ABDStatus_ID)
                    .Select(y => y.OrderBy(z => z.ABDStatusDate))
                    .Select
                    (x => x.Select(zx =>
                            new
                            {
                                Register_ID = zx.Register_ID,
                                Register_To_Status_ID = zx.Register_To_Status_ID,
                                //Created_By = zx.Created_By,
                                //Modified_By = zx.Modified_By,
                                ABDStatusDate = zx.ABDStatusDate,
                                ABDStatusDate_UINormalized = String.Empty,
                                status = zx.p_ABDStatus
                            }
                            )
                     )
                     .ToList();
                    var config = new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true);
                    IMapper mapper = config.CreateMapper();

                    var outputParameter = new Dictionary<Guid, List<RegisterStatus>>();
                    var t = er.Select(x => x.Select(mapper.Map<RegisterStatus>).ToList()).ToList();

                    foreach (var rs in t)
                    {
                        foreach (var ts in rs)
                        {
                            ts.normalizeDate();
                        }
                    }

                    return t;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    return
                        null;
                }
            }
        }
        public void normalizeDate()
        {
            var etm = ABDStatusDate ?? default(DateTime);
            this.ABDStatusDate_UINormalized = DateKit.convertToUIDate(etm);
        }
    }
    public class Status
    {
        public System.Guid ABDStatus_ID { get; set; }
        //public string Stage { get; set; }
        public string Code { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; } //UI
        //public Nullable<int> Status_Type { get; set; }
        //public Nullable<int> Row_status { get; set; }
        //public Nullable<System.DateTime> Insert_DTS { get; set; }
        //public Nullable<System.DateTime> Update_DTS { get; set; }
        //public string ReportColor { get; set; }
        //public Nullable<int> ReportOrder { get; set; }

        public IEnumerable<Status> getRegisterStatusList()
        {
            using (var context = new Entities())
            {
                try
                {
                    var entityStatusList = context.p_ABDStatus
                    //Если используем таблицы, а НЕ вьюхи,
                    //то нужно ограничение на Row_status,
                    //которое означает "только действительные записи".
                    //Либо нужно использовать вьюхи, а НЕ таблицы,
                    //тогда ограничение на Row_status уже НЕ нужно.
                    .Where(x => x.Row_status < 100)
                    .Where(x => x.ReportOrder != null)
                    .Where(x => x.Stage == "Interm ABD registers")
                    .OrderBy(x => x.ReportOrder).ToList();

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<p_ABDStatus, Status>());
                    IMapper mapper = config.CreateMapper();
                    IEnumerable<Status> okModel = entityStatusList.Select(x => mapper.Map<p_ABDStatus, Status>(x));

                    return okModel;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    return
                        null;
                }
            }
        }
    }
}