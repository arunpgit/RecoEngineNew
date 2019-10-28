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
                if (num <= 0)
                {
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'TEMP_CALACULATED'";
                    if (Common.iDBType == 1)
                    {
                        num = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num >= 1)
                    {
                        str = " DROP TABLE TEMP_CALACULATED";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    string[] strArrays = new string[] { " CREATE TABLE  TEMP_CALACULATED AS select ", strFormula, "  ", strColName, " from ", strTabName, " where rownum<=1" };
                    str = string.Concat(strArrays);
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    str = " SELECT COLUMN_NAME, DATA_TYPE FROM user_tab_columns WHERE table_name = 'TEMP_CALACULATED'";
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    object[] objArray = new object[] { "Insert into TRE_CALCULATED_COLUMNS (COLNAME,COMBINE_COLUMNS,PROJECT_ID,COLDATATYPE,TABLENAME) values ('", strColName.ToUpper(), "','", strFormula.Replace("'", "''"), "', ", ProjectId, " ,'", dataTable.Rows[0]["DATA_TYPE"], "','", strTabName, "')" };
                    str = string.Concat(objArray);
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
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
                if (Common.iDBType != 1)
                {
                    str = string.Concat("select top 100 * from ", strTabName);
                    dataTable1 = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
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
                    string str10 = "Create Table ETS_TRE_BASE2 (";
                    string str11 = "Create Table ETS_TRE_BASE3 (";
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
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_BASE2'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASE2";
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " Select count(1) from user_tab_columns where upper(table_name) = 'ETS_TRE_BASE3'";
                    if (Common.iDBType == 1)
                    {
                        num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    if (num3 >= 1)
                    {
                        str = " DROP TABLE ETS_TRE_BASE3";
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
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_BASE2' ";
                    if (Common.iDBType == 1)
                    {
                        int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    }
                    str = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_BASE3' ";
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
                                    str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column A_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column B_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column D_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column X_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column S_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column A_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column B_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column D_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column X_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column S_", dataRow[0].ToString().ToUpper());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column P_", dataRow[0].ToString().ToUpper());
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
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE2' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column ", dataRow[0].ToString());
                                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                }
                                str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE3' and upper(column_name) = '", dataRow[0].ToString().ToUpper(), "'");
                                if (Common.iDBType == 1)
                                {
                                    num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                                }
                                if (num3 > 0)
                                {
                                    str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column ", dataRow[0].ToString());
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
                                            str = string.Concat(" Alter Table ETS_TRE_BASE2 add A_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE2 add B_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE2 add X_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE2 add D_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE2 add S_", dataRow[0].ToString(), " varchar(200) ");
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE3 add A_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE3 add B_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE3 add X_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE3 add D_", dataRow[0].ToString(), str17);
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE3 add S_", dataRow[0].ToString(), " varchar(200) ");
                                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                            str = string.Concat(" Alter Table ETS_TRE_BASE3 add P_", dataRow[0].ToString(), str17);
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
                                if (num3 == 0)
                                {
                                    if (num != 0)
                                    {
                                        str = string.Concat(" Alter Table ETS_ADM_WEEKLY_A add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASE add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASE2 add ", dataRow[0].ToString().ToUpper(), str17);
                                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                                        str = string.Concat(" Alter Table ETS_TRE_BASE3 add ", dataRow[0].ToString().ToUpper(), str17);
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
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE2' and upper(column_name) = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column ", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE3' and upper(column_name) = '", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 > 0)
                        {
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column ", dataRow1[0].ToString().ToUpper());
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
                            str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column A_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column B_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column D_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column X_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column S_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column A_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column B_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column D_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column X_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column S_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat(" Alter Table ETS_TRE_BASE3 drop column P_", dataRow1[0].ToString().ToUpper());
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE2' and upper(column_name) = 'X_", dataRow1[0].ToString().ToUpper(), "'");
                        if (Common.iDBType == 1)
                        {
                            num3 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        }
                        if (num3 <= 0)
                        {
                            continue;
                        }
                        str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column D_", dataRow1[0].ToString().ToUpper());
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column X_", dataRow1[0].ToString().ToUpper());
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat(" Alter Table ETS_TRE_BASE2 drop column S_", dataRow1[0].ToString().ToUpper());
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
                    string strSql = "";
                    // fnDeleteTreMapping(strTabName);
                    string strCreateTString = "Create Table ETS_ADM_WEEKLY_A (";
                    string strCreateBString = "Create Table ETS_ADM_WEEKLY_B (";
                    string strKeyString = "";
                    string strSegmentString = "";
                    string strCreateTString1 = "";
                    string strCreateBString1 = "";
                    string strSellPtnlTableString = "";
                    string strSellPtnlUserTableString = "";
                    string strBaseString = "Create Table ETS_TRE_BASE (";
                    string strBase2String = "Create Table ETS_TRE_BASE2 (";
                    string strBase3String = "Create Table ETS_TRE_BASE3 (";
                    string strBaseString1 = "";
                    string strBase2String1 = "";
                    string strBase3String1 = "";
                    int iETS_ADM_WEEKLYExisits = 0;
                    int iETS_TRE_X_SELL_PNTLExisits = 0;
                    int iETS_TRE_BASE_Exisits = 0;
                    int iETS_TRE_BASE2_Exisits = 0;
                    int iETS_TRE_BASE3_Exisits = 0;
                    //int iTRE_Random = 0;
                    string strRandomColumns = "";
                    int iCount = 0;

                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' AND c.table_schema  = 'recousr'";
                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE ETS_ADM_WEEKLY_A";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }

                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_B' AND c.table_schema  = 'recousr'";

                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE ETS_ADM_WEEKLY_B";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }

                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE' AND c.table_schema  = 'recousr'";
                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE ETS_TRE_BASE";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }
                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE2' AND c.table_schema  = 'recousr'";
                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE ETS_TRE_BASE2";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }
                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE3' AND c.table_schema  = 'recousr'";
                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE ETS_TRE_BASE3";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }
                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PTNL' AND c.table_schema  = 'recousr'";
                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE ETS_TRE_X_SELL_PTNL";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }
                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'TRE_OPPORTUNITY' AND c.table_schema  = 'recousr'";
                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE TRE_OPPORTUNITY";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }




                    strSql = "SELECT count(1)  FROM information_schema.tables c where c.table_schema  = 'recousr' and c.table_name = 'ETS_ADM_WEEKLY_A'";
                    iETS_ADM_WEEKLYExisits = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    strSql = " SELECT count(1) FROM ALL_TABLES where table_name = 'ETS_TRE_X_SELL_PNTL' ";
                    iETS_TRE_X_SELL_PNTLExisits = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    strSql = "SELECT count(1)  FROM information_schema.tables c where c.table_schema  = 'recousr' and c.table_name = 'ETS_TRE_BASE'";
                    iETS_TRE_BASE_Exisits = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    strSql = "SELECT count(1)  FROM information_schema.tables c where c.table_schema  = 'recousr' and c.table_name = 'ETS_TRE_BASE2'";
                    iETS_TRE_BASE2_Exisits = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    strSql = "SELECT count(1)  FROM information_schema.tables c where c.table_schema  = 'recousr' and c.table_name = 'ETS_TRE_BASE3'";
                    iETS_TRE_BASE3_Exisits = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    DataTable dtDel = new DataTable();
                    strSql = "SELECT COLNAME FROM TRE_MAPPING Where ProjectId=" + ProjectId;
                    dtDel = (((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql));
                    //foreach (DataRow dtrow in dtDel.Rows)
                    //{
                    //    if (dtrow[0].ToString().StartsWith("B_"))
                    //    {
                    //        dtrow[0] = dtrow[0].ToString().Remove(0, 2);
                    //        dtrow.AcceptChanges();
                    //    }
                    //}


                    foreach (DataRow dr in drs)
                    {
                        if (dtDel.Rows.Count > 0)
                        {
                            dtDel.AsEnumerable().Where(r => r.Field<string>("COLNAME") == dr[0].ToString()).ToList().ForEach(row => row.Delete());
                            dtDel.AcceptChanges();
                        }
                        if (dr["type"].ToString() != ((int)Enums.ColType.None).ToString())
                        {

                            if (dr["Table"] == "C")
                            {
                                DataTable dt;
                                strSql = "select COMBINE_COLUMNS FROM TRE_CALCULATED_COLUMNS WHERE Project_Id = " + ProjectId + "  AND COLNAME='" + dr[0].ToString() + "'";
                                dt = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                                strRandomColumns += dt.Rows[0]["COMBINE_COLUMNS"].ToString() + " " + dr[0].ToString();

                            }
                            else
                            {
                                strRandomColumns += dr[0].ToString();
                            }
                            strRandomColumns += ",";
                            strSql = " Select count(1) from TRE_MAPPING where TABLENAME = '" + strTabName + "' and COLNAME = '" + dr[0].ToString() + "' and PROJECTID=" + ProjectId;

                            iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                            if (iCount == 0)
                            {
                                strSql = "INSERT INTO TRE_MAPPING (COLNAME, ISREQUIRED,TYPE,COLDATATYPE,TABLENAME,PROJECTID) VALUES" + "('" + dr[0].ToString() + "',";
                                if (dr["Required"] != DBNull.Value && (bool)dr["Required"])
                                    strSql += "1";
                                else
                                    strSql += "0";

                                strSql += "," + dr["type"].ToString() + ",'" + dr["dataType"].ToString() + "','" + strTabName + "'," + ProjectId + ")";


                                ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                            }
                            else
                            {
                                strSql = "update TRE_MAPPING Set ISREQUIRED= ";
                                if (dr["Required"] != DBNull.Value && (bool)dr["Required"])
                                    strSql += "1";
                                else
                                    strSql += "0";

                                strSql += ",TYPE=" + dr["type"].ToString() + ",COLDATATYPE='" + dr["dataType"].ToString() + "' where TABLENAME = '" + strTabName + "'";
                                strSql += " and COLNAME = '" + dr[0].ToString() + "'";

                                ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                            }
                            string strDType = "";
                            if (dr["dataType"].ToString() == "System.String")
                                strDType = " varchar(200)";
                            else if (dr["dataType"].ToString() == "System.Decimal")
                                strDType = " Number (18,2)";
                            else if (dr["dataType"].ToString() == "System.DateTime")
                                strDType = " Date ";
                            else
                                strDType = " Number (18,2)";

                            if (dr["type"].ToString() == ((int)Enums.ColType.Input).ToString())
                            {
                                if (dr["dataType"].ToString() != "System.String" && dr["dataType"].ToString() != "System.DateTime")
                                {


                                    strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' AND c.table_schema = 'recousr' and  c.column_name= 'A_" + dr[0].ToString().ToUpper() + "'";

                                    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                    if (iCount == 0)
                                    {
                                        if (iETS_ADM_WEEKLYExisits == 0)
                                        {
                                            if (strCreateTString1 != "")
                                                strCreateTString1 += ",";

                                            if (strCreateBString1 != "")
                                                strCreateBString1 += ",";


                                            if (strBaseString1 != "")
                                                strBaseString1 += ",";

                                            if (strBase2String1 != "")
                                                strBase2String1 += ",";


                                            if (strBase3String1 != "")
                                                strBase3String1 += ",";

                                            strCreateTString1 += "A_" + dr[0].ToString() + strDType;
                                            strCreateBString1 += "B_" + dr[0].ToString() + strDType;

                                            strBaseString1 += "A_" + dr[0].ToString() + strDType + ",B_" + dr[0].ToString() + strDType + ",X_" + dr[0].ToString() + strDType + ",D_" + dr[0].ToString() + strDType;

                                            strBase2String1 += "A_" + dr[0].ToString() + strDType + ",B_" + dr[0].ToString() + strDType + ",X_" + dr[0].ToString() + strDType + ",D_" + dr[0].ToString() + strDType + ",S_" + dr[0].ToString() + " varchar(200) ";

                                            strBase3String1 += "A_" + dr[0].ToString() + strDType + ",B_" + dr[0].ToString() + strDType + ",X_" + dr[0].ToString() + strDType + ",D_" + dr[0].ToString() + strDType + ",S_" + dr[0].ToString() + " varchar(200) ,P_" + dr[0].ToString() + strDType;

                                        }

                                    }
                                }
                                strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PNTL' AND c.table_schema  = 'recousr' and  c.column_name= 'X_" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount == 0)
                                {
                                    if (iETS_TRE_X_SELL_PNTLExisits == 0)
                                    {
                                        if (strSellPtnlTableString != "")
                                            strSellPtnlTableString += ",";

                                        if (strSellPtnlUserTableString != "")
                                            strSellPtnlUserTableString += ",";

                                        strSellPtnlTableString += "X_" + dr[0].ToString() + strDType;

                                    }
                                    else
                                    {
                                        strSql = " Alter Table ETS_TRE_X_SELL_PNTL add X_" + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    }
                                }



                            }
                            else if (dr["type"].ToString() == ((int)Enums.ColType.Segment).ToString())
                            {

                                strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' AND c.table_schema  = 'recousr' and c.column_name ='" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount == 0)
                                {
                                    if (iETS_ADM_WEEKLYExisits == 0)
                                    {
                                        if (strSegmentString != "")
                                        {
                                            strSegmentString += ",";
                                        }

                                        strSegmentString += dr[0].ToString() + strDType;
                                    }
                                    else
                                    {
                                        strSql = " Alter Table ETS_ADM_WEEKLY_A add " + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                        strSql = " Alter Table ETS_TRE_BASE add " + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                        strSql = " Alter Table ETS_TRE_BASE2 add " + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                        strSql = " Alter Table ETS_TRE_BASE3 add " + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                    }
                                }


                            }
                            else if (dr["type"].ToString() == ((int)Enums.ColType.Key).ToString())
                            {
                                strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' AND c.table_schema  = 'recousr' and c.column_name ='" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount == 0)
                                {
                                    if (iETS_ADM_WEEKLYExisits == 0)
                                    {
                                        if (strKeyString != "")
                                        {
                                            strKeyString += ",";
                                        }

                                        strKeyString += dr[0].ToString() + strDType;
                                    }
                                    else
                                    {
                                        strSql = " Alter Table ETS_ADM_WEEKLY_A add " + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                        strSql = " Alter Table ETS_ADM_WEEKLY_B add " + dr[0].ToString().ToUpper() + strDType;
                                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                    }
                                }


                            }

                        }
                        else
                        {
                            strSql = " Delete from TRE_MAPPING where table_name= '" + strTabName.ToUpper() + "' and column_name = '" + dr[0].ToString().ToUpper() + "'";
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);


                            if (iETS_ADM_WEEKLYExisits > 0)
                            {
                                strSql = " Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A' and column_name = 'A_" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_ADM_WEEKLY_A drop column A_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_ADM_WEEKLY_B drop column B_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);


                                    strSql = " Alter Table ETS_TRE_BASE drop column A_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE drop column B_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE drop column D_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE drop column X_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);



                                    strSql = " Alter Table ETS_TRE_BASE2 drop column A_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE2 drop column B_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE2 drop column D_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE2 drop column X_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE2 drop column S_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);


                                    strSql = " Alter Table ETS_TRE_BASE3 drop column A_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE3 drop column B_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE3 drop column D_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE3 drop column X_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                    strSql = " Alter Table ETS_TRE_BASE3 drop column S_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);


                                    strSql = " Alter Table ETS_TRE_BASE3 drop column P_" + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                }

                                strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_A' AND c.table_schema = 'recousr' and c.column_name ='" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_ADM_WEEKLY_A drop column " + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                }

                                strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_ADM_WEEKLY_B' AND c.table_schema  = 'recousr' and c.column_name ='" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_ADM_WEEKLY_B drop column " + dr[0].ToString().ToUpper();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                }

                                strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE' AND c.table_schema  = 'recousr' and c.column_name ='" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_TRE_BASE drop column " + dr[0].ToString();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                }

                                strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE2' AND c.table_schema  = 'recousr' and c.column_name = '" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_TRE_BASE2 drop column " + dr[0].ToString();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                }
                                strSql = "SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE3' AND c.table_schema  = 'recousr' and c.column_name ='" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_TRE_BASE3 drop column " + dr[0].ToString();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                                }
                                //strSql = " Select count(1) from user_tab_columns where table_name = 'TRE_RANDOM' and upper(column_name) = '" + dr[0].ToString().ToUpper() + "'";
                                //if (Common.iDBType == (int)Enums.DBType.Oracle)
                                //{
                                //    iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                                //}
                                //if (iCount > 0)
                                //{
                                //    strSql = " Alter Table TRE_RANDOM drop column " + dr[0].ToString();
                                //       ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                //}


                            }

                            if (iETS_TRE_X_SELL_PNTLExisits > 0)
                            {
                                strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PNTL' AND c.table_schema  = 'recousr' and c.column_name = 'X_" + dr[0].ToString().ToUpper() + "'";
                                iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                                if (iCount > 0)
                                {
                                    strSql = " Alter Table ETS_TRE_X_SELL_PNTL drop column X_" + dr[0].ToString();
                                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                                }
                            }


                        }
                    }


                    foreach (DataRow dr in dtDel.Rows)
                    {


                        strSql = " Delete from TRE_MAPPING where TABLE_NAME = '" + strTabName.ToUpper() + "' and colname = '" + dr[0].ToString().ToUpper() + "'";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        strSql = " Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A' and column_name = '" + dr[0].ToString().ToUpper() + "'";
                        iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                        if (iCount > 0)
                        {

                            strSql = " Alter Table ETS_ADM_WEEKLY_A drop column " + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        }

                        strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE' AND c.table_schema  = 'recousr' and c.column_name = '" + dr[0].ToString().ToUpper() + "'";
                        iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                        if (iCount > 0)
                        {

                            strSql = " Alter Table ETS_TRE_BASE drop column " + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        }
                        strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE2' AND c.table_schema  = 'recousr' and c.column_name  = '" + dr[0].ToString().ToUpper() + "'";
                        iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                        if (iCount > 0)
                        {

                            strSql = " Alter Table ETS_TRE_BASE2 drop column " + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        }

                        strSql = " Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE3' and upper(column_name) = '" + dr[0].ToString().ToUpper() + "'";
                        iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                        if (iCount > 0)
                        {

                            strSql = " Alter Table ETS_TRE_BASE3 drop column " + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        }


                        strSql = " Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A' and upper(column_name) = 'A_" + dr[0].ToString().ToUpper() + "'";
                        if (Common.iDBType == (int)Enums.DBType.Oracle)
                        {
                            iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                        }
                        if (iCount > 0)
                        {

                            strSql = " Alter Table ETS_ADM_WEEKLY_A drop column A_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_ADM_WEEKLY_B drop column B_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);


                            strSql = " Alter Table ETS_TRE_BASE drop column A_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                            strSql = " Alter Table ETS_TRE_BASE drop column B_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE drop column D_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE drop column X_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);



                            strSql = " Alter Table ETS_TRE_BASE2 drop column A_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                            strSql = " Alter Table ETS_TRE_BASE2 drop column B_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE2 drop column D_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE2 drop column X_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE2 drop column S_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);



                            strSql = " Alter Table ETS_TRE_BASE3 drop column A_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                            strSql = " Alter Table ETS_TRE_BASE3 drop column B_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE3 drop column D_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE3 drop column X_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE3 drop column S_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE3 drop column P_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        }

                        strSql = " Select count(1) from user_tab_columns where table_name = 'ETS_TRE_BASE2' and upper(column_name) = 'X_" + dr[0].ToString().ToUpper() + "'";
                        if (Common.iDBType == (int)Enums.DBType.Oracle)
                        {
                            iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                        }
                        if (iCount > 0)
                        {
                            //strSql = " Alter Table ETS_TRE_BASE2 drop column A_" + dr[0].ToString().ToUpper();
                            //((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                            //strSql = " Alter Table ETS_TRE_BASE2 drop column B_" + dr[0].ToString().ToUpper();
                            //((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE2 drop column D_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE2 drop column X_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                            strSql = " Alter Table ETS_TRE_BASE2 drop column S_" + dr[0].ToString().ToUpper();
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                        }

                    }

                    strRandomColumns = strRandomColumns.Substring(0, strRandomColumns.Length - 1);
                    strSql = " Select count(1) from user_tab_columns where upper(table_name) = 'TRE_RANDOM'";
                    //  strSql = " select Count(1) from   TRE_RANDOM";

                    if (Common.iDBType == (int)Enums.DBType.Oracle)
                    {
                        iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    }
                    if (iCount >= 1)
                    {

                        strSql = " DROP TABLE TRE_RANDOM";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }

                    strSql = "Select count(1) from user_tab_columns where table_name = 'ETS_ADM_WEEKLY_A'";
                    if (Common.iDBType == (int)Enums.DBType.Oracle)
                    {
                        iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    }

                    strSql = " Select count(1) from ETS_ADM_WEEKLY_A";
                    if (iCount > 0)
                    {
                        if (Common.iDBType == (int)Enums.DBType.Oracle)
                        {
                            iCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                        }
                    }
                    if (iCount != 0)
                    {

                        //strSql = "CREATE TABLE TRE_RANDOM AS SELECT " + strRandomColumns + "   from " + strTabName + " WHERE ";
                        //if (strFilerCondition != "")
                        //    strSql += strFilerCondition + " and  ";
                        //strSql += " Customer in( SELECT  Distinct CUSTOMER FROM  ETS_ADM_WEEKLY_A )";
                        //((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);



                        //                    Select C.CUSTOMER    from TRE_DETAILS_NEW_C  C,
                        //( SELECT CUSTOMER,week FROM   ( SELECT Distinct CUSTOMER,week FROM TRE_DETAILS_NEW_C Where HS_FLAG='0' 
                        //ORDER BY DBMS_RANDOM.RANDOM) WHERE  rownum < 5000) K WHERE C.CUSTOMER=K.cUSTOMER AND C.WEEK=K.WEEK

                        strSql = "CREATE TABLE TRE_RANDOM AS SELECT " + strRandomColumns + "   from " + strTabName + " C , ";

                        strSql += " ( SELECT RNDMCUSTOMER FROM   ( SELECT Distinct CUSTOMER as RNDMCUSTOMER FROM " + strTabName;

                        if (strFilerCondition != "")
                            strSql += " Where " + strFilerCondition + "";
                        strSql += " ORDER BY DBMS_RANDOM.RANDOM) WHERE  rownum < 5000)K WHERE C.CUSTOMER=K.RNDMCUSTOMER ";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                    }
                    else
                    {
                        strSql = "CREATE TABLE TRE_RANDOM AS SELECT " + strRandomColumns + "   from " + strTabName + " C , ";

                        strSql += " ( SELECT RNDMCUSTOMER FROM   ( SELECT Distinct CUSTOMER as RNDMCUSTOMER FROM " + strTabName;

                        if (strFilerCondition != "")
                            strSql += " Where " + strFilerCondition + "";
                        strSql += " ORDER BY DBMS_RANDOM.RANDOM) WHERE  rownum < 5000)K WHERE C.CUSTOMER=K.RNDMCUSTOMER ";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                    }



                    if (iETS_ADM_WEEKLYExisits == 0 && strCreateTString1 != "")
                    {
                        strCreateTString += "TIMEPERIOD_ID number";

                        if (strKeyString != "")
                            strCreateTString += "," + strKeyString;
                        if (strSegmentString != "")
                            strCreateTString += "," + strSegmentString;

                        strCreateTString += "," + strCreateTString1 + ") NOLOGGING";


                        strCreateBString += "TIMEPERIOD_ID number";
                        if (strKeyString != "")
                            strCreateBString += "," + strKeyString;

                        strCreateBString += "," + strCreateBString1 + ") NOLOGGING";


                        if (Common.iDBType == (int)Enums.DBType.Oracle)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strCreateTString);
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strCreateBString);
                        }
                        else
                        {
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strCreateTString);
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strCreateBString);
                        }
                        //indexes created by Sravanthi

                        strCreateTString = "CREATE INDEX ETS_ADM_WEEKLY_A_IX ON ETS_ADM_WEEKLY_A(CUSTOMER)";
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strCreateTString);

                        strCreateBString = "CREATE INDEX ETS_ADM_WEEKLY_B_IX ON ETS_ADM_WEEKLY_B(CUSTOMER)";
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strCreateBString);
                    }
                    string strKeySegmentString = "";
                    if (iETS_TRE_BASE_Exisits == 0 && strBaseString1 != "")
                    {


                        if (strKeyString != "")
                            strKeySegmentString += strKeyString;
                        if (strSegmentString != "")
                            strKeySegmentString += "," + strSegmentString;

                        strBaseString += strKeySegmentString + "," + strBaseString1 + ") NOLOGGING";

                        strBase2String += strKeySegmentString + "," + strBase2String1 + ") NOLOGGING";

                        strBase3String += strKeySegmentString + "," + strBase3String1 + ") NOLOGGING";
                        strSql = "CREATE TABLE TRE_OPPORTUNITY ( CUSTOMER varchar2(50)  NULL,";
                        strSql += "WEEK number(2)  NULL )  NOLOGGING";

                        if (Common.iDBType == (int)Enums.DBType.Oracle)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBaseString);
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBase2String);
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBase3String);
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                        }
                        else
                        {
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBaseString);
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBase2String);
                            ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBase3String);
                        }

                        //Sravanthi
                        strBaseString = "CREATE INDEX ETS_TRE_BASE_IX ON ETS_TRE_BASE(CUSTOMER)";
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBaseString);

                        strBase2String = "CREATE INDEX ETS_TRE_BASE2_IX ON ETS_TRE_BASE2(CUSTOMER)";
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBase2String);

                        strBase3String = "CREATE INDEX ETS_TRE_BAS3E_IX ON ETS_TRE_BASE3(CUSTOMER)";
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strBase3String);

                    }

                    if (iETS_TRE_X_SELL_PNTLExisits == 0 && strSellPtnlTableString != "")
                    {
                        if (strSellPtnlTableString != "")
                            strSellPtnlTableString = "CREATE TABLE ETS_TRE_X_SELL_PNTL(TIMEPERIOD varchar2(50),SEGMENTCOLNAME varchar(50),CURRENTSEGMENT VARCHAR(50), " + strSellPtnlTableString + ") NOLOGGING";

                        if (Common.iDBType == (int)Enums.DBType.Oracle)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSellPtnlTableString);
                        }

                    }
                    //dELETING UNSAVED OPPORTUNITITES
                    strSql = "select OPPORTUNITY_ID from Opportunity where IsOnMain = 0 and Project_Id=" + ProjectId;
                    DataTable dtOpp = new DataTable();
                    dtOpp = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                    foreach (DataRow dr in dtOpp.Rows)
                    {
                        strSql = " Delete from STATUS_BREAKDOWN Where OPPORTUNITY_ID= " + Convert.ToInt32(dr[0]);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);
                    }
                    strSql = " Delete from Opportunity where IsOnMain = 0 and Project_Id=" + ProjectId;
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, strSql);

                }
                catch (Exception ex)
                {
                    throw ex;
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
            dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
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
                if (Common.iDBType != 1)
                {
                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
                else
                {
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
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
                if (Common.iDBType != 1)
                {
                    str = string.Concat("Select Top 1 ", strString, " from ", strTableName);
                    dataTable = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else
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