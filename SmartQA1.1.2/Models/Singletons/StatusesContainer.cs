using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Service;

namespace SmartQA1._1._2.Models.Singletons
{
    public class StatusesContainer
    {
        private static StatusesContainer _instance = null;
        private static List<Status> statuses;

        private static readonly List<Status> _CheckItem;
        private static readonly List<Status> _CheckList;
        private static readonly List<Status> _Register;
        private static readonly List<Status> _Document;

        static StatusesContainer()
        {
            using (var context = new WEB_MainDataEntities())
            {
                var entities = context.Status.Select(x => x.StatusEntity).Distinct().ToList();
                if(!EnumStringComparator.Equals<StatusEntity>(entities))
                    throw new DatabaseStateException("StatusEntities has changed in the DB");
                statuses = context.Status.ToList();
            }

            _CheckItem = statuses.Where(x => x.StatusEntity == StatusEntity.CheckItem.ToString()).ToList();
            _CheckList = statuses.Where(x => x.StatusEntity == StatusEntity.CheckList.ToString()).ToList();
            _Register = statuses.Where(x => x.StatusEntity == StatusEntity.Register.ToString()).ToList();
            _Document = statuses.Where(x => x.StatusEntity == StatusEntity.Document.ToString()).ToList();

            //check CheckItemStatusCode enum:
            var checkItemsCode = CheckItemStatus.Select(x => x.Status_Code).ToList();
            if(!EnumStringComparator.Equals<CheckItemStatusCode>(checkItemsCode))
                throw new DatabaseStateException("CheckItems status has changed in the DB");

            //check CheckListStasucCode enum:
            var checkListCode = CheckListStatus.Select(x => x.Status_Code).ToList();
            if (!EnumStringComparator.Equals<CheckListStatusCode>(checkListCode))
                throw new DatabaseStateException("CheckLists status has changed in the DB");
        }

        public static List<Status> CheckItemStatus => _CheckItem;
        public static List<Status> CheckListStatus => _CheckList;
        public static List<Status> RegisterStatus => _Register;
        public static List<Status> DocumentStatus => _Document;

        private enum StatusEntity
        {
            CheckItem,
            CheckList,
            Document,
            Register
        }

        public enum RegisterStatusCode
        {
            wCarh, //Archived - auto
            wCcan, //Cancelled - manual
            wSCci, //CommentsIncorporation - auto
            wCCuna, //Not approved - auto
            wSCce, //Comments exists - manual
            wCCuAr, //Review - auto
            wCCua, //Approvement - auto/manual
            wCCuAsr, //Second review - auto
            wCwsmr, //Waiting SMR - manual
            wSCd //Draft - auto
        }

        public enum CheckItemStatusCode { wCLIa, wCLIc, wCLId, wCLIf, wCLIss }

        public enum CheckListStatusCode { wСLc, wСLd, wСLr, wCLf }

        public enum CheckListWrapperStatusCode
        {
            Draft, //all CheckLists are in 
            Review,
            ReviewCompleted,
            Fixed
        }
    }
}