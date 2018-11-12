using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Models.Singletons;

namespace SmartQA1._1._2.Models
{
    public class CheckItem : ICloneable
    {
        public string CheckList_Code { get; set; }
        public string CheckItem_Name { get; set; } //UI field
        public string Comment { get; set; } //UI field
        public string ShortName { get; set; } //UI field
        public string Position_Code { get; set; }
        public Guid? Status_ID { get; set; } //UI field
        public string CheckItem_Status { get; set; } //UI field
        public DateTime Update_DTS { get; set; }
        public int Position { get; set; }
        public Guid CheckList_ID { get; set; }
        public Guid CheckItem_ID { get; set; }
        public string Division_Name { get; set; } //UI field
        public Guid? Document_ID { get; set; }
        public string Document_Name { get; set; }
        public Guid Register_ID { get; set; }
        public string Document_Number { get; set; }
        public DateTime? Issued_Date { get; set; } //UI field
        public string Status_Description_Rus => State?.Status.Description_Rus;

        private string _Status_Code;

        //public CheckList parent;

        public CheckType CheckType_Code;
        public string CheckType => CheckType_Code.ToString();
        public StateCheckItem State;
        public string Status_Code
        {
            get { return _Status_Code; }
            set { _Status_Code = value; State = new StateCheckItem(value); }
        }

        public bool isFixed => State?.isFixed ?? false;
        public bool checkBoxReadonly => State?.checkBoxReadOnly ?? false;
        public bool showCheckBox => State?.showCheckBox ?? false;

        

        //all the documents that are already attached to the Register:
        public List<UI_Register_ListItem> LatestRevisionDocuments { get; set; }

        public string DocNumberNameConcatenated { get; set; }

        //current document:
        public UI_Register_ListItem CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                value?.ConcatDocumentName();
                _currentDocument = value;
            }
        } //UI field

        public UI_Register_ListItem _currentDocument { get; set; }

        public List<Status> statuses { get; private set; }

        //default constructor used by the explicit conversion operator:
        public CheckItem()
        {
        }
        public CheckItem(UI_CheckItem dbCheckItem, Register.Register register, CheckList parent):this()
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_CheckItem, CheckItem>());
            var mapper = cfg.CreateMapper();
            mapper.Map(dbCheckItem, this);

            LatestRevisionDocuments = register.GetLatestRevisionDocuments();

            //todo - this constraint has to become accurate when CheckItems will be attached to the revisions
            CurrentDocument = register.GetAllDocuments().SingleOrDefault(x => x.Document_ID == Document_ID);
            if(Document_ID != null && CurrentDocument == null) throw new DatabaseStateException(
                "CheckItem is attached to the document that doesn't belong to the Register. CheckItem_ID: "+CheckItem_ID);

            Enum.TryParse(parent.CheckType_Code, out CheckType_Code);
        }
        /// <summary>
        /// Used to copy editable field of the object coming from FE to the object stored in session
        /// </summary>
        public void CopyEditableFields(CheckItem checkItem)
        {
            this.CheckItem_Name = checkItem.CheckItem_Name;
            this.Document_ID = checkItem.Document_ID;
            this.Comment = checkItem.Comment;
        }
        public bool IsCompleted()
        {
            var completedStatusId = StatusesContainer.CheckItemStatus
                .Where(x => x.Status_Code == StatusesContainer.CheckItemStatusCode.wCLIa.ToString())
                .Select(x => x.Status_ID).First();
            return Status_ID == completedStatusId;
        }
        public CheckItem(WEB_MainDataEntities context, CheckList parent) : this()
        {
            T_CheckItem template;
            try
            {
                template = context.T_CheckItem.Single();
            }
            catch(InvalidOperationException ioe)
            {
                throw new DatabaseStateException("No template or multiple parent templates were found in T_CheckItem", ioe);
            }
            var cfg = new MapperConfiguration(c => c.CreateMap<T_CheckItem, CheckItem>());
            var mapper = cfg.CreateMapper();

            Enum.TryParse(parent.CheckType_Code, out CheckType_Code);

            mapper.Map(template, this);
        }
        public static explicit operator CheckItem(UI_CheckItem dbCheckItem)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_CheckItem, CheckItem>());
            var mapper = cfg.CreateMapper();
            return mapper.Map<CheckItem>(dbCheckItem);
        }

        public IResult<MsgIdPair> Update(string command)
        {
            if(command == null) throw new ArgumentNullException("Null command name provided for CheckItem.Update(command)");
            if (command != "Save")
            {
                State.Update(command);
            }
            else throw new NotImplementedException();

            return null;
        }
        public IResult<MsgIdPair> SaveNew(WEB_MainDataEntities context)
        {
            IResult<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();

            //todo - implement it with DB procedures
            return result;
        }

        public IResult<MsgIdPair> SaveExisting(WEB_MainDataEntities context)
        {
            IResult<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();

            //todo - implement it with DB procedures
            return result;
        }

        public object Clone()
        {
            var destination = (CheckItem) MemberwiseClone();

            //property state is created automatically when Status_Code is created
            //no need to copy LatestRevisionDocument - they have to point to the save List.
            //no need to copy CheckType - it's of value type

            destination.CurrentDocument = (UI_Register_ListItem)CurrentDocument?.Clone();

            return destination;
        }
    }
}