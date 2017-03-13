using Xcd.ERP.API;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Collections.Generic;

namespace Xcd.ERP.API.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class Utility
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

     

        public static Guid ConvertStringToGuid(string guid)
		{
			Guid id;
			Guid.TryParse(guid, out id);
			return id;
		}

		public static string GetStringData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetString(columnNumber).Trim() : default(string);
		}


		public static char GetCharData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetChar(columnNumber) : default(char);
		}


		public static DateTime GetDateTimeData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetDateTime(columnNumber) : default(DateTime);
		}


		public static int GetIntegerData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetInt32(columnNumber) : default(Int32);
		}

		public static short GetSortData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetInt16(columnNumber) : default(Int16);
		}


		public static decimal GetDecimalData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetDecimal(columnNumber) : default(Decimal);
		}

		public static Guid GetGuidData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetGuid(columnNumber) : default(Guid);
		}

		public static byte[] GetByteData(SqlDataReader reader, int columnNumber)
		{
			return (byte[])((!reader.IsDBNull(columnNumber)) ? reader.GetValue(columnNumber) : default(byte[]));
		}

		public static bool GetBoolData(SqlDataReader reader, int columnNumber)
		{
			return (!reader.IsDBNull(columnNumber)) ? reader.GetBoolean(columnNumber) : default(Boolean);
		}

		public static DateTime? checkDefaultDateTime(DateTime? dateTime)
		{
			return (dateTime != new DateTime()) ? dateTime : null;
		}

		public static Guid? checkDefaultGuid(Guid? guid)
		{
			return (guid != new Guid()) ? guid : null;
		}






		#region mapper function new
		public static Guid? MapGuid(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader.GetGuid(reader.GetOrdinal(columnName));
				}
			} return null;
		}

		public static string MapString(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{

				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader[columnName].ToString();
				}
			} return null;
		}

		public static char? MapChar(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					var value = reader.GetValue(reader.GetOrdinal(columnName));
					return Char.Parse(value.ToString());
				}
			} return null;
		}

		public static bool MapBool(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return false;
				}
				else
				{
					return (bool)reader[columnName];
				}
			} return false;
		}

		public static int? MapInt(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader.GetInt32(reader.GetOrdinal(columnName));
				}
			} return null;
		}

		public static Int16? MapInt16(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader.GetInt16(reader.GetOrdinal(columnName));
				}
			} return null;
		}

		public static short? MapShort(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader.GetInt16(reader.GetOrdinal(columnName));

				}
			} return null;

		}

		public static byte[] MapByte(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return default(byte[]);
				}
				else
				{
					return (byte[])reader[columnName];

				}
			} return default(byte[]);
		}

		private static bool HasColumn(IDataRecord dr, string columnName)
		{
			for ( int i = 0; i < dr.FieldCount; i++ )
			{
				if ( dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase) )
					return true;
			}
			return false;
		}

		internal static float? MapReal(IDataRecord reader, string columnName)
        {
            if (HasColumn(reader, columnName))
            {
                if (reader[columnName] == DBNull.Value)
                {
                    return null;
                }
                else
                {

					return (float)reader.GetFloat(reader.GetOrdinal(columnName));
                }
            }
            return null;
        }

        public static decimal? MapDecimal(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader.GetDecimal(reader.GetOrdinal(columnName));
				}
			} return null;
		}

		public static DateTime? MapDateTime(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				// DateTime dt;
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return reader.GetDateTime(reader.GetOrdinal(columnName));
				}
			} return null;
		}

		public static T GetValue<T>(object value)
		{
			if ( value == null || value == DBNull.Value )
				return default(T);
			else
				return (T)value;
		}
		///
		//public static float MapFloat(IDataRecord reader, string columnName)
		//{
		//	if ( HasColumn(reader, columnName) )
		//	{
		//		if ( reader[columnName] == DBNull.Value )
		//			return default(float);
		//		return reader.GetFloat(reader.GetOrdinal(columnName));
		//	} return default(float);
		//}

		public static float? MapFloat(IDataRecord reader, string columnName)
		{
			if ( HasColumn(reader, columnName) )
			{
				if ( reader[columnName] == DBNull.Value )
				{
					return null;
				}
				else
				{
					return (float?)reader.GetDouble(reader.GetOrdinal(columnName));
				}
			}
			return null;
		}

		#endregion

		public static StringBuilder bindFilterCondition(string filterType, string filterValue)
		{
			var command = new StringBuilder();
			#region Dynamic conditon
			switch ( filterType.ToLower() )
			{
				case "equals":
					command.Append(" = '" + filterValue + "'");
					break;
				case "not equals":
					command.Append(" <> '" + filterValue + "'");
					break;
				case "less than":
					command.Append(" < '" + filterValue + "'");
					break;
				case "less than or equals to":
					command.Append(" <= '" + filterValue + "'");
					break;
				case "greater than":
					command.Append(" > '" + filterValue + "'");
					break;
				case "greater than or equals to":
					command.Append(" >= '" + filterValue + "'");
					break;
				case "like":
					command.Append(" LIKE '%" + filterValue + "%'");
					break;
				case "not like":
					command.Append(" NOT LIKE '%" + filterValue + "%' ");
					break;
				case "between":
				case "not between":
					var values = filterValue.Split(',');
					if ( values.Length != 2 )
						return null;

					if ( filterType == "between" )
						command.Append(" BETWEEN '" + values[0] + "' AND '" + values[1] + "'");
					else
						command.Append(" NOT BETWEEN '" + values[0] + "' AND '" + values[1] + "'");
					break;

				case "in list":
				case "not in list":
					var listValue = filterValue.Split(',');
					string value = "";
					foreach ( var item in listValue )
					{
						value = value + "'" + item + "', ";
					}
					value = value.Substring(0, (value.Length - 2));
					if ( filterType == "in list" )
						command.Append(" IN (" + value + ") ");
					else
						command.Append(" NOT IN (" + value + ") ");
					break;
				case "blank":
					command.Append(" = '' ");
					break;
				case "not blank":
					command.Append(" <> '' ");
					break;
				default:
                    command.Append(" LIKE '%" + filterValue + "%'");
                    break;
			}
			return command;
			#endregion
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        public static StringBuilder bindNewFilterCondition(string filterType, List<string> filterValue)
        {
            var command = new StringBuilder();
            string values = string.Empty;
            DateTime dates;
            DateTime.TryParse(filterValue[0], out dates);
            if (DateTime.TryParse(filterValue[0], out dates))
            {
                values = "convert(varchar(10), CONVERT(datetime, '" + dates + "'), 101)";
            }
            else
            {
                    values = filterValue[0];
            }

            #region Dynamic conditon
            switch (filterType.ToLower())
            {
                case "equals":
                    if (dates != null)
                    {
                        command.Append(" = " + values + "");
                    }
                    else { command.Append(" = '" + values + "'"); }
                    break;
                case "not equals":
                    command.Append(" <> '" + values + "'");
                    break;
                case "less than":
                    command.Append(" < '" + values + "'");
                    break;
                case "less than or equals to":
                    command.Append(" <= '" + values + "'");
                    break;
                case "greater than":
                    command.Append(" > '" + values + "'");
                    break;
                case "greater than or equals to":
                    command.Append(" >= '" + values + "'");
                    break;
                case "like":
                    command.Append(" LIKE '%" + values + "%'");
                    break;
                case "not like":
                    command.Append(" NOT LIKE '%" + values + "%' ");
                    break;
                case "between":
                case "not between":
                    //var values = filterValue.Split(',');

                    if (filterValue.Count != 2)
                        return null;

                    string value2 = string.Empty;
                    DateTime date2;
                    DateTime.TryParse(filterValue[1], out date2);
                    if (DateTime.TryParse(filterValue[1], out date2))
                    {
                        value2 = "convert(varchar(10), CONVERT(datetime, '" + date2 + "'), 101)";
                    }
                    else
                    {
                        value2 = filterValue[1];
                    }


                    if (dates != null)
                    {
                        if (filterType == "between")
                            command.Append(" BETWEEN " + values + " AND " + value2 + "");
                        else
                            command.Append(" NOT BETWEEN " + values + " AND " + value2 + "");
                    }
                    else {
                        if (filterType == "between")
                            command.Append(" BETWEEN '" + values + "' AND '" + value2 + "'");
                        else
                            command.Append(" NOT BETWEEN '" + values + "' AND '" + value2 + "'");
                    }

                   
                    break;

                case "in list":
                case "not in list":
                    //var listvalue = filterValue.split(',');
                    string value = "";
                    foreach (var item in filterValue)
                    {
                        value = value + "'" + item + "', ";
                    }
                    value = value.Substring(0, (value.Length - 2));
                    if (filterType == "in list")
                        command.Append(" in (" + value + ") ");
                    else
                        command.Append(" not in (" + value + ") ");
                    break;
                case "blank":
                    command.Append(" = '' ");
                    break;
                case "not blank":
                    command.Append(" <> '' ");
                    break;
                default:
                    command.Append(" LIKE '%" + values + "%'");
                    break;
            }
            return command;
            #endregion
        }

        public static object GetSQLParameterValue(object obj)
		{
			//if ( obj.GetType().Equals(typeof(DateTime)) )
			//{
			//	if ( obj == default(DateTime) )
			//	{
			//		return DBNull.Value;
			//	}
			//}

			return obj ?? DBNull.Value;


		}
	}
}