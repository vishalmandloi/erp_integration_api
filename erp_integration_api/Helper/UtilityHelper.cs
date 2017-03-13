using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace erp_integration_api.Helper
{
    public class UtilityHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        #region mapperfunction new

        public static Guid? MapGuid(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return null;
            return reader.GetGuid(reader.GetOrdinal(columnName));
        }

        public static string MapString(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return null;
            return reader[columnName].ToString();
        }

        public static int? MapInt(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return default(int);
            return (Int32)reader[columnName];
        }

        public static Int16? MapSmallInt(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return null;
            return (Int16)reader[columnName];
        }

        public static decimal? MapDecimal(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return default(Decimal);
            return reader.GetDecimal(reader.GetOrdinal(columnName));
        }

        public static DateTime? MapDateTime(IDataRecord reader, string columnName)
        {
            // DateTime dt;
            if (reader[columnName] == DBNull.Value)
                return default(DateTime);
            return reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        public static bool? MapBool(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return null;
            return (bool)reader[columnName];
        }

        public static byte[] MapByte(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return default(byte[]);
            return (byte[])reader[columnName];
            // return (byte[])((!reader.IsDBNull(columnNumber)) ? reader.GetValue(columnNumber) : default(byte[]));
        }

        public static T GetValue<T>(object value)
        {
            if (value == null || value == DBNull.Value)
                return default(T);
            return (T)value;
        }

        public static char? MapChar(IDataRecord reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return null;
            var value = reader.GetValue(reader.GetOrdinal(columnName));
            return Char.Parse(value.ToString());
        }

        public static object GetSQLParameterValue(object obj)
        {
            return obj ?? DBNull.Value;
        }
        #endregion
    }
}