using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.Objects;
using Newtonsoft.Json;
using System.Data.SqlClient;
using SmartQA1._1._2.Service;
using System.Runtime.ExceptionServices;
using System.Text;
using SmartQA1._1._2.Logging;

namespace SmartQA1._1._2.DB.StoredProcedures
{
    public class MultipleSetsResultIdError<T> : IResult<T> where T:IDataSet<T>
    {
        protected readonly List<T> resultSet = new List<T>();
        private readonly List<SpOutput> spOutputs = new List<SpOutput>();
        private Guid? parentId;
        private struct SpOutput
        {
            public String Object_ID;
            public bool IsError;
        }
        public bool isValid { get; set; } = true;


        public void AddDataSet(ObjectResult<T> inputResult)
        {
            var result = inputResult.ToList();

            foreach (var dataSet in result)
            {
                resultSet.Add(dataSet);
            }
        }
        public void AddException(Exception ex)
        {
            IDataSet<T> t = Activator.CreateInstance<T>();
            resultSet.Add(t.ConvertFromException(ex));
            isValid = false;
        }
        public void AddError(string errorMessage)
        {
            IDataSet<T> t = Activator.CreateInstance<T>();
            resultSet.Add(t.ConvertFromErrorMessage(errorMessage));
            isValid = false;
        }
        public virtual void AddOutput(string procedureName, params SqlParameter[] outputParameters)
        {
            string o_Object_ID = null;
            bool o_IsError = false;

            foreach (var param in outputParameters)
            {
                if (param.ParameterName == "@o_Entity_ID")
                    o_Object_ID =
                    param.Value == DBNull.Value ?
                    null :
                    (string)param.Value;
                else
                    if (param.ParameterName == "@o_IsError")
                        o_IsError = ((string)param.Value) == "1";
                    else
                    {
                        var ex = new ArgumentException(
                            $"Not valid parameter came from " +
                            $"{procedureName} parameterName: " +
                            $"{param.ParameterName}");
                        throw ex;
                    }
            }
            spOutputs.Add(new SpOutput { Object_ID=o_Object_ID, IsError = o_IsError });

            //if isValid property have been set to "false" it'll never return to "true" value
            isValid &= !o_IsError;
        }
        public Guid? GetLastObject()
        {
            var lastGuid = spOutputs.Last().Object_ID;
            if (lastGuid != null)
            try
            {
                return Guid.Parse(lastGuid);
            }
            catch (FormatException fex)
            {
                fex.Data.Add("Guid format exception",
                    "Not valid db guid format returned from the DB as Entity_ID after executing stored procedure");
                new Logger(fex).Log();
                throw;
            }
            return null;
        }
        public string Serialize()
        {
            var FErepresentation =
                new
                {
                    resultSet = this.resultSet,
                    isValid = this.isValid,
                    parentId = this.parentId
                };
            return JsonConvert.SerializeObject(FErepresentation);
        }
        public void AddParentId()
        {
            parentId = GetLastObject();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in resultSet)
            {
                sb.Append(item.ToString());
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}