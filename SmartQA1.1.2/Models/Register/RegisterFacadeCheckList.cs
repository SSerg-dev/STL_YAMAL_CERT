using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.Models.Register
{
    public static class RegisterFacadeCheckList
    {
        /// <summary>
        /// Creates CheckTables for the current Register and fills them with people
        /// Used in the Register constructor
        /// </summary>
        public static void GetCheckTables(this Register register, WEB_MainDataEntities context)
        {
            register.ReviewWrapper = new CheckListWrapper(context, CheckType.Review, register);
            register.ApprovementWrapper = new CheckListWrapper(context, CheckType.Approvement, register);
        }

        /// <summary>
        /// Retrieves or creates new instance of the CheckItem
        /// </summary>
        public static CheckItem GetCheckItem(this Register register, Guid? CheckItem_ID, CheckType checkType)
        {
            return register.GetCheckListWrapper(checkType).GetCheckItem(CheckItem_ID);

        }

        public static CheckListWrapper GetCheckListWrapper(this Register register, CheckType checkType)
        {
            if (checkType == CheckType.Approvement) return register.ApprovementWrapper;
            if (checkType == CheckType.Review) return register.ReviewWrapper;

            throw new ArgumentException("Not valid checkType provided.");
        }
        /// <summary>
        /// Used to update single checkList after clicking checkboxes in CheckList table
        /// </summary>
        public static IResult<MsgIdPair> UpdateCheckListStatus(this Register register, CheckType checkType, Guid CheckList_ID, string command)
        {
            var checkListWrapper = register.GetCheckListWrapper(checkType);
            return checkListWrapper.UpdateCheckListStatus(CheckList_ID, command);
        }

        public static IResult<MsgIdPair> CreateUpdateCheckItem(this Register register, CheckItem checkItem, CheckType checkType, WEB_MainDataEntities context)
        {
            var checkListWrapper = register.GetCheckListWrapper(checkType);
            return checkListWrapper.CreateUpdateCheckItem(checkItem, context);
        }

        public static void CheckFixedItem(this Register register, CheckType checkType, Guid checkItem_ID)
        {
            var checkListWrapper = register.GetCheckListWrapper(checkType);
            checkListWrapper.CheckFixedItem(checkItem_ID);
        }
    }
}