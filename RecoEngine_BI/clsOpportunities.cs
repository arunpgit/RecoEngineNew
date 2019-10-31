using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RecoEngine_DataLayer;
using System.Collections;

namespace RecoEngine_BI
{
    public class clsOpportunities
    {
        private clsTre_Details clsTObj = new clsTre_Details();

        public clsOpportunities()
        {
        }

        public bool fnActiveOpportunities(string strOfferId)
        {
            bool flag;
            try
            {
                string[] strArrays = strOfferId.Split(new char[] { ';' });
                if ((int)strArrays.Length > 0)
                {
                    string str = string.Concat("UPDATE Opportunity SET  ISACTIVE = ", strArrays[1], " WHERE  OPPORTUNITY_ID = ", strArrays[0]);
                    if (Common.iDBType == 1 || Common.iDBType == 2)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        if (strArrays[1] == "0")
                        {
                            str = string.Concat("UPDATE CAMPAIGNS SET  ISACTIVE = ", strArrays[1], " WHERE  OPPORTUNITY_ID = ", strArrays[0]);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = " DELETE FROM PRIORITIZED_TEMP  WHERE CAMPAIGNID=";
                            str = string.Concat(str, "(SELECT  nvl(Sum(CAMPAIGN_ID),0) FROM CAMPAIGNS WHERE OPPORTUNITY_ID=", strArrays[0], ")");
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    else if(Common.iDBType ==3)
                    {
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        if (strArrays[1] == "0")
                        {
                            str = string.Concat("UPDATE CAMPAIGNS SET  ISACTIVE = ", strArrays[1], " WHERE  OPPORTUNITY_ID = ", strArrays[0]);
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = " DELETE FROM PRIORITIZED_TEMP  WHERE CAMPAIGNID=";
                            str = string.Concat(str, "(SELECT  nvl(Sum(CAMPAIGN_ID),0) FROM CAMPAIGNS WHERE OPPORTUNITY_ID=", strArrays[0], ")");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool fnCheckOPPHasInRanking(string strOppId, int iProjectId)
        {
            bool flag = false;
            try
            {

                object[] objArray = new object[] { "Select nvl(count(1),0) from OPPORTUNITY_RANKING where project_id= ", iProjectId, " AND ( RANK1 =", strOppId, " OR RANK2 = ", strOppId, " OR RANK3 = ", strOppId, " OR RANK4 =", strOppId, ")" };
                string str = string.Concat(objArray);
                if (Common.iDBType == 1 || Common.iDBType ==2)
                {
                    flag = (int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) <= 0 ? false : true);
                }
                else if(Common.iDBType == 3)
                {
                    flag = (int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) <= 0 ? false : true);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool fnDeleteOpportunity(ArrayList recForDelete)
        {
            bool flag;
            try
            {
                string str = "";
                string str1 = "";
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    for (int i = 0; i < recForDelete.Count; i++)
                    {
                        string[] strArrays = recForDelete[i].ToString().Split(new char[] { ';' });
                        str = strArrays[0];
                        str1 = strArrays[1];
                        string str2 = string.Concat("Delete from STATUS_BREAKDOWN where OPPORTUNITY_ID=", str);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        int num = 0;
                        str2 = string.Concat(" Select count(1) from user_tab_columns where table_name = 'TRE_OPPORTUNITY' and upper(column_name) = '", str1.ToUpper(), "_DELTA'");
                        if (Common.iDBType == 1)
                        {
                            num = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str2));
                        }
                        if (num > 0)
                        {
                            str2 = string.Concat("Alter  TABLE TRE_OPPORTUNITY drop Column ", str1.ToUpper(), "_DELTA");
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                            str2 = string.Concat("Alter  TABLE TRE_OPPORTUNITY drop Column ", str1.ToUpper(), "_STATUS");
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                            str2 = string.Concat("Alter  TABLE TRE_OPPORTUNITY drop Column ", str1.ToUpper(), "_PNTL");
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        }
                        str2 = string.Concat(" DELETE from OPPORTUNITY_VALUES WHERE OPPORTUNITY_ID=", str);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        str2 = string.Concat("Delete from CAMPAIGNS where OPPORTUNITY_ID=", str);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        str2 = string.Concat("Delete from OPPORTUNITY where OPPORTUNITY_ID=", str);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                    }
                }
                else if(Common.iDBType == 3)
                {
                    for (int i = 0; i < recForDelete.Count; i++)
                    {
                        string[] strArrays = recForDelete[i].ToString().Split(new char[] { ';' });
                        str = strArrays[0];
                        str1 = strArrays[1];
                        string str2 = string.Concat("Delete from STATUS_BREAKDOWN where OPPORTUNITY_ID=", str);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        int num = 0;
                        str2 = string.Concat(" Select count(1) from user_tab_columns where table_name = 'TRE_OPPORTUNITY' and upper(column_name) = '", str1.ToUpper(), "_DELTA'");
                        if (Common.iDBType == 1)
                        {
                            num = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str2));
                        }
                        if (num > 0)
                        {
                            str2 = string.Concat("Alter  TABLE TRE_OPPORTUNITY drop Column ", str1.ToUpper(), "_DELTA");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                            str2 = string.Concat("Alter  TABLE TRE_OPPORTUNITY drop Column ", str1.ToUpper(), "_STATUS");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                            str2 = string.Concat("Alter  TABLE TRE_OPPORTUNITY drop Column ", str1.ToUpper(), "_PNTL");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        }
                        str2 = string.Concat(" DELETE from OPPORTUNITY_VALUES WHERE OPPORTUNITY_ID=", str);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        str2 = string.Concat("Delete from CAMPAIGNS where OPPORTUNITY_ID=", str);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                        str2 = string.Concat("Delete from OPPORTUNITY where OPPORTUNITY_ID=", str);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str2);
                    }
                }
                flag = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ((OraDBManager)Common.dbMgr).RollbackTrans();
                throw exception;
            }
            return flag;
        }

        public bool fnDeleteRankingOpportunity(string strID)
        {
            bool flag;
            try
            {
                string str = string.Concat(" Delete From OPPORTUNITY_RANKING where ID =", strID);
                if (Common.iDBType == 2)
                {
                    ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if(Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataTable fnGetBaseColumns(ref DataTable dtSchema)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                if (Common.iDBType == 1 || Common.iDBType == 3)
                {
                    dataTable1 = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, "select top 1 * from ETS_TRE_BASE2") : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, "select * from ETS_TRE_BASE2 where ROWNUM <= 2"));
                }
                else if (Common.iDBType == 3)
                {
                    dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, "select top 1 * from ETS_TRE_BASE2");
                        
                }
                DataTableReader dataTableReader = new DataTableReader(dataTable1);
                dtSchema = dataTableReader.GetSchemaTable();
                dataTableReader.Close();
                dataTableReader = null;
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable fnGetOpportunity(int iProjectId, int iUserId, bool bIsOppList)
        {
            DataTable dataTable;
            DataTable dataTable1 = null;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    string str = "";
                    str = "Select A.OPPORTUNITY_ID,A.OPP_NAME,A.DESCRIPTION,A.FORMULA,A.ELGBL_FORMULA,A.OPP_ACTION,A.CREATEDDATE,A.CREATEDBY,A.PROJECT_ID,A.PTNL_FORMULA,A.ISONMAIN,A.ISACTIVE as ISACTIVEID,";
                    str = string.Concat(str, "CASE WHEN A.ISACTIVE=1 THEN 'YES' ELSE 'NO' END as ISACTIVE, ");
                    if (Common.iDBType == 1)
                    {
                        str = string.Concat(str, " U.First_name || ' ' || U.last_name as UName ");
                    }
                    else if (Common.iDBType == 2)
                    {
                        str = string.Concat(str, " ,U.First_name + ' ' + U.last_name as UName ");
                    }
                    str = string.Concat(str, " ,'' as Flag,'' as Threshold,B.T1,B.T2 From OPPORTUNITY A Left join Users U on U.USER_ID=A.CREATEDBY ");
                    str = string.Concat(str, " left join Status_BreakDown B ON A.Opportunity_ID=B.Opportunity_ID Where ");
                    if (iProjectId != 0)
                    {
                        object obj = str;
                        object[] objArray = new object[] { obj, " A.Project_Id=", iProjectId, " and  A.CREATEDBY=", iUserId };
                        str = string.Concat(objArray);
                    }
                    if (!bIsOppList)
                    {
                        str = string.Concat(str, " And A.IsActive=1");
                    }
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataTable1 = dataTable;
                }
                else if(Common.iDBType ==3)
                {
                    string str = "";
                    str = "Select A.OPPORTUNITY_ID,A.OPP_NAME,A.DESCRIPTION,A.FORMULA,A.ELGBL_FORMULA,A.OPP_ACTION,A.CREATEDDATE,A.CREATEDBY,A.PROJECT_ID,A.PTNL_FORMULA,A.ISONMAIN,A.ISACTIVE as ISACTIVEID,";
                    str = string.Concat(str, "CASE WHEN A.ISACTIVE=1 THEN 'YES' ELSE 'NO' END as ISACTIVE ");
                    str = string.Concat(str, " ,U.First_name + ' ' + U.last_name as UName ");
                    str = string.Concat(str, " ,'' as Flag,'' as Threshold,B.T1,B.T2 From OPPORTUNITY A Left join Users U on U.USER_ID=A.CREATEDBY ");
                    str = string.Concat(str, " left join Status_BreakDown B ON A.Opportunity_ID=B.Opportunity_ID Where ");
                    if (iProjectId != 0)
                    {
                        object obj = str;
                        object[] objArray = new object[] { obj, " A.Project_Id=", iProjectId, " and  A.CREATEDBY=", iUserId };
                        str = string.Concat(objArray);
                    }
                    if (!bIsOppList)
                    {
                        str = string.Concat(str, " And A.IsActive=1");
                    }
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataTable1 = dataTable;

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable1;
        }

        public DataTable fnGetOppRanking(int iProjectId)
        {
            DataTable dataTable=null;
            DataTable dataTable1;
            try
            {
                string str = "";
                str = "Select ORR.Project_ID,ORR.TYPE,ORR.RANK1,ORR.RANK2,ORR.RANK3,ORR.RANK4,O.OPP_NAME as Opportunity1, ";
                str = string.Concat(str, "O1.OPP_NAME as Opportunity2,O2.OPP_NAME as Opportunity3,O3.OPP_NAME as Opportunity4 ");
                str = string.Concat(str, " from OPPORTUNITY_RANKING ORR ");
                str = string.Concat(str, " Left Join  OPPORTUNITY O On O.Opportunity_ID=ORR.RANK1 ");
                str = string.Concat(str, " Left Join  OPPORTUNITY O1 On O1.Opportunity_ID=ORR.RANK2 ");
                str = string.Concat(str, " Left Join  OPPORTUNITY O2 On O2.Opportunity_ID=ORR.RANK3 ");
                str = string.Concat(str, " Left Join  OPPORTUNITY O3 On O3.Opportunity_ID=ORR.RANK4 ");
                str = string.Concat(str, "  where O.PROJECT_ID =", iProjectId);
                if (Common.iDBType == 1 || Common.iDBType == 2)
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

        public void fnInsertOpportunity()
        {
            if (Common.iDBType == 1 || Common.iDBType == 2)
            {
                foreach (DataRow row in ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, "Select OPP_NAME from opportunity").Rows)
                {
                    string str = row.ToString();
                    string str1 = str;
                    str1 = string.Concat(str, ",");
                }
            }
            else if (Common.iDBType == 3)
            {
                foreach (DataRow row in ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, "Select OPP_NAME from opportunity").Rows)
                {
                    string str = row.ToString();
                    string str1 = str;
                    str1 = string.Concat(str, ",");
                }
            }
        }

        public bool fnRunOPoortunities(int iProjectId, string strTabName)
        {
            bool flag = false;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {

                    DataTable dataTable = new DataTable();
                    string str = string.Concat("SELECT O.OPPORTUNITY_ID,O.OPP_NAME,O.FORMULA,O.ELGBL_FORMULA,O.PTNL_FORMULA,S.DROPPERS_CUTOFF ,S.STOPPERS_CUTOFF,S.GROWERS_CUTOFF,", " S.T1,S.T2,S.CURRENTSEGMENT,S.SEGMENTISACTIVE,TT.TIMEPERIOD_ID ");
                    str = string.Concat(str, " FROM OPPORTUNITY O INNER JOIN STATUS_BREAKDOWN S ON O.OPPORTUNITY_ID=S.OPPORTUNITY_ID ");
                    object obj = string.Concat(str, " LEFT JOIN TRE_TIMEPERIOD TT ON TT.T1=S.T1 AND TT.T2=S.T2");
                    object[] objArray = new object[] { obj, " WHERE O.PROJECT_ID= ", iProjectId, " AND O.ISONMAIN=0" };
                    str = string.Concat(objArray);
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    int num = 0;
                    while (num < dataTable.Rows.Count)
                    {
                        if (!this.fnSaveOppRecomendationSettings(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            ((OraDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                        else if (this.fnSaveThreshold(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            str = string.Concat("Update OPPORTUNITY A Set ISONMAIN=1 Where OPPORTUNITY_ID=", dataTable.Rows[num]["OPPORTUNITY_ID"]);
                            DataTable dataTable1 = new DataTable();
                            ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                            num++;
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                    }
                    flag = true;
                }
                else if(Common.iDBType == 3)
                {
                    DataTable dataTable = new DataTable();
                    string str = string.Concat("SELECT O.OPPORTUNITY_ID,O.OPP_NAME,O.FORMULA,O.ELGBL_FORMULA,O.PTNL_FORMULA,S.DROPPERS_CUTOFF ,S.STOPPERS_CUTOFF,S.GROWERS_CUTOFF,", " S.T1,S.T2,S.CURRENTSEGMENT,S.SEGMENTISACTIVE,TT.TIMEPERIOD_ID ");
                    str = string.Concat(str, " FROM OPPORTUNITY O INNER JOIN STATUS_BREAKDOWN S ON O.OPPORTUNITY_ID=S.OPPORTUNITY_ID ");
                    object obj = string.Concat(str, " LEFT JOIN TRE_TIMEPERIOD TT ON TT.T1=S.T1 AND TT.T2=S.T2");
                    object[] objArray = new object[] { obj, " WHERE O.PROJECT_ID= ", iProjectId, " AND O.ISONMAIN=0" };
                    str = string.Concat(objArray);
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    int num = 0;
                    while (num < dataTable.Rows.Count)
                    {
                        if (!this.fnSaveOppRecomendationSettings(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                        else if (this.fnSaveThreshold(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            str = string.Concat("Update OPPORTUNITY A Set ISONMAIN=1 Where OPPORTUNITY_ID=", dataTable.Rows[num]["OPPORTUNITY_ID"]);
                            DataTable dataTable1 = new DataTable();
                            ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                            num++;
                        }
                        else
                        {
                            ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                    }
                    flag = true;

                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ((OraDBManager)Common.dbMgr).RollbackTrans();
                throw exception;
            }
            return flag;
        }

        public bool fnRunOPoortunities(int iProjectId, string strTabName, string Timeperiod1, string Timeperiod2, string strMainFilter)
        {
            bool flag = false;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {

                    DataTable dataTable = new DataTable();
                    string str = "SELECT O.OPPORTUNITY_ID,O.OPP_NAME,O.FORMULA,O.ELGBL_FORMULA,O.PTNL_FORMULA,S.DROPPERS_CUTOFF ,S.STOPPERS_CUTOFF,S.GROWERS_CUTOFF,";
                    string[] timeperiod1 = new string[] { str, " '", Timeperiod1, "' as T1,'", Timeperiod2, "' as T2,S.CURRENTSEGMENT,S.SEGMENTISACTIVE,TT.TIMEPERIOD_ID " };
                    string str1 = string.Concat(string.Concat(timeperiod1), " FROM OPPORTUNITY O INNER JOIN STATUS_BREAKDOWN S ON O.OPPORTUNITY_ID=S.OPPORTUNITY_ID ");
                    string[] strArrays = new string[] { str1, " LEFT JOIN TRE_TIMEPERIOD TT ON TT.T1='", Timeperiod1, "' AND TT.T2='", Timeperiod2, "'" };
                    string str2 = string.Concat(strArrays);
                    str2 = string.Concat(str2, " WHERE O.PROJECT_ID= ", iProjectId);
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str2);
                    int num = 0;
                    while (num < dataTable.Rows.Count)
                    {
                        if (!this.fnSaveOppRecomendationSettings(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            ((OraDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                        else if (this.fnSaveThresholdfrmExport(dataTable.Rows[num], strTabName, iProjectId, strMainFilter))
                        {
                            str2 = string.Concat("Update OPPORTUNITY A Set ISONMAIN=1 Where OPPORTUNITY_ID=", dataTable.Rows[num]["OPPORTUNITY_ID"]);
                            DataTable dataTable1 = new DataTable();
                            ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str2);
                            num++;
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                    }
                    flag = true;
                }
                else if(Common.iDBType ==3)
                {

                    DataTable dataTable = new DataTable();
                    string str = "SELECT O.OPPORTUNITY_ID,O.OPP_NAME,O.FORMULA,O.ELGBL_FORMULA,O.PTNL_FORMULA,S.DROPPERS_CUTOFF ,S.STOPPERS_CUTOFF,S.GROWERS_CUTOFF,";
                    string[] timeperiod1 = new string[] { str, " '", Timeperiod1, "' as T1,'", Timeperiod2, "' as T2,S.CURRENTSEGMENT,S.SEGMENTISACTIVE,TT.TIMEPERIOD_ID " };
                    string str1 = string.Concat(string.Concat(timeperiod1), " FROM OPPORTUNITY O INNER JOIN STATUS_BREAKDOWN S ON O.OPPORTUNITY_ID=S.OPPORTUNITY_ID ");
                    string[] strArrays = new string[] { str1, " LEFT JOIN TRE_TIMEPERIOD TT ON TT.T1='", Timeperiod1, "' AND TT.T2='", Timeperiod2, "'" };
                    string str2 = string.Concat(strArrays);
                    str2 = string.Concat(str2, " WHERE O.PROJECT_ID= ", iProjectId);
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str2);
                    int num = 0;
                    while (num < dataTable.Rows.Count)
                    {
                        if (!this.fnSaveOppRecomendationSettings(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                        else if (this.fnSaveThresholdfrmExport(dataTable.Rows[num], strTabName, iProjectId, strMainFilter))
                        {
                            str2 = string.Concat("Update OPPORTUNITY A Set ISONMAIN=1 Where OPPORTUNITY_ID=", dataTable.Rows[num]["OPPORTUNITY_ID"]);
                            DataTable dataTable1 = new DataTable();
                            ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str2);
                            num++;
                        }
                        else
                        {
                            ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                    }
                    flag = true;
                }

            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ((OraDBManager)Common.dbMgr).RollbackTrans();
                throw exception;
            }
            return flag;
        }

        public bool fnRunOPoortunitiesfrmExport(int iProjectId, string strTabName, string Timeperiod1, string Timeperiod2, string strMainFilter)
        {
            bool flag= false;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {

                    DataTable dataTable = new DataTable();
                    string str = "SELECT O.OPPORTUNITY_ID,O.OPP_NAME,O.FORMULA,O.ELGBL_FORMULA,O.PTNL_FORMULA,S.DROPPERS_CUTOFF ,S.STOPPERS_CUTOFF,S.GROWERS_CUTOFF,";
                    string[] timeperiod1 = new string[] { str, " '", Timeperiod1, "' as T1,'", Timeperiod2, "' as T2,S.CURRENTSEGMENT,S.SEGMENTISACTIVE,TT.TIMEPERIOD_ID " };
                    string str1 = string.Concat(string.Concat(timeperiod1), " FROM OPPORTUNITY O INNER JOIN STATUS_BREAKDOWN S ON O.OPPORTUNITY_ID=S.OPPORTUNITY_ID ");
                    string[] strArrays = new string[] { str1, " LEFT JOIN TRE_TIMEPERIOD TT ON TT.T1='", Timeperiod1, "' AND TT.T2='", Timeperiod2, "'" };
                    object obj = string.Concat(strArrays);
                    object[] objArray = new object[] { obj, " WHERE O.PROJECT_ID= ", iProjectId, " AND O.ISONMAIN=1" };
                    string str2 = string.Concat(objArray);
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str2);
                    int num = 0;
                    while (num < dataTable.Rows.Count)
                    {
                        if (!this.fnSaveOppRecomendationSettings(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            ((OraDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                        else if (this.fnSaveThresholdfrmExport(dataTable.Rows[num], strTabName, iProjectId, strMainFilter))
                        {
                            num++;
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                    }
                    flag = true;
                }
                else if(Common.iDBType ==3)
                {


                    DataTable dataTable = new DataTable();
                    string str = "SELECT O.OPPORTUNITY_ID,O.OPP_NAME,O.FORMULA,O.ELGBL_FORMULA,O.PTNL_FORMULA,S.DROPPERS_CUTOFF ,S.STOPPERS_CUTOFF,S.GROWERS_CUTOFF,";
                    string[] timeperiod1 = new string[] { str, " '", Timeperiod1, "' as T1,'", Timeperiod2, "' as T2,S.CURRENTSEGMENT,S.SEGMENTISACTIVE,TT.TIMEPERIOD_ID " };
                    string str1 = string.Concat(string.Concat(timeperiod1), " FROM OPPORTUNITY O INNER JOIN STATUS_BREAKDOWN S ON O.OPPORTUNITY_ID=S.OPPORTUNITY_ID ");
                    string[] strArrays = new string[] { str1, " LEFT JOIN TRE_TIMEPERIOD TT ON TT.T1='", Timeperiod1, "' AND TT.T2='", Timeperiod2, "'" };
                    object obj = string.Concat(strArrays);
                    object[] objArray = new object[] { obj, " WHERE O.PROJECT_ID= ", iProjectId, " AND O.ISONMAIN=1" };
                    string str2 = string.Concat(objArray);
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str2);
                    int num = 0;
                    while (num < dataTable.Rows.Count)
                    {
                        if (!this.fnSaveOppRecomendationSettings(dataTable.Rows[num], strTabName, iProjectId))
                        {
                            ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                        else if (this.fnSaveThresholdfrmExport(dataTable.Rows[num], strTabName, iProjectId, strMainFilter))
                        {
                            num++;
                        }
                        else
                        {
                            ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                            flag = false;
                            return flag;
                        }
                    }
                    flag = true;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if(Common.iDBType==3)
                    ((MySqlDBManager)Common.dbMgr).RollbackTrans();
                else
                    ((OraDBManager)Common.dbMgr).RollbackTrans();

                throw exception;
            }
            return flag;
        }

        public int fnSaveOpportunity(int iOpportunityId, string strOppName, string strDesc, string strFormula, string strElgblFormula, int strLoginUserId, int iProjectId, string strTableName, string strKeyName, string[] strT1, string[] strT2, int iIsActive, string OppType)
        {
            int num = 0;
            try
            {

                if (Common.iDBType == 1 || Common.iDBType == 2)
                {

                    string str = "";
                    DataTable dataTable = new DataTable();
                    object[] objArray = new object[] { "Select OPPORTUNITY_ID from OPPORTUNITY  where OPPORTUNITY_ID='", iOpportunityId, "' and PROJECT_ID=", iProjectId };
                    str = string.Concat(objArray);
                    if (Common.iDBType == 1)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 2)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    if (dataTable.Rows.Count <= 0)
                    {
                        str = " Insert into OPPORTUNITY (OPP_NAME,DESCRIPTION,FORMULA,ELGBL_FORMULA,OPP_ACTION,CREATEDDATE,CREATEDBY,PROJECT_ID,ISACTIVE) Values ( ";
                        string str1 = str;
                        string[] strArrays = new string[] { str1, " '", strOppName, "','", strDesc.Replace("'", "''"), "','", strFormula.Replace("'", "''"), "', '", strElgblFormula.Replace("'", "''"), "', '", OppType, "'," };
                        str = string.Concat(strArrays);
                        if (Common.iDBType != 1)
                        {
                            object obj = str;
                            object[] objArray1 = new object[] { obj, "getdate() ,", strLoginUserId, ",", iProjectId, ",", iIsActive, ")" };
                            str = string.Concat(objArray1);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                        }
                        else
                        {
                            object obj1 = str;
                            object[] objArray2 = new object[] { obj1, " sysdate ,", strLoginUserId, ",", iProjectId, ",", iIsActive, ")" };
                            str = string.Concat(objArray2);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                        }
                    }
                    else
                    {
                        iOpportunityId = int.Parse(dataTable.Rows[dataTable.Rows.Count - 1][0].ToString());
                        string[] strArrays1 = new string[] { "Update OPPORTUNITY  Set OPP_NAME= '", strOppName, "',DESCRIPTION='", strDesc.Replace("'", "''"), "',FORMULA='", strFormula.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays1);
                        if (Common.iDBType != 1)
                        {
                            object obj2 = str;
                            object[] objArray3 = new object[] { obj2, "CREATEDDATE=getdate() ,CREATEDBY=", strLoginUserId, ",PROJECT_ID", iProjectId, ",ISACTIVE = ", iIsActive, ",OPP_ACTION = '", OppType, "'  where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray3);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            object obj3 = str;
                            object[] objArray4 = new object[] { obj3, "CREATEDDATE=sysdate ,CREATEDBY=", strLoginUserId, ",PROJECT_ID=", iProjectId, ",ISACTIVE = ", iIsActive, ",ELGBL_FORMULA = '", strElgblFormula.Replace("'", "''"), "',OPP_ACTION = '", OppType, "'  where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray4);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    int num1 = 0;
                    str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'TRE_OPPORTUNITY' and upper(column_name) = '", strOppName.ToUpper(), "_DELTA'");
                    num1 = (Common.iDBType != 1 ? int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) : int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)));
                    if (num1 == 0)
                    {
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_DELTA NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_STATUS varchar2(50) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_PNTL NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    num = iOpportunityId;
                }
                else if(Common.iDBType ==3)
                {
                    string str = "";
                    DataTable dataTable = new DataTable();
                    object[] objArray = new object[] { "Select OPPORTUNITY_ID from OPPORTUNITY  where OPPORTUNITY_ID='", iOpportunityId, "' and PROJECT_ID=", iProjectId };
                    str = string.Concat(objArray);
                    if (Common.iDBType == 1)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 2)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    if (dataTable.Rows.Count <= 0)
                    {
                        str = " Insert into OPPORTUNITY (OPP_NAME,DESCRIPTION,FORMULA,ELGBL_FORMULA,OPP_ACTION,CREATEDDATE,CREATEDBY,PROJECT_ID,ISACTIVE) Values ( ";
                        string str1 = str;
                        string[] strArrays = new string[] { str1, " '", strOppName, "','", strDesc.Replace("'", "''"), "','", strFormula.Replace("'", "''"), "', '", strElgblFormula.Replace("'", "''"), "', '", OppType, "'," };
                        str = string.Concat(strArrays);
                        if (Common.iDBType != 1)
                        {
                            object obj = str;
                            object[] objArray1 = new object[] { obj, "getdate() ,", strLoginUserId, ",", iProjectId, ",", iIsActive, ")" };
                            str = string.Concat(objArray1);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                        }
                        else
                        {
                            object obj1 = str;
                            object[] objArray2 = new object[] { obj1, " sysdate ,", strLoginUserId, ",", iProjectId, ",", iIsActive, ")" };
                            str = string.Concat(objArray2);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                        }
                    }
                    else
                    {
                        iOpportunityId = int.Parse(dataTable.Rows[dataTable.Rows.Count - 1][0].ToString());
                        string[] strArrays1 = new string[] { "Update OPPORTUNITY  Set OPP_NAME= '", strOppName, "',DESCRIPTION='", strDesc.Replace("'", "''"), "',FORMULA='", strFormula.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays1);
                        if (Common.iDBType != 1)
                        {
                            object obj2 = str;
                            object[] objArray3 = new object[] { obj2, "CREATEDDATE=getdate() ,CREATEDBY=", strLoginUserId, ",PROJECT_ID", iProjectId, ",ISACTIVE = ", iIsActive, ",OPP_ACTION = '", OppType, "'  where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray3);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            object obj3 = str;
                            object[] objArray4 = new object[] { obj3, "CREATEDDATE=sysdate ,CREATEDBY=", strLoginUserId, ",PROJECT_ID=", iProjectId, ",ISACTIVE = ", iIsActive, ",ELGBL_FORMULA = '", strElgblFormula.Replace("'", "''"), "',OPP_ACTION = '", OppType, "'  where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray4);
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    int num1 = 0;
                    str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'TRE_OPPORTUNITY' and upper(column_name) = '", strOppName.ToUpper(), "_DELTA'");
                    num1 = (Common.iDBType != 1 ? int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) : int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)));
                    if (num1 == 0)
                    {
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_DELTA NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_STATUS varchar2(50) ");
                        if (Common.iDBType != 1)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_PNTL NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    num = iOpportunityId;

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public int fnSaveOpportunity_old(int iOpportunityId, string strOppName, string strDesc, string strFormula, int strLoginUserId, int iProjectId, string strTableName, string strKeyName, string[] strT1, string[] strT2)
        {
            int num =0;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    string str = "";
                    DataTable dataTable = new DataTable();
                    object[] objArray = new object[] { "Select OPPORTUNITY_ID from OPPORTUNITY  where OPP_NAME='", strOppName, "' and PROJECT_ID=", iProjectId };
                    str = string.Concat(objArray);
                    if (Common.iDBType == 1)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 2)
                    {
                        dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    if (dataTable.Rows.Count <= 0)
                    {
                        str = " Insert into OPPORTUNITY (OPP_NAME,DESCRIPTION,FORMULA,CREATEDDATE,CREATEDBY,PROJECT_ID) Values ( ";
                        string str1 = str;
                        string[] strArrays = new string[] { str1, " '", strOppName, "','", strDesc.Replace("'", "''"), "','", strFormula.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays);
                        if (Common.iDBType != 1)
                        {
                            object obj = str;
                            object[] objArray1 = new object[] { obj, "getdate() ,", strLoginUserId, ",", iProjectId, ")" };
                            str = string.Concat(objArray1);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                        }
                        else
                        {
                            object obj1 = str;
                            object[] objArray2 = new object[] { obj1, " sysdate ,", strLoginUserId, ",", iProjectId, ")" };
                            str = string.Concat(objArray2);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                        }
                    }
                    else
                    {
                        iOpportunityId = int.Parse(dataTable.Rows[dataTable.Rows.Count - 1][0].ToString());
                        string[] strArrays1 = new string[] { "Update OPPORTUNITY  Set OPP_NAME= '", strOppName, "',DESCRIPTION='", strDesc.Replace("'", "''"), "',FORMULA='", strFormula.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays1);
                        if (Common.iDBType != 1)
                        {
                            object obj2 = str;
                            object[] objArray3 = new object[] { obj2, "CREATEDDATE=getdate() ,CREATEDBY=", strLoginUserId, ",PROJECT_ID", iProjectId, " where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray3);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            object obj3 = str;
                            object[] objArray4 = new object[] { obj3, "CREATEDDATE=sysdate ,CREATEDBY=", strLoginUserId, ",PROJECT_ID=", iProjectId, " where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray4);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    int num1 = 0;
                    str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'TRE_OPPORTUNITY' and upper(column_name) = '", strOppName.ToUpper(), "'");
                    num1 = (Common.iDBType != 1 ? int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) : int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)));
                    if (num1 == 0)
                    {
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), " NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_DELTA NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_STATUS varchar2(50) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_PNTL NUMBER(18,2) ");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    DataTable dataTable1 = new DataTable();
                    int num2 = 1;
                    int num3 = 3;
                    str = string.Concat("Select * from TRE_MAPPING where TYPE=", num2.ToString(), " OR TYPE=", num3.ToString());
                    dataTable1 = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    if (dataTable1.Rows.Count > 0)
                    {
                        string str2 = "";
                        string str3 = "";
                        string str4 = "";
                        string str5 = Common.fnBuildQuery(strT1);
                        string str6 = Common.fnBuildQuery(strT2);
                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            if (str2 != "")
                            {
                                str2 = string.Concat(str2, ",");
                                str3 = string.Concat(str3, " And ");
                                str4 = string.Concat(str4, " And ");
                            }
                            str2 = string.Concat(str2, dataTable1.Rows[i]["COLNAME"].ToString());
                            string str7 = str3;
                            string[] strArrays2 = new string[] { str7, "A.", dataTable1.Rows[i]["COLNAME"].ToString(), "=B.", dataTable1.Rows[i]["COLNAME"].ToString() };
                            str3 = string.Concat(strArrays2);
                            string str8 = str4;
                            string[] strArrays3 = new string[] { str8, "OPT.", dataTable1.Rows[i]["COLNAME"].ToString(), "=TDN.", dataTable1.Rows[i]["COLNAME"].ToString() };
                            str4 = string.Concat(strArrays3);
                            string str9 = str4;
                            string[] strArrays4 = new string[] { str9, " AND OPT.", dataTable1.Rows[i]["COLNAME"].ToString(), "=A.", dataTable1.Rows[i]["COLNAME"].ToString() };
                            str4 = string.Concat(strArrays4);
                        }
                        str = "Select count(1) from  TRE_OPPORTUNITY ";
                        num1 = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        if (num1 == 0)
                        {
                            string[] strArrays5 = new string[] { " INSERT INTO TRE_OPPORTUNITY(", str2, ",", strOppName, ")" };
                            str = string.Concat(strArrays5);
                            string str10 = str;
                            string[] strArrays6 = new string[] { str10, " select ", str2, ",", strOppName, " From " };
                            str = string.Concat(strArrays6);
                            str = string.Concat(str, "    from ", strTableName);
                            if (Common.iDBType != 1)
                            {
                                ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            }
                            else
                            {
                                ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            }
                        }
                        else if (Common.iDBType == 1)
                        {
                            str = string.Concat(" Update TRE_OPPORTUNITY A Set ", strOppName, "=");
                            string str11 = str;
                            string[] strArrays7 = new string[] { str11, " (Select ", strFormula.Replace("'", "''"), " from ", strTableName, " B where ", str3, ")" };
                            str = string.Concat(strArrays7);
                            string str12 = str;
                            string[] strArrays8 = new string[] { str12, " where Exists (select 1 from TRE_OPPORTUNITY OPT , ", strTableName, " TDN where ", str4, ")" };
                            str = string.Concat(strArrays8);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat("Update TRE_OPPORTUNITY A Set ", strOppName, "_Delta=");
                            str = string.Concat(str, " (select Case When T1=0 then 0 Else Round(T2/T1-1,2) End From ");
                            str = string.Concat(str, "(Select CUSTOMER, round(avg(", strOppName.ToUpper(), "),2) T1 from TRE_OPPORTUNITY  ");
                            str = string.Concat(str, " where ", str5, "  group by CUSTOMER) A ");
                            string str13 = str;
                            string[] upper = new string[] { str13, " Left join (Select CUSTOMER, round(avg(", strOppName.ToUpper(), "),2) T2 from TRE_OPPORTUNITY where  ", str6, " group by CUSTOMER) B " };
                            str = string.Concat(upper);
                            str = string.Concat(str, " On A.CUSTOMER=B.CUSTOMER)");
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    num = iOpportunityId;
                }
                else if(Common.iDBType ==3)
                {

                    string str = "";
                    DataTable dataTable = new DataTable();
                    object[] objArray = new object[] { "Select OPPORTUNITY_ID from OPPORTUNITY  where OPP_NAME='", strOppName, "' and PROJECT_ID=", iProjectId };
                    str = string.Concat(objArray);
                    
                        dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    if (dataTable.Rows.Count <= 0)
                    {
                        str = " Insert into OPPORTUNITY (OPP_NAME,DESCRIPTION,FORMULA,CREATEDDATE,CREATEDBY,PROJECT_ID) Values ( ";
                        string str1 = str;
                        string[] strArrays = new string[] { str1, " '", strOppName, "','", strDesc.Replace("'", "''"), "','", strFormula.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays);
                        
                            object obj1 = str;
                            object[] objArray2 = new object[] { obj1, " sysdate ,", strLoginUserId, ",", iProjectId, ")" };
                            str = string.Concat(objArray2);
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOpportunityId = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OPPORTUNITY_ID) from OPPORTUNITY"));
                    }
                    else
                    {
                        iOpportunityId = int.Parse(dataTable.Rows[dataTable.Rows.Count - 1][0].ToString());
                        string[] strArrays1 = new string[] { "Update OPPORTUNITY  Set OPP_NAME= '", strOppName, "',DESCRIPTION='", strDesc.Replace("'", "''"), "',FORMULA='", strFormula.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays1);
                     
                            object obj3 = str;
                            object[] objArray4 = new object[] { obj3, "CREATEDDATE=sysdate ,CREATEDBY=", strLoginUserId, ",PROJECT_ID=", iProjectId, " where OPPORTUNITY_ID=", iOpportunityId };
                            str = string.Concat(objArray4);
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        
                    }
                    int num1 = 0;
                    str = string.Concat(" Select count(1) from user_tab_columns where table_name = 'TRE_OPPORTUNITY' and upper(column_name) = '", strOppName.ToUpper(), "'");
                    num1 =  int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                    if (num1 == 0)
                    {
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), " NUMBER(18,2) ");
                      
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_DELTA NUMBER(18,2) ");
                       
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_STATUS varchar2(50) ");
                        
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        str = string.Concat("alter table TRE_OPPORTUNITY add ", strOppName.ToUpper(), "_PNTL NUMBER(18,2) ");
                       
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                     }
                    DataTable dataTable1 = new DataTable();
                    int num2 = 1;
                    int num3 = 3;
                    str = string.Concat("Select * from TRE_MAPPING where TYPE=", num2.ToString(), " OR TYPE=", num3.ToString());
                    dataTable1 =  ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    if (dataTable1.Rows.Count > 0)
                    {
                        string str2 = "";
                        string str3 = "";
                        string str4 = "";
                        string str5 = Common.fnBuildQuery(strT1);
                        string str6 = Common.fnBuildQuery(strT2);
                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            if (str2 != "")
                            {
                                str2 = string.Concat(str2, ",");
                                str3 = string.Concat(str3, " And ");
                                str4 = string.Concat(str4, " And ");
                            }
                            str2 = string.Concat(str2, dataTable1.Rows[i]["COLNAME"].ToString());
                            string str7 = str3;
                            string[] strArrays2 = new string[] { str7, "A.", dataTable1.Rows[i]["COLNAME"].ToString(), "=B.", dataTable1.Rows[i]["COLNAME"].ToString() };
                            str3 = string.Concat(strArrays2);
                            string str8 = str4;
                            string[] strArrays3 = new string[] { str8, "OPT.", dataTable1.Rows[i]["COLNAME"].ToString(), "=TDN.", dataTable1.Rows[i]["COLNAME"].ToString() };
                            str4 = string.Concat(strArrays3);
                            string str9 = str4;
                            string[] strArrays4 = new string[] { str9, " AND OPT.", dataTable1.Rows[i]["COLNAME"].ToString(), "=A.", dataTable1.Rows[i]["COLNAME"].ToString() };
                            str4 = string.Concat(strArrays4);
                        }
                        str = "Select count(1) from  TRE_OPPORTUNITY ";
                        num1 = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
                        if (num1 == 0)
                        {
                            string[] strArrays5 = new string[] { " INSERT INTO TRE_OPPORTUNITY(", str2, ",", strOppName, ")" };
                            str = string.Concat(strArrays5);
                            string str10 = str;
                            string[] strArrays6 = new string[] { str10, " select ", str2, ",", strOppName, " From " };
                            str = string.Concat(strArrays6);
                            str = string.Concat(str, "    from ", strTableName);
                            
                                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            }
                        
                    }
                    num = iOpportunityId;

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public void fnSaveOPPRanking(string strRName, int iProjectId, string strRank1, string strRank2, string strRank3, string strRank4)
        {
            try
            {
                string str = "";
                str = string.Concat("delete from OPPORTUNITY_RANKING where PROJECT_ID=", iProjectId);
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if(Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                str = " Insert into OPPORTUNITY_RANKING(TYPE,PROJECT_ID,RANK1,RANK2,RANK3,RANK4) values( ";
                object obj = str;
                object[] objArray = new object[] { obj, "'", strRName, "',", iProjectId, "," };
                str = string.Concat(objArray);
                str = (strRank1 == "" ? string.Concat(str, ",NULL") : string.Concat(str, "'", strRank1, "'"));
                str = (strRank2 == "" ? string.Concat(str, ", NULL") : string.Concat(str, ", '", strRank2, "'"));
                str = (strRank3 == "" ? string.Concat(str, ", NULL") : string.Concat(str, ", '", strRank3, "'"));
                str = (strRank4 == "" ? string.Concat(str, ",NULL") : string.Concat(str, ", '", strRank4, "'"));
                str = string.Concat(str, ")");
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private bool fnSaveOppRecomendationSettings(DataRow dr, string strTabName, int iProjectId)
        {
            bool flag;
            try
            {
                int num = 0;
                string str = "";
                string str1 = "";
                clsTre_Details clsTreDetail = this.clsTObj;
                string str2 = dr["T1"].ToString();
                char[] chrArray = new char[] { ',' };
                string[] array = str2.Split(chrArray).ToArray<string>();
                string str3 = dr["T2"].ToString();
                char[] chrArray1 = new char[] { ',' };
                clsTreDetail.fnGetTimePeriodData(strTabName, array, str3.Split(chrArray1).ToArray<string>(), int.Parse(dr["TIMEPERIOD_ID"].ToString()), iProjectId, ref num, ref str, ref str1, true);
                clsTre_Details clsTreDetail1 = this.clsTObj;
                string str4 = strTabName;
                int num1 = int.Parse(dr["TIMEPERIOD_ID"].ToString());
                string str5 = dr["CURRENTSEGMENT"].ToString();
                string str6 = dr["T2"].ToString();
                string str7 = dr["T2"].ToString();
                char[] chrArray2 = new char[] { ';' };
                clsTreDetail1.fnGetSegmentData(str4, num1, str5, str6, str7.Split(chrArray2), iProjectId, (dr["SEGMENTISACTIVE"].ToString() == "1" ? true : false), ref num, ref str);
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        private bool fnSaveThreshold(DataRow dr, string strTabName, int iProjectid)
        {
            bool flag;
            try
            {
                clsTre_Details clsTreDetail = this.clsTObj;
                string[] strArrays = dr["T1"].ToString().Split(new char[] { ',' });
                string str = dr["T2"].ToString();
                char[] chrArray = new char[] { ',' };
                clsTreDetail.fnSaveTREThreShold(strArrays, str.Split(chrArray), dr["OPP_NAME"].ToString(), dr["DROPPERS_CUTOFF"].ToString(), dr["GROWERS_CUTOFF"].ToString(), dr["STOPPERS_CUTOFF"].ToString(), int.Parse(dr["OPPORTUNITY_ID"].ToString()), strTabName, iProjectid, dr["ELGBL_FORMULA"].ToString(), true);
                this.clsTObj.fnGetBaseData(strTabName, dr["GROWERS_CUTOFF"].ToString(), iProjectid);
                if (dr["PTNL_FORMULA"].ToString() != "")
                {
                    this.clsTObj.fnSaveOPPPotential(dr["OPP_NAME"].ToString(), int.Parse(dr["OPPORTUNITY_ID"].ToString()), strTabName, dr["PTNL_FORMULA"].ToString());
                }
                this.clsTObj.fnInsertOppValues(int.Parse(dr["OPPORTUNITY_ID"].ToString()));
                flag = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if(Common.iDBType == 1)
                    ((OraDBManager)Common.dbMgr).RollbackTrans();
                else
                    ((OraDBManager)Common.dbMgr).RollbackTrans();

                throw exception;
            }
            return flag;
        }

        private bool fnSaveThresholdfrmExport(DataRow dr, string strTabName, int iProjectid, string strMainFilter)
        {
            bool flag;
            try
            {
                clsTre_Details clsTreDetail = this.clsTObj;
                string[] strArrays = dr["T1"].ToString().Split(new char[] { ',' });
                string str = dr["T2"].ToString();
                char[] chrArray = new char[] { ',' };
                clsTreDetail.fnSaveTREThreSholdfrmExport(strArrays, str.Split(chrArray), dr["OPP_NAME"].ToString(), dr["DROPPERS_CUTOFF"].ToString(), dr["GROWERS_CUTOFF"].ToString(), dr["STOPPERS_CUTOFF"].ToString(), int.Parse(dr["OPPORTUNITY_ID"].ToString()), strTabName, dr["ELGBL_FORMULA"].ToString(), iProjectid, strMainFilter, true);
                this.clsTObj.fnGetBaseData(strTabName, dr["GROWERS_CUTOFF"].ToString(), iProjectid);
                if (dr["PTNL_FORMULA"].ToString() != "")
                {
                    this.clsTObj.fnSaveOPPPotentialfrmExport(dr["OPP_NAME"].ToString(), int.Parse(dr["OPPORTUNITY_ID"].ToString()), strTabName, dr["PTNL_FORMULA"].ToString());
                }
                flag = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (Common.iDBType == 1)
                    ((OraDBManager)Common.dbMgr).RollbackTrans();
                else
                    ((OraDBManager)Common.dbMgr).RollbackTrans();

                throw exception;
            }
            return flag;
        }
    }
}

