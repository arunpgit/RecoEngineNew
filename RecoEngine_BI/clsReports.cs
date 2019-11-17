using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RecoEngine_DataLayer;

namespace RecoEngine_BI
{
   public class clsReports
    {
        public clsReports()
        {
        }

        public DataTable fnGetRankingReports(int iProjectId, int iRank)
        {
            DataTable dataTable;
            DataTable dataTable1;
            try
            {
                string str = "";
                object[] objArray = new object[] { " Select A.Rank", iRank, "_Action,(A.totalpotential) as Rank", iRank, "Potential,A.Customercount as Accounts," };
                str = string.Concat(objArray);
                str = string.Concat(str, " Round((A.Customercount)/(T.TotalCustomer),4)*100 as AccountsPercent,Round((A.totalpotential)/R.GrandPotential,6)*100  as Potentialpercent");
                str = string.Concat(str, " from");
                object obj = str;
                object[] objArray1 = new object[] { obj, " (Select Sum(Rank", iRank, ") as totalpotential,Rank", iRank, "_Action,Count(Customer) as Customercount  from tre_ranking where Rank", iRank, "=0 Group by Rank", iRank, "_Action" };
                str = string.Concat(objArray1);
                str = string.Concat(str, " Union");
                object obj1 = str;
                object[] objArray2 = new object[] { obj1, " Select Sum(Rank", iRank, ") as totalpotential,Rank", iRank, "_Action,Count(Customer) as Customercount  from tre_ranking where Rank", iRank, "!=0 Group by Rank", iRank, "_Action)A," };
                str = string.Concat(objArray2);
                str = string.Concat(str, " (select Count(Customer) as TotalCustomer From Tre_Ranking) T,");
                object obj2 = str;
                object[] objArray3 = new object[] { obj2, " (select Sum(Rank", iRank, ") as GrandPotential  From Tre_Ranking where Rank", iRank, "!=0) R Order by  Rank", iRank, "Potential desc" };
                str = string.Concat(objArray3);
                dataTable = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                 if (Common.iDBType == 3)
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

        public DataSet fnGetReports(int iProjectId)
        {
            DataTable dataTable;
            DataSet dataSet;
            try
            {
                DataSet dataSet1 = new DataSet();
                string str = "";
                str = string.Concat("Select OPP_NAME from Opportunity where ISACTIVE=1 And Isonmain=1 And PROJECT_ID=", iProjectId);
                dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] strArrays = new string[] { " Select '", row["OPP_NAME"].ToString(), "' as OppName , ", row["OPP_NAME"].ToString(), "_Status as OppStatus, Round(Ratio_To_Report(Count(*)) Over() *100,2)" };
                    str = string.Concat(strArrays);
                    str = string.Concat(str, " As AccountsPercentage,Round((Round(Sum(", row["OPP_NAME"].ToString(), "_Delta),2)/Count(Customer))*100,2)");
                    str = string.Concat(str, " As AverageDelta,Count(Customer) as Accounts,Round(Avg(", row["OPP_NAME"].ToString(), "_PNTL),2)  as AvgAccountPotential From Tre_OpportunityExport");
                    string str1 = str;
                    string[] strArrays1 = new string[] { str1, " Where ", row["OPP_NAME"].ToString(), "_Status!='NA' Group By ", row["OPP_NAME"].ToString(), "_Status " };
                    str = string.Concat(strArrays1);
                    dataTable = (Common.iDBType == 2 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    if (Common.iDBType == 3)
                    {
                        dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    }
                    dataSet1.Tables.Add(dataTable);
                }
                dataSet = dataSet1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataSet;
        }
    }
}
