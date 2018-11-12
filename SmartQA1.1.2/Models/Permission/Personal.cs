using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Models.Login;
using AutoMapper;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Service;
using static SmartQA1._1._2.Service.ModelStateSerializer;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.Models.Permission
{
    public class Personal
    {
        public string formName { get; set; }
        public Guid Person_ID { get; set; }
        public string Person_Code { get; set; }

        public Guid? Employee_ID { get; set; }
        public string Employee_Code { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }

        public Guid? AppUser_ID { get; set; }

        public Guid? Position_ID { get; set; }
        public string Position_Description { get; set; }

        public Guid? Contragent_ID { get; set; }
        public string Description_Rus { get; set; }

        public List<UI_Contragent> Contragents { get; set; }
        public List<UI_Position> Positions { get; set; }

        public Guid Document_ID { get; set; }
        public string Document_Number { get; set; }
        public DateTime? Document_Date { get; set; }
        public string DocumentType_Code { get; set; }
        public string Document_Name { get; set; }
        public string Document_Title { get; set; }

        public string Title_Description_Rus { get; set; }
        public string Marka_Description_Rus { get; set; }

        public List<permDbTitleObject> TitleObject { get; set; }
        public List<permDbMarka> Marka { get; set; }

        private IResult<MsgIdPair> result;
        private StoredProcedureAdapter spAdapter;
        private DEV_WEB_MainDataEntities context;

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        /// <summary>
        /// Default parameterless constructor used by the AutoMapper
        /// </summary>
        public Personal()
        {
        }
        /// <summary>
        /// Used by the controller to create new person or retrieve the existing person for editing
        /// </summary>
        public Personal(DEV_WEB_MainDataEntities context, Guid? Employee_ID = null)
        {
            this.context = context;

            if (Employee_ID.HasValue && Employee_ID.Value != Guid.Empty)
            {
                RetrieveExistingPerson((Guid)Employee_ID);
            }
            //Get Contragents list:
            Contragents = context.UI_Contragent.OrderBy(x => x.Contragent_Code).ToList();
            //Get Contragents list:
            Positions = context.UI_Position.OrderBy(x => x.Position_Code).ToList();
            //Get TitleObjects list:
            TitleObject = context.TitleObject.OrderBy(x => x.TitleObject_Code).ToList();
            //Get Marks list:
            Marka = context.Marka.OrderBy(x => x.Marka_Code).ToList();
            Document_Number = this.context.Document_SequenceNumber().FirstOrDefault().ToString();
            Document_Date = DateTime.Now;
            //else CreateNewPerson();

            //DocumentTypes = context.DocumentTypes.OrderBy(x => x.DocumentType_Code).ToList();
            //DocumentStatuses = context.Status.Where(x => x.StatusEntity == "Document").ToList();

            //whether document edit enabled is defined on it's status
            //try
            //{
            //    IsEditEnabled = !(bool)context.Status.First(x => x.Status_ID == Status_ID).EntityLocked;
            //}
            //catch (InvalidOperationException ioe) //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first?view=netframework-4.7.2#System_Linq_Enumerable_First__1_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Boolean__
            //{
            //    throw new DatabaseStateException(
            //        "No Status found in view Status or Status_ID of the template " +
            //        "T_Document_List is invalid. Status of template: " + Status_ID,
            //        ioe);
            //}
        }
        /// <summary>
        /// Used to retrieve the existing person for editings
        /// </summary>
        private void RetrieveExistingPerson(Guid Employee_ID)
        {
            var dbPerson = context.UI_Personal.FirstOrDefault(x => x.Employee_ID == Employee_ID);
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_Personal, Personal>());
            var mapper = cfg.CreateMapper();

            mapper.Map(dbPerson, this);
        }
        public static List<UI_Personal> GetList()
        {
            using (DEV_WEB_MainDataEntities db = new DEV_WEB_MainDataEntities())
            {
                return db.UI_Personal.OrderBy(x => x.Person_Code).ToList();
            }
        }

        public IResult<MsgIdPair> SaveNew(DEV_WEB_MainDataEntities context)
        {
            var newPerson = new Personal(context);

            using (var db = new DEV_WEB_MainDataEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    result = new MultipleSetsResultIdError<MsgIdPair>();
                    spAdapter = new StoredProcedureAdapter(db);

                    try
                    {
                        //INSERT PERSON
                        InsertPerson(spAdapter, result);
                        if (!result.isValid) return result;
                        //INSERT COMPANY and POSITION
                        Person_ID = (Guid)result.GetLastObject();
                        InsertEmployee(spAdapter, result, db);
                        if (!result.isValid) return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        new Logger(ex).Log();
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
                return result;
            }
        }

        public IResult<MsgIdPair> SaveNewDoc(DEV_WEB_MainDataEntities context)
        {
            var newPerson = new Personal(context);

            using (var db = new DEV_WEB_MainDataEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    result = new MultipleSetsResultIdError<MsgIdPair>();
                    spAdapter = new StoredProcedureAdapter(db);

                    try
                    {
                        //INSERT DOCUMENT
                        InsertDocument(spAdapter, result, context);
                        if (!result.isValid) return result;

                        Document_ID = (Guid)result.GetLastObject();

                        //INSERT TITLES
                        string AttributeType_ID = "F0A9EA74-D033-4643-81CA-3CE00EEC92A1";
                        foreach (var title in TitleObject)
                        {
                            InsertDocumentAttribute(spAdapter, result, AttributeType_ID, $"{ title.TitleObject_ID }");
                            if (!result.isValid) return result;
                        }

                        //INSERT MARKS
                        AttributeType_ID = "3916F7BE-2B1E-48E3-9050-B78649703CEC";
                        foreach (var mark in Marka)
                        {
                            InsertDocumentAttribute(spAdapter, result, AttributeType_ID, $"{ mark.Marka_ID }");
                            if (!result.isValid) return result;
                        }

                        //Relation Employee to Document
                        EmployeeToDocumentInsert(spAdapter, result);
                        if (!result.isValid) return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        new Logger(ex).Log();
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
                return result;
            }
        }

        public IResult<MsgIdPair> SaveExisting(DEV_WEB_MainDataEntities context)
        {
            using (var db = new DEV_WEB_MainDataEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    result = new MultipleSetsResultIdError<MsgIdPair>();
                    spAdapter = new StoredProcedureAdapter(db);

                    try
                    {
                        //UPDATE PERSON
                        UpdatePerson(spAdapter, result);
                        if (!result.isValid) return result;
                        //UPDATE COMPANY and POSITION
                        UpdateEmployee(spAdapter, result);
                        if (!result.isValid) return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        new Logger(ex).Log();
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }

                return null;
            }
        }
        private void InsertPerson<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Person_Insert",
                "0",
                UserId,
                //Person_Code (натуральный ключ)
                ToolKit.NaturalKey("_", FirstName, SecondName, LastName, $"{BirthDate:dd.MM.yyyy}"),
                FirstName,
                SecondName,
                LastName,
                ShortName,
                DateKit.DateTime2Sql(BirthDate)
            );
        }
        private void InsertDocument<T>(StoredProcedureAdapter spa, IResult<T> result, DEV_WEB_MainDataEntities context) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "abd",
                "Document_Insert",
                "0", //Row Status
                UserId,
                "33893566-0D11-49C2-9F52-1DC2C49B0D0C", //DocumentType_ID
                Document_Name,
                Document_Title,
                "0", //Document Revision
                null, //Responsible Employee ID
                Document_Number,
                Document_Date,
                //Document_Parent_Id из [abd].[Template_Act1_Doc] или другого шаблона (другой вьюхи) документа
                "9A3F6FF8-8A8F-4F89-93F3-84A00A1DACCC"
            );
        }
        private void InsertDocumentAttribute<T>(StoredProcedureAdapter spa, IResult<T> result, string AttributeType_ID, string DocumentAttribute_Value) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "abd",
                "DocumentAttribute_Insert",
                "0",
                UserId,
                DocumentAttribute_Value,
                AttributeType_ID,
                Document_ID,
                "1",
                null
            );
        }
        private void EmployeeToDocumentInsert<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Employee_to_Document_Insert",
                "0",
                UserId,
                Employee_ID,
                Document_ID
            );
        }
        private void InsertEmployee<T>(StoredProcedureAdapter spa, IResult<T> result, DEV_WEB_MainDataEntities context) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Employee_Insert",
                "0",
                UserId,
                //Employee_Code (натуральный ключ)
                context.Employee_SequenceNumber().FirstOrDefault(),
                Person_ID,
                Position_ID,
                AppUser_ID,
                Contragent_ID
            );
        }
        private void UpdatePerson<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Person_Update",
                Person_ID,
                "0",
                UserId,
                Person_Code,
                FirstName,
                SecondName,
                LastName,
                ShortName,
                DateKit.DateTime2Sql(BirthDate)
            );
        }
        private void UpdateEmployee<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Employee_Update",
                Employee_ID,
                "0",
                UserId,
                Employee_Code,
                Person_ID,
                Position_ID,
                AppUser_ID,
                Contragent_ID
            );
        }
    }
}