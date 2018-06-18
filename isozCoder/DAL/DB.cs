using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataConn
/// </summary>
public class DB 
{

    public string SqlServerName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string CatalogName { get; set; }
    public SqlConnection Conn = null;
    private string ConnStr = string.Empty;
    public string Error = string.Empty;
    public DB(string sqlServerName, string userName, string password, string catalogName)
	{
        SqlServerName = sqlServerName;
        UserName = userName;
        Password = password;
        CatalogName = catalogName;
        if (CatalogName == string.Empty)
            CatalogName = "master";

        ConnStr = @"Data Source=#SQLSERVERNAME;Pooling=true; Min Pool Size=0;Max Pool Size=100; Connection Lifetime=0; Initial Catalog=#CATALOG;User ID=#USERNAME;Password=#PASSWORD";
        ConnStr = ConnStr.Replace("#SQLSERVERNAME", SqlServerName);
        ConnStr = ConnStr.Replace("#USERNAME", UserName);
        ConnStr = ConnStr.Replace("#PASSWORD", Password);
        ConnStr = ConnStr.Replace("#CATALOG", CatalogName);

	}
    public SqlConnection OpenConneciton()
    {
        try
        {
            Conn = new SqlConnection (ConnStr);
            Conn.Open();
            return Conn;
        }
        catch ( SqlException  ex)
        {
            Error = ex.Message;
            return null;
        }
    }
}
