using RecoEngine_DataLayer;
using System;
using System.Data;

namespace RecoEngine_BI
{
    public class clsExport
    {
        public clsExport()
        {
        }

        public DataTable fnExportToFile(bool bIsControlGroup, bool bIsFixedCustomers, string strBaseCustomer, string MaxLimit, string MinLimit, int iprojectId, int iCampaignId, string strRank, ref DataTable dtRandom)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = new DataTable();
                bool flag = false;
                string str = "";
                str = " Select Project_Id,Customer,source as Ranking ,Val as CampaignId,'Y' AS CG From ";
                object obj = str;
                object[] objArray = new object[] { obj, "(select Project_Id,Customer,source,VAL from  (SELECT * FROM PRIORITIZED_TEMP WHERE PROJECT_ID=", iprojectId, " And ", strRank, ") UNPIVOT " };
                str = string.Concat(objArray);
                str = string.Concat(str, " ( VAL FOR( SOURCE ) IN (PR_RANK1 AS 'RANKING1',PR_RANK2 AS 'RANKING2', PR_RANK3 AS 'RANKING3', PR_RANK4 AS 'RANKING4')))  where Val=", iCampaignId);
                dataTable1 = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                if (MinLimit != "" && (double)dataTable1.Rows.Count < Convert.ToDouble(MinLimit))
                {
                    dataTable1 = new DataTable();
                }
                if (MaxLimit != "" && (double)dataTable1.Rows.Count > Convert.ToDouble(MaxLimit))
                {
                    str = "Select Project_Id,Customer,Ranking ,CampaignId,'Y' as CG From (Select Project_Id,Customer,source as Ranking ,Val as CampaignId From ";
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, "(select Project_Id,Customer, source,VAL from  (SELECT * FROM PRIORITIZED_TEMP WHERE PROJECT_ID=", iprojectId, " And ", strRank, ") UNPIVOT " };
                    str = string.Concat(objArray1);
                    str = string.Concat(str, " ( VAL FOR( SOURCE ) IN (PR_RANK1 AS 'RANKING1',PR_RANK2 AS 'RANKING2', PR_RANK3 AS 'RANKING3', PR_RANK4 AS 'RANKING4')))  where Val=", iCampaignId);
                    str = string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE rownum <=", Convert.ToDouble(MaxLimit));
                    if (Common.iDBType != 1)
                    {
                        dataTable1 = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else
                    {
                        dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                        flag = true;
                    }
                }
                if (bIsControlGroup && dataTable1.Rows.Count > 0)
                {
                    str = "";
                    if (flag)
                    {
                        str = string.Concat(str, " Select Customer From (");
                    }
                    str = string.Concat(str, " Select Customer From ( Select Project_Id,Customer,source as Ranking ,Val as CampaignId From ");
                    object obj2 = str;
                    object[] objArray2 = new object[] { obj2, "(select Project_Id,Customer,source,VAL from  (SELECT * FROM PRIORITIZED_TEMP WHERE PROJECT_ID=", iprojectId, " And ", strRank, ") UNPIVOT " };
                    str = string.Concat(objArray2);
                    str = string.Concat(str, " ( VAL FOR( SOURCE ) IN (PR_RANK1 AS 'RANKING1',PR_RANK2 AS 'RANKING2', PR_RANK3 AS 'RANKING3', PR_RANK4 AS 'RANKING4')))  where Val=", iCampaignId);
                    if (flag)
                    {
                        str = string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE rownum <=", Convert.ToDouble(MaxLimit));
                    }
                    if (!bIsFixedCustomers)
                    {
                        str = (!flag ? string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE rownum <=", Convert.ToDouble(strBaseCustomer) * (double)dataTable1.Rows.Count / 100) : string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE rownum <=", Convert.ToDouble(strBaseCustomer) * (double)dataTable1.Rows.Count / 100));
                    }
                    else
                    {
                        str = string.Concat(str, " ORDER BY DBMS_RANDOM.RANDOM) WHERE rownum <=", Convert.ToDouble(strBaseCustomer));
                    }
                    if (Common.iDBType != 1)
                    {
                        ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                }
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable fnGetCampaigns(int iProjectId)
        {
            string str = string.Concat("Select ELIGIBILITY,PROJECT_ID,SEGMENT_TYPE,SEGMENT_DESCRIPTION,CAMPAIGN_ID FROM CAMPAIGNS WHERE  ISACTIVE=1 AND PROJECT_ID=", iProjectId);
            DataTable dataTable = new DataTable();
            dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
            return dataTable;
        }

        public DataTable fnGetCountValues(int iProjectID, string strTabName)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = "";
                str = string.Concat(str, " Select T.Customers,S.Segment,O.Offers,C.Campaigns from");
                str = string.Concat(str, " (SELECT Count(Distinct Customer)as Customers from ", strTabName, " )T,");
                object obj = str;
                object[] objArray = new object[] { obj, " (SELECT Count(1) as Segment from OPPORTUNITY where PROJECT_ID=", iProjectID, " AND ISACTIVE=1)S," };
                str = string.Concat(objArray);
                object obj1 = str;
                object[] objArray1 = new object[] { obj1, " (SELECT Count(1)as Offers  from offers where PROJECT_ID=", iProjectID, " AND ISACTIVE=1)O," };
                str = string.Concat(objArray1);
                object obj2 = str;
                object[] objArray2 = new object[] { obj2, " (SELECT Count(1) as Campaigns from Campaigns where PROJECT_ID=", iProjectID, " AND ISACTIVE=1)C " };
                str = string.Concat(objArray2);
                if (Common.iDBType == 3)
                {
                    dataTable1 =  ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);

                }
                else
                {
                    dataTable1 = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                }

                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable fnGetExport()
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = "";
                str = string.Concat(str, "select * from Export");
                dataTable1 = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public bool fnInsertExportSettings(char bIsControlGroup, string strBaseCustomers, char bIsFixedCustomers, char bIsInsertintoDB, int iprojectId, string Rank, string MinimumCount, string MaximumCount)
        {
            string str = "";
            str = string.Concat("Select Count(1) from EXPORT_SETTINGS WHERE PROJECT_ID=", iprojectId);
            int num = 0;
            if (Common.iDBType == 1)
            {
                num = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str));
            }
            if (num > 0)
            {
                str = string.Concat("DELETE from EXPORT_SETTINGS WHERE PROJECT_ID=", iprojectId);
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
                }
            }
            object[] objArray = new object[] { "INSERT INTO EXPORT_SETTINGS (PROJECT_ID,RANKING,EXPORT_FILE,ISFIXEDCUSTOMER,BASECUSTOMERS,ISCONTROLGROUP,MINLIMIT,MAXLIMIT) VALUES (", iprojectId, ",'", Rank, "'," };
            str = string.Concat(objArray);
            object obj = str;
            object[] objArray1 = new object[] { obj, "'", bIsInsertintoDB, "','", bIsFixedCustomers, "','", strBaseCustomers, "','", bIsControlGroup, "','", MinimumCount, "','", MaximumCount, "')" };
            str = string.Concat(objArray1);
            if (Common.iDBType == 1)
            {
                ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str);
            }
            return true;
        }

        public DataTable fnSelectExportSettings(int iProjectId)
        {
            string str = string.Concat("Select * from Export_Settings where Project_Id=", iProjectId);
            DataTable dataTable = new DataTable();
            if (Common.iDBType == 1)
            {
                dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
            }
            return dataTable;
        }
    }
}