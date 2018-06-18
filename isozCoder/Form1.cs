using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace isozCoder
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        //private string getSelectedTablePrimaryKey()
        //{
        //    string RV = "";
        //    for (int i = 0; i < lbxTableFields.CheckedItems.Count; i++)
        //    {
        //        RV = lbxTableFields.CheckedItems[i].ToString();
        //    }
        //    if(RV != string.Empty)
        //    RV= RV.Substring(0,RV.IndexOf(']')+1);
        //    return RV;

        //}
        private string SP_IDENTITYCOLUMNNAMES = "";
        private string SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS = "";
        private string SP_OUTPUT_PARAMETERS = "";
        private string SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1 ="";
        private string SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT = "";
        private string SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_UPDATE = "";

        private string TABLE_COMMAND_PARAMETERS_OUTPUTS = "";
        private string TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS = "";
        private string TABLE_COMMAND_PARAMETERS_RETURN = "";
        

        private void button1_Click(object sender, EventArgs e)
        {
            string SqlServerName= txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();

            DB myDB = new DB(SqlServerName, UserName, Password,"");

            if (myDB.OpenConneciton() != null)
            {
                LoadDatabases();
                //MessageBox.Show("Başarılı");
                button1.Text = "OK";
            }
            else
            {
                button1.Text = "NOT";
                MessageBox.Show(myDB.Error);
            }
                
        }
        private void LoadDatabases()
        {
            string SqlServerName= txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();

            DB myDB = new DB(SqlServerName, UserName, Password,"");
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT name FROM master..sysdatabases ORDER BY name";
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                cmbDatabases.Items.Clear();
                while (rd.Read())
                {
                    cmbDatabases.Items.Add(rd.GetString(0));
                    
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void LoadDatabaseTales(string DBName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT name FROM sys.Tables Order BY name";
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                cmbTables.Items.Clear();
                while (rd.Read())
                {
                    cmbTables.Items.Add(rd.GetString(0));

                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = cmbDatabases.SelectedItem.ToString();
            if (dbName == string.Empty)
                return;
            LoadDatabaseTales(dbName);
        }
        private string getTableIdentityColumnName(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

 
 TOP 1   name
FROM sys.columns
WHERE 
    object_id = object_id(@TableName)
    AND is_identity = 1";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;

                SqlDataReader rd = cmd.ExecuteReader();
                string RV = "";
                int i = 0;
                while (rd.Read())
                {
                    RV =  rd.GetString(0) ;
                }
                conn.Close();

                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private bool getTableColumnIsIdentity(string DBName, string TableName, string ColumnName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

 
    is_identity
FROM sys.columns
WHERE 
    object_id = object_id(@TableName)
    AND name = @ColumnName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                cmd.Parameters.Add("@ColumnName", System.Data.SqlDbType.VarChar).Value = ColumnName;

                SqlDataReader rd = cmd.ExecuteReader();
                bool RV = false;
                int i = 0;
                while (rd.Read())
                {
                        i = Convert.ToInt32( rd.GetValue(0));
                }
                conn.Close();
                if (i == 1)
                    RV = true;
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private bool getTableColumnIsPrimaryKey(string DBName, string TableName, string ColumnName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

 A.Name,Col.Column_Name from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab, 
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col ,
    (select NAME from dbo.sysobjects where xtype='u') AS A
WHERE 
    Col.Constraint_Name = Tab.Constraint_Name
    AND Col.Table_Name = Tab.Table_Name
    AND Constraint_Type = 'PRIMARY KEY '
    AND Col.Table_Name = A.Name
    AND A.Name = @TableName 
    AND Col.Column_Name = @ColumnName
";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                cmd.Parameters.Add("@ColumnName", System.Data.SqlDbType.VarChar).Value = ColumnName;

                SqlDataReader rd = cmd.ExecuteReader();
                bool RV = false;
                int i = 0;
                while (rd.Read())
                {
                    i++;
                }
                conn.Close();
                if (i > 0)
                    RV = true;
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private bool getTableColumnPrimaryKeyAndSetVariables(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

Col.Column_Name, A.Name from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab, 
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col ,
    (select NAME from dbo.sysobjects where xtype='u') AS A
WHERE 
    Col.Constraint_Name = Tab.Constraint_Name
    AND Col.Table_Name = Tab.Table_Name
    AND Constraint_Type = 'PRIMARY KEY '
    AND Col.Table_Name = A.Name
    AND A.Name = @TableName 
    --AND Col.Column_Name = @ColumnName
";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                //cmd.Parameters.Add("@ColumnName", System.Data.SqlDbType.VarChar).Value = ColumnName;

                SqlDataReader rd = cmd.ExecuteReader();
                bool RV = false;
                int i = 0;
                SP_IDENTITYCOLUMNNAMES = "";
                SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS = "";
                SP_OUTPUT_PARAMETERS = "";
                SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1 = "";
                SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT = "";
                SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_UPDATE = "";

                TABLE_COMMAND_PARAMETERS_OUTPUTS = "";
                TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS = "";
                TABLE_COMMAND_PARAMETERS_RETURN = "return sonuc;";

                while (rd.Read())
                {
                    
                    string col = rd.GetString(0);
                    if (i == 0)
                    {
                        SP_IDENTITYCOLUMNNAMES += col;
                        SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS += col + "=@" + col;

                    }
                    else
                    {
                        SP_IDENTITYCOLUMNNAMES +=","+ col;
                        SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS += "AND" + col + "=@" + col;

                    }
                    
                    i++;
                }
                conn.Close();
                if (i > 0)
                    RV = true;
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private bool getTableColumnIdentityAndSetVariables(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

 
    name
FROM sys.columns
WHERE 
    object_id = object_id(@TableName)
AND is_identity = 1
   -- AND name = @ColumnName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                //cmd.Parameters.Add("@ColumnName", System.Data.SqlDbType.VarChar).Value = ColumnName;

                SqlDataReader rd = cmd.ExecuteReader();
                bool RV = false;
                int i = 0;
                SP_IDENTITYCOLUMNNAMES = "";
                SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS = "";
                SP_OUTPUT_PARAMETERS = "";
                SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1 = "";
                SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT = "";
                SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_UPDATE = "";

                TABLE_COMMAND_PARAMETERS_OUTPUTS = "";
                TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS = "";
                TABLE_COMMAND_PARAMETERS_RETURN = "return sonuc;";

                while (rd.Read())
                {

                    string col = rd.GetString(0);
                    if (i == 0)
                    {
                        SP_IDENTITYCOLUMNNAMES += col;
                        SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS += col + "=@" + col;
                        SP_OUTPUT_PARAMETERS += ",@Pk" + col + " as int output" + '\n';
                        SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1 +="SELECT @Pk" +col+" = 0 ";
                        SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT += "SELECT @Pk" + col + " = scope_identity() " + '\n';
                        SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_UPDATE += "SELECT @Pk" + col + " = @"+col + '\n';

                        TABLE_COMMAND_PARAMETERS_OUTPUTS += "cmd.Parameters.Add(\"@Pk" + col + "\", SqlDbType.Int);" + '\n';
                        TABLE_COMMAND_PARAMETERS_OUTPUTS += "cmd.Parameters[\"@Pk" + col + "\"]. Direction = ParameterDirection.Output;" + '\n';

                        TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS = "int Pk = Convert.ToInt32(cmd.Parameters[\"@Pk" + col + "\"].Value.ToString());";
                        TABLE_COMMAND_PARAMETERS_RETURN = "return Pk;";

                    }
                    else
                    {
                        SP_IDENTITYCOLUMNNAMES += "," + col;
                        SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS += "AND" + col + "=@" + col;
                        SP_OUTPUT_PARAMETERS += ",@Pk" + col + " as int output" + '\n';                        
                        SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1 += ", @Pk" + col + "=0";
                        SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT += ", @Pk" + col + " = @" + col + '\n';

                        TABLE_COMMAND_PARAMETERS_OUTPUTS = "";
                        TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS = "";
                        TABLE_COMMAND_PARAMETERS_RETURN = "return sonuc;";
                    }

                    i++;
                }
                conn.Close();
                if (i > 0)
                    RV = true;
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private string getTableSelectFields(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

 'ISNULL( '+COLUMN_NAME +', '	   + CASE 
														WHEN DATA_TYPE IN ('nvarchar','varchar','nchar','text','char') THEN ''''') '
														WHEN DATA_TYPE IN ('int','smallint','tinyint' ) THEN '0) '
														WHEN DATA_TYPE IN ('bit') THEN '0 )'
														WHEN DATA_TYPE IN ('smalldatetime','datetime') THEN '''1900-01-01'') '
														WHEN DATA_TYPE IN ('decimal') THEN '0 '
														ELSE 'bilemedik'	END 	 AS C#READER_SQL_SELECT_COLUMNS

FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                int i = 0;
                while (rd.Read())
                {
                    if (i==0)
                    RV += rd.GetString(0) + '\n';
                    else
                        RV += ',' + rd.GetString(0) + '\n';
                    i++;

                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private string getTableCommandParametersWithValue(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

'cmd.Parameters.Add(""@'+COLUMN_NAME +'"",SqlDbType.'	   + CASE 
														WHEN DATA_TYPE IN ('nvarchar') THEN 'NVarChar '
														WHEN DATA_TYPE IN ('varchar') THEN 'VarChar '
                                                        WHEN DATA_TYPE IN ('nchar') THEN 'VarChar '
                                                        WHEN DATA_TYPE IN ('char') THEN 'VarChar '
                                                        WHEN DATA_TYPE IN ('text') THEN 'Text '
														WHEN DATA_TYPE IN ('int','smallint','tinyint' ) THEN 'Int '
														WHEN DATA_TYPE IN ('bit') THEN 'Bit '
														WHEN DATA_TYPE IN ('smalldatetime','datetime') THEN 'DateTime '
														WHEN DATA_TYPE IN ('decimal') THEN 'Decimal '
														ELSE 'bilemedik'	END +').Value = bObj.' +	 COLUMN_NAME	+';'  AS C#SP_PARAMETERS_AND_VALUES

FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                while (rd.Read())
                {

                        RV +=  rd.GetString(0) + '\n';
                  

                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private string getTableReaderText(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

'd. '+COLUMN_NAME +'=  '	   + CASE 
														WHEN DATA_TYPE IN ('nvarchar','varchar','nchar','char') THEN ' rd.GetString(' +CAST(ORDINAL_POSITION-1 as varchar)+');'
                                                        WHEN DATA_TYPE IN ('text' ) THEN ' rd.GetValue( '  +CAST(ORDINAL_POSITION-1 as varchar)+').ToString();'
														WHEN DATA_TYPE IN ('int','smallint','tinyint' ) THEN ' rd.GetInt32( '  +CAST(ORDINAL_POSITION-1 as varchar)+');'
														WHEN DATA_TYPE IN ('bit') THEN 'rd.GetBoolean('	 +CAST(ORDINAL_POSITION-1 as varchar)+');'
														WHEN DATA_TYPE IN ('smalldatetime','datetime') THEN 'rd.GetDateTime('+CAST(ORDINAL_POSITION-1 as varchar)+');'
														WHEN DATA_TYPE IN ('decimal') THEN 'rd.GetDecimal('+CAST(ORDINAL_POSITION-1 as varchar)+');'
														ELSE 'bilemedik'	END	AS C#READER_VARIABLES_ASSG

FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                while (rd.Read())
                {

                    RV += rd.GetString(0) + '\n';


                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private string getTableFieldsVeriables(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

'public '  + CASE 
							WHEN DATA_TYPE IN ('nvarchar','varchar','nchar','text','char') THEN 'string '
							WHEN DATA_TYPE IN ('int','smallint','tinyint' ) THEN 'int '
							WHEN DATA_TYPE IN ('bit') THEN 'bool '
							WHEN DATA_TYPE IN ('smalldatetime','datetime') THEN 'DateTime '
							WHEN DATA_TYPE IN ('decimal') THEN 'decimal '
							ELSE 'bilemedik'	END +
COLUMN_NAME +' { get; set; }'		  AS C#VARIABLE_DEFINITIONS


FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                while (rd.Read())
                {

                    RV += rd.GetString(0) + '\n';


                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private void LoadTableFields(string DBName,string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

COLUMN_NAME,'['+COLUMN_NAME +']'  
, CASE 
							WHEN DATA_TYPE IN ('nvarchar','varchar','char') THEN DATA_TYPE +'('+CAST(CHARACTER_MAXIMUM_LENGTH as varchar)+'),'
							WHEN DATA_TYPE IN ('int','smallint','tinyint' ) THEN 'int, '
							WHEN DATA_TYPE IN ('bit') THEN 'bool, '
							WHEN DATA_TYPE IN ('smalldatetime','datetime') THEN 'DateTime, '
							WHEN DATA_TYPE IN ('decimal') THEN DATA_TYPE +'('+CAST(NUMERIC_PRECISION as varchar)+','+CAST(NUMERIC_SCALE as varchar)+'),'
							ELSE 'bilemedik,'	END
AS PROCEDURE_PARAMS
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";

            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();

                gList.Columns.Clear();

                gList.Columns.Add("FieldName", 100 );
                gList.Columns.Add("DataType", 100);
                gList.Columns.Add("PK", 100);
                gList.Columns.Add("Identity", 100);
                gList.Items.Clear();
                while (rd.Read())
                {

                    string column = rd.GetString(0);
                    string dataType = rd.GetString(2);
                 GlacialComponents.Controls.GLItem item;
                 item = this.gList.Items.Add(column);

                 item.SubItems[1].Text = dataType;
                 
                 item.SubItems[1].BackColor = Color.Bisque;

                 CheckBox ckPk = new CheckBox();
                 item.SubItems[2].Control = ckPk;
                 CheckBox ckID = new CheckBox();
                 item.SubItems[3].Control = ckID;

                    
                    bool isIdentity = getTableColumnIsIdentity(DBName, TableName, column);
                    bool isPrimaryKey = getTableColumnIsPrimaryKey(DBName, TableName, column);
                    if (isIdentity)
                        ckID.Checked = true;

                    if (isPrimaryKey)
                        ckPk.Checked = true;



                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        //SP
        private string getSqlSpParameters(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 
'@'+COLUMN_NAME +' as '  
+ CASE 
							WHEN DATA_TYPE IN ('nvarchar','varchar','char') THEN DATA_TYPE +'('+CAST(CHARACTER_MAXIMUM_LENGTH as varchar)+')'
							WHEN DATA_TYPE IN ('int','smallint','tinyint' ) THEN 'int '
							WHEN DATA_TYPE IN ('bit') THEN 'bool '
							WHEN DATA_TYPE IN ('smalldatetime','datetime') THEN 'DateTime '
							WHEN DATA_TYPE IN ('decimal') THEN DATA_TYPE +'('+CAST(NUMERIC_PRECISION as varchar)+','+CAST(NUMERIC_SCALE as varchar)+')'
							ELSE 'bilemedik'	END


FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                int i = 0;
                while (rd.Read())
                {
                    string f = rd.GetString(0);
                    //if (!f.Contains("@ID"))
                    //{
                        if (i == 0)
                            f = rd.GetString(0) + '\n';
                        else
                            f = ',' + rd.GetString(0) + '\n';
                        i++;
                            RV += f;
                    //}
                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private string getSqlSpTableInsertFields(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

'['+COLUMN_NAME+']'  AS INSERTTABLE,COLUMN_NAME

FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                int i = 0;
                while (rd.Read())
                {
                    string fc = rd.GetString(1);
                    bool isIdentity = getTableColumnIsIdentity(DBName, TableName, fc);
                    //bool isPrimaryKey = getTableColumnIsPrimaryKey(DBName, TableName, fc);
                   


                    string f = rd.GetString(0);
                    if (!isIdentity)
                    {
                        if (i == 0)
                            f = rd.GetString(0) + '\n';
                        else
                            f = ',' + rd.GetString(0) + '\n';
                        i++;
                        RV += f;
                    }
                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private string getSqlSpTableInsertFieldValues(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

'@'+COLUMN_NAME  AS INSERTTABLE_VALUES,COLUMN_NAME

FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                int i = 0;
                while (rd.Read())
                {
                    string fc = rd.GetString(1);
                    bool isIdentity = getTableColumnIsIdentity(DBName, TableName, fc);
                    //bool isPrimaryKey = getTableColumnIsPrimaryKey(DBName, TableName, fc);

                    string f = rd.GetString(0);
                    if (!isIdentity)
                    {
                        if (i == 0)
                            f = rd.GetString(0) + '\n';
                        else
                            f = ',' + rd.GetString(0) + '\n';
                        i++;
                        RV += f;
                    }
                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        private string getSqlSpTableUpdateFieldsAndValues(string DBName, string TableName)
        {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();


            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            string Sql = @"SELECT 

'['+COLUMN_NAME +']=  ' +'@'+COLUMN_NAME   AS UPDATE_PARAMS,COLUMN_NAME

FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName";


            try
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.VarChar).Value = TableName;
                SqlDataReader rd = cmd.ExecuteReader();
                string RV = string.Empty;
                int i = 0;
                while (rd.Read())
                {
                    string fc = rd.GetString(1);
                    bool isIdentity = getTableColumnIsIdentity(DBName, TableName, fc);
                    //bool isPrimaryKey = getTableColumnIsPrimaryKey(DBName, TableName, fc);
                    string f = rd.GetString(0);
                    if (!isIdentity)
                    {
                        if (i == 0)
                            f = rd.GetString(0) + '\n';
                        else
                            f = ',' + rd.GetString(0) + '\n';
                        i++;
                        RV += f;
                    }
                }
                conn.Close();
                return RV;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "";
            }

        }
        //

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DBName = cmbDatabases.SelectedItem.ToString();
            if (DBName == string.Empty)
                return;
            string TableName = cmbTables.SelectedItem.ToString();
            if (TableName == string.Empty)
                return;


            LoadTableFields(DBName, TableName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedIndex == -1)
                return;
            string DBName = cmbDatabases.SelectedItem.ToString();
            if (DBName == string.Empty)
                return;
            string TableName = cmbTables.SelectedItem.ToString();
            if (TableName == string.Empty)
                return;

            //DAL----------------------------------------------------------------------
            string strDAL = txtDalTemplate.Text;
            strDAL = strDAL.Replace("#TABLE_NAME", TableName);
            
            string SELECT_TABLE_COLUMNS = getTableSelectFields(DBName, TableName);
            strDAL = strDAL.Replace("#SELECT_TABLE_COLUMNS", SELECT_TABLE_COLUMNS);

            string TABLE_COMMAND_PARAMETERS_WITH_VALUES = getTableCommandParametersWithValue(DBName, TableName);
            strDAL = strDAL.Replace("#TABLE_COMMAND_PARAMETERS_WITH_VALUES", TABLE_COMMAND_PARAMETERS_WITH_VALUES);

            string TABLE_READER_VALUES = getTableReaderText(DBName, TableName);
            strDAL = strDAL.Replace("#TABLE_READER_VALUES", TABLE_READER_VALUES);

            strDAL = strDAL.Replace("#TABLE_COMMAND_PARAMETERS_OUTPUTS", TABLE_COMMAND_PARAMETERS_OUTPUTS);
            strDAL = strDAL.Replace("#TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS", TABLE_COMMAND_PARAMETERS_OUTPUTRESULTS);
            strDAL = strDAL.Replace("#TABLE_COMMAND_PARAMETERS_RETURN", TABLE_COMMAND_PARAMETERS_RETURN);




            txtDALCode.Text = strDAL;

            //BLL--------------------------------------------------------------
            string strBLL = txtBLLTemplate.Text;
            strBLL = strBLL.Replace("#TABLE_NAME", TableName);

            string TABLE_FIELDS_VARIABLES = getTableFieldsVeriables(DBName, TableName);
            strBLL = strBLL.Replace("#TABLE_FIELDS_VARIABLES", TABLE_FIELDS_VARIABLES);

            txtBLLCode.Text = strBLL;
            
            //SP--------------------------------------------------------------
            string strSpTamplates = txtspTemplate.Text;
            strSpTamplates = strSpTamplates.Replace("#TABLE_NAME", TableName);

            string SP_PARAMETERS = getSqlSpParameters(DBName, TableName);
            strSpTamplates = strSpTamplates.Replace("#SP_PARAMETERS", SP_PARAMETERS);

            string INSERT_TABLE_FIELDS = getSqlSpTableInsertFields(DBName, TableName);
            strSpTamplates = strSpTamplates.Replace("#INSERT_TABLE_FIELDS", INSERT_TABLE_FIELDS);

            string INSERT_TABLE_FIELD_VALUES = getSqlSpTableInsertFieldValues(DBName, TableName);
            strSpTamplates = strSpTamplates.Replace("#INSERT_TABLE_FIELD_VALUES", INSERT_TABLE_FIELD_VALUES);

            string SP_UPDATE_TABLE_FIELDS_AND_VALUES = getSqlSpTableUpdateFieldsAndValues(DBName, TableName);
            strSpTamplates = strSpTamplates.Replace("#SP_UPDATE_TABLE_FIELDS_AND_VALUES", SP_UPDATE_TABLE_FIELDS_AND_VALUES);

            //string IDENTITYCOLUMNNAME = getTableIdentityColumnName(DBName, TableName);
            //strSpTamplates = strSpTamplates.Replace("#IDENTITYCOLUMNNAME", IDENTITYCOLUMNNAME);
            bool ok = false;
            if (chkIDKey.Checked)
            ok=getTableColumnPrimaryKeyAndSetVariables(DBName, TableName);
            else
            ok=getTableColumnIdentityAndSetVariables(DBName, TableName);

            if (!ok)
                getTableColumnIdentityAndSetVariables(DBName, TableName);

            strSpTamplates = strSpTamplates.Replace("#SP_IDENTITYCOLUMNNAMES", SP_IDENTITYCOLUMNNAMES);
            strSpTamplates = strSpTamplates.Replace("#SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS", SP_IDENTITYCOLUMNNAME_WHERE_CONDITIONS);
            strSpTamplates = strSpTamplates.Replace("#SP_OUTPUT_PARAMETERS", SP_OUTPUT_PARAMETERS);
            strSpTamplates = strSpTamplates.Replace("#SP_OUTPUT_PARAMETERS", SP_OUTPUT_PARAMETERS);
            strSpTamplates = strSpTamplates.Replace("#SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1", SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY1);
            strSpTamplates = strSpTamplates.Replace("#SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT", SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_INSERT);
            strSpTamplates = strSpTamplates.Replace("#SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_UPDATE", SP_IDENTITYCOLUMN_OUTPUT_SELECET_QUERY_FOR_UPDATE);





            txtspCode.Text = strSpTamplates;
            //--------------------------------------------------------------


            tabMain.SelectTab(1);
            MessageBox.Show(null, "İşlme başarılı bir şekilde tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




        private void button4_Click(object sender, EventArgs e)
        {
            string DBName = cmbDatabases.SelectedItem.ToString();
            if (DBName == string.Empty)
                return;
            string TableName = cmbTables.SelectedItem.ToString();
            if (TableName == string.Empty)
                return;
            if (txtDALCode.Text.Trim() == string.Empty)
                return;
            string fName = txtDALFilePath.Text + "\\d" + TableName + ".cs";
            if (System.IO.File.Exists(fName))
                if (MessageBox.Show(null, "Dosya zaten var üzerine yazmak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                    return;
            if (System.IO.File.Exists(fName))
                System.IO.File.Delete(fName);
            System.IO.File.WriteAllText(fName, txtDALCode.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string DBName = cmbDatabases.SelectedItem.ToString();
            if (DBName == string.Empty)
                return;
            string TableName = cmbTables.SelectedItem.ToString();
            if (TableName == string.Empty)
                return;
            if (txtBLLCode.Text.Trim() == string.Empty)
                return;
            string fName = txtBLLFilePath.Text + "\\b" + TableName + ".cs";
            if (System.IO.File.Exists(fName))
                if (MessageBox.Show(null, "Dosya zaten var üzerine yazmak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                    return;
            if (System.IO.File.Exists(fName))
                System.IO.File.Delete(fName);
            System.IO.File.WriteAllText(fName, txtBLLCode.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try {
            string SqlServerName = txtSqlServer.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();

            string DBName = cmbDatabases.SelectedItem.ToString();
            if (DBName == string.Empty)
                return;
            string spCode = txtspCode.Text.Trim();
            if (spCode == string.Empty)
                return;
            DB myDB = new DB(SqlServerName, UserName, Password, DBName);
            SqlConnection conn = myDB.OpenConneciton();
            SqlCommand cmd = new SqlCommand(spCode, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            }
            catch ( Exception ex) {
            MessageBox.Show(ex.Message);
            }

        }

        private void lbxTableFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            //while (lbxTableFields.CheckedIndices.Count > 0)
            //    lbxTableFields.SetItemChecked(lbxTableFields.CheckedIndices[0], false);
        }

        private void lbxTableFields_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //int ind = e.Index;
            //while (lbxTableFields.CheckedIndices.Count > 0)
            //    lbxTableFields.SetItemChecked(lbxTableFields.CheckedIndices[0], false);
            //lbxTableFields.SetItemChecked(ind, true);
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tMainIndex = tabMain.SelectedIndex;

            if (tMainIndex != 1)
                return;
            int tCodeIndex = tabControl2.SelectedIndex;
            switch (tCodeIndex)
            {
                case 0:
                    txtDALCode.Focus();
                    txtDALCode.SelectionStart = 0;
                    txtDALCode.SelectionLength = txtDALCode.Text.Length;
                    break;
                case 1:
                    txtBLLCode.Focus();
                    txtBLLCode.SelectionStart = 0;
                    txtBLLCode.SelectionLength = txtBLLCode.Text.Length;
                    break;
                case 2:
                    txtspCode.Focus();
                    txtspCode.SelectionStart = 0;
                    txtspCode.SelectionLength = txtspCode.Text.Length;
                    break;

                default:
                    break;
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tMainIndex = tabMain.SelectedIndex;

            if (tMainIndex != 1)
                return;
            int tCodeIndex = tabControl2.SelectedIndex;
            switch (tCodeIndex)
            {
                case 0:
                    txtDALCode.Focus();
                    txtDALCode.SelectionStart = 0;
                    txtDALCode.SelectionLength = txtDALCode.Text.Length;
                    break;
                case 1:
                    txtBLLCode.Focus();
                    txtBLLCode.SelectionStart = 0;
                    txtBLLCode.SelectionLength = txtBLLCode.Text.Length;
                    break;
                case 2:
                    txtspCode.Focus();
                    txtspCode.SelectionStart = 0;
                    txtspCode.SelectionLength = txtspCode.Text.Length;
                    break;

                default:
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {


  


        }


    }
}
