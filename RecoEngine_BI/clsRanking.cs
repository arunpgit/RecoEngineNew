using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using RecoEngine_DataLayer;
using System.Data.SqlClient;

namespace RecoEngine_BI
{
    public class clsRanking
    {
        public clsRanking()
        {
        }

        public bool fnCheckOpportunityExists(int iProjectId)
        {
            DataTable dataTable = null;
            string str = "";
            str = string.Concat("Select OPP_NAME from Opportunity  where ISONMAIN=0 and Project_id= ", iProjectId);
            if (Common.iDBType == 1 || Common.iDBType == 2)
            {
                dataTable = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
            }
            else if(Common.iDBType ==3)
            {
                dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);

            }
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void fnCustomRanking(int iProjectid, string strRank1, string strRank2, string strRank3, string strRank4)
        {
            try
            {
                if (Common.iDBType == 3)
                {
                    string str = "";
                    str = "Delete from TRE_RANKING" + iProjectid;
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    ((MySqlDBManager)Common.dbMgr).savecustomRankingExport(iProjectid);
                }
                else
                {
                    string str = "";
                    str = "Delete from TRE_RANKING ";
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 2)
                    {
                        ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);

                    }
                    str = " DECLARE ";
                    str = string.Concat(str, " Rank1 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank2 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank3 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank4 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank1_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank2_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank3_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank4_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank1_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank2_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank3_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank4_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " customer  Tre_Opportunity.CUSTOMER%TYPE;");
                    str = string.Concat(str, " Counter integer :=0;");
                    str = string.Concat(str, " CURSOR ttl_customer IS ");
                    str = string.Concat(str, " SELECT CUSTOMER FROM Tre_Opportunity; ");
                    str = string.Concat(str, " BEGIN ");
                    str = string.Concat(str, " FOR cust_rec in ttl_customer");
                    str = string.Concat(str, " LOOP");
                    str = string.Concat(str, this.fnOpportunitiesRnkng(iProjectid));
                    str = string.Concat(str, " Rank1_Name  :='", strRank1, "';");
                    str = string.Concat(str, " Rank2_Name  :='", strRank2, "';");
                    str = string.Concat(str, " Rank3_Name  :='", strRank3, "';");
                    str = string.Concat(str, " Rank4_Name  :='", strRank4, "';");
                    str = string.Concat(str, " Customrank_Selection(cust_rec.customer,Rank1,Rank2,Rank3,Rank4,Counter,Rank1_Name,Rank2_Name,Rank3_Name,Rank4_Name,Rank1_Action,Rank2_Action,Rank3_Action,Rank4_Action);");
                    str = string.Concat(str, " Delete  from CUSTOMER_PNTL; ");
                    str = string.Concat(str, " end LOOP;");
                    str = string.Concat(str, " END;");
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);

                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void fnCustomRankingFrmExport(int iProjectid, string strRank1, string strRank2, string strRank3, string strRank4)
        {
            try
            {
                if (Common.iDBType == 3)
                {
                    string str = "";
                    str = "Delete from TRE_RANKING" + iProjectid;
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    ((MySqlDBManager)Common.dbMgr).savecustomRankingExport(iProjectid);
                }
                else
                {
                    string str = "";
                    str = "Delete from TRE_RANKING ";
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 2)
                    {
                        ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " DECLARE ";
                    str = string.Concat(str, " Rank1 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank2 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank3 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank4 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank1_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank2_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank3_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank4_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank1_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank2_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank3_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank4_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " customer  Tre_Opportunity.CUSTOMER%TYPE;");
                    str = string.Concat(str, " Counter integer :=0;");
                    str = string.Concat(str, " CURSOR ttl_customer IS ");
                    str = string.Concat(str, " SELECT CUSTOMER FROM Tre_OpportunityExport; ");
                    str = string.Concat(str, " BEGIN ");
                    str = string.Concat(str, " FOR cust_rec in ttl_customer");
                    str = string.Concat(str, " LOOP");
                    str = string.Concat(str, this.fnOpportunitiesRnkngfrmExport(iProjectid));
                    str = string.Concat(str, " Rank1_Name  :='", strRank1, "';");
                    str = string.Concat(str, " Rank2_Name  :='", strRank2, "';");
                    str = string.Concat(str, " Rank3_Name  :='", strRank3, "';");
                    str = string.Concat(str, " Rank4_Name  :='", strRank4, "';");
                    str = string.Concat(str, " Customrank_Selection(cust_rec.customer,Rank1,Rank2,Rank3,Rank4,Counter,Rank1_Name,Rank2_Name,Rank3_Name,Rank4_Name,Rank1_Action,Rank2_Action,Rank3_Action,Rank4_Action);");
                    str = string.Concat(str, " Delete  from CUSTOMER_PNTL; ");
                    str = string.Concat(str, " end LOOP;");
                    str = string.Concat(str, " END;");
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 3)
                    {
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void fnMainRanking(int iProjectId)
        {
            DataTable dataTable = this.fnRankingcriteria(iProjectId);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["Type"].ToString() == "Custom")
                {
                    this.fnCustomRanking(iProjectId, dataTable.Rows[0]["Rank1"].ToString(), dataTable.Rows[0]["Rank2"].ToString(), dataTable.Rows[0]["Rank3"].ToString(), dataTable.Rows[0]["Rank4"].ToString());
                    return;
                }
                this.fnPotentialRanking(iProjectId);
            }
        }

        public void fnMainRankingfrmExport(int iProjectId)
        {
            DataTable dataTable = this.fnRankingcriteria(iProjectId);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["Type"].ToString() == "Custom")
                {
                    this.fnCustomRankingFrmExport(iProjectId, dataTable.Rows[0]["Rank1"].ToString(), dataTable.Rows[0]["Rank2"].ToString(), dataTable.Rows[0]["Rank3"].ToString(), dataTable.Rows[0]["Rank4"].ToString());
                    return;
                }
                this.fnPotentialRankingFrmExport(iProjectId);
            }
        }

        public string fnOpportunitiesRnkng(int iProjectid)
        {
            DataTable dataTable = null ;
            string str = "";
            str = string.Concat("Select OPP_NAME from Opportunity  where  Project_id= ", iProjectid);

            if (Common.iDBType == 2 )
             dataTable =   ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
            else if(Common.iDBType ==3)
            {
                dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
            }
            str = " Insert into CUSTOMER_PNTL (OPP_NAME,OPP_PNTL,Opp_Status)";
            foreach (DataRow row in dataTable.Rows)
            {
                string str1 = str;
                string[] strArrays = new string[] { str1, " Select  '", row[0].ToString(), "'  ,", row[0].ToString(), "_Pntl ,  CASE  When ", row[0].ToString(), "_STATUS= 'NON_USER' Then 'X-SELL-", row[0].ToString(), "'" };
                str = string.Concat(strArrays);
                string str2 = str;
                string[] strArrays1 = new string[] { str2, " When ", row[0].ToString(), "_STATUS= 'DROPPER' Then 'MITIGATE-", row[0].ToString(), "'" };
                str = string.Concat(strArrays1);
                string str3 = str;
                string[] strArrays2 = new string[] { str3, " When ", row[0].ToString(), "_STATUS= 'STOPPER' Then 'REVIVE-", row[0].ToString(), "'" };
                str = string.Concat(strArrays2);
                string str4 = str;
                string[] strArrays3 = new string[] { str4, " When ", row[0].ToString(), "_STATUS= 'GROWER' Then 'NO ACTION-", row[0].ToString(), "'" };
                str = string.Concat(strArrays3);
                string str5 = str;
                string[] strArrays4 = new string[] { str5, " When ", row[0].ToString(), "_STATUS= 'FLAT' Then 'UP-SELL-", row[0].ToString(), "'" };
                str = string.Concat(strArrays4);
                str = string.Concat(str, " When ", row[0].ToString(), "_STATUS= 'NEW_USER' Then 'NO ACTION' END   FROM TRE_OPPORTUNITY WHERE CUSTOMER=cust_rec.customer ");
                str = string.Concat(str, " Union");
            }
            string str6 = string.Concat(str.Remove(str.Length - 5, 5), ";");
            str = str6;
            return str6;
        }

        public string fnOpportunitiesRnkngfrmExport(int iProjectid)
        {
            DataTable dataTable;
            string str = "";
            str = string.Concat("Select OPP_NAME from Opportunity where ISONMAIN=1 AND Project_id= ", iProjectid);
            dataTable = (Common.iDBType ==2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
            if (Common.iDBType == 3)
            {
                ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
            }
            str = " Insert into CUSTOMER_PNTL (OPP_NAME,OPP_PNTL,Opp_Status)";
            foreach (DataRow row in dataTable.Rows)
            {
                string str1 = str;
                string[] strArrays = new string[] { str1, " Select  '", row[0].ToString(), "'  ,", row[0].ToString(), "_Pntl ,  CASE  When ", row[0].ToString(), "_STATUS= 'NON_USER' Then 'X-SELL-", row[0].ToString(), "'" };
                str = string.Concat(strArrays);
                string str2 = str;
                string[] strArrays1 = new string[] { str2, " When ", row[0].ToString(), "_STATUS= 'DROPPER' Then 'MITIGATE-", row[0].ToString(), "'" };
                str = string.Concat(strArrays1);
                string str3 = str;
                string[] strArrays2 = new string[] { str3, " When ", row[0].ToString(), "_STATUS= 'STOPPER' Then 'REVIVE-", row[0].ToString(), "'" };
                str = string.Concat(strArrays2);
                string str4 = str;
                string[] strArrays3 = new string[] { str4, " When ", row[0].ToString(), "_STATUS= 'GROWER' Then 'NO ACTION-", row[0].ToString(), "'" };
                str = string.Concat(strArrays3);
                string str5 = str;
                string[] strArrays4 = new string[] { str5, " When ", row[0].ToString(), "_STATUS= 'FLAT' Then 'UP-SELL-", row[0].ToString(), "'" };
                str = string.Concat(strArrays4);
                str = string.Concat(str, " When ", row[0].ToString(), "_STATUS= 'NEW_USER' Then 'NO ACTION' END   FROM TRE_OPPORTUNITYEXPORT WHERE CUSTOMER=cust_rec.customer ");
                str = string.Concat(str, " Union");
            }
            string str6 = string.Concat(str.Remove(str.Length - 5, 5), ";");
            str = str6;
            return str6;
        }

        public void fnPotentialRanking(int iProjectid)
        {
            try
            {
                if (Common.iDBType == 3)
                {
                    string str = "";
                    str = "Delete from TRE_RANKING"+ iProjectid;
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    ((MySqlDBManager)Common.dbMgr).savepotentialRankingExport(iProjectid);
                    

                }
                else {
                    string str = "";
                    str = "Delete from TRE_RANKING ";
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    else if (Common.iDBType == 2)
                    {
                        ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }
                    str = " DECLARE ";
                    str = string.Concat(str, " Rank1 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank2 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank3 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank4 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank1_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank2_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank3_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank4_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank1_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank2_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank3_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank4_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " customer  Tre_Opportunity.CUSTOMER%TYPE;");
                    str = string.Concat(str, " CURSOR ttl_customer IS ");
                    str = string.Concat(str, " SELECT CUSTOMER FROM Tre_Opportunity; ");
                    str = string.Concat(str, " BEGIN ");
                    str = string.Concat(str, " FOR cust_rec in ttl_customer");
                    str = string.Concat(str, " LOOP ");
                    str = string.Concat(str, this.fnOpportunitiesRnkng(iProjectid));
                    str = string.Concat(str, " Rank_Selection(cust_rec.customer,Rank1,Rank2,Rank3,Rank4,Rank1_Name,Rank2_Name,Rank3_Name,Rank4_Name,Rank1_Action,Rank2_Action,Rank3_Action,Rank4_Action);");
                    str = string.Concat(str, " Delete  from CUSTOMER_PNTL; ");
                    str = string.Concat(str, " end LOOP;");
                    str = string.Concat(str, " END;");
                    if (Common.iDBType == 1)
                    {
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    }

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void fnPotentialRankingFrmExport(int iProjectid)
        {
            try
            {
                string str = "";
                str = "truncate table TRE_RANKING ";
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if (Common.iDBType == 2)
                {
                    ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                if (Common.iDBType == 1)
                {
                    str = " DECLARE ";
                    str = string.Concat(str, " Rank1 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank2 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank3 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank4 Customer_Pntl.Opp_Pntl%TYPE;");
                    str = string.Concat(str, " Rank1_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank2_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank3_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank4_Name Customer_Pntl.Opp_Name%TYPE ;");
                    str = string.Concat(str, " Rank1_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank2_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank3_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " Rank4_Action Customer_Pntl.Opp_Status%TYPE;");
                    str = string.Concat(str, " customer  Tre_Opportunity.CUSTOMER%TYPE;");
                    str = string.Concat(str, " CURSOR ttl_customer IS ");
                    str = string.Concat(str, " SELECT CUSTOMER FROM Tre_OpportunityExport; ");
                    str = string.Concat(str, " BEGIN ");
                    str = string.Concat(str, " FOR cust_rec in ttl_customer");
                    str = string.Concat(str, " LOOP ");
                    str = string.Concat(str, this.fnOpportunitiesRnkngfrmExport(iProjectid));
                    str = string.Concat(str, " Rank_Selection(cust_rec.customer,Rank1,Rank2,Rank3,Rank4,Rank1_Name,Rank2_Name,Rank3_Name,Rank4_Name,Rank1_Action,Rank2_Action,Rank3_Action,Rank4_Action);");
                    str = string.Concat(str, " Delete  from CUSTOMER_PNTL; ");
                    str = string.Concat(str, " end LOOP;");
                    str = string.Concat(str, " END;");
                }
               
                if (Common.iDBType == 1)
                {
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                }
                else if (Common.iDBType == 3)
                {
                    ((MySqlDBManager)Common.dbMgr).savepotentialRankingExport(iProjectid);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataTable fnRankingcriteria(int iProjectId)
        {
            DataTable dataTable = null ;
            string str = "";
            str = string.Concat(str, "Select TYPE,RANK1,RANK2,RANK3,RANK4 from OPPORTUNITY_RANKING where PROJECT_ID=", iProjectId);
            if (Common.iDBType == 1 || Common.iDBType == 2)
            {
                dataTable = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
            }
            if (Common.iDBType == 3)
            {
               dataTable= ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
            }
            return dataTable;
        }
    }
}




