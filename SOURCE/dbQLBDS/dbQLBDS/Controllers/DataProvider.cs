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

        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }
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

        public DataTable ExecuteProcQuery(string procName,ref SqlParameter[] param) 
        {
            DataTable dt = new DataTable();
            try
            {
                if (OpenConnect())
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Parameters.AddRange(param);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    for (int i = 0; i < cmd.Parameters.Count; i++)
                    {
                        param[i].Value = cmd.Parameters[i].Value;
                    }

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
        }

        public bool ExecuteProcNonQuery(string procName,ref SqlParameter[] param)
        {
            try
            {
                if (OpenConnect())
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Parameters.AddRange(param);

                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < cmd.Parameters.Count; i++)
                    {
                        param[i].Value = cmd.Parameters[i].Value;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
        }

        #endregion
    }
}