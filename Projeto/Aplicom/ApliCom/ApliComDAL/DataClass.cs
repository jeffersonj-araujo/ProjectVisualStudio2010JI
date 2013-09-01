using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace System.Data.DataClass
{
    public interface IDataClass
    {
        DataSet getDataSet(string StrSqlCommand);
        DataSet getDataSet(string StrSqlCommand, string StrStringConnection);
        DataSet getDataSet(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName);
        DataTableReader getDataReader(string StrSqlCommand);
        DataTableReader getDataReader(string StrSqlCommand, string StrStringConnection);
        DataTableReader getDataReader(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName);
        DataTable getDataTable(string StrSqlCommand);
        DataTable getDataTable(string StrSqlCommand, string StrStringConnection);
        DataTable getDataTable(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName);
        object getValue(string StrSqlCommand, string NomeDoCampo);
        object getValue(string StrSqlCommand, int IndexDoCampo);
        bool Execute(string StrSqlCommand);
        bool Execute(string StrSqlCommand, string StrStringConnection);
        bool Execute(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName);
    }
    public class DataClass : IDataClass
    {
        private string _StringConnection;
        private ProviderName _DataBaseName;
        private string _providerName = "";
        Exception e;

        private string getStringConnection(string StringConnection)
        {
            string strcnx = "";

            try
            {
                strcnx = ConfigurationManager.ConnectionStrings[StringConnection].ConnectionString;
                _providerName = ConfigurationManager.ConnectionStrings[StringConnection].ProviderName;

                if (_providerName != null)
                {
                    switch (_providerName)
                    {
                        case "System.Data.SqlClient":
                            _DataBaseName = ProviderName.SQLServer;
                            break;
                        case "MySql.Data.MySqlClient":
                            _DataBaseName = ProviderName.MySQL;
                            break;
                        case "System.Data.OracleClient":
                            _DataBaseName = ProviderName.Oracle;
                            break;
                    }
                }
                else
                    throw e;
            }
            catch
            {
                if (_providerName == null)
                    throw new Exception("O provedor de banco de dados não foi informado! Talvez esteja faltando passar o parametro na sobrecarga do construtor da classe ou do método com o nome do provedor de banco de dados.", e);
                else
                {
                    strcnx = StringConnection;

                    switch (_providerName)
                    {
                        case "SQLServer":
                            _DataBaseName = ProviderName.SQLServer;
                            break;
                        case "MySQL":
                            _DataBaseName = ProviderName.MySQL;
                            break;
                        case "Oracle":
                            _DataBaseName = ProviderName.Oracle;
                            break;
                    }
                }
            }
            return strcnx;
        }
        public DataClass()
        {

        }
        public DataClass(string StringConnection)
        {
            _providerName = null;
            _StringConnection = getStringConnection(StringConnection);
        }
        public DataClass(ProviderName DataBaseName)
        {
            _providerName = DataBaseName.ToString();
        }
        public DataClass(string StringConnection, ProviderName DataBaseName)
        {
            _providerName = DataBaseName.ToString();
            _StringConnection = getStringConnection(StringConnection);
        }
        public DataSet getDataSet(string StrSqlCommand)
        {
            try
            {
                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(_StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataSet getDataSet(string StrSqlCommand, string StrStringConnection)
        {
            try
            {
                string StringConnection = getStringConnection(StrStringConnection);

                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet getDataSet(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName)
        {
            try
            {
                switch (ProviderName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StrStringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTableReader getDataReader(string StrSqlCommand)
        {
            try
            {
                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(_StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    DataTableReader dr = ds.CreateDataReader();
                                    return dr;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            DataTableReader dr = ds.CreateDataReader();
                        //            return dr;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            DataTableReader dr = ds.CreateDataReader();
                        //            return dr;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public object getValue(string StrSqlCommand, string NomeDoCampo)
        {
            try
            {
                string StringConnection = getStringConnection(_StringConnection);

                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    using (DataTableReader dr = ds.CreateDataReader())
                                    {
                                        object retorno = null;
                                        if (dr.Read())
                                            retorno = dr[NomeDoCampo];
                                        else
                                            retorno = null;

                                        return retorno;
                                    }
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            using (DataTableReader dr = ds.CreateDataReader())
                        //            {
                        //                object retorno = null;
                        //                if (dr.Read())
                        //                    retorno = dr[NomeDoCampo];
                        //                else
                        //                    retorno = null;

                        //                return retorno;
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            using (DataTableReader dr = ds.CreateDataReader())
                        //            {
                        //                object retorno = null;
                        //                if (dr.Read())
                        //                    retorno = dr[NomeDoCampo];
                        //                else
                        //                    retorno = null;

                        //                return retorno;
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public object getValue(string StrSqlCommand, int IndexOfField)
        {
            try
            {
                string StringConnection = getStringConnection(_StringConnection);

                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    using (DataTableReader dr = ds.CreateDataReader())
                                    {
                                        object retorno = null;
                                        if (dr.Read())
                                            retorno = dr[IndexOfField];
                                        else
                                            retorno = null;

                                        return retorno;
                                    }
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            using (DataTableReader dr = ds.CreateDataReader())
                        //            {
                        //                object retorno = null;
                        //                if (dr.Read())
                        //                    retorno = dr[IndexOfField];
                        //                else
                        //                    retorno = null;

                        //                return retorno;
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            using (DataTableReader dr = ds.CreateDataReader())
                        //            {
                        //                object retorno = null;
                        //                if (dr.Read())
                        //                    retorno = dr[IndexOfField];
                        //                else
                        //                    retorno = null;

                        //                return retorno;
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataTableReader getDataReader(string StrSqlCommand, string StrStringConnection)
        {
            try
            {
                string StringConnection = getStringConnection(StrStringConnection);

                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds.CreateDataReader();
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.CreateDataReader();
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.CreateDataReader();
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataTableReader getDataReader(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName)
        {
            try
            {
                switch (ProviderName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StrStringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds.CreateDataReader();
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.CreateDataReader();
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.CreateDataReader();
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataTable getDataTable(string StrSqlCommand)
        {
            try
            {
                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(_StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    DataTable dr = ds.Tables[0];
                                    return dr;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            DataTable dr = ds.Tables[0];
                        //            return dr;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            DataTable dr = ds.Tables[0];
                        //            return dr;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataTable getDataTable(string StrSqlCommand, string StrStringConnection)
        {
            try
            {
                string StringConnection = getStringConnection(StrStringConnection);

                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds.Tables[0];
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.Tables[0];
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.Tables[0];
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataTable getDataTable(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName)
        {
            try
            {
                switch (ProviderName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StrStringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return ds.Tables[0];
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.Tables[0];
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return ds.Tables[0];
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool Execute(string StrSqlCommand)
        {
            try
            {
                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(_StringConnection))
                        {
                            conn.Open();

                            using (SqlDataAdapter da = new SqlDataAdapter(StrSqlCommand, conn))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    da.Fill(ds); conn.Close();
                                    return true;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlDataAdapter da = new MySqlDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return true;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(_StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleDataAdapter da = new OracleDataAdapter(StrSqlCommand, conn))
                        //    {
                        //        using (DataSet ds = new DataSet())
                        //        {
                        //            da.Fill(ds); conn.Close();
                        //            return true;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Execute(string StrSqlCommand, string StrStringConnection)
        {
            try
            {
                string StringConnection = getStringConnection(StrStringConnection);

                switch (_DataBaseName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StringConnection))
                        {
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand(StrSqlCommand, conn))
                            {
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    conn.Close();
                                    return true;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlCommand cmd = new MySqlCommand(StrSqlCommand, conn))
                        //    {
                        //        using (MySqlDataReader dr = cmd.ExecuteReader())
                        //        {
                        //            conn.Close();
                        //            return true;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleCommand cmd = new OracleCommand(StrSqlCommand, conn))
                        //    {
                        //        using (OracleDataReader dr = cmd.ExecuteReader())
                        //        {
                        //            conn.Close();
                        //            return true;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool Execute(string StrSqlCommand, string StrStringConnection, ProviderName ProviderName)
        {
            try
            {
                switch (ProviderName)
                {
                    case ProviderName.SQLServer:
                        #region SQL Server
                        using (SqlConnection conn = new SqlConnection(StrStringConnection))
                        {
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand(StrSqlCommand, conn))
                            {
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    conn.Close();
                                    return true;
                                }
                            }
                        }
                        #endregion
                    case ProviderName.MySQL:
                        #region MsSQL
                        //using (MySqlConnection conn = new MySqlConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (MySqlCommand cmd = new MySqlCommand(StrSqlCommand, conn))
                        //    {
                        //        using (MySqlDataReader dr = cmd.ExecuteReader())
                        //        {
                        //            conn.Close();
                        //            return true;
                        //        }
                        //    }
                        //}
                        #endregion
                    case ProviderName.Oracle:
                        #region Oracle
                        //using (OracleConnection conn = new OracleConnection(StrStringConnection))
                        //{
                        //    conn.Open();

                        //    using (OracleCommand cmd = new OracleCommand(StrSqlCommand, conn))
                        //    {
                        //        using (OracleDataReader dr = cmd.ExecuteReader())
                        //        {
                        //            conn.Close();
                        //            return true;
                        //        }
                        //    }
                        //}
                        #endregion
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        ~DataClass()
        {
        }
    }
    public enum ProviderName
    {
        SQLServer = 0,
        MySQL = 1,
        Oracle = 2
    }
}


