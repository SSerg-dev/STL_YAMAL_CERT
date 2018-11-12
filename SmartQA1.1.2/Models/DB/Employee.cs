using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.Authentication;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Service;

namespace SmartQA1._1._2.DB.PermissionDb
{
    public partial class Employee
    {
        public string FullName => Person == null ? "" : String.Join(" ", Person.LastName, Person.FirstName, Person.SecondName);

        private void UpdatePerson<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Person_Update",
                Person_Id,
                "0",
                User.GetFromContext(HttpContext.Current).Id,
                Person.Person_Code,
                Person.FirstName,
                Person.SecondName,
                Person.LastName,
                Person.ShortName,
                DateKit.DateTime2Sql(Person.BirthDate)
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
                User.GetFromContext(HttpContext.Current).Id,
                Employee_Code,
                Person_Id,
                Position_Id,
                AppUser_Id,
                Contragent_ID
            );
        }

        private void InsertPerson<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Person_Insert",
                "0",
                User.GetFromContext(HttpContext.Current).Id,
                //Person_Code (натуральный ключ)
                ToolKit.NaturalKey("_", Person.FirstName,
                    Person.SecondName,
                    Person.LastName, $"{Person.BirthDate:dd.MM.yyyy}"),
                Person.FirstName,
                Person.SecondName,
                Person.LastName,
                Person.ShortName,
                DateKit.DateTime2Sql(Person.BirthDate)
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
                User.GetFromContext(HttpContext.Current).Id,
                //Employee_Code (натуральный ключ)
                context.Employee_SequenceNumber().FirstOrDefault(),
                Person_Id,
                Position_Id,
                AppUser_Id,
                Contragent_ID
            );
        }
        private void DeletePerson<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Person_Delete",
                User.GetFromContext(HttpContext.Current).Id,
                Person_Id                
            );
        }

        private void DeleteEmployee<T>(StoredProcedureAdapter spa, IResult<T> result, DEV_WEB_MainDataEntities context) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Employee_Delete",
                Employee_ID,
                User.GetFromContext(HttpContext.Current).Id                
            );
        }

        public void Save()
        {
            using (var db = new DEV_WEB_MainDataEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var result = new MultipleSetsResultIdError<MsgIdPair>();
                    var spAdapter = new StoredProcedureAdapter(db);

                    try
                    {
                        if (Employee_ID == Guid.Empty)
                        {
                            //INSERT PERSON
                            InsertPerson(spAdapter, result);
                            if (!result.isValid) throw new Exception();
                            //INSERT COMPANY and POSITION
                            Person.Person_ID = Person_Id = (Guid)result.GetLastObject();
                            InsertEmployee(spAdapter, result, db);
                            if (!result.isValid) throw new Exception();
                        }
                        else
                        {
                            //UPDATE PERSON
                            UpdatePerson(spAdapter, result);
                            if (!result.isValid) throw new Exception();
                            //UPDATE COMPANY and POSITION
                            UpdateEmployee(spAdapter, result);
                            if (!result.isValid) throw new Exception();                            
                        }
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

        }

        public void Delete()
        {
            using (var db = new DEV_WEB_MainDataEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var result = new MultipleSetsResultIdError<MsgIdPair>();
                    var spAdapter = new StoredProcedureAdapter(db);

                    try
                    {
                        DeleteEmployee(spAdapter, result, db);
                        if (!result.isValid) throw new Exception();

                        DeletePerson(spAdapter, result);
                        if (!result.isValid) throw new Exception();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
             
        }


    }
}