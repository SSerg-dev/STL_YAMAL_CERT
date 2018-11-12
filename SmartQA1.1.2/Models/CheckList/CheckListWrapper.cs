using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Data.Linq;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.Models
{
    public class CheckListWrapper
    {
        public List<CheckList> CheckLists { get; private set; }
        public CheckType checkType;
        public Register.Register register;
        public string Register_Number;

        public bool IsEditable = false;

        //all CheckItems
        public List<CheckItem> CheckItems => CheckLists.Select(x => x.CheckItems).ToList().SelectMany(x => x).ToList();

        public bool IsCompleted => CheckLists.All(x => x.IsCompleted);

        public CheckListWrapper(WEB_MainDataEntities context, CheckType checkType, Register.Register register)
        {
            this.register = register;
            Register_Number = register.Register_Code;

            this.checkType = checkType;

            CheckLists = context.UI_CheckList
                .Where(x => x.Register_ID == register.Register_ID && x.CheckType_Code == checkType.ToString())
                .ToList()
                .Select(x=>(CheckList)x)
                .ToList();

            //check for some inconsintency among the CheckLists:
            //todo - check for some inconsintency among the CheckLists:

            //todo - then we have to switch to async loading of CheckItems:
            foreach (var checkList in CheckLists) checkList.RetrieveCheckItems(context, register);
        }

        public void SendToReview()
        {
            //todo - check for some inconsintency among the CheckLists:
        }

        public void AddCheckList(WEB_MainDataEntities context)
        {
            throw new NotImplementedException();

            CheckLists.Add(new CheckList(context, register));
        }
        public void Save()
        {
            if(register.Register_ID == Guid.Empty) throw new ApplicationException("First Register has to be saved");
        }

        public CheckItem GetCheckItem(Guid? CheckItem_ID) //null for new CheckItem
        {
            var searchCheckList = SelectCheckList(CheckItem_ID);
            return searchCheckList.GetCheckItem(CheckItem_ID);
        }

        public CheckItem CheckItem(Guid CheckItem_ID)
        {
            return CheckItems.Single(x => x.CheckItem_ID == CheckItem_ID);
        }

        public CheckList CheckList(Guid CheckList_ID)
        {
            return CheckLists.Single(x => x.CheckList_ID == CheckList_ID);
        }

        public IResult<MsgIdPair> CreateUpdateCheckItem(CheckItem checkItem, WEB_MainDataEntities context)
        {
            var parentCheckList = SelectCheckList(checkItem.CheckItem_ID);
            return parentCheckList.CreateUpdateCheckItem(checkItem, context);
        }

        //todo - reimplement this method after creating system of roles:
        public CheckList SelectCheckList(Guid? CheckItem_ID)
        {
            if (CheckItem_ID == null) return CheckLists.First();
            return CheckLists.Single(x => x.ContainsCheckItem((Guid)CheckItem_ID));
        }

        public void CheckFixedItem(Guid checkItem_ID)
        {
            var checkList = SelectCheckList(checkItem_ID);
            checkList.CheckFixedItem(checkItem_ID);
        }

        public IResult<MsgIdPair> UpdateCheckListStatus(Guid CheckList_ID, string command)
        {
            var checkList = CheckLists.Single(x => x.CheckList_ID == CheckList_ID);
            return checkList.UpdateCheckListStatus(command);
        }
    }
}