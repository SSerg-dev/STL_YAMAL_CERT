using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

namespace SmartQA1._1._2.DB.StoredProcedures
{
    public interface IResult<T> where T: IDataSet<T>
    {
        //used by the StoredProcedureAdapter to add multiple data sets, returned by EF
        void AddDataSet(ObjectResult<T> inputResult);

        //used by the StoredProcedureAdapter to add stored procedure output parameters
        void AddOutput(string procedureName, params SqlParameter[] outputParameters);

        //used by Model to decide if the transaction will be rolled back
        bool isValid { get; }

        //used by Model to add information about the Application exceptions
        void AddException(Exception ex);

        //used by Model to add information about Business logic error:
        void AddError(string errorMessage);

        //used by Model to retrieve the last object Guid - in case the object is parent of others
        Guid? GetLastObject();

        //used by the Model to add guid of the newly created parent object
        void AddParentId();

        //used to create a representation for FE and then to be send via controller
        string Serialize();

        //used to create a representation for DevExpress
        string ToString();
    }
}
