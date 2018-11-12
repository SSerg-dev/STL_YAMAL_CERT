using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class PID
    {
        public static IEnumerable<PID> GetPidRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            using (var db = new WEB_MainDataEntities())
            {
                var skip = args.BeginIndex;
                var take = args.EndIndex - args.BeginIndex + 1;

                var query = (
                    from pid in db.PIDs
                    where (pid.PID_Code.Contains(args.Filter))
                    orderby (pid.PID_Code)
                    select pid
                ).Skip(skip).Take(take);

                return query.ToList();
            }
        }
        public static PID GetPidById(ListEditItemRequestedByValueEventArgs args)
        {
            using (var db = new WEB_MainDataEntities())
            {
                Guid id;
                if (args.Value == null || !Guid.TryParse(args.Value.ToString(), out id))
                    return null;

                return db.PIDs.FirstOrDefault(x => x.PID_ID == id);
            }
        }
    }
}