using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dbQLBDS.Controllers
{
    public class DataProvider
    {
        #region attribute
        private string SqlConnectionStr;
        private SqlConnection connect;
        #endregion


        #region contructor
        public DataProvider()
        {
            SqlConnectionStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            connect = new SqlConnection(SqlConnectionStr);
        }
        #endregion

        #region method
        /// <summary>
        /// Open connection to Database
        /// </summary>
        /// <returns>bool</returns>
        public bool OpenConnect()
        {
            try
            {
                if (connect == null)
                {
                    connect = new SqlConnection(SqlConnectionStr);
                }
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }

                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Execute non query 
        /// </summary>
        /// <param name="sql">sql string</param>
        /// <returns>bool</returns>
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                if (OpenConnect())
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// Execute query return datatable
        /// </summary>
        /// <param name="sql">sql string</param>
        /// <returns>Database</returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (OpenConnect())
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                connect.Close();
            }
        }
        #endregion
    }
}