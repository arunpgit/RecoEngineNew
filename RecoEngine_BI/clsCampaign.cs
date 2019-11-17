using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RecoEngine_DataLayer;
using System.Collections;

namespace RecoEngine_BI
{
    public class clsCampaign
    {
        public clsCampaign()
        {
        }

        public bool fnActiveCampaigns(string strOfferId)
        {
            bool flag;
            try
            {
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool fnDeleteCampaign(int iCampaignId, string strTabName)
        {
            bool flag=false;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    DataTable dataTable = new DataTable();
                    string str = "";
                    str = " Select Eligibility,O.Opp_Name as Segment,Segment_Type from Campaigns C";
                    str = string.Concat(str, " Left Join Opportunity  O on   O.Opportunity_Id=C.Opportunity_Id Where Campaign_Id=", iCampaignId);
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    if (dataTable.Rows.Count > 0)
                    {
                        this.fnDeleteCampaignRankings(iCampaignId, dataTable.Rows[0]["Eligibility"].ToString(), string.Concat(dataTable.Rows[0]["Segment"].ToString(), "-", dataTable.Rows[0]["Segment_Type"].ToString()), strTabName);
                    }
                    str = string.Concat("DELETE from CAMPAIGNS WHERE  CAMPAIGN_ID =", iCampaignId);
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    flag = true;
                }
                else if(Common.iDBType ==3)
                {
                    DataTable dataTable = new DataTable();
                    string str = "";
                    str = " Select Eligibility,O.Opp_Name as Segment,Segment_Type from Campaigns C";
                    str = string.Concat(str, " Left Join Opportunity  O on   O.Opportunity_Id=C.Opportunity_Id Where Campaign_Id=", iCampaignId);
                    dataTable =  ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    if (dataTable.Rows.Count > 0)
                    {
                        this.fnDeleteCampaignRankings(iCampaignId, dataTable.Rows[0]["Eligibility"].ToString(), string.Concat(dataTable.Rows[0]["Segment"].ToString(), "-", dataTable.Rows[0]["Segment_Type"].ToString()), strTabName);
                    }
                    str = string.Concat("DELETE from CAMPAIGNS WHERE  CAMPAIGN_ID =", iCampaignId);
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public void fnDeleteCampaignRankings(int Campaignid, string strEligibilty, string strOppRankstatus, string strTabName)
        {
            string str = "";
            str = string.Concat(str, " DECLARE  ");
            str = string.Concat(str, " Customer  TRE_OPPORTUNITYEXPORT.CUSTOMER%TYPE;");
            object obj = str;
            object[] campaignid = new object[] { obj, " Campaignid Varchar2(3):=", Campaignid, ";" };
            str = string.Concat(campaignid);
            str = string.Concat(str, " CurrentSegment string(500):='", strOppRankstatus, "';");
            str = string.Concat(str, " CurrentCmpgnRank1 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank2 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank3 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank4 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CampaignRank1  string(100);");
            str = string.Concat(str, " CampaignRank2  string(100);");
            str = string.Concat(str, " CampaignRank3  string(100);");
            str = string.Concat(str, " CampaignRank4  string(100);");
            str = string.Concat(str, " CURSOR ttl_customer IS ");
            str = string.Concat(str, " SELECT A.CUSTOMER    FROM  TRE_OPPORTUNITYEXPORT A ");
            str = string.Concat(str, " LEFT JOIN (SELECT * FROM ", strTabName, " ) D ON A.CUSTOMER=D.CUSTOMER AND D.WEEK=A.WEEK ");
            str = string.Concat(str, " LEFT JOIN (SELECT CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION  FROM Tre_Ranking ) R");
            str = string.Concat(str, " ON A.CUSTOMER=R.CUSTOMER WHERE  ");
            if (strEligibilty != "")
            {
                str = string.Concat(str, strEligibilty, " AND");
            }
            str = string.Concat(str, " (RANK1_ACTION =  CurrentSegment");
            str = string.Concat(str, " OR RANK2_ACTION = CurrentSegment");
            str = string.Concat(str, " OR RANK3_ACTION = CurrentSegment");
            str = string.Concat(str, " OR RANK4_ACTION =CurrentSegment);");
            str = string.Concat(str, " BEGIN  FOR cust_rec in ttl_customer LOOP");
            str = string.Concat(str, " SELECT Campaign_Ranking1,Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4 INTO CurrentCmpgnRank1,CurrentCmpgnRank2");
            str = string.Concat(str, " ,CurrentCmpgnRank3,CurrentCmpgnRank4 from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER;");
            str = string.Concat(str, " Delete from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER; ");
            str = string.Concat(str, " SP_DeleteCampaignRanking(cust_rec.customer,Campaignid,CurrentCmpgnRank1,CurrentCmpgnRank2,CurrentCmpgnRank3,CurrentCmpgnRank4,CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4);");
            str = string.Concat(str, " END LOOP; ");
            str = string.Concat(str, " END; ");
            if (Common.iDBType == 1)
            {
                ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
            else if (Common.iDBType == 3)
            {
                ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
        }

        public void fnDelteCampaignRankings(int iProjectId, string strTabname)
        {
            try
            {
                string str = "";
                if (Common.iDBType == 1 || Common.iDBType == 2)
                { 
                    str = string.Concat("Select Count(1) from Campaign_Ranking where ProjectId=", iProjectId);
                if (int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) != 0)
                {
                    str = "Delete from CAMPAIGN_RANKING ";
                    if (Common.iDBType == 2)
                    {
                        ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }


                }
                str = string.Concat("INSERT INTO CAMPAIGN_RANKING(CUSTOMER,CAMPAIGN_RANKING1,CAMPAIGN_RANKING2,CAMPAIGN_RANKING3,CAMPAIGN_RANKING4,PROJECTID)  SELECT CUSTOMER,'No Campaign','No Campaign','No Campaign','No Campaign',", iProjectId, " FROM TRE_RANKING");
                ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                str = "Select Eligibility,O.Opp_Name as Segment,Segment_Type,CAMPAIGN_ID from Campaigns C";
                str = string.Concat(str, " Left Join Opportunity  O on   O.Opportunity_Id=C.Opportunity_Id Where C.Project_Id=", iProjectId);
                DataTable dataTable = new DataTable();
                dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.fnSaveCampaignRankings(row["Eligibility"].ToString(), iProjectId, string.Concat(row["Segment_Type"].ToString(), "-", row["Segment"].ToString()), Convert.ToInt32(row["CAMPAIGN_ID"]), strTabname);
                    }
                }
            }
            else if(Common.iDBType ==3)
                {
                    str = string.Concat("Select Count(1) from Campaign_Ranking where ProjectId=", iProjectId);
                    if (int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) != 0)
                    {
                        str = "Delete from CAMPAIGN_RANKING ";
                       
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                       
                    }
                    str = string.Concat("INSERT INTO CAMPAIGN_RANKING(CUSTOMER,CAMPAIGN_RANKING1,CAMPAIGN_RANKING2,CAMPAIGN_RANKING3,CAMPAIGN_RANKING4,PROJECTID)  SELECT CUSTOMER,'No Campaign','No Campaign','No Campaign','No Campaign',", iProjectId, " FROM TRE_RANKING");
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    str = "Select Eligibility,O.Opp_Name as Segment,Segment_Type,CAMPAIGN_ID from Campaigns C";
                    str = string.Concat(str, " Left Join Opportunity  O on   O.Opportunity_Id=C.Opportunity_Id Where C.Project_Id=", iProjectId);
                    DataTable dataTable = new DataTable();
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            this.fnSaveCampaignRankings(row["Eligibility"].ToString(), iProjectId, string.Concat(row["Segment_Type"].ToString(), "-", row["Segment"].ToString()), Convert.ToInt32(row["CAMPAIGN_ID"]), strTabname);
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void fnDelteCampaignRankingsfrmExport(int iProjectId, string strTabname)
        {
            string str = "";
            if (Common.iDBType == 2)
            {
                str = string.Concat("Select Count(1) from Campaign_Ranking where ProjectId=", iProjectId);
                if (int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) != 0)
                {
                    str = "Delete from CAMPAIGN_RANKING ";
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = "Delete from PRIORITIZED_TEMP";
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                str = string.Concat("INSERT INTO CAMPAIGN_RANKING(CUSTOMER,CAMPAIGN_RANKING1,CAMPAIGN_RANKING2,CAMPAIGN_RANKING3,CAMPAIGN_RANKING4,PROJECTID)  SELECT CUSTOMER,'No Campaign','No Campaign','No Campaign','No Campaign',", iProjectId, " FROM TRE_RANKING");
                ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
            else if (Common.iDBType == 3)
            {
                str = string.Concat("Select Count(1) from Campaign_Ranking where ProjectId=", iProjectId);
                if (int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, str)) != 0)
                {
                    str = "Delete from CAMPAIGN_RANKING ";

                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    str = "Delete from PRIORITIZED_TEMP";
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                str = string.Concat("INSERT INTO CAMPAIGN_RANKING(CUSTOMER,CAMPAIGN_RANKING1,CAMPAIGN_RANKING2,CAMPAIGN_RANKING3,CAMPAIGN_RANKING4,PROJECTID)  SELECT CUSTOMER,'No Campaign','No Campaign','No Campaign','No Campaign',", iProjectId, " FROM TRE_RANKING");
                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
        }

        public DataTable fnGetCampaignMapping(int iProjectId)
        {
            DataTable dataTable;
            DataTable dataTable1;
            try
            {
                string str = "";
                str = "  Select C.CAMPAIGN_ID,C.PROJECT_ID,C.NAME,C.CODE,C.OPPORTUNITY_ID,C.OFFER_ID,C.CHANNEL,C.DESCRIPTION,C.OPP_RANK,C.TAKE_UP_RATE,C.ELIGIBILITY,C.Segment_Type,C.SEGMENT_DESCRIPTION, ";
                str = string.Concat(str, " C.ACCOUNTS,C.TOTAL_POTENTIAL,  Case When C.ACCOUNTS=0 then 0 Else Round(C.TOTAL_POTENTIAL/C.ACCOUNTS) END AS Average,Case When C.ACCOUNTS=0 then 0 Else Round(C.TOTAL_POTENTIAL/C.ACCOUNTS) END AS Average1, C.CREATEDDATE,C.ISACTIVE as ISACTIVEID,");
                str = string.Concat(str, " CASE WHEN C.ISACTIVE=1 THEN 'YES' ELSE 'NO' END as ISACTIVE, ");
                if (Common.iDBType == 1)
                {
                    str = string.Concat(str, " U.First_name || ' ' || U.last_name as UName ");
                }
                else if (Common.iDBType == 2)
                {
                    str = string.Concat(str, " ,U.First_name + ' ' + U.last_name as UName ");
                }
                str = string.Concat(str, " ,'' as Flag From CAMPAIGNS C Left join Users U on U.USER_ID=C.CREATEDBY ");
                if (iProjectId != 0)
                {
                    str = string.Concat(str, " Where C.Project_Id=", iProjectId);
                }
                dataTable = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                if(Common.iDBType ==3)
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

        public DataTable fnGetCampaignPtnl(string strOppName, string strEligibility, string strOppRankstatus, string strTabName)
        {
            DataTable dataTable;
            DataTable dataTable1;
            try
            {
                string str = "";
                str = string.Concat("SELECT  ROUND(Sum(A.", strOppName, "_pntl),2) as TotalPotential  , Count(A.Customer)AS ACCOUNTS ");
                str = string.Concat(str, " FROM  TRE_OPPORTUNITYEXPORT A ");
                str = string.Concat(str, " LEFT JOIN  ", strTabName, "  D ON A.CUSTOMER=D.CUSTOMER AND A.WEEK=D.WEEK ");
                str = string.Concat(str, " LEFT JOIN  Tre_Ranking  R");
                str = string.Concat(str, " ON A.CUSTOMER=R.CUSTOMER");
                str = string.Concat(str, " WHERE ");
                if (strEligibility != "")
                {
                    str = string.Concat(str, strEligibility, " AND");
                }
                str = string.Concat(str, " (RANK1_ACTION  IN ('", strOppRankstatus, "')");
                str = string.Concat(str, " OR RANK2_ACTION IN ('", strOppRankstatus, "')");
                str = string.Concat(str, " OR RANK3_ACTION IN ('", strOppRankstatus, "')");
                str = string.Concat(str, " OR RANK4_ACTION IN ('", strOppRankstatus, "'))");
                dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                if (Common.iDBType == 3)
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

        public DataTable fnGetEffectiveTable(int iProjectId, out string tablequery, string strTabName)
        {
            DataTable dataTable = null;
            try
            {
                DataTable dataTable1 = new DataTable();
                tablequery = "";
                string str = "";
                if (Common.iDBType == 1)
                {
                    str = this.fnTre_oppColumns(iProjectId);
                    if (str == "")
                    {
                        tablequery = string.Concat(" SELECT C.* FROM ", strTabName, " C LEFT JOIN TRE_OPPORTUNITYEXPORT T  ON T.CUSTOMER=C.CUSTOMER AND T.WEEK=C.WEEK WHERE ROWNUM <= 2");
                    }
                    else
                    {
                        string[] strArrays = new string[] { " SELECT C.*,", str, " FROM ", strTabName, "  C LEFT JOIN TRE_OPPORTUNITYEXPORT T  ON T.CUSTOMER=C.CUSTOMER AND T.WEEK=C.WEEK WHERE ROWNUM <= 2" };
                        tablequery = string.Concat(strArrays);
                    }
                    if (Common.iDBType == 3)
                    {
                        dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else
                    {
                        dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, tablequery);

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

        public DataSet fnGetSgmntOfferChnl(int iProjectId)
        {
            DataSet dataSet = null;
            try
            {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    DataSet dataSet1 = new DataSet();
                    DataTable dataTable = new DataTable("Segment");
                    string str = "";
                    str = string.Concat("Select * from Opportunity where ISACTIVE=1 and PROJECT_ID=", iProjectId);
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Offer");
                    str = string.Concat("Select * from Offers where ISACTIVE=1 and PROJECT_ID=", iProjectId);
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("OPT_LOOKUP");
                    str = "";
                    str = "Select * from OPT_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("ACTION");
                    str = "";
                    str = "Select * from ACTION_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Channel");
                    str = "Select * from CHANNEL_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataSet = dataSet1;
                }
                else if(Common.iDBType == 3)
                {
                    DataSet dataSet1 = new DataSet();
                    DataTable dataTable = new DataTable("Segment");
                    string str = "";
                    str = string.Concat("Select * from Opportunity where ISACTIVE=1 and PROJECT_ID=", iProjectId);
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Offer");
                    str = string.Concat("Select * from Offers where ISACTIVE=1 and PROJECT_ID=", iProjectId);
                    dataTable =  ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("OPT_LOOKUP");
                    str = "";
                    str = "Select * from OPT_LOOKUP ";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("ACTION");
                    str = "";
                    str = "Select * from ACTION_LOOKUP ";
                    dataTable =  ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Channel");
                    str = "Select * from CHANNEL_LOOKUP ";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataSet = dataSet1;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataSet;
        }

        public void fnPrioritizeRankings(int iprojectId, string strPrioritize)
        {
            string str = "";
            str = string.Concat(str, " DECLARE ");
            str = string.Concat(str, " Customer  TRE_OPPORTUNITYEXPORT.CUSTOMER%TYPE;");
            object obj = str;
            object[] objArray = new object[] { obj, " Project_id  int(3):=", iprojectId, ";" };
            str = string.Concat(objArray);
            str = string.Concat(str, " strPrioritise  String(50):='", strPrioritize, "';");
            str = string.Concat(str, " CampaignRank1    Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CampaignRank2    Campaign_Ranking.Campaign_Ranking2%TYPE;");
            str = string.Concat(str, " CampaignRank3    Campaign_Ranking.Campaign_Ranking3%TYPE;");
            str = string.Concat(str, " CampaignRank4    Campaign_Ranking.Campaign_Ranking4%TYPE;  ");
            str = string.Concat(str, " PriorCampaignRank1    Campaigns.Campaign_Id%TYPE;");
            str = string.Concat(str, " PriorCampaignRank2    Campaigns.Campaign_Id%TYPE;");
            str = string.Concat(str, " PriorCampaignRank3    Campaigns.Campaign_Id%TYPE;");
            str = string.Concat(str, " PriorCampaignRank4    Campaigns.Campaign_Id%TYPE; ");
            str = string.Concat(str, " CURSOR ttl_customer IS ");
            str = string.Concat(str, " SELECT CUSTOMER FROM CAMPAIGN_RANKING;");
            str = string.Concat(str, " BEGIN  FOR cust_rec in ttl_customer LOOP");
            str = string.Concat(str, " CampaignRank1:='';");
            str = string.Concat(str, " CampaignRank2:='';");
            str = string.Concat(str, " CampaignRank3:='';");
            str = string.Concat(str, " CampaignRank4:='';");
            str = string.Concat(str, " Select Campaign_Ranking1,Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4 INTO CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4  from Campaign_Ranking C where C.CUSTOMER=cust_rec.Customer;");
            str = string.Concat(str, " DELETE FROM PRIORITIZED_TEMP WHERE Customer=cust_rec.Customer;");
            str = string.Concat(str, " SP_PrioritizeCampaignRanking(cust_rec.customer,Project_id,CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4,strPrioritise,PriorCampaignRank1,PriorCampaignRank2,PriorCampaignRank3,PriorCampaignRank4);");
            str = string.Concat(str, " END LOOP; ");
            str = string.Concat(str, " END; ");
            if (Common.iDBType == 1)
            {
                ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
           else if (Common.iDBType == 3)
            {
                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
        }

        public void fnPrioritizeRankingsfrmExport(int iprojectId, string strPrioritize)
        {
            try
            {
                string str = "";
                str = string.Concat(str, " DECLARE ");
                str = string.Concat(str, " Customer  TRE_OPPORTUNITYEXPORT.CUSTOMER%TYPE;");
                object obj = str;
                object[] objArray = new object[] { obj, " Project_id  int(3):=", iprojectId, ";" };
                str = string.Concat(objArray);
                str = string.Concat(str, " strPrioritise  String(50):='", strPrioritize, "';");
                str = string.Concat(str, " CampaignRank1    Campaign_Ranking.Campaign_Ranking1%TYPE;");
                str = string.Concat(str, " CampaignRank2    Campaign_Ranking.Campaign_Ranking2%TYPE;");
                str = string.Concat(str, " CampaignRank3    Campaign_Ranking.Campaign_Ranking3%TYPE;");
                str = string.Concat(str, " CampaignRank4    Campaign_Ranking.Campaign_Ranking4%TYPE;  ");
                str = string.Concat(str, " PriorCampaignRank1    Campaigns.Campaign_Id%TYPE;");
                str = string.Concat(str, " PriorCampaignRank2    Campaigns.Campaign_Id%TYPE;");
                str = string.Concat(str, " PriorCampaignRank3    Campaigns.Campaign_Id%TYPE;");
                str = string.Concat(str, " PriorCampaignRank4    Campaigns.Campaign_Id%TYPE; ");
                str = string.Concat(str, " CURSOR ttl_customer IS ");
                str = string.Concat(str, " SELECT CUSTOMER FROM CAMPAIGN_RANKING;");
                str = string.Concat(str, " BEGIN  FOR cust_rec in ttl_customer LOOP");
                str = string.Concat(str, " CampaignRank1:='';");
                str = string.Concat(str, " CampaignRank2:='';");
                str = string.Concat(str, " CampaignRank3:='';");
                str = string.Concat(str, " CampaignRank4:='';");
                str = string.Concat(str, " Select Campaign_Ranking1,Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4 INTO CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4  from Campaign_Ranking C where C.CUSTOMER=cust_rec.Customer;");
                str = string.Concat(str, " DELETE FROM PRIORITIZED_TEMP WHERE Customer=cust_rec.Customer;");
                str = string.Concat(str, " SP_PrioritizeCampaignRanking(cust_rec.customer,Project_id,CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4,strPrioritise,PriorCampaignRank1,PriorCampaignRank2,PriorCampaignRank3,PriorCampaignRank4);");
                str = string.Concat(str, " END LOOP; ");
                str = string.Concat(str, " END; ");
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void fnPriorotiseCampaigns(DataRow[] drows, string strTabName)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    str = "Delete from PRIORITIZED_TEMP";
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    DataRow[] dataRowArray = drows;
                    for (int i = 0; i < (int)dataRowArray.Length; i++)
                    {
                        DataRow dataRow = dataRowArray[i];
                        DataTable dataTable1 = this.fnRankOpportunityName(dataRow["OPP_RANK"].ToString());
                        str = string.Concat("SELECT OPP_NAME from OPPORTUNITY WHERE OPPORTUNITY_ID=", dataRow["OPPORTUNITY_ID"]);
                        dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                        str = " Insert into PRIORITIZED_TEMP(CampaignId,Customer)";
                        object obj = str;
                        object[] item = new object[] { obj, " SELECT ", dataRow["CAMPAIGN_ID"], ",  A.Customer FROM tre_opportunity  A " };
                        str = string.Concat(item);
                        str = string.Concat(str, " LEFT JOIN (SELECT  CUSTOMER , WEEK FROM  ", strTabName, " ) D ON D.CUSTOMER=A.CUSTOMER ");
                        str = string.Concat(str, " wHERE  A.Customer IN (SELECT CUSTOMER FROM ETS_TRE_BASE3  WHERE ");
                        if (dataRow["ELIGIBILITY"].ToString() != "")
                        {
                            str = string.Concat(str, dataRow["ELIGIBILITY"], " and ");
                        }
                        str = string.Concat(str, " WEEK= (Select Max(week) from ", strTabName, " where year=to_char(sysdate, 'YYYY'))) ");
                        object obj1 = str;
                        object[] objArray = new object[] { obj1, " and  A.", dataTable.Rows[0]["OPP_NAME"], "_STATUS!='NA' " };
                        str = string.Concat(objArray);
                        if (dataTable1.Rows.Count > 0)
                        {
                            object obj2 = str;
                            object[] item1 = new object[] { obj2, " and  A.", dataTable1.Rows[0]["OPP_NAME"], "_STATUS!='NA' " };
                            str = string.Concat(item1);
                        }
                        str = string.Concat(str, "and A.CUSTOMER NOT IN ( SELECT CUSTOMER FROM PRIORITIZED_TEMP)");
                        if (Common.iDBType != 1)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        str = string.Concat("Update Campaigns C SET ACCOUNTS= (Select Count(P.Customer) from PRIORITIZED_TEMP P  where C.CAMPAIGN_ID=P.CAMPAIGNID and P.CAMPAIGNID=", dataRow["CAMPAIGN_ID"], ")");
                        str = string.Concat(str, "  where C.CAMPAIGN_ID=", dataRow["CAMPAIGN_ID"]);
                        if (Common.iDBType == 2)
                        {
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                        else if (Common.iDBType == 1)
                        {
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }

                }
                else if (Common.iDBType == 3)
                {
                        str = "Delete from PRIORITIZED_TEMP";
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        DataRow[] dataRowArray = drows;
                        for (int i = 0; i < (int)dataRowArray.Length; i++)
                        {
                            DataRow dataRow = dataRowArray[i];
                            DataTable dataTable1 = this.fnRankOpportunityName(dataRow["OPP_RANK"].ToString());
                            str = string.Concat("SELECT OPP_NAME from OPPORTUNITY WHERE OPPORTUNITY_ID=", dataRow["OPPORTUNITY_ID"]);
                            dataTable =((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                            str = " Insert into PRIORITIZED_TEMP(CampaignId,Customer)";
                            object obj = str;
                            object[] item = new object[] { obj, " SELECT ", dataRow["CAMPAIGN_ID"], ",  A.Customer FROM tre_opportunity  A " };
                            str = string.Concat(item);
                            str = string.Concat(str, " LEFT JOIN (SELECT  CUSTOMER , WEEK FROM  ", strTabName, " ) D ON D.CUSTOMER=A.CUSTOMER ");
                            str = string.Concat(str, " wHERE  A.Customer IN (SELECT CUSTOMER FROM ETS_TRE_BASE3  WHERE ");
                            if (dataRow["ELIGIBILITY"].ToString() != "")
                            {
                                str = string.Concat(str, dataRow["ELIGIBILITY"], " and ");
                            }
                            str = string.Concat(str, " WEEK= (Select Max(week) from ", strTabName, " where year=to_char(sysdate, 'YYYY'))) ");
                            object obj1 = str;
                            object[] objArray = new object[] { obj1, " and  A.", dataTable.Rows[0]["OPP_NAME"], "_STATUS!='NA' " };
                            str = string.Concat(objArray);
                            if (dataTable1.Rows.Count > 0)
                            {
                                object obj2 = str;
                                object[] item1 = new object[] { obj2, " and  A.", dataTable1.Rows[0]["OPP_NAME"], "_STATUS!='NA' " };
                                str = string.Concat(item1);
                            }
                            str = string.Concat(str, "and A.CUSTOMER NOT IN ( SELECT CUSTOMER FROM PRIORITIZED_TEMP)");
                           
                                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = string.Concat("Update Campaigns C SET ACCOUNTS= (Select Count(P.Customer) from PRIORITIZED_TEMP P  where C.CAMPAIGN_ID=P.CAMPAIGNID and P.CAMPAIGNID=", dataRow["CAMPAIGN_ID"], ")");
                            str = string.Concat(str, "  where C.CAMPAIGN_ID=", dataRow["CAMPAIGN_ID"]);
                            
                                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            }
                    }
                
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataTable fnRankOpportunityName(string strRank)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = "";
                str = string.Concat(str, "select OPP_NAME from Opportunity where OPP_NAME =(select NVL(Rank", strRank, ",0) from opportunity_ranking)");
                if (Common.iDBType == 1)
                {
                    dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                }
                if (dataTable1.Rows.Count < 1)
                {
                    str = "select OPP_NAME from Opportunity where OPPORTUNITY_ID= ";
                    str = string.Concat(str, "(select OPPORTUNITY_ID from (");
                    str = string.Concat(str, " select OPPORTUNITY_ID, rownum as rn ");
                    str = string.Concat(str, " from (select OPPORTUNITY_ID from Opportunity_Values order by OPP_PTNL_SUM desc");
                    str = string.Concat(str, "  )  ) where rn=", strRank, ")");
                    if (Common.iDBType == 1)
                    {
                        dataTable1 = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {
                        dataTable1 = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
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

        public int fnSaveCampaign(int iCampaignId, string strName, string strCode, string strDesc, string strOppName, string strOfferid, string strOppid, string strChnl, string strtakeUp, string strEligibilty, string strSegmentType, string strOppRankstatus, int iLoginUserId, int iProjectId, int iIsActive, string strTabName)
        {
            int num;
            try
            {
                string str = "";
                if (iCampaignId != 0)
                {
                    DataTable dataTable = new DataTable();
                    str = " Select Eligibility,O.Opp_Name as Segment,Segment_Type from Campaigns C";
                    str = string.Concat(str, " Left Join Opportunity  O on   O.Opportunity_Id=C.Opportunity_Id Where Campaign_Id=", iCampaignId);
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    if (dataTable.Rows.Count > 0)
                    {
                        this.fnDeleteCampaignRankings(iCampaignId, dataTable.Rows[0]["Eligibility"].ToString(), string.Concat(dataTable.Rows[0]["Segment_Type"].ToString(), "-", dataTable.Rows[0]["Segment"].ToString()), strTabName);
                    }
                    dataTable = this.fnGetCampaignPtnl(strOppName, strEligibilty, strOppRankstatus, strTabName);
                    string[] strArrays = new string[] { "UPDATE  CAMPAIGNS SET NAME='", strName.Replace("'", "''"), "',CODE='", strCode.Replace("'", "''"), "',DESCRIPTION='", strDesc.Replace("'", "''"), "'," };
                    str = string.Concat(strArrays);
                    string str1 = str;
                    string[] strArrays1 = new string[] { str1, " OPPORTUNITY_ID = '", strOppid, "',OFFER_ID ='", strOfferid, "',CHANNEL ='", strChnl.Replace("'", "''"), "'," };
                    str = string.Concat(strArrays1);
                    string str2 = str;
                    string[] strArrays2 = new string[] { str2, "TAKE_UP_RATE ='", strtakeUp, "',SEGMENT_TYPE='", strSegmentType, "',ELIGIBILITY ='", strEligibilty.Replace("'", "''"), "',ACCOUNTS ='", dataTable.Rows[0]["ACCOUNTS"].ToString(), "',TOTAL_POTENTIAL ='", dataTable.Rows[0]["TotalPotential"].ToString(), "'," };
                    str = string.Concat(strArrays2);
                    str = string.Concat(str, "CREATEDBY='", iLoginUserId.ToString(), "',");
                    if (Common.iDBType != 1)
                    {
                        str = string.Concat(str, "CREATEDDATE =' getdate() ,',ISACTIVE ='", iIsActive);
                        ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        iCampaignId = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(CAMPAIGN_ID) from CAMPAIGNS"));
                    }
                    else
                    {
                        object obj = str;
                        object[] objArray = new object[] { obj, "CREATEDDATE = sysdate,ISACTIVE ='", iIsActive, "',SEGMENT_DESCRIPTION='", strOppRankstatus.Replace("'", "''"), "' WHERE CAMPAIGN_ID = ", iCampaignId };
                        str = string.Concat(objArray);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                }
                else
                {
                    str = "INSERT INTO CAMPAIGNS(PROJECT_ID,NAME,CODE,DESCRIPTION,OPPORTUNITY_ID,OFFER_ID,CHANNEL,SEGMENT_TYPE,TAKE_UP_RATE,ELIGIBILITY,ACCOUNTS,TOTAL_POTENTIAL,CREATEDBY,CREATEDDATE,ISACTIVE,SEGMENT_DESCRIPTION) ";
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, "SELECT ", iProjectId, ",'", strName.Replace("'", "''"), "','", strCode.Replace("'", "''"), "','", strDesc.Replace("'", "''"), "'," };
                    str = string.Concat(objArray1);
                    string str3 = str;
                    string[] strArrays3 = new string[] { str3, strOppid, ",", strOfferid, ",'", strChnl.Replace("'", "''"), "','", strSegmentType.Replace("'", "''"), "',", strtakeUp, ",'", strEligibilty.Replace("'", "''"), "'," };
                    str = string.Concat(strArrays3);
                    string str4 = str;
                    string[] strArrays4 = new string[] { str4, "Count(A.Customer),Sum(A.", strOppName, "_pntl),", iLoginUserId.ToString(), ", " };
                    str = string.Concat(strArrays4);
                    if (Common.iDBType != 1)
                    {
                        str = string.Concat(str, "getdate() ,", iIsActive);
                        string str5 = str;
                        string[] strArrays5 = new string[] { str5, " FROM tre_opportunity  A  LEFT JOIN ( SELECT CUSTOMER FROM ", strTabName, "  WHERE ", strEligibilty, " and Week= (Select Max(week) from ", strTabName, " where year=year(getdate()))) " };
                        str = string.Concat(strArrays5);
                        str = string.Concat(str, " B ON B.customer = A.customer");
                        ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        iCampaignId = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(CAMPAIGN_ID) from CAMPAIGNS"));
                    }
                    else
                    {
                        str = string.Concat(str, " sysdate ,", iIsActive);
                        str = string.Concat(str, ",'", strOppRankstatus.Replace("'", "''"));
                        str = string.Concat(str, "'  FROM  TRE_OPPORTUNITYEXPORT A ");
                        str = string.Concat(str, " LEFT JOIN  ", strTabName, " D ON A.CUSTOMER=D.CUSTOMER AND A.WEEK=D.WEEK ");
                        str = string.Concat(str, " LEFT JOIN  Tre_Ranking  R");
                        str = string.Concat(str, " ON A.CUSTOMER=R.CUSTOMER");
                        str = string.Concat(str, " WHERE ");
                        if (strEligibilty != "")
                        {
                            str = string.Concat(str, strEligibilty, " AND");
                        }
                        str = string.Concat(str, " (RANK1_ACTION  IN ('", strOppRankstatus, "')");
                        str = string.Concat(str, " OR RANK2_ACTION IN ('", strOppRankstatus, "')");
                        str = string.Concat(str, " OR RANK3_ACTION IN ('", strOppRankstatus, "')");
                        str = string.Concat(str, " OR RANK4_ACTION IN ('", strOppRankstatus, "'))");
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        iCampaignId = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(CAMPAIGN_ID) from CAMPAIGNS"));
                    }
                }
                num = iCampaignId;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public void fnSaveCampaignRankings(string strEligibility, int IprojectId, string Oppsegment, int CampaignId, string strTabName)
        {
            string str = "";
            str = string.Concat(str, " DECLARE");
            str = string.Concat(str, "  customer  Tre_Opportunity.CUSTOMER%TYPE; ");
            object obj = str;
            object[] campaignId = new object[] { obj, " Campaignid Campaigns.Campaign_Id%TYPE:=", CampaignId, ";" };
            str = string.Concat(campaignId);
            object obj1 = str;
            object[] iprojectId = new object[] { obj1, "  ProjectId INT(4):=", IprojectId, ";" };
            str = string.Concat(iprojectId);
            str = string.Concat(str, " CurrentSegment string(5000):='''", Oppsegment.Replace("'", "''"), "''';");
            str = string.Concat(str, " CurrentCmpgnRank1 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank2 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank3 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank4 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " Rank1_Action Tre_Ranking.Rank1_Action%TYPE;");
            str = string.Concat(str, " Rank2_Action Tre_Ranking.Rank2_Action%TYPE;");
            str = string.Concat(str, " Rank3_Action Tre_Ranking.Rank3_Action%TYPE;");
            str = string.Concat(str, " Rank4_Action Tre_Ranking.Rank4_Action%TYPE;");
            str = string.Concat(str, " CampaignRank1    string(100);");
            str = string.Concat(str, " CampaignRank2    string(100);");
            str = string.Concat(str, " CampaignRank3    string(100);");
            str = string.Concat(str, " CampaignRank4    string(100);");
            str = string.Concat(str, " CURSOR ttl_customer IS ");
            str = string.Concat(str, " SELECT A.CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION    FROM  TRE_OPPORTUNITYEXPORT A ");
            str = string.Concat(str, " LEFT JOIN (SELECT * FROM ", strTabName, "_V ) D ON A.CUSTOMER=D.CUSTOMER AND A.WEEK=D.WEEK ");
            str = string.Concat(str, " LEFT JOIN (SELECT CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION  FROM Tre_Ranking ) R");
            str = string.Concat(str, " ON A.CUSTOMER=R.CUSTOMER ");
            str = string.Concat(str, " WHERE ");
            if (strEligibility != "")
            {
                str = string.Concat(str, strEligibility, " AND ");
            }
            str = string.Concat(str, " (RANK1_ACTION IN ( CurrentSegment )");
            str = string.Concat(str, " OR RANK2_ACTION IN ( CurrentSegment )");
            str = string.Concat(str, " OR RANK3_ACTION IN ( CurrentSegment )");
            str = string.Concat(str, " OR RANK4_ACTION IN ( CurrentSegment ));");
            str = string.Concat(str, " BEGIN  FOR cust_rec in ttl_customer LOOP");
            str = string.Concat(str, " SELECT Campaign_Ranking1,Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4 INTO CurrentCmpgnRank1,CurrentCmpgnRank2");
            str = string.Concat(str, " ,CurrentCmpgnRank3,CurrentCmpgnRank4 from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER;");
            str = string.Concat(str, " Delete from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER;");
            str = string.Concat(str, " SP_CampaignRanking(cust_rec.customer,Campaignid,ProjectId,CurrentSegment,CurrentCmpgnRank1,CurrentCmpgnRank2,CurrentCmpgnRank3,CurrentCmpgnRank4,cust_rec.RANK1_ACTION,cust_rec.RANK2_ACTION,cust_rec.RANK3_ACTION,cust_rec.RANK4_ACTION,CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4);");
            str = string.Concat(str, " end LOOP; ");
            str = string.Concat(str, "  END; ");
            if (Common.iDBType == 1)
            {
                 ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
            else if (Common.iDBType == 3)
            {
                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
        }

        public void fnSaveCampaignRankingsfrmExport(string strEligibility, int IprojectId, string Oppsegment, int CampaignId, string strTabName, string strMainFilter)
        {
            string str = "";
            str = string.Concat(str, " DECLARE");
            str = string.Concat(str, "  customer  TRE_OPPORTUNITYEXPORT.CUSTOMER%TYPE; ");
            object obj = str;
            object[] campaignId = new object[] { obj, " Campaignid Campaigns.Campaign_Id%TYPE:=", CampaignId, ";" };
            str = string.Concat(campaignId);
            object obj1 = str;
            object[] iprojectId = new object[] { obj1, "  ProjectId INT(4):=", IprojectId, ";" };
            str = string.Concat(iprojectId);
            str = string.Concat(str, " CurrentSegment string(5000):='", Oppsegment.Replace("'", ""), "';");
            str = string.Concat(str, " CurrentCmpgnRank1 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank2 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank3 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " CurrentCmpgnRank4 Campaign_Ranking.Campaign_Ranking1%TYPE;");
            str = string.Concat(str, " Rank1_Action Tre_Ranking.Rank1_Action%TYPE;");
            str = string.Concat(str, " Rank2_Action Tre_Ranking.Rank2_Action%TYPE;");
            str = string.Concat(str, " Rank3_Action Tre_Ranking.Rank3_Action%TYPE;");
            str = string.Concat(str, " Rank4_Action Tre_Ranking.Rank4_Action%TYPE;");
            str = string.Concat(str, " CampaignRank1    string(100);");
            str = string.Concat(str, " CampaignRank2    string(100);");
            str = string.Concat(str, " CampaignRank3    string(100);");
            str = string.Concat(str, " CampaignRank4    string(100);");
            str = string.Concat(str, " CURSOR ttl_customer IS ");
            str = string.Concat(str, " SELECT A.CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION    FROM  TRE_OPPORTUNITYEXPORT A ");
            str = string.Concat(str, " LEFT JOIN (SELECT * FROM ", strTabName, "_V ) D ON A.CUSTOMER=D.CUSTOMER AND A.WEEK=D.WEEK ");
            str = string.Concat(str, " LEFT JOIN (SELECT CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION  FROM Tre_Ranking ) R");
            str = string.Concat(str, " ON A.CUSTOMER=R.CUSTOMER ");
            str = string.Concat(str, " WHERE ");
            if (strEligibility != "")
            {
                str = string.Concat(str, strEligibility, " And ");
            }
            if (strMainFilter != "" && strMainFilter != strEligibility)
            {
                str = string.Concat(str, strMainFilter, " And");
            }
            str = string.Concat(str, " (RANK1_ACTION IN ('", Oppsegment, "')");
            str = string.Concat(str, " OR RANK2_ACTION IN ('", Oppsegment, "')");
            str = string.Concat(str, " OR RANK3_ACTION IN ('", Oppsegment, "')");
            str = string.Concat(str, " OR RANK4_ACTION IN ('", Oppsegment, "'));");
            str = string.Concat(str, " BEGIN  FOR cust_rec in ttl_customer LOOP");
            str = string.Concat(str, " SELECT Campaign_Ranking1,Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4 INTO CurrentCmpgnRank1,CurrentCmpgnRank2");
            str = string.Concat(str, " ,CurrentCmpgnRank3,CurrentCmpgnRank4 from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER;");
            str = string.Concat(str, " Delete from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER;");
            str = string.Concat(str, " SP_CampaignRanking(cust_rec.customer,Campaignid,ProjectId,CurrentSegment,CurrentCmpgnRank1,CurrentCmpgnRank2,CurrentCmpgnRank3,CurrentCmpgnRank4,cust_rec.RANK1_ACTION,cust_rec.RANK2_ACTION,cust_rec.RANK3_ACTION,cust_rec.RANK4_ACTION,CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4);");
            str = string.Concat(str, " end LOOP; ");
            str = string.Concat(str, "  END; ");
            if (Common.iDBType == 1)
            {
               ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
            else if (Common.iDBType == 3)
            {
                ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
            }
        }

        public string fnTre_oppColumns(int iProjectId)
        {
            string str;
            try
            {
                DataTable dataTable = new DataTable();
                string str1 = "";
                if (Common.iDBType == 1)
                {
                    str1 = string.Concat("SELECT OPP_NAME  from OPPORTUNITY where project_id=", iProjectId, " And ISONMAIN=1");
                    dataTable = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str1);
                    str1 = "";
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            str1 = string.Concat(str1, row["OPP_NAME"].ToString(), "_DELTA,");
                            str1 = string.Concat(str1, row["OPP_NAME"].ToString(), "_STATUS,");
                            str1 = string.Concat(str1, row["OPP_NAME"].ToString(), "_PNTL,");
                        }
                    }
                }
                if (Common.iDBType == 3)
                {
                    str1 = string.Concat("SELECT OPP_NAME  from OPPORTUNITY where project_id=", iProjectId, " And ISONMAIN=1");
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str1);
                    str1 = "";
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            str1 = string.Concat(str1, row["OPP_NAME"].ToString(), "_DELTA,");
                            str1 = string.Concat(str1, row["OPP_NAME"].ToString(), "_STATUS,");
                            str1 = string.Concat(str1, row["OPP_NAME"].ToString(), "_PNTL,");
                        }
                    }
                }
                if (str1.Length > 1)
                {
                    str1 = str1.Remove(str1.Length - 1);
                }
                str = str1;
            }
            catch (Exception exception)
            {
                throw;
            }
            return str;
        }
    }
}


