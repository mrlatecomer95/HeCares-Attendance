using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace DataFactory
{
    public class SQLite
    {
        SQLiteConnection sqlConn;
        public SQLite(string strConn)
        {
            sqlConn = new SQLiteConnection(strConn);
        }

        string _ConnectionString = "";
        /// <summary>
        /// get the Connection String of the DataBase
        /// </summary>
        public string getConnectionString {
            get { return _ConnectionString; }
        }

        /// <summary>
        /// set the Connection String of the Database
        /// </summary>
        public string setConnectionString
        {
            set { _ConnectionString = value; }
        }

        /// <summary>
        /// Returns a DataTable based on your query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// 
        public DataTable CreateTable(string query)
        {
            DataTable dt = new DataTable();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.CommandText = query;
                cmd.Connection = sqlConn;
                using (SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
            return dt;
        }

        public DataSet CreateDataSet(String[] querys)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    foreach (string sqlQuery in querys)
                    {
                        cmd.CommandText = sqlQuery;
                        using (SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd))
                        {
                            adp.Fill(ds.Tables.Add());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                //throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return ds;
        }

        /// <summary>
        /// Runs a Sql query
        /// </summary>
        /// <param name="query"> SELECT,INSERT,UPDATE,EXEC query</param>
        /// <returns></returns>
        public bool RunSql(string query)
        {
            bool retVal = false;
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                retVal = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retVal = false;
                //throw;
            }
            finally
            {
                if(sqlConn.State ==ConnectionState.Open) sqlConn.Close();
            }
            return retVal;
        }

        /// <summary>
        /// Runs the query With but uses Parameters for added Security
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        public bool RunSql(string query, SQLiteParameter[] sqlParam)
        {
            bool retVal = false;
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = query;
                    cmd.Parameters.AddRange(sqlParam.ToArray());
                    retVal = cmd.ExecuteNonQuery().Equals(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retVal = false;
                //throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }

            return retVal;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        public bool TestConnection(string connectionString)
        {
            bool retVal = false;
            SQLiteConnection _connStr;
            _connStr = new SQLiteConnection(connectionString);
            try
            {
                _connStr.Open();
                _connStr.Close();
                retVal = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                retVal = false;
                //throw;
            }
            finally
            {
                if (_connStr.State == ConnectionState.Open) _connStr.Close();
            }
            return retVal;
        }


        //[System.Diagnostics.DebuggerStepThrough()]
        public string GenerateID(string _IDFieldName, string _TableName)
        {
            string ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int cnt = 0;
            string ctemp = "";
            string prefix = "";
            //try
            //{
            //    sqlConn.Open();
            //    using (SQLiteCommand cmd = new SQLiteCommand())
            //    {
            //        cmd.Connection = sqlConn;
            //        cmd.CommandText = "SELECT FORMAT(NOW, 'yyMMdd')";
            //        prefix = (string)cmd.ExecuteScalar();
            //    }
            //    sqlConn.Close();

            //}
            //catch (Exception ex)
            //{
            //    //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical);
            //    MessageBox.Show(ex.Message, Application.ProductName);
            //}
            //finally
            //{
            //    if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            //}

            prefix = "HECARES";
            do
            {
                Random rnd = new Random();
                for (cnt = 1; cnt <= 10 - 2; cnt++)
                {
                    //ctemp = ctemp + ValidChars.Substring(Convert.ToInt32(ValidChars.Length * rnd.Next(ValidChars.Length)), 1);
                    ctemp = ctemp + ValidChars.Substring(Convert.ToInt32(rnd.Next(ValidChars.Length)), 1);
                }
            } while (!string.IsNullOrEmpty(DLookUp(_IDFieldName, _TableName, "", _IDFieldName + "='" + prefix + ctemp + "'")));
            return prefix + ctemp;
        }

        #region DLookUp
        //[System.Diagnostics.DebuggerStepThrough()]
        public string DLookUp(string expr, string TableName, string defaulValue)
        {
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandText = "SELECT TOP 1 [" + expr + "] FROM " + TableName;
                    defaulValue = (string)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                defaulValue = "";
                MessageBox.Show(ex.Message, Application.ProductName);
                //throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return defaulValue;
        }

        //[System.Diagnostics.DebuggerStepThrough()]
        public string DLookUp(string expr, string TableName, string DefaultValue, string Criteria)
        {
            try
            {
                sqlConn.Open();
                using (SQLiteCommand sqlcmd = new SQLiteCommand())
                {
                    sqlcmd.Connection = sqlConn;
                    string sqlWhere = Criteria == "" ? "" : " WHERE " + Criteria;
                    sqlcmd.CommandText = "SELECT TOP 1 [" + expr + "] FROM "+ TableName  + sqlWhere;
                    DefaultValue = (string)sqlcmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                //throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
            return DefaultValue;
        }
        //[System.Diagnostics.DebuggerStepThrough()]
        private DateTime DLookUp(string expr, string TableName, DateTime DefaultValue, string Criteria)
        {
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = sqlConn;
                    string sqlWhere = Criteria == "" ? "" : " WHERE " + Criteria;
                    cmd.CommandText = "SELECT TOP 1 [" + expr + "] FROM " + TableName + sqlWhere;
                    DefaultValue = (DateTime)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }

            return DefaultValue;
        }
        #endregion

    }
}
