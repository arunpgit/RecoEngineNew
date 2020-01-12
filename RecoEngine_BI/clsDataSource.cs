using RecoEngine_DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RecoEngine_BI
{
    public class clsDataSource
    {
        public clsDataSource()
        {
        }

        public bool fnAddCalaculatedColumn(string strTabName, string strColName, string strFormula, ref string strMessage, int ProjectId)
        {
            bool flag;
            try
            {
                DataTable dataTable = new DataTable();
                int num = 0;
                string[] upper = new string[] { " Select count(1) from user_tab_columns where upper(table_name) = '", strTabName.ToUpper(), "' and upper(column_name) = '", strColName.ToUpper(), "'" };
                string str = string.Concat(upper);
                if (Common.iDBType == 1)
                {

                    num = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                }
                else if (Common.iDBType == 3) ;
                {
                    str = " Select count(1) FROM TRE_CALCULATED_COLUMNS c WHERE   colname = '" + strColName.ToUpper() + "'  and project_id="+ProjectId;

                    num = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                }
                if (num <= 0)
                {
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'TEMP_CALACULATED'";
                    if (Common.iDBType == 1)
                    {
                        num = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (Common.iDBType == 3)
                    {

                        str = " Select count(1) from information_schema.columns where table_name= 'TEMP_CALACULATED'";
                        num = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num >= 1)
                    {
                        str = " DROP TABLE TEMP_CALACULATED";
                        if (Common.iDBType == 1)
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else if (Common.iDBType == 3)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    string[] strArrays = new string[] { " CREATE TABLE  TEMP_CALACULATED AS select ", strFormula, "  ", strColName, " from ", strTabName, " where rownum<=1" };
                    str = string.Concat(strArrays);
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {
                        strArrays = new string[] { " CREATE TABLE  TEMP_CALACULATED AS select ", strFormula, "  ", strColName, " from ", strTabName, " limit  1" };
                        str = string.Concat(strArrays);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " SELECT COLUMN_NAME, DATA_TYPE FROM user_tab_columns WHERE table_name = 'TEMP_CALACULATED'";

                    if (Common.iDBType == 1)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {

                        str = " SELECT COLUMN_NAME, DATA_TYPE FROM information_schema.columns WHERE table_name = 'TEMP_CALACULATED'";
                        dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    object[] objArray = new object[] { "Insert into TRE_CALCULATED_COLUMNS (COLNAME,COMBINE_COLUMNS,PROJECT_ID,COLDATATYPE,TABLENAME) values ('", strColName.ToUpper(), "','", strFormula.Replace("'", "''"), "', ", ProjectId, " ,'", dataTable.Rows[0]["DATA_TYPE"], "','", strTabName, "')" };
                    str = string.Concat(objArray);
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                    }
                    else if (Common.iDBType ==3)
                    {
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                    }
                    return true;
                }
                else
                {
                    strMessage = string.Concat(strColName, " is already there.");
                    flag = false;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataTable fnCreateColTypes()
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                dataTable1.Columns.Add(new DataColumn("TypeId", typeof(int)));
                dataTable1.Columns.Add(new DataColumn("Type", typeof(string)));
                DataRowCollection rows = dataTable1.Rows;
                object[] str = new object[] { 1.ToString(), "Key" };
                rows.Add(str);
                DataRowCollection dataRowCollection = dataTable1.Rows;
                object[] objArray = new object[] { 2.ToString(), "Input" };
                dataRowCollection.Add(objArray);
                DataRowCollection rows1 = dataTable1.Rows;
                object[] str1 = new object[] { 3.ToString(), "Time" };
                rows1.Add(str1);
                DataRowCollection dataRowCollection1 = dataTable1.Rows;
                object[] objArray1 = new object[] { 4.ToString(), "Segment" };
                dataRowCollection1.Add(objArray1);
                DataRowCollection rows2 = dataTable1.Rows;
                object[] str2 = new object[] { 5.ToString(), "None" };
                rows2.Add(str2);
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public void fnCreateTreMApping(DataRow[] drs, string strTabName, string strWherecndtn)
        {
            try
            {
                string str = "";
                string str1 = "";
                DataRow[] dataRowArray = drs;
                for (int i = 0; i < (int)dataRowArray.Length; i++)
                {
                    DataRow dataRow = dataRowArray[i];
                    if (dataRow["type"].ToString() != 5.ToString())
                    {
                        str = string.Concat(str, dataRow[0]);
                        str = string.Concat(str, ",");
                    }
                }
                str = str.Substring(0, str.Length - 1);
                if (strWherecndtn != "")
                {
                    string[] strArrays = new string[] { "create table OPPORTUNITY_RANKING11 as select ", str, " from ", strTabName, " Where ", strWherecndtn };
                    str1 = string.Concat(strArrays);
                }
                else
                {
                    str1 = string.Concat("create table OPPORTUNITY_RANKING11 as select ", str, " from ", strTabName);
                }
                if (Common.iDBType != 1)
                {
                    ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str1);
                }
                else
                {
                    ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str1);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void fnDeleteTreMapping(string strTabName)
        {
            try
            {
                string str = string.Concat("delete from TRE_MAPPING where TABLENAME='", strTabName, "'");
                if (Common.iDBType != 1)
                {
                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
                else
                {
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataTable fnGetCalaculatedColMappingData(int ProjectId, string strTabName)
        {
            DataTable dataTable= null;
            DataTable dataTable1;
            try
            {
                object[] objArray = new object[] { "Select * from  TRE_CALCULATED_COLUMNS WHERE TABLENAME= '", strTabName, "' AND  PROJECT_ID=", ProjectId };
                string str = string.Concat(objArray);
                if (Common.iDBType == 1)
                {
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                }
                else if(Common.iDBType ==3)
                {
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                    dataTable1 = dataTable;
            }
            catch (Exception exception)
            {
                throw;
            }
            return dataTable1;
        }

        public DataTable fnGetColMappingData(int ProjectID)
        {
            DataTable dataTable = null;
            DataTable dataTable1;
            try
            {
                string str = "";
                str = string.Concat("Select * from TRE_MAPPING Where ProjectId =", ProjectID);
                if (Common.iDBType == 1)
                {
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                }
                else if(Common.iDBType ==3)
                {
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                    dataTable1 = dataTable;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable1;
        }

        public DataTable fnGetTableNames()
        {
            DataTable dataTable;
            DataTable dataTable1;
            try
            {
                string str = "";
                if (Common.iDBType == 1)
                {
                    str = "select TName from tab WHERE TABTYPE = 'TABLE' AND  TName not like 'APEX%' AND TName not like 'BIN%' AND TName not like 'DEMO%'";
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                   
                }
                else if (Common.iDBType == 3)
                {
                     str= "select TABLE_NAME as TName FROM information_schema.TABLES WHERE  TABLE_SCHEMA = 'recousr'";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else
                {
                    dataTable = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                dataTable1 = dataTable;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable1;
        }

        public DataTable fnGetTreDetails(string strTabName)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = "";
                if (Common.iDBType == 1)
                {
                    str = (strTabName != "Tre_Random" ? string.Concat("Select * from ", strTabName, "  where ROWNUM <= 100") : string.Concat("Select * from ", strTabName));
                    dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    str = ( !strTabName.Contains("Tre_Random") ? string.Concat("Select * from ", strTabName, "  limit 100") : string.Concat("Select * from ", strTabName));
                    dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else
                {
                    str = (strTabName != "Tre_Random" ? string.Concat("Select * from ", strTabName, "  where ROWNUM <= 100") : string.Concat("Select * from ", strTabName));
                    dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable fnGetTreDetailsSchema(string strTabName)
        {
            DataTable dataTable1;
            try
            {
                 dataTable1 = new DataTable();
                string str = "";
                if (Common.iDBType == (int)Enums.DBType.Oracle)
                {
                    str = string.Concat("select * from ", strTabName, " where ROWNUM <= 2");
                    dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);

                }
                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                {
                    str = "select * from recousr." + strTabName + " limit 2";
                    dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else
                {
                    str = string.Concat("select top 1 * from ", strTabName);
                    dataTable1 = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                DataTableReader dataTableReader = new DataTableReader(dataTable1);
                DataTable schemaTable = dataTableReader.GetSchemaTable();
                dataTableReader.Close();
                dataTableReader = null;
                dataTable1 = schemaTable;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable1;
        }

        public void fnInserFilter(string strFilterCondition, int ProjectId)
        {
            try
            {
                string str = string.Concat("Select Count(1) FROM FILTER_MAIN WHERE PROJECT_ID=", ProjectId);
                if (int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) <= 0)
                {
                    object[] projectId = new object[] { "INSERT  INTO FILTER_MAIN (PROJECT_ID,FILTER) VALUES ( ", ProjectId, ",'", strFilterCondition.Replace("'", "''"), "' )" };
                    str = string.Concat(projectId);
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                    }
                }
                else
                {
                    str = string.Concat("DELETE  FROM FILTER_MAIN WHERE PROJECT_ID=", ProjectId);
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void fnInsertTreMApping(DataRow[] drs, string strTabName, string strFilerCondition, int ProjectId)
        {
            if (Common.iDBType == (int)Enums.DBType.Oracle || Common.iDBType == (int)Enums.DBType.SQl)
            {
                try
                {
                    string str = "";
                    string str1 = "Create Table ETS_ADM_WEEKLY_A (";
                    string str2 = "Create Table ETS_ADM_WEEKLY_B (";
                    string str3 = "";
                    string str4 = "";
                    string str5 = "";
                    string str6 = "";
                    string str7 = "";
                    string str8 = "";
                    string str9 = "Create Table ETS_TRE_BASE (";
                    string str10 = "Create Table ETS_TRE_BASED (";
                    string str11 = "Create Table ETS_TRE_BASEP (";
                    string str12 = "";
                    string str13 = "";
                    string str14 = "";
                    int num = 0;
                    int num1 = 0;
                    int num2 = 0;
                    string str15 = "";
                    int num3 = 0;
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_A'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_ADM_WEEKLY_A";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_B'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_ADM_WEEKLY_B";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_BASE'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASE";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_BASED'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASED";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_BASEP'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASEP";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_X_SELL_PTNL'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_X_SELL_PTNL";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'TRE_OPPORTUNITY'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE TRE_OPPORTUNITY";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_ADM_WEEKLY_A' ";
                    if (Common.iDBType == 1)
                    {
                        num = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_X_SELL_PNTL' ";
                    if (Common.iDBType == 1)
                    {
                        num1 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_BASE' ";
                    if (Common.iDBType == 1)
                    {
                        num2 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_BASED' ";
                    if (Common.iDBType == 1)
                    {
                        int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_BASEP' ";
                    if (Common.iDBType == 1)
                    {
                        int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    DataTable dataTable = new DataTable();
                    str = string.Concat("SELECT COLNAME FROM TRE_MAPPING Where ProjectId=", ProjectId);
                    if (Common.iDBType == 1)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    DataRow[] dataRowArray = drs;
                    for (int i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow = dataRowArray[i];
                        if (dataTable.Rows.Count > 0)
                        {
                            dataTable.AsEnumerable().Where<DataRow>((DataRow r) => r.Field<string>("COLNAME") == dataRow[0].ToString()).ToList<DataRow>().ForEach((DataRow row) => row.Delete());
                            dataTable.AcceptChanges();
                        }
                        if (dataRow["type"].ToString() == 5.ToString())
                        {
                            string[] upper = new string[] { " Delete from TRE_MAPPING where upper(TABLENAME) = '", strTabName.ToUpper(), "' and upper(COLNAME) = '", dataRow[0].ToString().ToUpper(), "'" };
                            str = string.Concat(upper);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            if (num > 0)
                            {
                                str = string.Concat(" Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_A' and upper(column_name) = 'A_", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A drop column A_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B drop column B_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE drop column A_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE drop column B_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE drop column D_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE drop column X_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED drop column A_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED drop column B_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED drop column D_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED drop column X_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED drop column S_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column A_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column B_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column D_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column X_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column S_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column P_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_A' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A drop column ", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_B' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B drop column ", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASE drop column ", dataRow[0].ToString());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASED' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASED drop column ", dataRow[0].ToString());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASEP' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP drop column ", dataRow[0].ToString());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                            }
                            if (num1 > 0)
                            {
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_X_SELL_PNTL' and upper(column_name) = 'X_", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_X_SELL_PNTL drop column X_", dataRow[0].ToString());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                            }
                        }
                        else
                        {
                            if (dataRow["Table"] != null)
                            {
                                str15 = string.Concat(str15, dataRow[0].ToString());
                            }
                            else
                            {
                                object[] projectId = new object[] { "select COMBINE_COLUMNS FROM TRE_CALCULATED_COLUMNS WHERE Project_Id = ", ProjectId, "  AND COLNAME='", dataRow[0].ToString(), "'" };
                                str = string.Concat(projectId);
                                if (Common.iDBType == 1)
                                {
                                    DataTable dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                                    str15 = string.Concat(str15, dataTable1.Rows[0]["COMBINE_COLUMNS"].ToString(), " ", dataRow[0].ToString());
                                }
                            }
                            str15 = string.Concat(str15, ",");
                            object[] objArray = new object[] { " Select count(1) from TRE_MAPPING where TABLENAME = '", strTabName, "' and COLNAME = '", dataRow[0].ToString(), "' and PROJECTID=", ProjectId };
                            str = string.Concat(objArray);
                            num3 = (Common.iDBType != 1 ? int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) : int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)));
                            if (num3 != 0)
                            {
                                str = "update TRE_MAPPING Set ISREQUIRED= ";
                                str = (dataRow["Required"] == DBNull.Value || !(bool)dataRow["Required"] ? string.Concat(str, "0") : string.Concat(str, "1"));
                                string str16 = str;
                                string[] strArrays = new string[] { str16, ",TYPE=", dataRow["type"].ToString(), ",COLDATATYPE='", dataRow["dataType"].ToString(), "' where TABLENAME = '", strTabName, "'" };
                                str = string.Concat(strArrays);
                                str = string.Concat(str, " and COLNAME = '", dataRow[0].ToString(), "'");
                                if (Common.iDBType != 1)
                                {
                                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                                }
                                else
                                {
                                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                                }
                            }
                            else
                            {
                                str = string.Concat("INSERT INTO TRE_MAPPING (COLNAME, ISREQUIRED,TYPE,COLDATATYPE,TABLENAME,PROJECTID) VALUES('", dataRow[0].ToString(), "',");
                                str = (dataRow["Required"] == DBNull.Value || !(bool)dataRow["Required"] ? string.Concat(str, "0") : string.Concat(str, "1"));
                                object obj = str;
                                object[] objArray1 = new object[] { obj, ",", dataRow["type"].ToString(), ",'", dataRow["dataType"].ToString(), "','", strTabName, "',", ProjectId, ")" };
                                str = string.Concat(objArray1);
                                if (Common.iDBType != 1)
                                {
                                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                                }
                                else
                                {
                                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                                }
                            }
                            string str17 = "";
                            if (dataRow["dataType"].ToString() == "System.String")
                            {
                                str17 = " varchar(200)";
                            }
                            else if (dataRow["dataType"].ToString() != "System.Decimal")
                            {
                                str17 = (dataRow["dataType"].ToString() != "System.DateTime" ? " Number (18,2)" : " Date ");
                            }
                            else
                            {
                                str17 = " Number (18,2)";
                            }
                            if (dataRow["type"].ToString() == 2.ToString())
                            {
                                if (dataRow["dataType"].ToString() != "System.String" && dataRow["dataType"].ToString() != "System.DateTime")
                                {
                                    str = string.Concat(" Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_A' and upper(column_name) = 'A_", dataRow[0].ToString().ToUpper(), "'");
                                    if (Common.iDBType == 1)
                                    {
                                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                    }
                                    if (num3 == 0)
                                    {
                                        if (num != 0)
                                        {
                                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A add A_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B add B_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE add A_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE add B_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE add X_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE add D_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED add A_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED add B_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED add X_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED add D_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED add S_", dataRow[0].ToString(), " varchar(200) ");
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP add A_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP add B_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP add X_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP add D_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP add S_", dataRow[0].ToString(), " varchar(200) ");
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP add P_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        }
                                        else
                                        {
                                            if (str5 != "")
                                            {
                                                str5 = string.Concat(str5, ",");
                                            }
                                            if (str6 != "")
                                            {
                                                str6 = string.Concat(str6, ",");
                                            }
                                            if (str12 != "")
                                            {
                                                str12 = string.Concat(str12, ",");
                                            }
                                            if (str13 != "")
                                            {
                                                str13 = string.Concat(str13, ",");
                                            }
                                            if (str14 != "")
                                            {
                                                str14 = string.Concat(str14, ",");
                                            }
                                            str5 = string.Concat(str5, "A_", dataRow[0].ToString(), str17);
                                            str6 = string.Concat(str6, "B_", dataRow[0].ToString(), str17);
                                            string str18 = str12;
                                            string[] strArrays1 = new string[] { str18, "A_", dataRow[0].ToString(), str17, ",B_", dataRow[0].ToString(), str17, ",X_", dataRow[0].ToString(), str17, ",D_", dataRow[0].ToString(), str17 };
                                            str12 = string.Concat(strArrays1);
                                            string str19 = str13;
                                            string[] strArrays2 = new string[] { str19, "A_", dataRow[0].ToString(), str17, ",B_", dataRow[0].ToString(), str17, ",X_", dataRow[0].ToString(), str17, ",D_", dataRow[0].ToString(), str17, ",S_", dataRow[0].ToString(), " varchar(200) " };
                                            str13 = string.Concat(strArrays2);
                                            string str20 = str14;
                                            string[] strArrays3 = new string[] { str20, "A_", dataRow[0].ToString(), str17, ",B_", dataRow[0].ToString(), str17, ",X_", dataRow[0].ToString(), str17, ",D_", dataRow[0].ToString(), str17, ",S_", dataRow[0].ToString(), " varchar(200) ,P_", dataRow[0].ToString(), str17 };
                                            str14 = string.Concat(strArrays3);
                                        }
                                    }
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_X_SELL_PNTL' and upper(column_name) = 'X_", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 == 0)
                                {
                                    if (num1 != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_TRE_X_SELL_PNTL add X_", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    }
                                    else
                                    {
                                        if (str7 != "")
                                        {
                                            str7 = string.Concat(str7, ",");
                                        }
                                        if (str8 != "")
                                        {
                                            str8 = string.Concat(str8, ",");
                                        }
                                        str7 = string.Concat(str7, "X_", dataRow[0].ToString(), str17);
                                    }
                                }
                            }
                            else if (dataRow["type"].ToString() == 4.ToString())
                            {
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (Common.iDBType == 3)
                                {
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 == 0)
                                {
                                    if (num != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASE add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASED add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASEP add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    }
                                    else
                                    {
                                        if (str4 != "")
                                        {
                                            str4 = string.Concat(str4, ",");
                                        }
                                        str4 = string.Concat(str4, dataRow[0].ToString(), str17);
                                    }
                                }
                            }
                            else if (dataRow["type"].ToString() == 1.ToString())
                            {
                                str = string.Concat(" Select count(1) from user_tab_columns where upper(table_name) = 'ETS_ADM_WEEKLY_A' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 == 0)
                                {
                                    if (num != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    }
                                    else
                                    {
                                        if (str3 != "")
                                        {
                                            str3 = string.Concat(str3, ",");
                                        }
                                        str3 = string.Concat(str3, dataRow[0].ToString(), str17);
                                    }
                                }
                            }
                        }
                    }
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        string[] upper1 = new string[] { " Delete from TRE_MAPPING where upper(TABLENAME) = '", strTabName.ToUpper(), "' and upper(COLNAME) = '", dataRow1[0].ToString().ToUpper(), "'" };
                        str = string.Concat(upper1);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A' and upper(column_name) = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A drop column ", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE' and upper(column_name) = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASE drop column ", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASED' and upper(column_name) = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column ", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASEP' and upper(column_name) = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column ", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A' and upper(column_name) = 'A_", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A drop column A_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B drop column B_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE drop column A_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE drop column B_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE drop column D_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE drop column X_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column A_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column B_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column D_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column X_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column S_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column A_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column B_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column D_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column X_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column S_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP drop column P_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASED' and upper(column_name) = 'X_", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 <= 0)
                        {
                            continue;
                        }
                        str = string.Concat(" Alter Table ETS_TRE_BASED drop column D_", dataRow1[0].ToString().ToUpper());
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Alter Table ETS_TRE_BASED drop column X_", dataRow1[0].ToString().ToUpper());
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Alter Table ETS_TRE_BASED drop column S_", dataRow1[0].ToString().ToUpper());
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str15 = str15.Substring(0, str15.Length - 1);
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'TRE_RANDOM'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE TRE_RANDOM";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = "Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " Select count(1) from ETS_ADM_WEEKLY_A";
                    if (num3 > 0 && Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 == 0)
                    {
                        string[] strArrays4 = new string[] { "CREATE TABLE TRE_RANDOM AS SELECT ", str15, "   from ", strTabName, " C , " };
                        str = string.Concat(strArrays4);
                        str = string.Concat(str, " ( SELECT RNDMCUSTOMER FROM   ( SELECT Distinct CUSTOMER as RNDMCUSTOMER FROM ", strTabName);
                        if (strFilerCondition != "")
                        {
                            str = string.Concat(str, " Where ", strFilerCondition);
                        }
                        str = string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE  rownum < 5000)K WHERE C.CUSTOMER=K.RNDMCUSTOMER ");
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else
                    {
                        string[] strArrays5 = new string[] { "CREATE TABLE TRE_RANDOM AS SELECT ", str15, "   from ", strTabName, " C , " };
                        str = string.Concat(strArrays5);
                        str = string.Concat(str, " ( SELECT RNDMCUSTOMER FROM   ( SELECT Distinct CUSTOMER as RNDMCUSTOMER FROM ", strTabName);
                        if (strFilerCondition != "")
                        {
                            str = string.Concat(str, " Where ", strFilerCondition);
                        }
                        str = string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE  rownum < 5000)K WHERE C.CUSTOMER=K.RNDMCUSTOMER ");
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    if (num == 0 && str5 != "")
                    {
                        str1 = string.Concat(str1, "TIMEPERIOD_ID number");
                        if (str3 != "")
                        {
                            str1 = string.Concat(str1, ",", str3);
                        }
                        if (str4 != "")
                        {
                            str1 = string.Concat(str1, ",", str4);
                        }
                        str1 = string.Concat(str1, ",", str5, ") NOLOGGING");
                        str2 = string.Concat(str2, "TIMEPERIOD_ID number");
                        if (str3 != "")
                        {
                            str2 = string.Concat(str2, ",", str3);
                        }
                        str2 = string.Concat(str2, ",", str6, ") NOLOGGING");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str1);
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str2);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str1);
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str2);
                        }
                    }
                    string str21 = "";
                    if (num2 == 0 && str12 != "")
                    {
                        if (str3 != "")
                        {
                            str21 = string.Concat(str21, str3);
                        }
                        if (str4 != "")
                        {
                            str21 = string.Concat(str21, ",", str4);
                        }
                        string str22 = str9;
                        string[] strArrays6 = new string[] { str22, str21, ",", str12, ") NOLOGGING" };
                        str9 = string.Concat(strArrays6);
                        string str23 = str10;
                        string[] strArrays7 = new string[] { str23, str21, ",", str13, ") NOLOGGING" };
                        str10 = string.Concat(strArrays7);
                        string str24 = str11;
                        string[] strArrays8 = new string[] { str24, str21, ",", str14, ") NOLOGGING" };
                        str11 = string.Concat(strArrays8);
                        str = "CREATE TABLE TRE_OPPORTUNITY ( CUSTOMER varchar2(50)  NULL,";
                        str = string.Concat(str, "WEEK number(2)  NULL )  NOLOGGING");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str9);
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str10);
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str11);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str9);
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str10);
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str11);
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                        }
                    }
                    if (num1 == 0 && str7 != "")
                    {
                        if (str7 != "")
                        {
                            str7 = string.Concat("CREATE TABLE ETS_TRE_X_SELL_PNTL(TIMEPERIOD varchar2(50),SEGMENTCOLNAME varchar(50),CURRENTSEGMENT VARCHAR(50), ", str7, ") NOLOGGING");
                        }
                        if (Common.iDBType == 1)
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str7);
                        }
                    }
                    str = string.Concat("select OPPORTUNITY_ID from Opportunity where IsOnMain = 0 and Project_Id=", ProjectId);
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        str = string.Concat(" Delete from STATUS_BREAKDOWN Where OPPORTUNITY_ID= ", Convert.ToInt32(dataRow2[0]));
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = string.Concat(" Delete from Opportunity where IsOnMain = 0 and Project_Id=", ProjectId);
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else if (Common.iDBType == (int)Enums.DBType.Mysql)
            {
                try
                {

                    string str = "";
                    string str1 = "Create Table ETS_ADM_WEEKLY_A"+ProjectId+" (";
                    string str2 = "Create Table ETS_ADM_WEEKLY_B" + ProjectId + " (";
                    string str3 = "";
                    string str4 = "";
                    string str5 = "";
                    string str6 = "";
                    string str7 = "";
                    string str8 = "";
                    string str9 = "Create Table ETS_TRE_BASE" + ProjectId + " (";
                    string str10 = "Create Table ETS_TRE_BASED" + ProjectId + "  (";
                    string str11 = "Create Table ETS_TRE_BASEP" + ProjectId + "  (";
                    string str12 = "";
                    string str13 = "";
                    string str14 = "";
                    int num = 0;
                    int num1 = 0;
                    int num2 = 0;
                    string str15 = "";
                    int num3 = 0;
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A"+ ProjectId + "' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_ADM_WEEKLY_A" + ProjectId;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_B" + ProjectId + "' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_ADM_WEEKLY_B" + ProjectId;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE" + ProjectId + "' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASE" + ProjectId;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASED" + ProjectId + "' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASED" + ProjectId;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASEP" + ProjectId + "' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASEP" + ProjectId;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PTNL" + ProjectId + "' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_X_SELL_PTNL" + ProjectId;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) FROM information_schema.columns c WHERE c.table_name = 'TRE_OPPORTUNITY' AND c.table_schema  = 'recousr'";
                    if (Common.iDBType == 3)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE TRE_OPPORTUNITY";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A" + ProjectId + "' AND c.table_schema  = 'recousr' ";
                    if (Common.iDBType == 3)
                    {
                        num = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PNTL" + ProjectId + "' AND c.table_schema  = 'recousr' ";
                    if (Common.iDBType == 3)
                    {
                        num1 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE" + ProjectId + "' AND c.table_schema  = 'recousr' ";
                    if (Common.iDBType == 3)
                    {
                        num2 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASED" + ProjectId + "' AND c.table_schema  = 'recousr' ";
                    if (Common.iDBType == 3)
                    {
                        int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASEP" + ProjectId + "' AND c.table_schema  = 'recousr' ";
                    if (Common.iDBType == 3)
                    {
                        int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    DataTable dataTable = new DataTable();
                    str = string.Concat("SELECT COLNAME FROM TRE_MAPPING Where ProjectId=", ProjectId);
                    if (Common.iDBType == 3)
                    {
                        dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    DataRow[] dataRowArray = drs;

                    for (int i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow = dataRowArray[i];
                        if (dataTable.Rows.Count > 0)
                        {
                            dataTable.AsEnumerable().Where<DataRow>((DataRow r) => r.Field<string>("COLNAME") == dataRow[0].ToString()).ToList<DataRow>().ForEach((DataRow row) => row.Delete());
                            dataTable.AcceptChanges();
                        }
                        if (dataRow["type"].ToString() == 5.ToString())
                        {
                            string[] upper = new string[] { " Delete from TRE_MAPPING where TABLENAME = '", strTabName.ToUpper(), "' and COLNAME = '", dataRow[0].ToString().ToUpper(), "'" };
                            str = string.Concat(upper);
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            if (num > 0)
                            {
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' and c.column_name = 'A_", dataRow[0].ToString().ToUpper(), "'");
                                
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + " drop column A_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B" + ProjectId + " drop column B_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column A_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column B_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column D_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column X_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column A_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column B_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column D_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column X_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column S_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column A_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column B_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column D_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column X_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column S_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column P_", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A" + ProjectId + "' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                                
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + " drop column ", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_B" + ProjectId + "' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                                
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B" + ProjectId + " drop column ", dataRow[0].ToString().ToUpper());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                                 num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column ", dataRow[0].ToString());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASED' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                                 num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column ", dataRow[0].ToString());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASEP' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                               
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column ", dataRow[0].ToString());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                            }
                            if (num1 > 0)
                            {
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PNTL" + ProjectId + "' and c.column_name = 'X_", dataRow[0].ToString().ToUpper(), "'");
                                 num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_X_SELL_PNTL" + ProjectId + " drop column X_", dataRow[0].ToString());
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                            }
                        }
                        else
                        {
                            if (dataRow["Table"].ToString() != "C")
                            {
                                str15 = string.Concat(str15, dataRow[0].ToString());
                            }
                            else
                            {
                                object[] projectId = new object[] { "select COMBINE_COLUMNS FROM TRE_CALCULATED_COLUMNS WHERE Project_Id = ", ProjectId, "  AND COLNAME='", dataRow[0].ToString(), "'" };
                                str = string.Concat(projectId);
                               
                                    DataTable dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                                    str15 = string.Concat(str15, dataTable1.Rows[0]["COMBINE_COLUMNS"].ToString(), " ", dataRow[0].ToString());
                                
                            }
                            str15 = string.Concat(str15, ",");
                            object[] objArray = new object[] { " Select count(1) from TRE_MAPPING where TABLENAME = '", strTabName, "' and COLNAME = '", dataRow[0].ToString(), "' and PROJECTID=", ProjectId };
                            str = string.Concat(objArray);
                            num3 = (int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)));
                            if (num3 != 0)
                            {
                                str = "update TRE_MAPPING Set ISREQUIRED= ";
                                str = (dataRow["Required"] == DBNull.Value || !(bool)dataRow["Required"] ? string.Concat(str, "0") : string.Concat(str, "1"));
                                string str16 = str;
                                string[] strArrays = new string[] { str16, ",TYPE=", dataRow["type"].ToString(), ",COLDATATYPE='", dataRow["dataType"].ToString(), "' where TABLENAME = '", strTabName, "'" };
                                str = string.Concat(strArrays);
                                str = string.Concat(str, " and COLNAME = '", dataRow[0].ToString(), "'");
                                
                                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                                
                            }
                            else
                            {
                                str = string.Concat("INSERT INTO TRE_MAPPING (COLNAME, ISREQUIRED,TYPE,COLDATATYPE,TABLENAME,PROJECTID) VALUES('", dataRow[0].ToString(), "',");
                                str = (dataRow["Required"] == DBNull.Value || !(bool)dataRow["Required"] ? string.Concat(str, "0") : string.Concat(str, "1"));
                                object obj = str;
                                object[] objArray1 = new object[] { obj, ",", dataRow["type"].ToString(), ",'", dataRow["dataType"].ToString(), "','", strTabName, "',", ProjectId, ")" };
                                str = string.Concat(objArray1);
                             
                                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                                
                            }
                            string str17 = "";
                            if (dataRow["dataType"].ToString() == "System.String")
                            {
                                str17 = " varchar(200)";
                            }
                            else if (dataRow["dataType"].ToString() != "System.Decimal")
                            {
                                str17 = (dataRow["dataType"].ToString() != "System.DateTime" ? " bigint" : " Date ");
                            }
                            else
                            {
                                str17 = " Double ";
                            }
                            if (dataRow["type"].ToString() == 2.ToString())
                            {
                                if (dataRow["dataType"].ToString() != "System.String" && dataRow["dataType"].ToString() != "System.DateTime")
                                {
                                    str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' and c.column_name = 'A_", dataRow[0].ToString().ToUpper(), "'");
                                   
                                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                    
                                    if (num3 == 0)
                                    {
                                        if (num != 0)
                                        {
                                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + " add A_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B" + ProjectId + " add B_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " add A_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " add B_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " add X_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " add D_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " add A_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " add B_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + "  add X_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + "  add D_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + "  add S_", dataRow[0].ToString(), " varchar(200) ");
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " add A_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + "  add B_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " add X_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + "  add D_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + "  add S_", dataRow[0].ToString(), " varchar(200) ");
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + "  add P_", dataRow[0].ToString(), str17);
                                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        }
                                        else
                                        {
                                            if (str5 != "")
                                            {
                                                str5 = string.Concat(str5, ",");
                                            }
                                            if (str6 != "")
                                            {
                                                str6 = string.Concat(str6, ",");
                                            }
                                            if (str12 != "")
                                            {
                                                str12 = string.Concat(str12, ",");
                                            }
                                            if (str13 != "")
                                            {
                                                str13 = string.Concat(str13, ",");
                                            }
                                            if (str14 != "")
                                            {
                                                str14 = string.Concat(str14, ",");
                                            }
                                            str5 = string.Concat(str5, "A_", dataRow[0].ToString(), str17);
                                            str6 = string.Concat(str6, "B_", dataRow[0].ToString(), str17);
                                            string str18 = str12;
                                            string[] strArrays1 = new string[] { str18, "A_", dataRow[0].ToString(), str17, ",B_", dataRow[0].ToString(), str17, ",X_", dataRow[0].ToString(), str17, ",D_", dataRow[0].ToString(), str17 };
                                            str12 = string.Concat(strArrays1);
                                            string str19 = str13;
                                            string[] strArrays2 = new string[] { str19, "A_", dataRow[0].ToString(), str17, ",B_", dataRow[0].ToString(), str17, ",X_", dataRow[0].ToString(), str17, ",D_", dataRow[0].ToString(), str17, ",S_", dataRow[0].ToString(), " varchar(200) " };
                                            str13 = string.Concat(strArrays2);
                                            string str20 = str14;
                                            string[] strArrays3 = new string[] { str20, "A_", dataRow[0].ToString(), str17, ",B_", dataRow[0].ToString(), str17, ",X_", dataRow[0].ToString(), str17, ",D_", dataRow[0].ToString(), str17, ",S_", dataRow[0].ToString(), " varchar(200) ,P_", dataRow[0].ToString(), str17 };
                                            str14 = string.Concat(strArrays3);
                                        }
                                    }
                                }
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PNTL" + ProjectId + "' and c.column_name = 'X_", dataRow[0].ToString().ToUpper(), "'");
                                
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 == 0)
                                {
                                    if (num1 != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_TRE_X_SELL_PNTL" + ProjectId + " add X_", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    }
                                    else
                                    {
                                        if (str7 != "")
                                        {
                                            str7 = string.Concat(str7, ",");
                                        }
                                        if (str8 != "")
                                        {
                                            str8 = string.Concat(str8, ",");
                                        }
                                        str7 = string.Concat(str7, "X_", dataRow[0].ToString(), str17);
                                    }
                                }
                            }
                            else if (dataRow["type"].ToString() == 4.ToString())
                            {
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A" + ProjectId + "' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                              
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 == 0)
                                {
                                    if (num != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + " add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    }
                                    else
                                    {
                                        if (str4 != "")
                                        {
                                            str4 = string.Concat(str4, ",");
                                        }
                                        str4 = string.Concat(str4, dataRow[0].ToString(), str17);
                                    }
                                }
                            }
                            else if (dataRow["type"].ToString() == 1.ToString())
                            {
                                str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A" + ProjectId + "' and c.column_name = '", dataRow[0].ToString().ToUpper(), "'");
                               
                                    num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                
                                if (num3 == 0)
                                {
                                    if (num != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + "add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B" + ProjectId + " add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    }
                                    else
                                    {
                                        if (str3 != "")
                                        {
                                            str3 = string.Concat(str3, ",");
                                        }
                                        str3 = string.Concat(str3, dataRow[0].ToString(), str17);
                                    }
                                }
                            }
                        }
                    }
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        string[] upper1 = new string[] { " Delete from TRE_MAPPING where TABLENAME = '", strTabName.ToUpper(), "' and COLNAME = '", dataRow1[0].ToString().ToUpper(), "'" };
                        str = string.Concat(upper1);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' and c.column_name = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 3)
                        {
                            num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + " drop column ", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE" + ProjectId + "' and c.column_name = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 3)
                        {
                            num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column ", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASED" + ProjectId + "' and c.column_name = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 3)
                        {
                            num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASED drop column ", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASEP"+ ProjectId + "' and c.column_name = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 3)
                        {
                            num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column ", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from information_schema.columns C where table_name = 'ETS_ADM_WEEKLY_A" + ProjectId + "' and c.column_name = 'A_", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 3)
                        {
                            num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A" + ProjectId + "drop column A_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_ADM_WEEKLY_B" + ProjectId + "drop column B_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + "drop column A_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + "drop column B_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column D_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE" + ProjectId + " drop column X_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column A_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column B_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column D_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column X_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column S_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column A_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column B_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column D_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + "drop column X_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column S_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASEP" + ProjectId + " drop column P_", dataRow1[0].ToString().ToUpper());
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASED" + ProjectId + "' and c.column_name = 'X_", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 3)
                        {
                            num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 <= 0)
                        {
                            continue;
                        }
                        str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column D_", dataRow1[0].ToString().ToUpper());
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column X_", dataRow1[0].ToString().ToUpper());
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Alter Table ETS_TRE_BASED" + ProjectId + " drop column S_", dataRow1[0].ToString().ToUpper());
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str15 = str15.Substring(0, str15.Length - 1);
                    str = " Select count(1) from information_schema.columns c WHERE c.table_name = 'TRE_RANDOM"+ProjectId+"'";
                   
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE TRE_RANDOM"+ProjectId ;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = "Select count(1) from information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A" + ProjectId + "'";
                   
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    
                    str = " Select count(1) from ETS_ADM_WEEKLY_A" + ProjectId + "";
                    if (num3 > 0)
                    {
                        num3 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 == 0)
                    {
                        string[] strArrays4 = new string[] { "CREATE TABLE TRE_RANDOM"+ ProjectId+" AS SELECT ", str15, "   from ", strTabName, " C , " };
                        str = string.Concat(strArrays4);
                        str = string.Concat(str, " ( SELECT RNDMCUSTOMER FROM   ( SELECT Distinct CUSTOMER as RNDMCUSTOMER FROM ", strTabName);
                        if (strFilerCondition != "")
                        {
                            str = string.Concat(str, " Where ", strFilerCondition);
                        }
                        str = string.Concat(str, " ORDER BY Rand() Limit 5000)R)K WHERE C.CUSTOMER=K.RNDMCUSTOMER ");
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else
                    {
                        string[] strArrays5 = new string[] { "CREATE TABLE TRE_RANDOM"+ ProjectId+ " AS SELECT ", str15, "   from ", strTabName, " C , " };
                        str = string.Concat(strArrays5);
                        str = string.Concat(str, " ( SELECT RNDMCUSTOMER FROM   ( SELECT Distinct CUSTOMER as RNDMCUSTOMER FROM ", strTabName);
                        if (strFilerCondition != "")
                        {
                            str = string.Concat(str, " Where ", strFilerCondition);
                        }
                        str = string.Concat(str, " ORDER BY rand() Limit 5000) K WHERE C.CUSTOMER=K.RNDMCUSTOMER ");
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " CREATE INDEX idx_randomcust ON tre_random" + ProjectId + " (Customer)";
                    if (Common.iDBType == (int)Enums.DBType.Mysql)
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                    if (num == 0 && str5 != "")
                    {
                        str1 = string.Concat(str1, "TIMEPERIOD_ID int");
                        if (str3 != "")
                        {
                            str1 = string.Concat(str1, ",", str3);
                        }
                        if (str4 != "")
                        {
                            str1 = string.Concat(str1, ",", str4);
                        }
                        str1 = string.Concat(str1, ",", str5, ") ");
                        str2 = string.Concat(str2, "TIMEPERIOD_ID int");
                        if (str3 != "")
                        {
                            str2 = string.Concat(str2, ",", str3);
                        }
                        str2 = string.Concat(str2, ",", str6, ") ");
                        
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str1 + ";" + "ALTER TABLE `recousr`.`ets_adm_weekly_a" + ProjectId + "` ADD INDEX `customer` (`CUSTOMER` ASC); ");
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str2 + ";" + "ALTER TABLE `recousr`.`ets_adm_weekly_b" + ProjectId + "` ADD INDEX `customer` (`CUSTOMER` ASC); ");

                    }
                    string str21 = "";
                    if (num2 == 0 && str12 != "")
                    {
                        if (str3 != "")
                        {
                            str21 = string.Concat(str21, str3);
                        }
                        if (str4 != "")
                        {
                            str21 = string.Concat(str21, ",", str4);
                        }
                        string str22 = str9;
                        string[] strArrays6 = new string[] { str22, str21, ",", str12, ") " };
                        str9 = string.Concat(strArrays6);
                        string str23 = str10;
                        string[] strArrays7 = new string[] { str23, str21, ",", str13, ") " };
                        str10 = string.Concat(strArrays7);
                        string str24 = str11;
                        string[] strArrays8 = new string[] { str24, str21, ",", str14, ") " };
                        str11 = string.Concat(strArrays8);
                        str = "CREATE TABLE TRE_OPPORTUNITY ( CUSTOMER varchar(50) ,";
                        str = string.Concat(str, "WEEK int   )  ");
                     
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str9+";"+ "ALTER TABLE `recousr`.`ets_tre_base" + ProjectId + "` ADD INDEX `customer` (`CUSTOMER` ASC, `DECILE` ASC); ");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str10 + ";" + "ALTER TABLE `recousr`.`ETS_TRE_BASED" + ProjectId + "` ADD INDEX `customer` (`CUSTOMER` ASC, `DECILE` ASC);");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str11+";" + "ALTER TABLE `recousr`.`ETS_TRE_BASEP" + ProjectId + "` ADD INDEX `customer` (`CUSTOMER` ASC, `DECILE` ASC);");
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str + ";" + "ALTER TABLE `recousr`.`TRE_OPPORTUNITY` ADD INDEX `customer` (`CUSTOMER` ASC);");

                    }
                    if (num1 == 0 && str7 != "")
                    {
                        if (str7 != "")
                        {
                            str7 = string.Concat("CREATE TABLE ETS_TRE_X_SELL_PNTL" + ProjectId + "(TIMEPERIOD varchar(50),SEGMENTCOLNAME varchar(50),CURRENTSEGMENT VARCHAR(50), ", str7, ",Index(CURRENTSEGMENT)) ");
                        }
                        if (Common.iDBType == 3)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str7);
                        }
                    }
                    str = string.Concat("select OPPORTUNITY_ID from Opportunity where IsOnMain = 0 and Project_Id=", ProjectId);
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        str = string.Concat(" Delete from STATUS_BREAKDOWN Where OPPORTUNITY_ID= ", Convert.ToInt32(dataRow2[0]));
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = string.Concat(" Delete from Opportunity where IsOnMain = 0 and Project_Id=", ProjectId);
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                catch (Exception exception)
                {
                    throw exception;
                }                
            }
        }

        public bool fnIsTREDetailsMapped()
        {
            DataTable dataTable;
            bool flag;
            try
            {
                string str = "Select * from TRE_MAPPING";
                dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                flag = (dataTable.Rows.Count <= 0 ? false : true);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public string fnselectFilterCondition(int iProjectid)
        {
            string str = "";
            string str1 = "";
            DataTable dataTable = new DataTable();
            str = string.Concat("Select FILTER FROM FILTER_MAIN WHERE PROJECT_ID=", iProjectid);
            if (Common.iDBType == 1)
            { 
                dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
             }
            else if(Common.iDBType == 3)
            {
                dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
            }

            if (dataTable.Rows.Count > 0)
            {
                str1 = dataTable.Rows[0]["FILTER"].ToString();
            }
            return str1;
        }

        public bool fnUpdateCalaculatedColumn(string strTabName, string strColName, string strFormula, int ProjectId)
        {
            bool flag;
            try
            {
                object[] objArray = new object[] { "update TRE_CALCULATED_COLUMNS Set COMBINE_COLUMNS= '", strFormula, "' Where Project_Id= ", ProjectId, " and COLNAME ='", strColName, "'" };
                string str = string.Concat(objArray);
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataTable fnValidateExpressEditor(string strString, string strTableName, int iExpressionFor)
        {
            DataTable dataTable;
            DataTable dataTable1;
            try
            {
                string str = "";
                dataTable = null;
                if (Common.iDBType == 1)
                {
                    if (iExpressionFor == 3 || iExpressionFor == 5 || iExpressionFor == 2)
                    {
                        string[] strArrays = new string[] { "Select  ", strString, " from ", strTableName, " Where ROWNUM <=2" };
                        str = string.Concat(strArrays);
                    }
                    else
                    {
                        string[] strArrays1 = new string[] { "Select  1 from ", strTableName, " Where ", strString, " and  ROWNUM <=2" };
                        str = string.Concat(strArrays1);
                    }
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else if(Common.iDBType == 3)

                {
                    if (iExpressionFor == 3 || iExpressionFor == 5 || iExpressionFor == 2)
                    {
                        string[] strArrays = new string[] { "Select  ", strString, " from ", strTableName, "  limit 2" };
                        str = string.Concat(strArrays);
                    }
                    else
                    {
                        string[] strArrays1 = new string[] { "Select  1 from ", strTableName, " Where ", strString, "   limit 2" };
                        str = string.Concat(strArrays1);
                    }
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);

                }

                dataTable1 = dataTable;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable1;
        }
    }
}