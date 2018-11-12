using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Models.Register
{
    public class Register
    {
        public Guid Register_ID { get; set; }
        public string Register_Code { get; set; }
        public DateTime Register_Date { get; set; }
        public uint Current_Iteration { get; set; }
        public Guid Status_ID { get; set; } 
        public string Status_Code { get; set; }
        public Guid? Contractor_ID { get; set; }
        public string Contractor_Code { get; set; }
        public Guid? SubContractor_ID { get; set; }
        public string SubContractor_Code { get; set; }
        public Guid? Customer_ID { get; set; }
        public string Customer_Code { get; set; }
        public string Complex { get; set; }
        public string Project { get; set; }
        public int UI_PageNumber { get; set; }
        public string Status_Description_Rus { get; set; }
        public Guid? WorkPackage_ID { get; set; }
        public string WorkPackage_Code { get; set; }

        //public List<Guid> Marka_ID { get; set; } = new List<Guid>();

        //public List<Guid> TitleObject_ID { get; set; } = new List<Guid>();

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        public List<TitleObject> TitleObjects { get; set; }

        public List<Revision> Revisions { get; private set; }

        public Revision LatestRevision => Revisions[(int)Current_Iteration - 1];

        public Dictionary<Guid, string> AvailableStatuses { get; set; }
        public List<WorkPackage> WorkPackages { get; set; }
        public List<Marka> Markas { get; set; }

        public CheckListWrapper ReviewWrapper { get; set; }
        public CheckListWrapper ApprovementWrapper { get; set; }

        public bool IsEditEnabled { get; set; }
        public bool IsStatusChangeEnabled { get; set; }

        /// <summary>
        /// Default parameterless constructor
        /// </summary>
        public Register()
        {
        }

        /// <summary>
        /// Used by the controller to create new document or retrieve the existing document for editing
        /// </summary>
        public Register(WEB_MainDataEntities context, Guid? Register_ID = null)
        {
            if (Register_ID != null)
            {
                RetrieveExistingRegister(context, (Guid)Register_ID);
            }
            else CreateNewRegister(context);

            //initializing Revisions:
            GetRevisions(context);

           //initializing CheckTables:
            this.GetCheckTables(context);

            //initializing available Statuses dictionary:
            GetAvailableStatuses(context);

            //Get TitleObject list:
            TitleObjects = context.TitleObjects.OrderBy(x => x.ReportOrder).ToList();

            //Get WorkPackage list:
            WorkPackages = context.WorkPackages.OrderBy(x => x.WorkPackage_Code).ToList();

            //get Marka list:
            Markas = context.Markas.OrderBy(x => x.ReportOrder).ToList();

            //check if Register can be edited - defined in by its Status
            try
            {
                IsEditEnabled = !(bool) context.Status.First(x => x.Status_ID == Status_ID).EntityLocked;
            }
            catch (InvalidOperationException ioe) //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first?view=netframework-4.7.2#System_Linq_Enumerable_First__1_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Boolean__
            {
                throw new DatabaseStateException(
                    "No Status found in view or Status or Status_ID of the template " +
                    "T_Register_List is invalid. Status of the template: " + Status_ID,
                    ioe);
            }
        }
        /// <summary>
        /// Used to create new Register
        /// </summary>
        private void CreateNewRegister(WEB_MainDataEntities context)
        {
            T_Register_List template = null;
            try
            {
                template = context.T_Register_List.Single();
            }
            catch (InvalidOperationException ioe)
            {
                var databaseStateException = new DatabaseStateException(
                    "No parent template or more than one found " +
                    "for T_Register_List in T_Register_List view, ioe", ioe);
                throw databaseStateException;
            }

            var cfg = new MapperConfiguration(c => c.CreateMap<T_Register_List, Register>());
            var mapper = cfg.CreateMapper();
            mapper.Map(template, this);

            Register_Date = DateTime.Now;
            Register_Code = context.Register_SequenceNumber().First().ToString();
            IsStatusChangeEnabled = false;

            if (Status_ID == null)
                throw new DatabaseStateException(
                    "Null status was specified for Register template. Template ID: " + template.Register_ID);
        }
        /// <summary>
        /// Used to retrieve the existing register for editings
        /// </summary>
        private void RetrieveExistingRegister(WEB_MainDataEntities context, Guid Register_ID)
        {
            var dbRegister = context.UI_Register_List.First(x => x.Register_ID == Register_ID);
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_Register_List, Register>());
            var mapper = cfg.CreateMapper();

            mapper.Map(dbRegister, this);

            if (Status_ID == null)
                throw new DatabaseStateException(
                    "Null status was specified for Register. Register_ID: "+Register_ID);
        }
        /// <summary>
        /// Get available statuses for the current Register based on the current Status_ID of the egister
        /// </summary>
        /// <param name="context"></param>
        public void GetAvailableStatuses(WEB_MainDataEntities context)
        {
            AvailableStatuses = new Dictionary<Guid, string>();
            var dbAvailableStatuses = context.UI_StatusRelation.Where(x => x.FromStatus_ID == Status_ID);
            AvailableStatuses.Add(Status_ID, Status_Description_Rus);
            foreach (var avai in dbAvailableStatuses)
            {
                AvailableStatuses.Add(avai.ToStatus_ID, avai.ToStatus);
            }
        }
        public void SaveCheckItem(CheckItem item, CheckType checkType)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fills the current Register.Revisions property
        /// </summary>
        public void GetRevisions(WEB_MainDataEntities context)
        {
            if (Current_Iteration == 0)
            {
                string message;
                if (Register_ID == Guid.Empty)
                    message = "Not valid Register Current_Iteration was specified in the template";
                else message = "Not valid Register Current_Iteration - it equals 0. Register_ID: " + Register_ID;
                throw new DatabaseStateException(message);
            }

            //invoking Revisions constructor
            Revisions = new List<Revision>();
            for (uint i = 0; i < Current_Iteration; i++)
            {
                Revisions.Add(new Revision(this, i, context));
            }

            //escape from new Register
            if (Register_ID == Guid.Empty) return;

            //retrieving documents could be handled in Revisions themselves, but 
            //it'll take much more requests to the database
            var documents = context.UI_Register_ListItem.Where(x => x.Register_ID == Register_ID)
                .OrderBy(x => x.Document_Position).ToList();
            foreach (var document in documents)
            {
                try
                {
                    //because Register and Document iteration starts with 1
                    Revisions[document.Document_Iteration - 1].AddDocument(document);
                }
                catch (IndexOutOfRangeException iore)
                {
                    var dse = new DatabaseStateException(
                        "Document iteration is greater then current register iteration in UI_Register_ListItem. Document_ID: " +
                        document.Document_ID, iore);
                    throw dse;
                }
                catch (InvalidOperationException ioe)
                {
                    var dse = new DatabaseStateException(
                        "Iteration was null for the UI_Register_ListItem. Document_ID: " +
                        document.Document_ID, ioe);
                    throw dse;
                }
            }
        }
        public List<UI_Register_ListItem> GetLatestRevisionDocuments()
        {
            return LatestRevision.Documents;
        }

        public List<UI_Register_ListItem> GetAllDocuments()
        {
            List<UI_Register_ListItem> allDocuments = new List<UI_Register_ListItem>();
            foreach(var revision in Revisions)
            allDocuments.AddRange(revision.Documents);
            return allDocuments;
        }
        public Revision GetRevision(uint Iteration)
        {
            return Revisions[(int)Iteration];
        }
        /// <summary>
        /// Add document for the current Register
        /// </summary>
        public bool AddDocument(WEB_MainDataEntities context, Guid Document_ID)
        {
            return LatestRevision.AddDocument(context, Document_ID);
        }

        /// <summary>
        /// Deleted document from NamedList for the current Register
        /// </summary>
        /// <param name="Document_ID"></param>
        public void RemoveDocument(Guid Document_ID)
        {
            LatestRevision.RemoveDocument(Document_ID);
        }
        public static List<UI_Register_List> GetList()
        {
            using (var context = new WEB_MainDataEntities())
            {
                return context.UI_Register_List.OrderBy(x => x.Register_Code).ToList();
            }
        }
        

        //public IResult<T> Insert<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        //{
        //    return spa.ExecuteStoredProcedure(
        //        result,
        //        "dbo",
        //        "Register_Insert",
        //        "0",
        //        user.Id,
        //        Register_Code,
        //        Register_Date,
        //        1, //Current_Iteration
        //        Customer_ID,
        //        Contractor_ID,
        

        //        SubContractor_ID,

        //        ...,


        //    );

        //}


        private IResult<T> Register_to_Status_Delete<T>(StoredProcedureAdapter spa, IResult<T> result, Guid status)
            where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_To_Status_Delete",
                UserId,
                status
            );
        }

        private IResult<T> Register_To_Status_Insert<T>(StoredProcedureAdapter spa, IResult<T> result, Guid status)
            where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_To_Status_Insert",
                "0",
                UserId,
                Register_ID,
                status,
                Current_Iteration
            );
        }

        public void CheckCriticalProperties()
        {
            if (Current_Iteration == 0) throw new ArgumentException("Current_Iteration equals 0. Register_ID: " + Register_ID);
            if (Register_ID == Guid.Empty) throw new ArgumentException("Current Register_ID is empty");
        }

    }
}