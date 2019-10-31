using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RecoEngine_DataLayer;
using System.Collections;

namespace RecoEngine_BI
{
    public class clsOffers 
    {
        public clsOffers()
            {
            }

            public bool fnActiveOffers(string strOfferId)
            {
                bool flag = false;
                try
                {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {
                    string[] strArrays = strOfferId.Split(new char[] { ';' });
                    if ((int)strArrays.Length > 0)
                    {
                        string str = string.Concat("UPDATE OFFERS SET  ISACTIVE = ", strArrays[1], " WHERE  OFFER_ID = ", strArrays[0]);
                        ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        if (strArrays[1] == "0")
                        {
                            str = string.Concat("UPDATE CAMPAIGNS SET  ISACTIVE = ", strArrays[1], " WHERE  OFFER_ID = ", strArrays[0]);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = " DELETE FROM PRIORITIZED_TEMP  WHERE CAMPAIGNID=";
                            str = string.Concat(str, "(SELECT  nvl(Sum(CAMPAIGN_ID),0) FROM CAMPAIGNS WHERE  OFFER_ID = ", strArrays[0], ")");
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    flag = true;
                }
                else if(Common.iDBType == 3)
                {
                    string[] strArrays = strOfferId.Split(new char[] { ';' });
                    if ((int)strArrays.Length > 0)
                    {
                        string str = string.Concat("UPDATE OFFERS SET  ISACTIVE = ", strArrays[1], " WHERE  OFFER_ID = ", strArrays[0]);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        if (strArrays[1] == "0")
                        {
                            str = string.Concat("UPDATE CAMPAIGNS SET  ISACTIVE = ", strArrays[1], " WHERE  OFFER_ID = ", strArrays[0]);
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            str = " DELETE FROM PRIORITIZED_TEMP  WHERE CAMPAIGNID=";
                            str = string.Concat(str, "(SELECT  nvl(Sum(CAMPAIGN_ID),0) FROM CAMPAIGNS WHERE  OFFER_ID = ", strArrays[0], ")");
                            ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        }
                    }
                    flag = true;
                }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return flag;
            }

            public bool fnCheckOffersDependencies(string strOfferId)
            {
                bool flag = false;
            try
            {
                if (Common.iDBType == 1)
                {
                    flag = (int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, string.Concat("Select nvl(count(1),0) from CAMPAIGNS WHERE  OFFER_ID = ", strOfferId))) <= 0 ? false : true);
                }
                else if(Common.iDBType ==3)
                {
                    flag = (int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, string.Concat("Select nvl(count(1),0) from CAMPAIGNS WHERE  OFFER_ID = ", strOfferId))) <= 0 ? false : true);

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
                return flag;
            }

            public bool fnDeleteOffers(string strOfferId)
            {
                bool flag;
            try
            {
                if (Common.iDBType == 1)
                {
                    string str = string.Concat("DELETE from CAMPAIGNS WHERE  OFFER_ID =", strOfferId);
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    str = string.Concat("DELETE FROM OFFERS WHERE  OFFER_ID = ", strOfferId);
                    ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    flag = true;
                }
                else
                {
                    string str = string.Concat("DELETE from CAMPAIGNS WHERE  OFFER_ID =", strOfferId);
                    ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                    str = string.Concat("DELETE FROM OFFERS WHERE  OFFER_ID = ", strOfferId);
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

            public DataSet fnGetLevels()
            {
                DataSet dataSet = null;
                try
                {
                if (Common.iDBType == 1 || Common.iDBType == 2)
                {


                    DataSet dataSet1 = new DataSet();
                    DataTable dataTable = new DataTable("Level1");
                    string str = "";
                    str = "Select * from PRODUCT_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level2");
                    str = "";
                    str = "Select * from REVENUE_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level3");
                    str = "Select * from BUSINESS_AXE_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level4");
                    str = "Select * from CATEGORY_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level5");
                    str = "Select * from TYPE_LOOKUP ";
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                    dataSet1.Tables.Add(dataTable);
                    dataSet = dataSet1;
                }
                else if(Common.iDBType == 3)
                {
                    DataSet dataSet1 = new DataSet();
                    DataTable dataTable = new DataTable("Level1");
                    string str = "";
                    str = "Select * from PRODUCT_LOOKUP ";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level2");
                    str = "";
                    str = "Select * from REVENUE_LOOKUP ";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level3");
                    str = "Select * from BUSINESS_AXE_LOOKUP ";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level4");
                    str = "Select * from CATEGORY_LOOKUP ";
                    dataTable = ((MySqlDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str);
                    dataSet1.Tables.Add(dataTable);
                    dataTable = new DataTable("Level5");
                    str = "Select * from TYPE_LOOKUP ";
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

            public DataTable fnGetOffers(int iProjectId)
            {
                DataTable dataTable = null;
                DataTable dataTable1 = null;
                try
                {
                    string str = "";
                    str = "Select O.OFFER_ID,O.PROJECT_ID,O.NAME,O.CODE,O.DESCRIPTION,O.LEVEL1,O.LEVEL2,O.LEVEL3,O.LEVEL4,O.CREATEDDATE,O.ISACTIVE as ISACTIVEID,";
                    str = string.Concat(str, "CASE WHEN O.ISACTIVE=1 THEN 'YES' ELSE 'NO' END as ISACTIVE, ");
                    if (Common.iDBType == 1)
                    {
                        str = string.Concat(str, " U.First_name || ' ' || U.last_name as UName ");
                    }
                    else if (Common.iDBType == 2)
                    {
                        str = string.Concat(str, " ,U.First_name + ' ' + U.last_name as UName ");
                    }
                    str = string.Concat(str, " ,'' as Flag From OFFERS O Left join Users U on U.USER_ID=O.CREATEDBY ");
                    if (iProjectId != 0)
                    {
                        str = string.Concat(str, " Where O.Project_Id=", iProjectId);
                    }

                if (Common.iDBType == 1 || Common.iDBType ==2)
                {
                    dataTable = (Common.iDBType != 1 ? ((DBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str) : ((OraDBManager)Common.dbMgr).ExecuteDataTable(CommandType.Text, str));
                }
                else if(Common.iDBType == 3)
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

            public int fnSaveOffers(int iOfferId, string strName, string strCode, string strDesc, string strLevel1, string strLevel2, string strLevel3, string strLevel4, int strLoginUserId, int iProjectId, int iIsActive)
            {
                int num;
                try
                {
                    string str = "";
                    if (iOfferId != 0)
                    {
                        string[] strArrays = new string[] { "UPDATE   OFFERS SET NAME='", strName.Replace("'", "''"), "',CODE='", strCode.Replace("'", "''"), "',DESCRIPTION='", strDesc.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays);
                        string str1 = str;
                        string[] strArrays1 = new string[] { str1, " LEVEL1 = '", strLevel1.Replace("'", "''"), "',LEVEL2 ='", strLevel2.Replace("'", "''"), "',LEVEL3 ='", strLevel3.Replace("'", "''"), "'," };
                        str = string.Concat(strArrays1);
                        object obj = str;
                        object[] objArray = new object[] { obj, "LEVEL4 ='", strLevel4.Replace("'", "''"), "',ISACTIVE=", iIsActive, " WHERE OFFER_ID = ", iOfferId };
                        str = string.Concat(objArray);
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

                }
                else
                    {
                        str = "INSERT INTO OFFERS(PROJECT_ID,NAME,CODE,DESCRIPTION,LEVEL1,LEVEL2,LEVEL3,LEVEL4,CREATEDBY,CREATEDDATE,ISACTIVE) Values (";
                        object obj1 = str;
                        object[] objArray1 = new object[] { obj1, iProjectId, ",'", strName.Replace("'", "''"), "','", strCode.Replace("'", "''"), "','", strDesc.Replace("'", "''"), "','", strLevel1.Replace("'", "''"), "'," };
                        str = string.Concat(objArray1);
                        object obj2 = str;
                        object[] objArray2 = new object[] { obj2, "'", strLevel2.Replace("'", "''"), "','", strLevel3.Replace("'", "''"), "','", strLevel4.Replace("'", "''"), "',", strLoginUserId, "," };
                        str = string.Concat(objArray2);
                        if (Common.iDBType == 2)
                        {
                            object obj3 = str;
                            object[] objArray3 = new object[] { obj3, "getdate() ,", iIsActive, ")" };
                            str = string.Concat(objArray3);
                            ((DBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOfferId = int.Parse(((DBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OFFER_ID) from OFFERS"));
                        }
                        else if(Common.iDBType == 1)
                        {
                            object obj4 = str;
                            object[] objArray4 = new object[] { obj4, " sysdate ,", iIsActive, ")" };
                            str = string.Concat(objArray4);
                            ((OraDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                            iOfferId = int.Parse(((OraDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OFFER_ID) from OFFERS"));
                        }

                    else if (Common.iDBType == 3)
                    {
                        object obj4 = str;
                        object[] objArray4 = new object[] { obj4, " getdate() ,", iIsActive, ")" };
                        str = string.Concat(objArray4);
                        ((MySqlDBManager)Common.dbMgr).ExecuteNonQuery(CommandType.Text, str);
                        iOfferId = int.Parse(((MySqlDBManager)Common.dbMgr).ExecuteScalar(CommandType.Text, "Select max(OFFER_ID) from OFFERS"));
                    }
                }
                    num = iOfferId;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return num;
            }
        }
    }
