using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class GOST
    {
        public static IEnumerable<GOST> GetGostRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            using (var db = new WEB_MainDataEntities())
            {
                var skip = args.BeginIndex;
                var take = args.EndIndex - args.BeginIndex + 1;

                var query = (
                        from gost in db.GOSTs
                        where (gost.GOST_Code.Contains(args.Filter))
                        orderby (gost.GOST_Code)
                        select gost
                    ).Skip(skip).Take(take);
                return query.ToList();
            }
        }
        public static GOST GetGostById(ListEditItemRequestedByValueEventArgs args)
        {
            using (var db = new WEB_MainDataEntities())
            {
                Guid id;
                if (args.Value == null || !Guid.TryParse(args.Value.ToString(), out id))
                    return null;

                return db.GOSTs.FirstOrDefault(x => x.GOST_ID == id);
            }
        }
    }
}