using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SmartQA1._1._2.DB
{
	public class Repository
	{
		/*at this moment we don't know how authorisation will be implemented in this
            * application, so now when beeing created Repository is supplied with 
            * SQL string by the controller */
            
        String localSqlString =
        "Server = (local);" +
        "Database = DEV_STL_MainData;" +
        "User Id = DevWebServerUser;" +
        "Password = ShareMe724; ";
        
        String remoteSqlString =
		"Server = 10.131.72.32;" +
		"Database = DEV_STL_MainData;" +
		"User Id = WebServerUser;" +
		"Password = ShareWare724; ";
        
		String sqlConnectionString;
		SqlConnection myConnection;
		SqlDataReader result;

		private Repository(String sqlString)
		{
			this.sqlConnectionString = sqlString;
			//remove this mock when authorization is implemented and pass other string into the model
			this.sqlConnectionString = remoteSqlString;
		}
		//you have to use this method to create an instance of the Repository
		public static Repository createRepository(String sqlString)
		{
			//here will be implemented methods for user name and password validation
			return new Repository(sqlString);
		}
		//here establishing and dectruction connections is implemented
		public void connectDB()
		{
			try
			{
				if (myConnection != null && myConnection.State == System.Data.ConnectionState.Open)
				{
					System.Diagnostics.Debug.WriteLine("You've tried to open the connection which is already opened");
					return;
				}
				else
				{
					myConnection = new SqlConnection(sqlConnectionString);
					myConnection.Open();
				}
			}
			catch (SqlException DBEx)
			{
				System.Diagnostics.Debug.WriteLine("ERROR: SqlException while opening connection"+DBEx.Message);
			}
			catch (ArgumentException AEEx)
			{
				System.Diagnostics.Debug.WriteLine("ERROR: SQL ArgumentExcepstion while opening connection"+AEEx.Message);
			}
			if (myConnection.State == System.Data.ConnectionState.Open) System.Diagnostics.Debug.WriteLine("The connection is opened");
		}
		public void disconnectDB()
		{
			try
			{
				if (myConnection != null && myConnection.State == System.Data.ConnectionState.Closed)
				{
					System.Diagnostics.Debug.WriteLine("You've tried to close the connection which is already closed");
					return;
				}
				else myConnection.Close();
			}
			catch (SqlException DBEx)
			{
				System.Diagnostics.Debug.WriteLine("ERROR: SqlException while closing connection");
			}
			catch (ArgumentException AEEx)
			{
				System.Diagnostics.Debug.WriteLine("ERROR: SQL ArgumentExcepstion while closing connection");
			}
			if (myConnection.State == System.Data.ConnectionState.Closed) System.Diagnostics.Debug.WriteLine("The connection is closed");
		}
		private SqlDataReader getSqlData(SqlCommand myCommand)
		{
			System.Diagnostics.Debug.WriteLine("Running it");
			connectDB();
			myCommand.Connection = myConnection;
            try
            {
                result = myCommand.ExecuteReader();
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("SqlException: " + ex.Message);
            }

			return result;
		}

        public List<Object> fillModelTyped(object exampleModel, SqlCommand myCommand)
        {
            List<Object> outPutModelList = new List<object>();
            try
            {
                connectDB();
                result = getSqlData(myCommand);
                
                if(result!=null && result.HasRows)
                {
                    while (result.Read())
                    {
                        Type requiredModelType = exampleModel.GetType();
                        var newModel = Activator.CreateInstance(requiredModelType);
                        int i = 0;
                        foreach (var property in requiredModelType.GetProperties())
                        {
                                var _value = result.GetValue(i++);
                                if (_value == DBNull.Value) property.SetValue(newModel, null);
                                else property.SetValue(newModel, _value);
                            
                        }
                        outPutModelList.Add(newModel);
                    }
                    return outPutModelList;
                }
                else
                {
                    return null;
                }
                
            }
            finally
            {
                disconnectDB();
                result.Close();
            }
        }
        /* By default this method returns 2-dimensional collection of different objects
        the collection returned is transpiled to the data of the model 
        using methods of the model itself (if it's neccessary - sometimes model just
        retrieves data from the DB and passes it into the controller to be further
        passed by Json respond */
        [Obsolete("DEPRECATED - now in use only by ServiceController")]
        public List<List<object>> getData(SqlCommand myCommand)
        {
            try
            {
                List<List<object>> resultArray = new List<List<object>>();
                result = getSqlData(myCommand);

                if (result != null && result.HasRows)
                {
                    while (result.Read())
                    {
                        //beware - list<> doesn't implements IDisposable - it can affect perfomance
                        List<object> row = new List<object>();
                        for (int j = 0; j < result.FieldCount; j++) row.Add(result.GetValue(j));
                        resultArray.Add(row);
                    }
                }
                return resultArray;
            }
            finally
            {
                disconnectDB();
                result.Close();
            }
        }
        
    }
}


