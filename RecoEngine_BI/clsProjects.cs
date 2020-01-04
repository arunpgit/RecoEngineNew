using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RecoEngine_DataLayer;

namespace RecoEngine_BI
{
    public class clsProjects
    {
        public int fnGetOpportunityCount(int iProjectID,int iUserID, ref int iOfferCount)

        {
            try
            {
                string strSql = "Select count(1) from  OPPORTUNITY WHERE PROJECT_ID =" + iProjectID + " and CREATEDBY=" + iUserID;


                if (Common.iDBType == (int)Enums.DBType.Oracle)
                {
                    iOfferCount = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select count(1) from  OFFERS WHERE ISACTIVE=1 AND PROJECT_ID =" + iProjectID));
                    return int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                }
                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                {
                    iOfferCount = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select count(1) from  OFFERS WHERE ISACTIVE=1 AND PROJECT_ID =" + iProjectID));
                    return int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                }
                else
                {
                    //iOfferCount = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select count(1) from  OFFERS WHERE PROJECT_ID =" + iProjectID));
                    return int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public DataTable fnGetProjectDetails(int iUserId,int iProjectId = 0)
        {
            try
            {

                DataTable dt = new DataTable();
                //string strSql = "select * from PROJECTS ";

                string strSql = "Select P.Project_Id,P.Name,P.Description, P.CREATEDON ";

                if (Common.iDBType == (int)Enums.DBType.Oracle)
                    strSql += " ,U.First_name || ' ' || U.last_name as UName ";
                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    strSql += " ,U.First_name || ' ' || U.last_name as UName ";
                else if(Common.iDBType == (int)Enums.DBType.SQl)
                    strSql += " ,U.First_name + ' ' + U.last_name as UName ";
                strSql += " From Projects P Left join Users U on U.USER_ID=P.CREATEDBY ";
                if (iUserId != 0)
                    strSql += " Where CREATEDBY=" + iUserId;

                if (iProjectId != 0)
                    strSql += " AND Project_Id=" + iProjectId ;
               
                    

                if (Common.iDBType == (int)Enums.DBType.Oracle)
                    dt = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
               else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    dt = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                else
                {
                    dt = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void fnDeleteProject(int iProjectId)
        {
            try
            {
                string strSql = "";
                        

                strSql += "Delete from Projects where Project_Id=" + iProjectId;
                if (Common.iDBType == (int)Enums.DBType.Oracle)
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
              strSql = "DELETE FROM TRE_MAPPING WHERE PROJECTID=" + iProjectId;
              if (Common.iDBType == (int)Enums.DBType.Oracle)
                  ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                  ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

              strSql = "DELETE FROM  TRE_Calculated_columns WHERE PROJECT_ID=" + iProjectId;
              if (Common.iDBType == (int)Enums.DBType.Oracle)
                  ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                  ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
              strSql = "DELETE FROM  Filter_Main WHERE PROJECT_ID=" + iProjectId;
              if (Common.iDBType == (int)Enums.DBType.Oracle)
                  ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                  ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
              strSql = "DELETE FROM OPPORTUNITY WHERE PROJECT_ID=" + iProjectId;
              if (Common.iDBType == (int)Enums.DBType.Oracle)
                  ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                  ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
              strSql = "DELETE FROM offers where project_id=" + iProjectId;
              if (Common.iDBType == (int)Enums.DBType.Oracle)
                  ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                  ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
              strSql = "DELETE FROM campaigns where project_id=" + iProjectId;
              if (Common.iDBType == (int)Enums.DBType.Oracle)
                  ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                  ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
              strSql = "DELETE FROM Export_Settings where project_id=" + iProjectId;

                if (Common.iDBType == (int)Enums.DBType.Oracle)
                    ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);

                else if (Common.iDBType == (int)Enums.DBType.Mysql)
                    ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                else
                    ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                strSql = "drop table tre_random" + iProjectId;

                strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'tre_random" + iProjectId+"' AND c.table_schema  = 'recousr' ";
                if (Common.iDBType == 3)
                {
                    int i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table tre_random" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }
                }
                if (Common.iDBType == 3)
                {
                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'tre_ranking" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    int i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table tre_ranking" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }

                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_X_SELL_PNTL" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table ETS_TRE_X_SELL_PNTL" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }
                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_ADM_WEEKLY_A" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table ETS_TRE_ADM_WEEKLY_A" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }
                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_ADM_WEEKLY_B" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table ETS_TRE_ADM_WEEKLY_B" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }
                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASE" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table ETS_TRE_BASE" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }
                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASED" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table ETS_TRE_BASED" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }
                    strSql = " SELECT count(1) FROM information_schema.columns c WHERE c.table_name = 'ETS_TRE_BASEP" + iProjectId + "' AND c.table_schema  = 'recousr' ";

                    i = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));

                    if (i > 0)
                    {
                        strSql = "drop table ETS_TRE_BASEP" + iProjectId;
                        if (Common.iDBType == (int)Enums.DBType.Mysql)
                            ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    }


                                                                                                                                                                                                                      }

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fnInsertProjectdtls(int iProjectId, string strPName, string strDescription, int iLoginUserID)
        {
            try
            {
                string strSql = "";
                string dateformat = "yyyy/mm/dd hh24:mi:ss";


                if (iProjectId == 0)
                {
                    strSql = "INSERT INTO PROJECTS (NAME, DESCRIPTION,CREATEDON,CREATEDBY) VALUES(";
                    strSql += "'" + strPName.Replace("'", "''") + "','" + strDescription + "',";
                    if (Common.iDBType == (int)Enums.DBType.Oracle)
                        strSql += " sysdate," + iLoginUserID + ")";
                   else if (Common.iDBType == (int)Enums.DBType.Mysql)
                        strSql += " CURDATE()," + iLoginUserID + ")";
                    else
                        strSql += " Getdate()," + iLoginUserID + ")";
                    if (Common.iDBType == (int)Enums.DBType.Oracle)
                        ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    else if (Common.iDBType == (int)Enums.DBType.Mysql)
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    else
                        ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);


                    strSql = "SELECT max(project_id) as projectid FROM projects";
                   int newProjectId= int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql));
                    strSql = " CREATE TABLE tre_ranking" + newProjectId + " (";
                    strSql += "   CUSTOMER varchar(100) DEFAULT NULL,";
                    strSql += "   RANK1_ACTION varchar(100) DEFAULT NULL, ";
                    strSql += "   RANK2_ACTION varchar(100) DEFAULT NULL, ";
                    strSql += "   RANK3_ACTION varchar(100) DEFAULT NULL, ";
                    strSql += "   RANK4_ACTION varchar(100) DEFAULT NULL, ";
                    strSql += "   RANK1 int(11) DEFAULT NULL, ";
                    strSql += "   RANK2 int(11) DEFAULT NULL, ";
                    strSql += "   RANK3 int(11) DEFAULT NULL, ";
                    strSql += "   RANK4 int(11) DEFAULT NULL )  ";
                    if (Common.iDBType == (int)Enums.DBType.Mysql)
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    strSql = " CREATE INDEX idx_rankingcust ON tre_ranking" + newProjectId + " (Customer)";
                    if (Common.iDBType == (int)Enums.DBType.Mysql)
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
       

                }
                else
                {
                    strSql = "Update PROJECTS set name='" + strPName.Replace("'", "''") + "',";
                    strSql += " Description = '" + strDescription.Replace("'", "''") + "'";
                    strSql += " where Project_Id=" + iProjectId;
                    if (Common.iDBType == (int)Enums.DBType.Oracle)
                        ((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    else if (Common.iDBType == (int)Enums.DBType.Mysql)
                        ((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                    else
                        ((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, strSql);
                }
      





            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable fnGetProjectNames(int iUserId)
        {
            try
            {

                DataTable dt = new DataTable();
                //string strSql = "select * from PROJECTS ";

                string strSql = "Select P.Project_Id,P.Name ";

                strSql += " From Projects P Left join Users U on U.USER_ID=P.CREATEDBY ";
                if (iUserId != 0)
                    strSql += " Where CREATEDBY=" + iUserId;


                if (Common.iDBType == (int)Enums.DBType.Oracle)
                    dt = ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                else if(Common.iDBType == (int)Enums.DBType.Mysql)
                           dt = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                else
                {
                    dt = ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, strSql);
                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
    }
}
