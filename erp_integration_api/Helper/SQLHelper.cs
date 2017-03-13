using Xcd.ERP.API.Common;
using Xcd.ERP.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace erp_integration_api.Helper
{
    public class SQLHelper
    {
        public static SqlConnection GetConnection()
        {
           return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

		public static SqlConnection GetDefaultConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
		}

		public static SqlConnection GetAdminConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnection"].ConnectionString);
		}

        public static bool ExecuteProcedure(string procedureName, Dictionary<string, string> sqlParams)
        {
          using (var con = SQLHelper.GetConnection())
            {
                con.Open();
                var command = new SqlCommand(procedureName, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (sqlParams.Count > 0)
                {
                    foreach (var sqlParam in sqlParams)
                    {
                        command.Parameters.AddWithValue("@" + sqlParam.Key, sqlParam.Value);
                    }
                }
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static int ExecuteQuery(string query, Dictionary<string, string> sqlParams)
        {
            using (var con = SQLHelper.GetConnection())
            {
                con.Open();
                var command = new SqlCommand(query, con);
                if (sqlParams!=null && sqlParams.Count > 0)
                {
                    foreach (var sqlParam in sqlParams)
                    {
                        command.Parameters.AddWithValue("@" + sqlParam.Key, sqlParam.Value);
                    }
                }
                return command.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExecuteQueryReturnReader(string query, Dictionary<string, string> sqlParams)
        {
            using (var con = SQLHelper.GetConnection())
            {
                con.Open();
                var command = new SqlCommand(query, con);
                if (sqlParams!=null && sqlParams.Count > 0)
                {
                    foreach (var sqlParam in sqlParams)
                    {
                        command.Parameters.AddWithValue("@" + sqlParam.Key, sqlParam.Value);
                    }
                }

                return command.ExecuteReader();
                
            }
        }

        public static DataSet ExecuteProcedureWithReturnDataSet(string procedureName, Dictionary<string, string> sqlParams)
        {
            var ds = new DataSet();
            SqlConnection connString;
            if (procedureName == Procedures.SPUserLogin)
            {
              connString = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
            else
            {
              connString = SQLHelper.GetConnection();
            }
            using (var con = connString)
            {
                var command = new SqlCommand(procedureName, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (sqlParams.Count > 0)
                {
                    foreach (var sqlParam in sqlParams)
                    {
                        command.Parameters.AddWithValue("@" + sqlParam.Key, sqlParam.Value);
                    }
                }
                var da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;

            }
        }
       
    }
}