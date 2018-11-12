using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartQA1._1._2.DB.StoredProcedures
{
    public class StoredProcedureAdapter
    {
        private DbContext context;
        private Type contextType;
        private ObjectContext objectContext;

        public StoredProcedureAdapter(DbContext context)
        {
            this.context = context;
            //retieving the objectContext from its incapsulation - DbContext
            objectContext = ((IObjectContextAdapter)context).ObjectContext;
            contextType = context.GetType();
        }
        public DbContext GetContext()
        {
            return context;
        }
        /// <summary>
        /// Вызывает хранимую процедуру с параметрами
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">Набор сообщений об ошибках после вызова хранимой процедуры</param>
        /// <param name="dbSchemaName">Имя схемы данных в базе данных</param>
        /// <param name="dbContextProcedureName">Имя метода в контексте Entity Framework (имя хранимой процедуры в базе данных)</param>
        /// <param name="inputValues">Входящие параметры хранимой процедуры</param>
        /// <returns></returns>
        public IResult<T> ExecuteStoredProcedure<T>(IResult<T> result, string dbSchemaName, string dbContextProcedureName, params object[] inputValues) where T : IDataSet<T>
        {
            //COLLECTING ALL THE NECESSARY INFORMATION FROM THE DB CONTEXT ITSELF

            //retrieving the stored procedure function and retrieving all its parameters
            MethodInfo dbContextStoredProcedure = contextType.GetMethod(dbContextProcedureName);
            if (dbContextStoredProcedure == null) throw new ArgumentException("No procedure with name " + dbContextProcedureName + " exists in this context.");

            /*retrieving all the input and output
            parameters from the signature of the DbContext method, associated with the specified procedure*/
            List<ParameterInfo> inputParameters = dbContextStoredProcedure.GetParameters()
                .Where(parameter => parameter.ParameterType.Name != "ObjectParameter").ToList();

            List <ParameterInfo> outputParameters = dbContextStoredProcedure.GetParameters()
                .Where(parameter => parameter.ParameterType.Name == "ObjectParameter").ToList();

            //check if the amount of required parameters equals the amount of this method arguments:
            if (inputParameters.Count() > inputValues.Count()) throw new ArgumentException("Not all parameters for the current Stored Procedure are specified");
            if (inputParameters.Count() > inputValues.Count()) throw new ArgumentException("Too many parameters for the current Stored Procedure were specified");

            IDbCommand cmd = context.Database.Connection.CreateCommand();
            cmd.Transaction = context.Database.CurrentTransaction.UnderlyingTransaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = $"{ dbSchemaName }.{ dbContextProcedureName }";

            /*adding input parameters -  DbParameter(abstract) for each Stored procedure parameter 
                * and for each argument specified: */
            var inputParameterEnumerator = inputParameters.GetEnumerator();
            var argumentEnumerator = inputValues.GetEnumerator();
            while (inputParameterEnumerator.MoveNext() && argumentEnumerator.MoveNext())
            {
                IDbDataParameter cmdParam = cmd.CreateParameter();
                cmdParam.ParameterName = "@"+inputParameterEnumerator.Current.Name;
                cmdParam.Value = argumentEnumerator.Current==null?DBNull.Value : argumentEnumerator.Current;
                cmd.Parameters.Add(cmdParam);
            }

            /*adding output parameters*/
            foreach (var param in outputParameters)
            {
                IDbDataParameter cmdParam = cmd.CreateParameter();
                cmdParam.ParameterName = "@"+param.Name;
                cmdParam.Direction = ParameterDirection.Output;
                cmdParam.Size = 200; //for varchar output
                cmd.Parameters.Add(cmdParam);
            }
            //EXECUTING THE STORED PROCEDURE
            DbDataReader reader = (DbDataReader)cmd.ExecuteReader();

            //RETRIEVING THE RESULT - to the non-generic class
            do
            {
                /*using ObjectContext instance of the current context to translate the 
                    * returning from the DbDataReader*/
                ObjectResult<T> singleDataSet = 
                    objectContext
                    .Translate<T>(reader);
                result.AddDataSet(singleDataSet);
            }
            while (reader.NextResult());

            //retrieve the output values from the DbCommand:
            List<SqlParameter> outputParametersWithValue = new List<SqlParameter>();
            foreach (var param in outputParameters)
            {
                outputParametersWithValue.Add((SqlParameter)cmd.Parameters["@"+param.Name]);
            }
            result.AddOutput(dbContextProcedureName, outputParametersWithValue.ToArray());

            return result;
        }
    }
}