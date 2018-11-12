using System;
using System.Data.SqlClient;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.DB.StoredProcedures
{
    public class UserGetResult<T> : MultipleSetsResultIdError<T> where T: IDataSet<T>
    {
        private readonly Guid userId;
        public string ShortName;
        public Guid? Division_ID;
        public string Division_Name;
        public string Role_Code;

        public UserGetResult(Guid? userId)
        {
            if(userId == null) throw new ArgumentNullException("UserId is null");
            this.userId = (Guid) userId;
        }

        public override void AddOutput(string procedureName, params SqlParameter[] outputParameters)
        {
            foreach (var param in outputParameters)
            {
                switch (param.ParameterName)
                {
                    case "@o_Role_Code":
                        Role_Code = param.Value == DBNull.Value ? null : (string)param.Value;
                        break;
                    case "@o_Division_ID":
                        Division_ID = param.Value == DBNull.Value ? null : Guid.Parse(param.Value.ToString()) as Guid?;
                        break;
                    case "@o_Division_Name":
                        Division_Name = param.Value == DBNull.Value ? null : param.Value as string;
                        break;
                    case "@o_Person_ShortName":
                        ShortName = param.Value == DBNull.Value ? null : param.Value as string;
                        break;
                    case "@o_IsError":
                        isValid = !(param.Value == DBNull.Value || param.Value is bool b && b);
                        break;
                    default:
                        throw new ArgumentException(
                            $"Not valid parameter came from " +
                            $"{procedureName} parameterName: " +
                            $"{param.ParameterName}");
                }
            }
        }

    }
}