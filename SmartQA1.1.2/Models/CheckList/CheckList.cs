using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Models.Singletons;

namespace SmartQA1._1._2.Models
{
    public class CheckList
    {
        public string CheckList_Code { get; set; }
        public DateTime CheckList_Date { get; set; }
        public string CheckParty_Code { get; set; }
        public string Position_Description { get; set; }
        public string ShortName { get; set; }
        public string CheckList_Status { get; set; }
        public Guid Register_ID { get; set; }
        public Guid CheckList_ID { get; set; }
        //public string Comment { get; set; }
        //public string CheckItem_Status { get; set; }
        public string Status_Code
        {
            get { return _Status_Code; }
            set { _Status_Code = value;  state = new StateCheckList(value);}
        }

        private string _Status_Code;

        public StateCheckList state;

        public Guid Status_ID //automatically assigns IsCompleted property
        {
            get { return _Status_ID; }
            set
            {
                var completedStatusId = StatusesContainer.CheckListStatus
                    .Where(x => x.Status_Code == StatusesContainer.CheckListStatusCode.wСLc.ToString())
                    .Select(x => x.Status_ID)
                    .First();
                IsCompleted =  value == completedStatusId;
                _Status_ID = value;
            }
        }
        public Guid _Status_ID;

        public Guid? Position_ID { get; set; }
        public Guid? Person_ID { get; set; }
        public Guid? CheckType_ID { get; set; }
        public string CheckType_Code { get; set; }

        public List<CheckItem> CheckItems { get; set; } = new List<CheckItem>();
        public List<UI_Register_ListItem> CurrentRegisterDocuments { get; set; }
        public List<UI_Register_ListItem> _currentDocuments;

        public bool NoMoreObservations { get; set; } = false; // this property has to be set true to change status to approved
        public bool IsCompleted { get; set; } = false; //this property is a trigger for Status

        public Register.Register register;
        public string Register_Number;

        public List<Status> Statuses { get; private set; }

        public CheckList() //used by the explicit convert operator
        {
            Statuses = StatusesContainer.CheckListStatus;
        }

        /// <summary>
        /// Only new CheckList from template can creating by using this Constructor
        /// </summary>
        public CheckList(WEB_MainDataEntities context, Register.Register register): this()
        {
            this.register = register;
            Register_Number = register.Register_Code;
        
            //todo - retrieve the existing template from the context
            T_CheckList template;
            try
            {
                template = context.T_CheckList.Single();
            }
            catch (InvalidOperationException ioe)
            {
                throw new DatabaseStateException("No template or multiple parent templates were found in T_Checklist", ioe);
            }
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_CheckList, CheckList>());
            var mapper = cfg.CreateMapper();
            mapper.Map(template, this);
        }
        
        public void RetrieveCheckItems(WEB_MainDataEntities context, Register.Register register)
        {
            var _checkItems = context.UI_CheckItem
                .Where(x => x.CheckList_ID == CheckList_ID)
                .ToList();

            foreach (var item in _checkItems)
            {
                CheckItems.Add(new CheckItem(item, register, this));
            }

            var allRegisterDocuments = register.GetAllDocuments();
            foreach (var item in CheckItems)
            {
                if (item.Document_ID != null)
                    item.CurrentDocument = allRegisterDocuments.Single(x => x.Document_ID == item.Document_ID);
            }


            if(CheckItems.Any(x=>x.Register_ID != Register_ID))
            throw new DatabaseStateException("Not valid Register_ID of UI_CheckItems of the UI_CheckList. UI_CheckList_ID: "+CheckList_ID);
        }

        public static explicit operator CheckList(UI_CheckList checkList)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_CheckList, CheckList>());
            var mapper = cfg.CreateMapper();
            return mapper.Map<CheckList>(checkList);
        }
        public bool CanBeCompleted()
        {
            return CheckItems.All(x => x.IsCompleted());
        }

        public bool ContainsCheckItem(Guid id)
        {
            return CheckItems.Any(x => x.CheckItem_ID == id);
        }

        public CheckItem GetCheckItem(Guid? id) // null id for new CheckItem
        {
            if(id == null)
            {
                using (var context = new WEB_MainDataEntities())
                {
                    return new CheckItem(context, this);
                }
            }
            else
            {
                try //throws ArgumentNullException and InvalidOperationException 
                {
                    return CheckItems.Single(x => x.CheckItem_ID == id);
                }
                catch (ArgumentNullException ane)
                {
                    ane.Data.Add("CheckItems list is null", "Null CheckItems list for CheckList_ID: "+CheckList_ID);
                    throw;
                }
                catch (InvalidOperationException ioe)
                {
                    ioe.Data.Add("Not found CheckItem", "Couldn't find CheckItem_ID" +id+ "in CheckList_ID: "+ CheckList_ID);
                    throw;
                }
            }
        }
        /// <summary>
        /// Called when any CheckList status is changed and button Save is pressed
        /// </summary>
        public IResult<MsgIdPair> UpdateCheckListStatus(string command)
        {
            var result = new MultipleSetsResultIdError<MsgIdPair>();
            return state.UpdateStatus(command, result);
        }
        public IResult<MsgIdPair> CreateUpdateCheckItem(CheckItem checkItem, WEB_MainDataEntities context)
        {
            IResult<MsgIdPair> result;

            //fork: New or Existing CheckItem:
            if (checkItem.CheckItem_ID == null || checkItem.CheckItem_ID == Guid.Empty) //CREATE NEW AND ADD TO THE LIST
            {
                result = checkItem.SaveNew(context);
                if(result.isValid) CheckItems.Add(checkItem);
            }
            else //UPDATE EXISTING
            {
                result = checkItem.SaveExisting(context);
                if (result.isValid)
                {
                    CheckItems.RemoveAll(x => x.CheckItem_ID == checkItem.CheckItem_ID);
                    CheckItems.Add(checkItem);
                }
            }
            return result;
        }
        public void CheckFixedItem(Guid checkItemId)
        {
            var checkItem = CheckItems.Single(x => x.CheckItem_ID == checkItemId);
            checkItem.Update("CheckFixedItem");
        }
    }
    public enum CheckType
    {
        Approvement,
        Review
    }
}